using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Widgets
{
    public interface IWidgetsService
    {
        IEnumerable<WidgetModel> GetUserWidgets(int userId);
        WidgetModel GetWidget(int id);
        WidgetModel AddWidget(WidgetModel model);
        WidgetModel UpdateWidget(WidgetModel model);
        void DeleteWidget(int id);
    }

    public class WidgetsService : IWidgetsService
    {
        private readonly IWidgetsRepository _repo;

        public WidgetsService(IWidgetsRepository repo)
        {
            _repo = repo;
        }

        public WidgetModel AddWidget(WidgetModel model)
        {
            var inserted = _repo.Insert(model);
            return GetWidget(inserted.Id);
        }

        public void DeleteWidget(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<WidgetModel> GetUserWidgets(int userId)
        {
            return _repo.FindByUser(userId);
        }

        public WidgetModel GetWidget(int id)
        {
            return _repo.FindByKey(id);
        }

        public WidgetModel UpdateWidget(WidgetModel model)
        {
            var updated = _repo.Update(model);
            return GetWidget(updated.Id);
        }
    }
}
