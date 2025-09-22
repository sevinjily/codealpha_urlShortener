﻿using System.Net;

namespace UrlShortener.Application.Wrappers.ServiceResponses
{
    public class ServiceResponseWithData<T> : ServiceResponse
    {
        public T Value { get; private set; }
        //Mesajsiz
        public ServiceResponseWithData(T value, bool isSuccess, HttpStatusCode statusCode) : base(isSuccess, statusCode)
        {
            Value = value;
        }

        //mesajli
        public ServiceResponseWithData(T value, bool isSuccess, HttpStatusCode statusCode, string message) : base(isSuccess, statusCode, message)
        {
            Value = value;
        }
        public ServiceResponseWithData()
        {

        }
    }
}
