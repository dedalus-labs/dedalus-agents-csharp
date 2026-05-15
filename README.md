# Dedalus C# API Library

The Dedalus C# SDK provides convenient access to the [Dedalus REST API](https://docs.dedaluslabs.ai) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [docs.dedaluslabs.ai](https://docs.dedaluslabs.ai).

## Installation

```bash
git clone git@github.com:dedalus-labs/dedalus-sdk-csharp.git
dotnet add reference dedalus-sdk-csharp/src/DedalusSdk
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using DedalusSdk;
using DedalusSdk.Models.Chat.Completions;

DedalusClient client = new();

CompletionCreateParams parameters = new()
{
    Model = "openai/gpt-5-nano",
    Messages =
    [
        new ChatCompletionSystemMessageParam(
            new ChatCompletionSystemMessageParamContent(
                "You are Stephen Dedalus. Respond in morose Joycean malaise."
            )
        ),
        new ChatCompletionUserMessageParam(
            new ChatCompletionUserMessageParamContent(
                "Hello, how are you today?"
            )
        ),
    ],
};

var chatCompletion = await client.Chat.Completions.Create(parameters);

Console.WriteLine(chatCompletion);
```

## Client configuration

Configure the client using environment variables:

```csharp
using DedalusSdk;

// Configured using the DEDALUS_API_KEY, DEDALUS_X_API_KEY, DEDALUS_AS_URL, DEDALUS_ORG_ID, DEDALUS_PROVIDER, DEDALUS_PROVIDER_KEY, DEDALUS_PROVIDER_MODEL and DEDALUS_BASE_URL environment variables
DedalusClient client = new();
```

Or manually:

```csharp
using DedalusSdk;

DedalusClient client = new() { ApiKey = "My API Key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property        | Environment variable     | Required | Default value                  |
| --------------- | ------------------------ | -------- | ------------------------------ |
| `ApiKey`        | `DEDALUS_API_KEY`        | false    | -                              |
| `XApiKey`       | `DEDALUS_X_API_KEY`      | false    | -                              |
| `AsBaseUrl`     | `DEDALUS_AS_URL`         | false    | `"https://as.dedaluslabs.ai"`  |
| `DedalusOrgID`  | `DEDALUS_ORG_ID`         | false    | -                              |
| `Provider`      | `DEDALUS_PROVIDER`       | false    | -                              |
| `ProviderKey`   | `DEDALUS_PROVIDER_KEY`   | false    | -                              |
| `ProviderModel` | `DEDALUS_PROVIDER_MODEL` | false    | -                              |
| `BaseUrl`       | `DEDALUS_BASE_URL`       | true     | `"https://api.dedaluslabs.ai"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var chatCompletion = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Chat.Completions.Create(parameters);

Console.WriteLine(chatCompletion);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Dedalus API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Chat.Completions.Create` should be called with an instance of `CompletionCreateParams`, and it will return an instance of `Task<ChatCompletion>`.

## Streaming

The SDK defines methods that return response "chunk" streams, where each chunk can be individually processed as soon as it arrives instead of waiting on the full response. Streaming methods generally correspond to [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events) or [JSONL](https://jsonlines.org) responses.

Some of these methods may have streaming and non-streaming variants, but a streaming method will always have a `Streaming` suffix in its name, even if it doesn't have a non-streaming variant.

These streaming methods return [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1):

```csharp
using System;
using DedalusSdk.Models.Chat.Completions;

CompletionCreateParams parameters = new()
{
    Model = "openai/gpt-5-nano",
    Messages =
    [
        new ChatCompletionSystemMessageParam(
            new ChatCompletionSystemMessageParamContent(
                "You are Stephen Dedalus. Respond in morose Joycean malaise."
            )
        ),
        new ChatCompletionUserMessageParam(
            new ChatCompletionUserMessageParamContent(
                "What do you think of artificial intelligence?"
            )
        ),
    ],
};

await foreach (var chatCompletion in client.Chat.Completions.CreateStreaming(parameters))
{
    Console.WriteLine(chatCompletion);
}
```

## Binary responses

The SDK defines methods that return binary responses, which are used for API responses that shouldn't necessarily be parsed, like non-JSON data.

These methods return `HttpResponse`:

```csharp
using System;
using DedalusSdk.Models.Audio.Speech;

SpeechCreateParams parameters = new()
{
    Input = "input",
    Model = Model.Tts1,
    Voice = UnionMember1.Alloy,
};

var speech = await client.Audio.Speech.Create(parameters);

Console.WriteLine(speech);
```

To save the response content to a file, or any [`Stream`](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-9.0), use the [`CopyToAsync`](<https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=net-9.0#system-io-stream-copytoasync(system-io-stream)>) method:

```csharp
using System.IO;

using var response = await client.Audio.Speech.Create(parameters);
using var contentStream = await response.ReadAsStream();
using var fileStream = File.Open(path, FileMode.OpenOrCreate);
await contentStream.CopyToAsync(fileStream); // Or any other Stream
```

## Raw responses

The SDK defines methods that deserialize responses into instances of C# classes. However, these methods don't provide access to the response headers, status code, or the raw response body.

To access this data, prefix any HTTP method call on a client or service with `WithRawResponse`:

```csharp
var response = await client.WithRawResponse.Chat.Completions.Create(parameters);
var statusCode = response.StatusCode;
var headers = response.Headers;
```

The raw `HttpResponseMessage` can also be accessed through the `RawMessage` property.

For non-streaming responses, you can deserialize the response into an instance of a C# class if needed:

```csharp
using System;
using DedalusSdk.Models.Chat.Completions;

var response = await client.WithRawResponse.Chat.Completions.Create(parameters);
ChatCompletion deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

For streaming responses, you can deserialize the response to an [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1) if needed:

```csharp
using System;

var response = await client.WithRawResponse.Chat.Completions.CreateStreaming(parameters);
await foreach (var item in response.Enumerate())
{
    Console.WriteLine(item);
}
```

## Error handling

The SDK throws custom unchecked exception types:

- `DedalusApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                              |
| ------ | -------------------------------------- |
| 400    | `DedalusBadRequestException`           |
| 401    | `DedalusUnauthorizedException`         |
| 403    | `DedalusForbiddenException`            |
| 404    | `DedalusNotFoundException`             |
| 422    | `DedalusUnprocessableEntityException`  |
| 429    | `DedalusRateLimitException`            |
| 5xx    | `Dedalus5xxException`                  |
| others | `DedalusUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Dedalus4xxException`.

- `DedalusSseException`: thrown for errors encountered during [SSE streaming](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events) after a successful initial HTTP response.

- `DedalusIOException`: I/O networking errors.

- `DedalusInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `DedalusException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using DedalusSdk;

DedalusClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var chatCompletion = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Chat.Completions.Create(parameters);

Console.WriteLine(chatCompletion);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using DedalusSdk;

DedalusClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var chatCompletion = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Chat.Completions.Create(parameters);

Console.WriteLine(chatCompletion);
```

### Proxies

To route requests through a proxy, configure your client with a custom [`HttpClient`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-10.0):

```csharp
using System.Net;
using System.Net.Http;
using DedalusSdk;

var httpClient = new HttpClient
(
    new HttpClientHandler
    {
        Proxy = new WebProxy("https://example.com:8080")
    }
);

DedalusClient client = new() { HttpClient = httpClient };
```

### Environments

The SDK sends requests to the production environment by default. To send requests to a different environment, configure the client like so:

```csharp
using DedalusSdk;
using DedalusSdk.Core;

DedalusClient client = new() { BaseUrl = EnvironmentUrl.Development };
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Parameters

To set undocumented parameters, a constructor exists that accepts dictionaries for additional header, query, and body values. If the method type doesn't support request bodies (e.g. `GET` requests), the constructor will only accept a header and query dictionary.

```csharp
using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Models.Chat.Completions;

CompletionCreateParams parameters = new
(
    rawHeaderData: new Dictionary<string, JsonElement>()
    {
        { "Custom-Header", JsonSerializer.SerializeToElement(42) }
    },

    rawQueryData: new Dictionary<string, JsonElement>()
    {
        { "custom_query_param", JsonSerializer.SerializeToElement(42) }
    },

    rawBodyData: new Dictionary<string, JsonElement>()
    {
        { "custom_body_param", JsonSerializer.SerializeToElement(42) }
    }
)
{
    // Documented properties can still be added here.
    // In case of conflict, these parameters take precedence over the custom parameters.
    AutomaticToolExecution = true
};
```

The raw parameters can also be accessed through the `RawHeaderData`, `RawQueryData`, and `RawBodyData` (if available) properties.

This can also be used to set a documented parameter to an undocumented or not yet supported _value_, as long as the parameter is optional. If the parameter is required, omitting its `init` property will result in a compile-time error. To work around this, the `FromRawUnchecked` method can be used:

```csharp
using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Models.Chat.Completions;

var parameters = CompletionCreateParams.FromRawUnchecked
(

    rawHeaderData: new Dictionary<string, JsonElement>(),
    rawQueryData: new Dictionary<string, JsonElement>(),
    rawBodyData: new Dictionary<string, JsonElement>
    {
        {
            "model",
            JsonSerializer.SerializeToElement("custom value")
        }
    }
);
```

### Nested Parameters

Undocumented properties, or undocumented values of documented properties, on nested parameters can be set similarly, using a dictionary in the constructor of the nested parameter.

```csharp
using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Models.Chat.Completions;

CompletionCreateParams parameters = new()
{
    Audio = new
    (
        new Dictionary<string, JsonElement>
        {
            { "custom_nested_param", JsonSerializer.SerializeToElement(42) }
        }
    )
};
```

Required properties on the nested parameter can also be changed or omitted using the `FromRawUnchecked` method:

```csharp
using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Models.Chat.Completions;

CompletionCreateParams parameters = new()
{
    Audio = ChatCompletionAudioParam.FromRawUnchecked
    (
        new Dictionary<string, JsonElement>
        {
            { "required_property", JsonSerializer.SerializeToElement("custom value") }
        }
    )
};
```

### Response properties

To access undocumented response properties, the `RawData` property can be used:

```csharp
using System.Text.Json;

var response = client.Chat.Completions.Create(parameters)
if (response.RawData.TryGetValue("my_custom_key", out JsonElement value))
{
    // Do something with `value`
}
```

`RawData` is a `IReadonlyDictionary<string, JsonElement>`. It holds the full data received from the API server.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `DedalusInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var chatCompletion = client.Chat.Completions.Create(parameters);
chatCompletion.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using DedalusSdk;

DedalusClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var chatCompletion = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Chat.Completions.Create(parameters);

Console.WriteLine(chatCompletion);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/dedalus-labs/dedalus-sdk-csharp/issues) with questions, bugs, or suggestions.
