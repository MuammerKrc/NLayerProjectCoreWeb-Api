using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.ResponseDto
{
    public class Response<T> where T:class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        public ErrorDto Error { get; private set; }
        [JsonIgnore]
        public bool IsSuccess { get; private set; }
        public static Response<T> Success(T data, int satusCode)
        {
            return new Response<T> { Data = data, StatusCode = satusCode, IsSuccess = true };
        }
        public static Response<NoContent> Success(int statusCode)
        {
            return new Response<NoContent>() { Data = default, StatusCode = statusCode, IsSuccess = true };
        }
        public static Response<T>Fail (List<string> errors,int statusCode)
        {
            return new Response<T> { Error =new ErrorDto(errors), StatusCode = statusCode, IsSuccess = false };
        }
        public static Response<T>Fail(string error,int statusCode)
        {
            return new Response<T> { Error = new ErrorDto(error), StatusCode = statusCode, IsSuccess = false };
        }

    }
}
