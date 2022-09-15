using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.BlazorApp.Data
{
    public class BaseLookup : BaseLookup<int>
    {

    }

    public class BaseLookup<TKey>
    {
        public TKey Id { get; set; }

        public string Guid { get; set; } = string.Empty;

        public string LookupValue { get; set; } = string.Empty;
    }
}
