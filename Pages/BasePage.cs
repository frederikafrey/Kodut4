using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abc.Aids;
using Abc.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abc.Pages
{
    public abstract class BasePage<TRepository, TDomain, TView, TData> : PageModel
    where TRepository : ICrudMethods<TDomain>, ISorting, ISearching, IPaging
    { 
        private TRepository data;

        protected internal BasePage(TRepository r)
        {
            data = r;
        }

        [BindProperty] 
        public TView Item { get; set; }
        public IList<TView> Items { get; set; }
        public abstract string ItemId { get; }

        public string PageTitle { get; set; }
        public string PageSubTitle { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; } 
        public string SearchString { get; set; }

        public int PageIndex
        {
            get => data.PageIndex; 
            set => data.PageIndex = value;
        }

        public bool HasPreviousPage => data.HasPreviousPage;
        public bool HasNextPage => data.HasNextPage;


        public int TotalPages => data.TotalPages;

        protected internal async Task<bool> addObject()
        {
            try
            {
                if (!ModelState.IsValid) return false;
                await data.Add(toObject(Item));
            }
            catch
            {
                return false;
            }

            return true;
        }

        protected internal abstract TDomain toObject(TView view);

        protected internal async Task updateObject()
        {
            //TODO see viga tuleb lahendada
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            await data.Update(toObject(Item));
        }

        protected internal async Task getObject(string id)
        {
            var o = await data.Get(id);
            Item = toView(o);
        }

        protected internal abstract TView toView(TDomain obj);

        protected internal async Task deleteObject(string id)
        {
            await data.Delete(id);
        }

        public string GetSortString(Expression<Func<TData, object>> e, string page)
        {
            var name = GetMember.Name(e);
            string sortOrder;
            if (string.IsNullOrEmpty(CurrentSort)) sortOrder = name;
            else if (!CurrentSort.StartsWith(name)) sortOrder = name;
            else if (CurrentSort.EndsWith("_desc")) sortOrder = name;
            else sortOrder = name + "_desc";

            return $"{page}?sortOrder={sortOrder}&currentFilter={CurrentFilter}";
        }

        protected internal async Task getList(string sortOrder, string currentFilter, string searchString,
            int? pageIndex)
        {
            sortOrder = string.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;
            CurrentSort = sortOrder;

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

            PageIndex = pageIndex ?? 1;
            var l = await data.Get(); // Get annab kätte listi
            Items = new List<TView>();
            foreach (var e in l) Items.Add(toView(e));
        }
    }
}

