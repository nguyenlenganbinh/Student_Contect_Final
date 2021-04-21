using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOCls
{
    public class DTOStudentAccount
    {
        public int AccountId { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
        public int StudentId { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public DateTime Birth { get; set; }
        public string Faculty { get; set; }
        public string Phone { get; set; }
        public int IdentityCardNumber { get; set; }
        public DTOStudentAccount() { }
    }
}
