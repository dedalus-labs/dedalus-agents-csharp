using System.Net.Http;

namespace DedalusSdk.Exceptions;

public class DedalusBadRequestException : Dedalus4xxException
{
    public DedalusBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
