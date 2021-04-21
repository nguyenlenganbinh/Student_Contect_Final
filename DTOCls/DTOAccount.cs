using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOCls
{
    public class DTOAccount
    {
        public int AccountId { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
        public DTOAccount() { }
    }
}
