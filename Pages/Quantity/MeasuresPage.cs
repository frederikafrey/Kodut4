using Abc.Domain.Quantity;
using Facade.Quantity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Abc.Pages
{
    public abstract class MeasuresPage : PageModel
    {
        protected internal readonly IMeasuresRepository data;

        protected internal MeasuresPage(IMeasuresRepository r) => data = r;

        [BindProperty]
        public MeasureView Item { get; set; }
        public IList<MeasureView> Items { get; set; }
    }
}
