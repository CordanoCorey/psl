using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Dealers
{
    public interface IDealersService
    {
        IEnumerable<DealerModel> GetDealers(int userId);
        DealerModel GetDealer(int id);
        DealerModel AddDealer(DealerModel model);
        DealerModel UpdateDealer(DealerModel model);
        void DeleteDealer(int id);
    }

    public class DealersService : IDealersService
    {
        private readonly IDealersRepository _repo;

        public DealersService(IDealersRepository repo)
        {
            _repo = repo;
        }

        public DealerModel AddDealer(DealerModel model)
        {
            var inserted = _repo.Insert(model);
            return GetDealer(inserted.Id);
        }

        public void DeleteDealer(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<DealerModel> GetDealers(int userId)
        {
            return _repo.All();
        }

        public DealerModel GetDealer(int id)
        {
            return _repo.FindByKey(id);
        }

        public DealerModel UpdateDealer(DealerModel model)
        {
            var updated = _repo.Update(model);
            return GetDealer(updated.Id);
        }
    }
}
