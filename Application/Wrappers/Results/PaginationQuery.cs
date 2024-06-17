namespace Application.Wrappers.Results;

public class PaginationQuery : IPaginationQuery
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PaginationQuery()
    {
        this.PageNumber = 1;
        this.PageSize = 25;
    }

    public PaginationQuery(int pageNumber, int pageSize)
    {
        this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
        this.PageSize = pageSize < 25 ? 25 : pageSize;
    }
}