using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Data.Common
{
    public abstract class NamedEntityData : UniqueEntityData
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
