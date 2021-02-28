﻿using OlayaDigital.Core.CustomEntities;

namespace OlayaDigitalAPI.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public MetaData Meta { get; set; }
    }
}
