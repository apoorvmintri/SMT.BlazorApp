using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.BlazorApp.Data
{
    public class UserLookup : BaseLookup, IUser
    {
        private string _employeeId = string.Empty;

        public string EmployeeId
        {
            get { return _employeeId; }
            set
            {
                if (value == null)
                    _employeeId = string.Empty;
                else
                    _employeeId = value;
            }
        }

        public string StatusType { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        private string _middleName = string.Empty;

        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (value == null)
                    _middleName = string.Empty;
                else
                    _middleName = value;
            }
        }

        private string _suffix = string.Empty;

        public string Suffix
        {
            get { return _suffix; }
            set
            {
                if (value == null)
                    _suffix = string.Empty;
                else
                    _suffix = value;
            }
        }

        public string Email { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;
    }
}
