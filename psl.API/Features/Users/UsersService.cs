using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Users
{
    public interface IUsersService
    {
        IEnumerable<UserModel> GetUsers(int userId);
        UserModel GetUser(int id);
        UserModel AddUser(UserModel model);
        UserModel UpdateUser(UserModel model);
        void DeleteUser(int id);
    }

    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repo;

        public UsersService(IUsersRepository repo)
        {
            _repo = repo;
        }

        public UserModel AddUser(UserModel model)
        {
            var inserted = _repo.Insert(model);
            return GetUser(inserted.Id);
        }

        public void DeleteUser(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<UserModel> GetUsers(int userId)
        {
            return _repo.All();
        }

        public UserModel GetUser(int id)
        {
            return _repo.FindByKey(id);
        }

        public UserModel UpdateUser(UserModel model)
        {
            var updated = _repo.Update(model);
            return GetUser(updated.Id);
        }
    }
}
