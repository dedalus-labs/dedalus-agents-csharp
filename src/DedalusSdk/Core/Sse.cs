using System.Collections.Generic;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Core;

static class Sse
{
    internal static async IAsyncEnumerable<T> Enumerate<T>(
        HttpResponseMessage response,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var stream = await response
            .Content.ReadAsStreamAsync(
#if NET
                cancellationToken
#endif
            )
            .ConfigureAwait(false);

        var done = false;
        await foreach (var item in SseParser.Create(stream).EnumerateAsync(cancellationToken))
        {
            // Stop emitting messages, but iterate through the full stream.
            if (done)
            {
                continue;
            }

            if (item.Data.StartsWith("[DONE]"))
            {
                // In this case we don't break because we still want to iterate through the full stream.
                done = true;
                continue;
            }

            switch (item.EventType)
            {
                case "error":
                    throw new DedalusSseException(
                        string.Format("SSE error returned from server: '{0}'", item.Data)
                    );
                case null:
                    T? message;
                    try
                    {
                        message = JsonSerializer.Deserialize<T>(
                            item.Data,
                            ModelBase.SerializerOptions
                        );
                    }
                    catch (JsonException e)
                    {
                        throw new DedalusInvalidDataException(
                            $"Message must be of type {typeof(T).FullName}",
                            e
                        );
                    }
                    yield return message
                        ?? throw new DedalusInvalidDataException("Message cannot be null");
                    break;
            }
        }
    }
}
