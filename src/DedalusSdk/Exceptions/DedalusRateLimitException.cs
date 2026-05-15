using System.Net.Http;

namespace DedalusSdk.Exceptions;

public class DedalusRateLimitException : Dedalus4xxException
{
    public DedalusRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
