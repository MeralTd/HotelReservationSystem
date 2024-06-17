namespace Application.Wrappers.Results;

public interface IPaginationResult<out T> : IResponseResult
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}