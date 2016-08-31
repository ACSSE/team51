using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Security;
using Bursify.Web.Utility;
using System.Web;
using System.Linq;
using System.IO;
using Bursify.Api.Students;
using Bursify.Api.Users;

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
            var user = _membershipApi.GetUserByEmail(email);

            var model = new BursifyUserViewModel();

            var userVm = model.MapSingleBursifyUser(user);

            userVm.PasswordHash = null;
            userVm.PasswordSalt = null;

            var response = request.CreateResponse(HttpStatusCode.OK, userVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("GetUser")]
        public HttpResponseMessage GetUser(HttpRequestMessage request, int userId)
        {
            var user = _userApi.GetCompleteUser(userId);

            var model = new BursifyUserViewModel();

            var userVm = model.MapSingleBursifyUser(user);

            userVm.PasswordHash = null;
            userVm.PasswordSalt = null;

            var report = _studentApi.GetMostRecentReport(userId);
            var studentModel = new StudentViewModel(_studentApi.GetStudent(userId));

            if (report != null)
            {
                studentModel.AverageMark = report.Average;
            }

            var response = request.CreateResponse(HttpStatusCode.OK, userVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("UploadImage")]
        [MimeMultipart]
        public HttpResponseMessage UploadImage(HttpRequestMessage request, int userId)
        {
            var user = _membershipApi.GetUserById(userId);

            if (user == null) return null;
         
            var imagePath = HttpContext.Current.Server.MapPath("~/Content/BursifyUploads/" + userId + "/images");

            var directory = new DirectoryInfo(imagePath);

            if (!directory.Exists) { directory.Create();}

            var multipartFormDataStreamProvider = new UploadMultipartFormProvider(directory.FullName);

            // Read the MIME multipart asynchronously 
            Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

            var localFileName = multipartFormDataStreamProvider
                .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

            // Create response
            if (localFileName == null) return null;
            var fileUploadResult = new FileUploadResult
            {
                LocalFilePath = localFileName,
                FileName = Path.GetFileName(localFileName),
                FileLength = new FileInfo(localFileName).Length
            };

            // update profile picture path of the user
            user.ProfilePicturePath = fileUploadResult.FileName;

            //update the user in the database
            _membershipApi.UpdateUser(user);

            var response = request.CreateResponse(HttpStatusCode.OK, fileUploadResult);

            return response;
        }
    }
}