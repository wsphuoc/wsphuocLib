using System;
using System.Collections.Generic;
using System.Linq;

namespace wsphuoc.Paging
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; }
        public PagedResult()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">Items source</param>
        /// <param name="pageIndex">Current page</param>
        /// <param name="pageSize">Rows per page</param>
        /// <param name="pageNum">Pages per page</param>
        public PagedResult(List<T> data, int? pageIndex, int? pageSize, int? pageNum)
        {
            TotalRecords = data.Count;
            PageSize = pageSize ?? 20;
            if (PageSize < 0) PageSize = 20;
            PageNums = pageNum ?? 5;
            if (PageNums < 5) PageNums = 5;
            PageIndex = pageIndex ?? 1;
            if (PageIndex < 1) PageIndex = 1;
            else if (PageIndex > PageCount) PageIndex = PageCount;
            var beginIndex = (PageIndex - 1) * PageSize;

            //var endIndex = beginIndex + PageSize - 1;
            //if (endIndex > TotalRecords - 1) PageSize = TotalRecords - beginIndex;
            //var tdata = data.GetRange(beginIndex, PageSize);

            var tdata2 = data.Skip(beginIndex).Take(PageSize).ToList();
            Items = tdata2;
        }
    }
}
