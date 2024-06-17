namespace Application.Wrappers.Results;

public class ErrorPaginationDataResult<T> : DataResult<T>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public ErrorPaginationDataResult(T data, string message) : base(data, false, message)
    {
    }

    public ErrorPaginationDataResult(T data) : base(data, false)
    {
    }

    public ErrorPaginationDataResult(string message) : base(default, false, message)
    {
    }

    public ErrorPaginationDataResult() : base(default, false)
    {
    }
}