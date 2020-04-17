using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace psl.API.Infrastructure
{
    public interface IQueryModel<TModel>
    {
        string UserId { get; set; }
        IEnumerable<string> Fields { get; set; }
        IEnumerable<string> Filters { get; set; }
        IEnumerable<string> Groups { get; set; }
        int Skip { get; set; }
        IEnumerable<string> Sort { get; set; }
        int Take { get; set; }
        string Term { get; set; }
    }
    public class QueryModel<TModel> : IQueryModel<TModel>
    {
        public static QueryModel<TModel> Build(IQueryModel<TModel> model)
        {
            return new QueryModel<TModel>()
            {
                UserId = model.UserId,
                Fields = model.Fields,
                Filters = model.Filters,
                Groups = model.Groups,
                Skip = model.Skip,
                Sort = model.Sort,
                Take = model.Take,
                Term = model.Term
            };
        }

        public string UserId { get; set; }
        public IEnumerable<string> Fields { get; set; }
        public IEnumerable<string> Filters { get; set; }
        public IEnumerable<string> Groups { get; set; }
        public int Skip { get; set; } = 0;
        public virtual IEnumerable<string> Sort { get; set; }
        public int Take { get; set; } = 20;
        public string Term { get; set; }

        internal Func<TModel, bool> FilterBy { get; set; }
        internal Func<TModel, object> GroupBy { get; set; }
        internal Func<TModel, object> Include { get; set; }
        public bool IsNullOrDefault =>
            Skip == 0 && Take == 0 && Fields == null && Filters == null && Groups == null && Sort == null;
        internal Func<TModel, object> Map { get; set; } = (TModel x) => x;

        internal Func<TModel, object> OrderBy
        {
            get
            {
                return Sort.IsAny()
                    ? (Func<TModel, object>)((TModel x) => x.GetType().GetProperty(Sort.First()).GetValue(x, null))
                    : null;
            }
        }

        public Func<TModel, bool> Predicate { get; set; } = (TModel x) => true;
    }
}
