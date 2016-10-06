using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class NotificationRepository : Repository<Notification>
    {
        public NotificationRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public int getNumberOfUnreadMessages(int id)
        {
            return FindMany(x => x.BursifyUserId == id && x.ReadStatus == false).Count;
        }

        public List<Notification> GetNotifications(int id)
        {
            return FindMany(x => x.BursifyUserId == id);
        }

        public Notification GetSingleNotification(int id)
        {
            return LoadById(id);
        }

        public void MarkAllRead(int id)
        {
            List<Notification> notifications = FindMany(x => x.BursifyUserId == id && x.ReadStatus == false);
            foreach (var n in notifications)
            {
                n.ReadStatus = true;
            }
            Save(notifications);
        }

        public void MarkSingleRead(int id)
        {
            Notification n = LoadById(id);
            n.ReadStatus = true;
            Save(n);
        }
    }
}
