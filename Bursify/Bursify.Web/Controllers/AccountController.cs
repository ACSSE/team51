using System;
using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using Bursify.Api.Security;
using Bursify.Api.Students;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Web.Controllers
{

    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly MembershipApi _membershipApi;
        private readonly StudentApi _studentApi;

        public AccountController(MembershipApi membershipApi, StudentApi studentApi)
        {
            _membershipApi = membershipApi;
            _studentApi = studentApi;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("VerifyPassword")]
        public HttpResponseMessage VerifyPassword(HttpRequestMessage request, int userId, string password)
        {
            var user = _membershipApi.GetUserById(userId);
            HttpResponseMessage response = null;

            var isValid = _membershipApi.IsPasswordValid(user, password);

            if (isValid)
            {
                response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
            }
            else
            {
                response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
            }

            return response;
        }

        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel userVm)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
                return request.CreateResponse(HttpStatusCode.OK, new { success = false });

            var loginSuccess = _membershipApi.Login(userVm.UserEmail, userVm.Password);

            if (loginSuccess)
            {
                var loggedInUser = _membershipApi.GetUserByEmail(userVm.UserEmail);
                var user = (new BursifyUserViewModel()).ReverseMapUser(loggedInUser);
                    
                if(user.UserType.Equals("Admin"))
                {
                    return request.CreateResponse(HttpStatusCode.OK, new { success = true, user });
                }

                SetUserName(user);

                response = request.CreateResponse(HttpStatusCode.OK, new { success = true, user });
            }
            else
            {
                response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
            }

            return response;
        }

        private void SetUserName(BursifyUserViewModel userVm)
        {
            if(userVm.UserType.Equals("Student", System.StringComparison.OrdinalIgnoreCase))
            {
                var tempUser = _studentApi.GetStudent(userVm.ID);
                var fullName = tempUser.Firstname + " "
                                + tempUser.Surname;
                userVm.Name = fullName;
            }
            else
            {
                userVm.Name = _studentApi.GetSponsor(userVm.ID).CompanyName;
            }
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel newUser)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
            }
            else
            {
                BursifyUser user = _membershipApi.RegisterUser(newUser.UserEmail, newUser.Password, newUser.UserType);

                if (user != null)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = true, user});

                    try
                    {
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.EnableSsl = true;
                        client.Timeout = 10000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("bursifyproject@gmail.com", "Bursify123!");
                        MailMessage msg = new MailMessage();
                        msg.To.Add(user.Email);
                        msg.From = new MailAddress("bursifyproject@gmail.com");
                        msg.Subject = "Bursify Welcome!";
                        msg.Body = string.Format("Welcome to Bursify,  {0}{0} Thank you for creating an account on our system. {0} Regards,{0} Bursify Team", Environment.NewLine);

                        client.Send(msg);
                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                    }
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                }
            }

            return response;
        }
    }
}
