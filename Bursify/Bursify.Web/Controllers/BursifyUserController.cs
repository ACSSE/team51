using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Security;
using Bursify.Web.Utility;
using System.Web;
using System.Linq;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using Bursify.Api.Students;
using Bursify.Api.Users;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/BursifyUser")]
    public class BursifyUserController : ApiController
    {
        private readonly MembershipApi _membershipApi;
        private readonly UserApi _userApi;
        private readonly StudentApi _studentApi;

        public BursifyUserController(MembershipApi membershipApi, UserApi userApi, StudentApi studentApi)
        {
            _membershipApi = membershipApi;
            _userApi = userApi;
            _studentApi = studentApi;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("GetUser")]
        public HttpResponseMessage GetUser(HttpRequestMessage request, string email)
        {
            BursifyUser user;
            BursifyUser userVm = null;

            if (_userApi.GetUserType(email).Equals("Student"))
            {
                user = _userApi.GetCompletStudentUser(email);
                userVm = new BursifyUserViewModel().MapStudentUser(user);
            }
            else
            {
                user = _userApi.GetCompletSponsorUser(email);
                userVm = new BursifyUserViewModel().MapSponsorUser(user);
            }

            userVm.PasswordHash = null;
            userVm.PasswordSalt = null;

            var response = request.CreateResponse(HttpStatusCode.OK, userVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("GetUser")]
        public HttpResponseMessage GetUser(HttpRequestMessage request, int userId)
        {
            BursifyUser user;
            BursifyUser userVm = null;

            if (_userApi.GetUserType(userId).Equals("Student"))
            {
                var student = _studentApi.GetStudent(userId);
                student.NumberOfViews += 1;
                _studentApi.SaveStudent(student);

                user = _userApi.GetCompletStudentUser(userId);
                userVm = new BursifyUserViewModel().MapStudentUser(user);
            }
            else
            {
                user = _userApi.GetCompletSponsorUser(userId);
                userVm = new BursifyUserViewModel().MapSponsorUser(user);
            }

            userVm.PasswordHash = null;
            userVm.PasswordSalt = null;

            var response = request.CreateResponse(HttpStatusCode.OK, userVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("UploadImage")]
        [MimeMultipart]
        public async Task<HttpResponseMessage> UploadImage(HttpRequestMessage request, int userId)
        {
            var user = _membershipApi.GetUserById(userId);

            if (user == null) return null;
         
            var imagePath = HttpContext.Current.Server.MapPath("~/Content/BursifyUploads/" + userId + "/images");

            var directory = new DirectoryInfo(imagePath);

            if (!directory.Exists) { directory.Create();}

            var multipartFormDataStreamProvider = new UploadMultipartFormProvider(directory.FullName);

            // Read the MIME multipart asynchronously 
            await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);
           
            var localFileName = multipartFormDataStreamProvider
                .FileData.Select(multiPartData => multiPartData.LocalFileName).ToList();

            var nameOfFile = localFileName[0];

            // Create response
            if (nameOfFile == null) return null;
            var fileUploadResult = new FileUploadResult
            {
                LocalFilePath = nameOfFile,
                FileName = Path.GetFileName(nameOfFile),
                FileLength = new FileInfo(nameOfFile).Length
            };

            // update profile picture path of the user
            user.ProfilePicturePath = fileUploadResult.FileName;

            //update the user in the database
            _membershipApi.UpdateUser(user);

            var response = request.CreateResponse(HttpStatusCode.OK, fileUploadResult);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("UploadCampaignImage")]
        [MimeMultipart]
        public async Task<HttpResponseMessage> UploadCampaignImage(HttpRequestMessage request, int userId, int campaignId)
        {
            var camapaign = _studentApi.GetSingleCampaign(campaignId);

            if (camapaign == null) return null;

            var imagePath = HttpContext.Current.Server.MapPath("~/Content/BursifyUploads/" + userId + "/images");

            var directory = new DirectoryInfo(imagePath);

            if (!directory.Exists) { directory.Create(); }

            var multipartFormDataStreamProvider = new UploadMultipartFormProvider(directory.FullName);

            // Read the MIME multipart asynchronously 
            await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

            var localFileName = multipartFormDataStreamProvider
                .FileData.Select(multiPartData => multiPartData.LocalFileName).ToList();

            var nameOfFile = localFileName[0];

            // Create response
            if (nameOfFile == null) return null;
            var fileUploadResult = new FileUploadResult
            {
                LocalFilePath = nameOfFile,
                FileName = Path.GetFileName(nameOfFile),
                FileLength = new FileInfo(nameOfFile).Length
            };

            

            camapaign.PicturePath = fileUploadResult.FileName;

            //update the user in the database
            _studentApi.SaveCampaign(camapaign);

            var response = request.CreateResponse(HttpStatusCode.OK, fileUploadResult);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("SendEmail")]
        public HttpResponseMessage SendEmail(HttpRequestMessage request, string email)
        {
            using (var mail = new MailMessage("brandonsibbs@gmail.com", "malcolmcollin@gmail.com"))
            {

                var client = new SmtpClient
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Host = "smtp.gmail.com"
                };

                mail.Subject = "this is a test email.";
                mail.Body = "this is my test email body";
                client.Send(mail);

                return request.CreateResponse(HttpStatusCode.OK, new {sent = true});
            }
        }
    }
}