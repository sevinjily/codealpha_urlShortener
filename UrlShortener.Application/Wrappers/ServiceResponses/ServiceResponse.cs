﻿using System.Net;

namespace UrlShortener.Application.Wrappers.ServiceResponses
{
    public class ServiceResponse
    {
        public bool isSuccess { get; private set; }    // əməliyyat uğurlu olub-olmadığını göstərir
        public string Message { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        //MESAJSIZ
        public ServiceResponse(bool IsSuccess, HttpStatusCode statusCode)
        {
            isSuccess = IsSuccess;
            StatusCode = statusCode;
        }
        //MESAJLI
        public ServiceResponse(bool IsSuccess, HttpStatusCode statusCode, string message) : this(IsSuccess, statusCode)
        {
            {

                Message = message;
            }

        }
        public ServiceResponse()
        {

        }
    }
}
