﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Facade.Quantity;
using Soft.Data;
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
        public async Task OnGetAsync()
        {
            var l = await data.Get();
            Items = new List<MeasureView>();
            foreach (var e in l)
            {
                Items.Add(MeasureViewFactory.Create(e));
            }
        }
    }
}
