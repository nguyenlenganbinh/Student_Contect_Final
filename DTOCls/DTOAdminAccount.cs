using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOCls
{
    public class DTOAdminAccount
    {
        public int AccountId { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
        public int AdminId { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int IdentityCardNumber { get; set; }
        public DTOAdminAccount() { }
    }
}
