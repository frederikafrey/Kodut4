using System.Collections.Generic;
using System.Threading.Tasks;
using Facade.Quantity;
using Abc.Pages;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class IndexModel : MeasuresPage
    {
        
        public IndexModel(IMeasuresRepository r) : base(r)
        {

        }

        public string NameSort { get; set; }
        public string CurrentSort { get; set; }
        public string DateSort { get; set; }

        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public int PageIndex { get; set; }

        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            data.SortOrder = sortOrder;
            SearchString = CurrentFilter;
            data.SearchString = searchString;
            data.PageIndex = pageIndex ?? 1; // kui pageIndex on 0, siis tuleb 1
            PageIndex = data.PageIndex;
            var l = await data.Get(); // Get annab kätte listi
            Items = new List<MeasureView>();
            foreach (var e in l) Items.Add(MeasureViewFactory.Create(e));
            HasNextPage = data.HasNextPage;
            HasPreviousPage = data.HasPreviousPage;
        }
    }
}
