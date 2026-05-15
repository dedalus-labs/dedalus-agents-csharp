using System.Net.Http;

namespace DedalusSdk.Exceptions;

public class DedalusNotFoundException : Dedalus4xxException
{
    public DedalusNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
