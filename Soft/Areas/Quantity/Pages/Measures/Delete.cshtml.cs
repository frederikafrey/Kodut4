using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abc.Pages;
using Abc.Domain.Quantity;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class DeleteModel : MeasuresPage
    {
        public DeleteModel(IMeasuresRepository r) : base(r)
        {

        }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            await getObject(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            await deleteObject(id);

            return RedirectToPage("./Index");
        }
    }
}
