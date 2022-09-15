using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.BlazorApp.Data
{
    public interface IUser : IBaseUser
    {
        public string? EmployeeId { get; set; }

        public string StatusType { get; set; }
    }
}
