namespace Application.Wrappers.Results;

public class SuccessPaginationDataResult<T> : DataResult<T>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public SuccessPaginationDataResult(T data, string message, int count, PaginationQuery paginationQuery) : base(data, true, message)
    {
        TotalCount = count;
        PageSize = paginationQuery.PageSize;
        CurrentPage = paginationQuery.PageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)paginationQuery.PageSize);
    }

    public SuccessPaginationDataResult(T data) : base(data, true)
    {
    }
}