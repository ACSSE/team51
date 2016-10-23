using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Web.Models
{
    public class NotificationViewModel
    {
        public int ID { get; set; }
        public int BursifyUserId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }
        public int ActionId { get; set; }
        public string Sender { get; set; }
        public bool ReadStatus { get; set; }

        public NotificationViewModel()
        {
            
        }

        public NotificationViewModel(Notification n)
        {
            MapSingleNotification(n);
        }

        public NotificationViewModel MapSingleNotification(Notification n)
        {
            ID = n.ID;
            BursifyUserId = n.BursifyUserId;
            TimeStamp = n.TimeStamp;
            Message = n.Message;
            Action = n.Action;
            ActionId = n.ActionId;
            Sender = n.Sender;
            ReadStatus = n.ReadStatus;
            return this;
        }

        public Notification ReverseMap()
        {
            return new Notification()
            {
                ID = this.ID,
                BursifyUserId = this.BursifyUserId,
                TimeStamp = this.TimeStamp,
                Message = this.Message,
                Action = this.Action,
                ActionId = this.ActionId,
                Sender = this.Sender,
                ReadStatus = this.ReadStatus
            };
        }

        public static List<NotificationViewModel> MultipleNotificationsMap(List<Notification> notifications)
        {
            List<NotificationViewModel> notificationsVM = new List<NotificationViewModel>();
            foreach (var s in notifications)
            {
                NotificationViewModel sVm = new NotificationViewModel(s);
                notificationsVM.Add(sVm);
            }
            return notificationsVM;
        }
    }
}