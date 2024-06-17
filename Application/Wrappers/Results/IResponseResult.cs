namespace Application.Wrappers.Results;

public interface IResponseResult
{
    bool Success { get; }
    string Message { get; }
}