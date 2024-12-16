namespace MiniPOSSystemWithRepositoryDesignPattern.Utils;

public class Result<T>
{
    public T Data { get; set; }
    public EnumStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }

    #region Success

    public static Result<T> Success(string message = "Success")
    {
        return new Result<T>
        {
            Message = message,
            IsSuccess = true,
            StatusCode = EnumStatusCode.Success
        };
    }

    #endregion

    #region Success with data

    public static Result<T> Success(T data, string message = "Success")
    {
        return new Result<T>
        {
            Data = data,
            Message = message,
            IsSuccess = true,
            StatusCode = EnumStatusCode.Success
        };
    }

    #endregion

    #region Fail

    public static Result<T> Fail(string message = "Fail.", EnumStatusCode statusCode = EnumStatusCode.BadRequest)
    {
        return new Result<T>
        {
            Message = message,
            IsSuccess = false,
            StatusCode = statusCode
        };
    }

    #endregion

    public static Result<T> Fail(Exception ex)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = ex.ToString(),
            StatusCode = EnumStatusCode.InternalServerError
        };
    }
    public static Result<T> Conflict(string message = "Data Conflict")
    {
        return new Result<T>
        {
            Message = message,
            IsSuccess = false,
            StatusCode = EnumStatusCode.Conflict
        };
    }

    public static Result<T> NotFound(string message = "No Data Found")
    {
        return new Result<T>
        {
            Message = message,
            IsSuccess = false,
            StatusCode = EnumStatusCode.NotFound
        };
    }

}
