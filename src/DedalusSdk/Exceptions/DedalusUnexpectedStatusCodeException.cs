using System.Net.Http;

namespace DedalusSdk.Exceptions;

public class DedalusUnexpectedStatusCodeException : DedalusApiException
{
    public DedalusUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
