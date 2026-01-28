using System.Reflection.Metadata.Ecma335;

namespace API.Specifications
{
    public class ProductSpecParams
    {
        public const int MaxPageSize=50;
        public int PageIndex {get;set;}=1;
        private int _pagesize=6;
        public int PageSize
        {
            get=> _pagesize;
            set=>_pagesize=(value>MaxPageSize)? MaxPageSize:value;
        }
        public int ? Brand {get;set;}
        public int ?Type{get;set;}
        public String ? sort {get;set;}
        private String ?_search;
        public String ?search
        {
            get=>_search;
            set=>_search=value.ToLower();
        }

    }
}