using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.BlazorApp.Data
{
    public class BaseDto : BaseDto<int>
    {

    }

    public class BaseDto<TKey>
    {
        public TKey Id { get; set; }

        public string RowVersion { get; set; } = string.Empty;

        public UserLookup ModifiedBy { get; set; } = null!;

        public UserLookup CreatedBy { get; set; } = null!;

        public string DateModified { get; set; } = string.Empty;

        public string DateCreated { get; set; } = string.Empty;

        public virtual string LookupValue { get; set; } = string.Empty;
    }
}
