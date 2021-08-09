namespace wsphuoc.Paging
{
    public class PagingRequestBase
    {
        public int pageIndex { get; set; } = 1; //current page, begin: 1
        public int pageSize { get; set; } = 20; //rows data per page
        public int pageNums { get; set; } = 5; //page links per page
    }
}
