using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using DTOCls;

namespace Student_Contact_Final_GUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly HttpClient _client = new HttpClient();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password, string role)
        {
            int type = 0; // For Alert
            string message = string.Empty;// For Alert
            _client.BaseAddress = new Uri("http://localhost:49940/api/");
            var responseTask = _client.GetAsync("account?username=" + username + "&password=" + password + "&role=" + role);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<DTOAccount>();
                readTask.Wait();
                DTOAccount account = readTask.Result;
                if (account.Status)
                {
                    if (account.Role == "Admin")
                    {
                        var responseTask1 = _client.GetAsync("personalinformation?id=" + account.AccountId.ToString());
                        responseTask1.Wait();
                        var result1 = responseTask1.Result;
                        if (result1.IsSuccessStatusCode)
                        {
                            var readTask1 = result1.Content.ReadAsAsync<DTOAdminAccount>();
                            readTask1.Wait();
                            DTOAdminAccount admin = readTask1.Result;
                            return View("AdminPage", admin);
                        }
                    }
                    else if (account.Role == "Teacher")
                    {
                        var responseTask1 = _client.GetAsync("personalinformation?id=" + account.AccountId.ToString());
                        responseTask1.Wait();
                        var result1 = responseTask1.Result;
                        if (result1.IsSuccessStatusCode)
                        {
                            var readTask1 = result1.Content.ReadAsAsync<DTOTeacherAccount>();
                            readTask1.Wait();
                            var teacher = readTask1.Result;
                            return View("TeacherPage", teacher);
                        }
                    }
                    else if (account.Role == "Student")
                    {
                        var responseTask1 = _client.GetAsync("personalinformation?id=" + account.AccountId.ToString());
                        responseTask1.Wait();
                        var result1 = responseTask1.Result;
                        if (result1.IsSuccessStatusCode)
                        {
                            var readTask1 = result1.Content.ReadAsAsync<DTOStudentAccount>();
                            readTask1.Wait();
                            var student = readTask1.Result;
                            return View("StudentPage", student);
                        }
                    }
                    else // role = parent
                    {
                        var responseTask1 = _client.GetAsync("personalinformation?id=" + account.AccountId.ToString());
                        responseTask1.Wait();
                        var result1 = responseTask1.Result;
                        if (result1.IsSuccessStatusCode)
                        {
                            var readTask1 = result1.Content.ReadAsAsync<DTOParentAccount>();
                            readTask1.Wait();
                            var parent = readTask1.Result;
                            return View("ParentPage", parent);
                        }
                    }
                }
                else //status == false
                {
                    type = 1;
                    message = "Your account has been disabled!";
                }
            }
            else // Fail to get account
            {
                ModelState.AddModelError(string.Empty, "Error!!!");
                type = 2;
                message = "Account does not exist!";
            }
            SetAlert(message, type);
            return View();
        }

        public ActionResult AdminPage()
        {
            return View();
        }

        public ActionResult TeacherPage()
        {
            return View();
        }

        public ActionResult StudentPage()
        {
            return View();
        }

        public ActionResult ParentPage()
        {
            return View();
        }


        // Alert for form Login
        protected void SetAlert(string message, int type)
        {
            TempData["AlertMessage"] = message;
            if (type == 1)
            {
                TempData["AlertType"] = "alert-danger";
            }
            else if (type == 2)
            {
                TempData["AlertType"] = "alert-warning";
            }
            //else if (type == 3)
            //{
            //    TempData["AlertType"] = "alert-success";
            //}
            //else
            //{
            //    TempData["AlertType"] = "alert-info";
            //}
        }

    }
}