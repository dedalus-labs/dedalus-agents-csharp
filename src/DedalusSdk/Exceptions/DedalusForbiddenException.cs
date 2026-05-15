using System.Net.Http;

namespace DedalusSdk.Exceptions;

public class DedalusForbiddenException : Dedalus4xxException
{
    public DedalusForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
