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
    public class PersonalInformationController : ApiController
    {
        private readonly MyDBContext _context = new MyDBContext();

        /// <summary>
        /// After login success -> Go to view with role
        /// Save PersonalInformation for function PersonalInformation Management
        /// 
        /// Note: Avatar need to modiffied
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetPersonalInformation(int id)
        {
            Account itemAccount = (from n in _context.accounts
                                   where n.AccountId.Equals(id)
                                   select n).FirstOrDefault();
            if (itemAccount.Role == "Admin")
            {
                Admin itemAdmin = (from n in _context.admins
                                   where n.AdminId.Equals(id)
                                   select n).FirstOrDefault();
                DTOAdminAccount admin = new DTOAdminAccount();
                admin.AccountId = itemAccount.AccountId;
                admin.UserName = itemAccount.UserName;
                admin.Password = itemAccount.Password;
                admin.Role = itemAccount.Role;
                admin.Status = itemAccount.Status;
                admin.AdminId = itemAdmin.AdminId;
                admin.Avatar = itemAdmin.Avatar;
                admin.Name = itemAdmin.Name;
                admin.Email = itemAdmin.Email;
                admin.Phone = itemAdmin.Phone;
                admin.IdentityCardNumber = itemAdmin.IdentityCardNumber;
                return Ok(admin);
            }
            else if (itemAccount.Role == "Teacher")
            {
                Teacher itemTeacher = (from n in _context.teachers
                                       where n.TeacherId.Equals(id)
                                       select n).FirstOrDefault();
                DTOTeacherAccount teacher = new DTOTeacherAccount();
                teacher.AccountId = itemAccount.AccountId;
                teacher.UserName = itemAccount.UserName;
                teacher.Password = itemAccount.Password;
                teacher.Role = itemAccount.Role;
                teacher.Status = itemAccount.Status;
                teacher.TeacherId = itemTeacher.TeacherId;
                teacher.Avatar = itemTeacher.Avatar;
                teacher.Name = itemTeacher.Name;
                teacher.Email = itemTeacher.Email;
                teacher.Gender = itemTeacher.Gender;
                teacher.Faculty = itemTeacher.Faculty;
                teacher.Phone = itemTeacher.Phone;
                teacher.IdentityCardNumber = itemTeacher.IdentityCardNumber;
                return Ok(teacher);
            }
            else if (itemAccount.Role == "Student")
            {
                Student itemStudent = (from n in _context.students
                                       where n.StudentId.Equals(id)
                                       select n).FirstOrDefault();
                DTOStudentAccount student = new DTOStudentAccount();
                student.AccountId = itemAccount.AccountId;
                student.UserName = itemAccount.UserName;
                student.Password = itemAccount.Password;
                student.Role = itemAccount.Role;
                student.Status = itemAccount.Status;
                student.StudentId = itemStudent.StudentId;
                student.Avatar = itemStudent.Avatar;
                student.Name = itemStudent.Name;
                student.Email = itemStudent.Email;
                student.Gender = itemStudent.Gender;
                student.Birth = itemStudent.Birth;
                student.Faculty = itemStudent.Faculty;
                student.Phone = itemStudent.Phone;
                student.IdentityCardNumber = itemStudent.IdentityCardNumber;
                return Ok(student);
            }
            else
            {
                Parent itemParent = (from n in _context.parents
                                     where n.ParentId.Equals(id)
                                     select n).FirstOrDefault();
                DTOParentAccount parent = new DTOParentAccount();
                parent.AccountId = itemAccount.AccountId;
                parent.UserName = itemAccount.UserName;
                parent.Password = itemAccount.Password;
                parent.Role = itemAccount.Role;
                parent.Status = itemAccount.Status;
                parent.ParentId = itemParent.ParentId;
                parent.Avatar = itemParent.Avatar;
                parent.Name = itemParent.Name;
                parent.Email = itemParent.Email;
                parent.Phone = itemParent.Phone;
                parent.IdentityCardNumber = itemParent.IdentityCardNumber;
                return Ok(parent);
            }
        }
    }
}
