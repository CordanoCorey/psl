using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Routings
{
    public interface IRoutingsService
    {
        IEnumerable<RoutingModel> GetRoutings(int userId);
        RoutingModel GetRouting(int id);
        RoutingModel AddRouting(RoutingModel model);
        RoutingModel UpdateRouting(RoutingModel model);
        void DeleteRouting(int id);
    }

    public class RoutingsService : IRoutingsService
    {
        private readonly IRoutingsRepository _repo;

        public RoutingsService(IRoutingsRepository repo)
        {
            _repo = repo;
        }

        public RoutingModel AddRouting(RoutingModel model)
        {
            var inserted = _repo.Insert(model);
            return GetRouting(inserted.Id);
        }

        public void DeleteRouting(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<RoutingModel> GetRoutings(int userId)
        {
            return _repo.All();
        }

        public RoutingModel GetRouting(int id)
        {
            return _repo.FindByKey(id);
        }

        public RoutingModel UpdateRouting(RoutingModel model)
        {
            var updated = _repo.Update(model);
            return GetRouting(updated.Id);
        }
    }
}
