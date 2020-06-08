using AutoMapper;
using psl.API.Infrastructure;
using psl.Entity.Context;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Widgets
{
    public interface IWidgetsRepository : IBaseRepository<Widget, WidgetModel>
    {
        IEnumerable<WidgetModel> FindByUser(int userId);
    }

    public class WidgetsRepository : BaseRepository<PSLContext, Widget, WidgetModel>, IWidgetsRepository
    {
        public WidgetsRepository(PSLContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<WidgetModel> FindByUser(int userId)
        {
            return FindBy(x => x.UserId == userId);
        }
    }
}
