using System;

public class OperationResult<T>
{
    public bool Success { get; private set; }
    public T Result { get; private set; }
    public string ErrorMessage { get; private set; }
    public Exception Exception { get; private set; }



    private OperationResult() { }

    public static OperationResult<T> ItWorked(T result)
    {
        return new OperationResult<T> { Success = true, Result = result };
    }

    public static OperationResult<T> Failure(string errorMessage, Exception exception = null)
    {
        return new OperationResult<T>
        {
            Success = false,
            ErrorMessage = errorMessage,
            Exception = exception
        };
    }
}