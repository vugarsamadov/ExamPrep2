using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pagination
{
    public class GenericPaginatedEntity<T>
    {
        public GenericPaginatedEntity(int currentPage, int perPage, int rowCount, string next, string prev, IEnumerable<T> data)
        {
            CurrentPage = currentPage;
            PerPage = perPage;
            RowCount = rowCount;
            Next = next;
            Prev = prev;
            Data = data;
        }

        public int PageCount { get => (int)Math.Ceiling(RowCount*1.0/PerPage);}
        public bool HasNext { get => CurrentPage < PageCount; }
        public bool HasPrev { get => CurrentPage > 1; }

        public int CurrentPage { get; init; }
        public int PerPage { get;  init; }
        public int RowCount { get; init; }
        public string Next { get;  init; }
        public string Prev { get;  init; }
        public IEnumerable<T> Data { get; init; }
    }
}
