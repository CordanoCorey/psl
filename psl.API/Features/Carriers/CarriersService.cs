using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Carriers
{
    public interface ICarriersService
    {
        IEnumerable<CarrierModel> GetCarriers(int userId);
        CarrierModel GetCarrier(int id);
        CarrierModel AddCarrier(CarrierModel model);
        CarrierModel UpdateCarrier(CarrierModel model);
        void DeleteCarrier(int id);
    }

    public class CarriersService : ICarriersService
    {
        private readonly ICarriersRepository _repo;

        public CarriersService(ICarriersRepository repo)
        {
            _repo = repo;
        }

        public CarrierModel AddCarrier(CarrierModel model)
        {
            var inserted = _repo.Insert(model);
            return GetCarrier(inserted.Id);
        }

        public void DeleteCarrier(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<CarrierModel> GetCarriers(int userId)
        {
            return _repo.All();
        }

        public CarrierModel GetCarrier(int id)
        {
            return _repo.FindByKey(id);
        }

        public CarrierModel UpdateCarrier(CarrierModel model)
        {
            var updated = _repo.Update(model);
            return GetCarrier(updated.Id);
        }
    }
}
