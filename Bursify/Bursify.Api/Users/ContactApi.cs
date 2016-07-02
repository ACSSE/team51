using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using Bursify.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Api.Users
{
    public class ContactApi
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly Repository<Contact> _contact;

        public ContactApi(IUnitOfWorkFactory unitOfWorkFactory, Repository<Contact> contact)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _contact = contact;

        }

        public void CreateUser(string name)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = new Contact();
                
                user.CellphoneNumber = name;
                _contact.Save(user);

                //delete


                //send email

                uow.Commit();
            }
        }
    }
}
