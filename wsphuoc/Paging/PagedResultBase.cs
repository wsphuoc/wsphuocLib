using System;
using System.Collections.Generic;

namespace wsphuoc.Paging
{
    public class PagedResultBase
    {
        public int PageIndex { get; set; } = 1; //current page
        public int PageSize { get; set; } = 20; //rows per page
        public int TotalRecords { get; set; } //total rows
        public int PageNums { get; set; } = 5; //page links per page
        public string FirstText { get; set; } = "««";
        public string PreviousText { get; set; } = "«";
        public string NextText { get; set; } = "»";
        public string LastText { get; set; } = "»»";
        public int PageCount //total pages
        {
            get
            {
                var pageCount = (double)TotalRecords / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
        private bool HasNext
        {
            get
            {
                return (PageIndex < PageCount);
            }
        }
        private bool HasLast
        {
            get
            {
                return (PageIndex < PageCount);
            }
        }
        private bool HasPrevious
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        private bool HasFirst
        {
            get
            {
                return (PageIndex > PageNums);
            }
        }
        public List<PageLink> PageLinks
        {
            get
            {
                var segment = (PageIndex-1) / PageNums;
                var beginIndex = segment * PageNums + 1;
                var endIndex = beginIndex + PageNums - 1;
                if (endIndex > PageCount) endIndex = PageCount;

                var result = new List<PageLink>();
                PageLink link;
                if (HasFirst)
                {
                    link = new PageLink
                    {
                        Index = 1,
                        Text = FirstText,
                        Current = false
                    };
                    result.Add(link);
                }
                if (HasPrevious)
                {
                    link = new PageLink
                    {
                        Index = PageIndex - 1,
                        Text = PreviousText,
                        Current = false
                    };
                    result.Add(link);
                }
                for (var i = beginIndex; i <= endIndex; i++)
                {
                    link = new PageLink
                    {
                        Index = i,
                        Text = i.ToString(),
                        Current = (i == PageIndex)
                    };
                    result.Add(link);
                }
                if (HasNext)
                {
                    link = new PageLink
                    {
                        Index = PageIndex + 1,
                        Text = NextText,
                        Current = false
                    };
                    result.Add(link);
                }
                if (HasLast)
                {
                    link = new PageLink
                    {
                        Index = PageCount,
                        Text = LastText,
                        Current = false
                    };
                    result.Add(link);
                }
                return result;
            }
        }
    }
}
