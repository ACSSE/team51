using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using Bursify.Data.User;

namespace Bursify.Api.Users
{
    public class UserApi
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly Repository<BursifyUser> _userRepository;

        public UserApi(
            IUnitOfWorkFactory unitOfWorkFactory,
            Repository<BursifyUser> userRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userRepository = userRepository;
        }

        public void CreateUser(string name)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = new BursifyUser();
                user.Name = name;
                _userRepository.Save(user);

                //delete


                //send email

                uow.Commit();
            }
        }
    }
}