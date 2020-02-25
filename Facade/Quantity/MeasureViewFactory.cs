using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Facade.Quantity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Facade.Quantity
{
    public static class MeasureViewFactory
    {
        public static Measure Create(MeasureView v)
        {
            var d = new MeasureData
            {
                Id = v.Id,
                Code = v.Code,
                Name = v.Name,
                Definition = v.Definition,
                ValidFrom = v.ValidFrom,
                ValidTo = v.ValidTo
            };

            return new Measure(d);
        }

        public static MeasureView Create(Measure o)
        {
            var v = new MeasureView
            {
                Id = o.Data.Id,
                Code = o.Data.Code,
                Name = o.Data.Name,
                Definition = o.Data.Definition,
                ValidFrom = o.Data.ValidFrom,
                ValidTo = o.Data.ValidTo
            };

            return v;
        }
    }
}
