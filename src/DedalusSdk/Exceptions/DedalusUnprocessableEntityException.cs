using System.Net.Http;

namespace DedalusSdk.Exceptions;

public class DedalusUnprocessableEntityException : Dedalus4xxException
{
    public DedalusUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
