using System.Net.Http;

namespace DedalusSdk.Exceptions;

public class DedalusUnauthorizedException : Dedalus4xxException
{
    public DedalusUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
