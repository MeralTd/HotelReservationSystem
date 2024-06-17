namespace Application.Wrappers.Results;

public interface IDataResult<T> : IResponseResult
{
    T Data { get; }
}