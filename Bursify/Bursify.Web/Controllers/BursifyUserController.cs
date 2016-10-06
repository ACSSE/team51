using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Security;
using Bursify.Web.Utility;
using System.Web;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Bursify.Api.Students;
using Bursify.Api.Users;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Api.Sponsors;
using System;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/BursifyUser")]
    public class BursifyUserController : ApiController
    {
        public const int NOTIFICATION_SYSTEM = -1;

        private readonly MembershipApi _membershipApi;
        private readonly UserApi _userApi;
        private readonly StudentApi _studentApi;
        private readonly SponsorApi _sponsorApi;

        public BursifyUserController(MembershipApi membershipApi, UserApi userApi, StudentApi studentApi, SponsorApi sponsorApi)
        {
            _membershipApi = membershipApi;
            _userApi = userApi;
            _studentApi = studentApi;
            _sponsorApi = sponsorApi;
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

        //use sender Id = -1 for notification sent from system/bursify
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("CreateNotification")]
        public HttpResponseMessage GetNumberUnreadMessages(HttpRequestMessage request, int senderId, NotificationViewModel nVm)
        {
            if (senderId == NOTIFICATION_SYSTEM)
            {
                nVm.Sender = "Bursify";
            } else {
                nVm.Sender = _sponsorApi.GetSponsor(senderId).CompanyName;
            }

            nVm.TimeStamp = DateTime.UtcNow;

            _userApi.CreateNotification(nVm.ReverseMap());

            var response = request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("GetNumberUnreadMessages")]
        public HttpResponseMessage GetNumberUnreadMessages(HttpRequestMessage request, int userId)
        {
            int number = _userApi.GetNumberOfUnreadMessages(userId);

            var response = request.CreateResponse(HttpStatusCode.OK, number);
            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("GetNotifications")]
        public HttpResponseMessage GetNotifications(HttpRequestMessage request, int userId)
        {
            var notifications = _userApi.GetNotifications(userId);

            var notificationVMs  = NotificationViewModel.MultipleNotificationsMap(notifications);

            var response = request.CreateResponse(HttpStatusCode.OK, notificationVMs);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("GetSingleNotification")]
        public HttpResponseMessage GetSingleNotification(HttpRequestMessage request, int Id)
        {
            var notification = _userApi.GetSingleNotification(Id);

            NotificationViewModel notificationVM = new NotificationViewModel(notification);

            var response = request.CreateResponse(HttpStatusCode.OK, notificationVM);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("MarkAllRead")]
        public HttpResponseMessage MarkAllRead(HttpRequestMessage request, int UserId)
        {

            _userApi.MarkAllRead(UserId);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("MarkSingleRead")]
        public HttpResponseMessage MarkSingleRead(HttpRequestMessage request, int Id)
        {

            _userApi.MarkSingleRead(Id);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

    }
}