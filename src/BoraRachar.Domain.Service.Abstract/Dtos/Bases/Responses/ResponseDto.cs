using System.Net;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;

public class ResponseDto : ResponseDto<None>
{
    protected ResponseDto()
    {
    }
}

public class ResponseDto<TData>
{
    protected ResponseDto()
    {
    }

    public HttpStatusCode StatusCode { get; protected set; }
    public MetaDataResponse? MetaData { get; protected set; }
    public string Msg { get; protected set; }
    public virtual TData? Data { get; protected set; }
    public IEnumerable<ErrorResponse>? Errors { get; protected set; }

    public static ResponseDto<TData> Sucess() => new() { StatusCode = HttpStatusCode.OK };
    public static ResponseDto<TData> Sucess(HttpStatusCode statusCode) => new() { StatusCode = statusCode };
    public static ResponseDto<TData> Sucess(string mensagem, HttpStatusCode statusCode) => new() { StatusCode = statusCode, Msg = mensagem };
    public static ResponseDto<TData> Sucess(TData data) => new() { Data = data, StatusCode = HttpStatusCode.OK };

    public static ResponseDto<TData> Sucess(TData data, MetaDataResponse metaData) => new() { StatusCode = HttpStatusCode.OK, Data = data, MetaData = metaData };
    public static ResponseDto<TData> Sucess(string mensagem, TData data, MetaDataResponse metaData) => new() { StatusCode = HttpStatusCode.OK, Data = data, MetaData = metaData };

    public static ResponseDto<TData> Sucess(TData data, MetaDataResponse metaData, HttpStatusCode statusCode) =>
        new() { StatusCode = statusCode, Data = data, MetaData = metaData };

    public static ResponseDto<TData> Fail() => new() { StatusCode = HttpStatusCode.BadRequest };

    public static ResponseDto<TData> Fail(HttpStatusCode status) => new() { StatusCode = status };

    public static ResponseDto<TData> Fail(ErrorResponse error, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
        new() { StatusCode = statusCode, Errors = new List<ErrorResponse> { error } };

    public static ResponseDto<TData> Fail(IEnumerable<ErrorResponse> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
        new() { StatusCode = statusCode, Errors = errors };

    public static ResponseDto<TData> Fail(string error, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
        new() { StatusCode = statusCode, Errors = new List<ErrorResponse> { ErrorResponse.CreateError(error) } };
}