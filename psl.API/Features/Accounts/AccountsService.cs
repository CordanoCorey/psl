using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Accounts
{
    public interface IAccountsService
    {
        IEnumerable<AccountModel> GetAccounts(int userId);
        AccountModel GetAccount(int id);
        AccountModel AddAccount(AccountModel model);
        AccountModel UpdateAccount(AccountModel model);
        void DeleteAccount(int id);
    }

    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _repo;

        public AccountsService(IAccountsRepository repo)
        {
            _repo = repo;
        }

        public AccountModel AddAccount(AccountModel model)
        {
            var inserted = _repo.Insert(model);
            return GetAccount(inserted.Id);
        }

        public void DeleteAccount(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<AccountModel> GetAccounts(int userId)
        {
            return _repo.All();
        }

        public AccountModel GetAccount(int id)
        {
            return _repo.FindByKey(id);
        }

        public AccountModel UpdateAccount(AccountModel model)
        {
            var updated = _repo.Update(model);
            return GetAccount(updated.Id);
        }
    }
}
