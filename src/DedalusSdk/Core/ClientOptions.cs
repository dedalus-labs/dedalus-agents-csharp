using System;
using System.Net.Http;

namespace DedalusSdk.Core;

/// <summary>
/// A class representing the SDK client configuration.
/// </summary>
public record struct ClientOptions()
{
    /// <summary>
    /// The default value used for <see cref="MaxRetries"/>.
    /// </summary>
    public static readonly int DefaultMaxRetries = 2;

    /// <summary>
    /// The default value used for <see cref="Timeout"/>.
    /// </summary>
    public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(1);

    /// <summary>
    /// The HTTP client to use for making requests in the SDK.
    ///
    /// <para>Note: The HttpClient has a built-in timeout, which defaults to 100 seconds.
    /// When passing a custom HttpClient, this timeout may conflict with the SDK's
    /// own timeout handler and cause premature cancellation.</para>
    /// </summary>
    public HttpClient HttpClient { get; set; } =
        new(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Available })
        {
            Timeout = global::System.Threading.Timeout.InfiniteTimeSpan,
        };

    Lazy<string> _baseUrl = new(() =>
        Environment.GetEnvironmentVariable("DEDALUS_BASE_URL") ?? EnvironmentUrl.Production
    );

    /// <summary>
    /// The base URL to use for every request.
    ///
    /// <para>Defaults to the production environment: <see cref="EnvironmentUrl.Production"/></para>
    ///
    /// <para>
    /// The following other environments are available:
    /// <list type="bullet">
    ///   <item>development: <see cref="EnvironmentUrl.Development"/></item>
    /// </list>
    /// </para>
    /// </summary>
    public string BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    /// <summary>
    /// Whether to validate response bodies before returning them.
    ///
    /// <para>Defaults to false, which means the shape of the response body will not be validated upfront.
    /// Instead, validation will only occur for the parts of the response body that are accessed.</para>
    ///
    /// <para>Note that when set to true, the response body is only validated if the response is
    /// deserialized. Methods that don't eagerly deserialize the response, such as those on
    /// <see cref="IDedalusClient.WithRawResponse"/>, don't perform validation until deserialization
    /// is triggered.</para>
    /// </summary>
    public bool ResponseValidation { get; set; } = false;

    /// <summary>
    /// The maximum number of times to retry failed requests, with a short exponential backoff between requests.
    ///
    /// <para>
    /// Only the following error types are retried:
    /// <list type="bullet">
    ///   <item>Connection errors (for example, due to a network connectivity problem)</item>
    ///   <item>408 Request Timeout</item>
    ///   <item>409 Conflict</item>
    ///   <item>429 Rate Limit</item>
    ///   <item>5xx Internal</item>
    /// </list>
    /// </para>
    ///
    /// <para>The API may also explicitly instruct the SDK to retry or not retry a request.</para>
    ///
    /// <para>Defaults to 2 when null. Set to 0 to
    /// disable retries, which also ignores API instructions to retry.</para>
    /// </summary>
    public int? MaxRetries { get; set; } = null;

    /// <summary>
    /// Sets the maximum time allowed for a complete HTTP call, not including retries.
    ///
    /// <para>This includes resolving DNS, connecting, writing the request body, server processing, as
    /// well as reading the response body.</para>
    ///
    /// <para>Defaults to <c>TimeSpan.FromMinutes(1)</c> when null.</para>
    /// </summary>
    public TimeSpan? Timeout { get; set; } = null;

    /// <summary>
    /// API key for Bearer token authentication.
    /// </summary>
    Lazy<string?> _apiKey = new(() => Environment.GetEnvironmentVariable("DEDALUS_API_KEY"));

    /// <summary>
    /// API key for Bearer token authentication.
    /// </summary>
    public string? ApiKey
    {
        readonly get { return _apiKey.Value; }
        set { _apiKey = new(() => value); }
    }

    /// <summary>
    /// API key for X-API-Key header authentication.
    /// </summary>
    Lazy<string?> _xApiKey = new(() => Environment.GetEnvironmentVariable("DEDALUS_X_API_KEY"));

    /// <summary>
    /// API key for X-API-Key header authentication.
    /// </summary>
    public string? XApiKey
    {
        readonly get { return _xApiKey.Value; }
        set { _xApiKey = new(() => value); }
    }

    /// <summary>
    /// MCP Authorization Server URL
    /// </summary>
    Lazy<string?> _asBaseUrl = new(() =>
        Environment.GetEnvironmentVariable("DEDALUS_AS_URL") ?? "https://as.dedaluslabs.ai"
    );

    /// <summary>
    /// MCP Authorization Server URL
    /// </summary>
    public string? AsBaseUrl
    {
        readonly get { return _asBaseUrl.Value; }
        set { _asBaseUrl = new(() => value); }
    }

    /// <summary>
    /// Organization ID for request scoping.
    /// </summary>
    Lazy<string?> _dedalusOrgID = new(() => Environment.GetEnvironmentVariable("DEDALUS_ORG_ID"));

    /// <summary>
    /// Organization ID for request scoping.
    /// </summary>
    public string? DedalusOrgID
    {
        readonly get { return _dedalusOrgID.Value; }
        set { _dedalusOrgID = new(() => value); }
    }

    /// <summary>
    /// Provider name for BYOK mode (e.g., 'google', 'openai', 'anthropic').
    /// </summary>
    Lazy<string?> _provider = new(() => Environment.GetEnvironmentVariable("DEDALUS_PROVIDER"));

    /// <summary>
    /// Provider name for BYOK mode (e.g., 'google', 'openai', 'anthropic').
    /// </summary>
    public string? Provider
    {
        readonly get { return _provider.Value; }
        set { _provider = new(() => value); }
    }

    /// <summary>
    /// Provider API key for BYOK mode.
    /// </summary>
    Lazy<string?> _providerKey = new(() =>
        Environment.GetEnvironmentVariable("DEDALUS_PROVIDER_KEY")
    );

    /// <summary>
    /// Provider API key for BYOK mode.
    /// </summary>
    public string? ProviderKey
    {
        readonly get { return _providerKey.Value; }
        set { _providerKey = new(() => value); }
    }

    /// <summary>
    /// Model identifier for BYOK provider.
    /// </summary>
    Lazy<string?> _providerModel = new(() =>
        Environment.GetEnvironmentVariable("DEDALUS_PROVIDER_MODEL")
    );

    /// <summary>
    /// Model identifier for BYOK provider.
    /// </summary>
    public string? ProviderModel
    {
        readonly get { return _providerModel.Value; }
        set { _providerModel = new(() => value); }
    }
}
