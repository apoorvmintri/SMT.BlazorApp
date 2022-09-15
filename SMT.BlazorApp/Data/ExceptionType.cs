using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.BlazorApp.Data
{
    public enum ExceptionType
    {
        Exception,
        SqlException,
        DbUpdateException,
        DbUpdateConcurrencyException,
        ValidationFailure,
        DocDuplicateException,
    }
}
