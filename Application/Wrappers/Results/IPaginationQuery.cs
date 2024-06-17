namespace Application.Wrappers.Results;

public interface IPaginationQuery
{
    int PageNumber { get; set; }
    int PageSize { get; set; }
}