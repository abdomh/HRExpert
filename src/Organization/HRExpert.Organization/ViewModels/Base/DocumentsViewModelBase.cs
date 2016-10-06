using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HRExpert.Organization.BL;
namespace HRExpert.Organization.ViewModels
{
    public class DocumentsViewModelBase<TDTO, TFILTER>
    {
        public DocumentsViewModelBase()
        {
            this.Documents = new List<TDTO>();
        }
        private IEnumerable<TDTO> documents { get; set; }
        
        private Func<TCollection, TCollection> GetOrderDelegate<TCollection,TElement>()
        {
            var Tcollection = Expression.Parameter(typeof(TCollection));                  
            var Tsource = Expression.Parameter(typeof(TElement));
            var Tkey = Tsource.GetProperty(this.OrderBy);
            var lambda = Expression.Lambda(Tkey, Tsource);

            MethodInfo OrderByMethod = typeof(Enumerable).GetMethods().Where(method => method.Name == "OrderBy" && method.GetParameters().Length == 2).First().MakeGenericMethod(typeof(TElement), Tkey.Type);

            var OrderExpression = Expression.Call(OrderByMethod,Tcollection,lambda);
            return Expression.Lambda<Func<TCollection, TCollection>>(OrderExpression, Tcollection).Compile();
        }
        
        public TFILTER Filter { get; set; }
        public string OrderBy { get; set; }
        public bool OrderDirection { get; set; }
        public IEnumerable<TDTO> Documents
        {
            get
            {
                return (OrderBy==null || String.IsNullOrEmpty(OrderBy))? this.documents : GetOrderDelegate<IEnumerable<TDTO>,TDTO>().Invoke(this.documents);
            }
            set
            {
                this.documents = value;
            }
        }
    }
}
