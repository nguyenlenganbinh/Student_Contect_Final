using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Student_Contact_Final.Models;
using Student_Contact_Final.Data;
using DTOCls;

namespace Student_Contact_Final.Controllers.api
{
    public class AccountController : ApiController
    {
        private readonly MyDBContext _context = new MyDBContext();

        /// <summary>
        /// Support Login with role
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public IHttpActionResult GetAccount(string username, string password, string role)
        {
            Account item = (from n in _context.accounts
                            where n.UserName.Equals(username) && n.Password.Equals(password) && n.Role.Equals(role)
                            select n).FirstOrDefault();
            if (item != null)
            {
                DTOAccount account = new DTOAccount();
                account.AccountId = item.AccountId;
                account.UserName = item.UserName;
                account.Password = item.Password;
                account.Role = item.Role;
                account.Status = item.Status;
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
