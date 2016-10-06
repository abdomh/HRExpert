using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRExpert.Organization.BL
{
    using DTO;
    public static class ContentFilterFactory
    {
        public static MemberExpression GetProperty(this Expression expression, string property)
        {
            string[] props = property.Split('.');
            var result = Expression.Property(expression, props[0]);
            for (int i = 1; i < props.Length; i++)
                result = Expression.Property(result, props[i]);
            return result;
        }
        
        public static Expression<Func<TDomain, bool>> Create<TDomain>(object searchmodel)
        {
            Type searchmodelType = searchmodel.GetType();
            ConstantExpression search = ConstantExpression.Constant(searchmodel);
            var domain = Expression.Parameter(typeof(TDomain), "domain");
            var props = searchmodelType.GetProperties();
            Expression result = Expression.Equal(Expression.Constant(true),Expression.Constant(true));
            foreach (var prop in props)
            {
                var propValue = prop.GetValue(searchmodel, null);
                if (propValue == null) continue;
                var attrs = prop.GetCustomAttributes(typeof(ContentFilterAttribute), false);
                foreach (ContentFilterAttribute attr in attrs)
                {                
                    var domainprop = domain.GetProperty(attr.ModelPropertyName);
                    Expression searchprop = Expression.Property(search, prop);
                    switch (attr.CheckAction)
                    {
                        case ContentFilterActions.Equals:
                            result = Expression.AndAlso(result, Expression.Equal(domainprop, searchprop));
                            break;
                        case ContentFilterActions.GreatOrEquals:
                            result = Expression.AndAlso(result, Expression.GreaterThanOrEqual(domainprop, searchprop));
                            break;
                        case ContentFilterActions.LessOrEquals:
                            result = Expression.AndAlso(result, Expression.LessThanOrEqual(domainprop, searchprop));
                            break;
                        case ContentFilterActions.Great:
                            result = Expression.AndAlso(result, Expression.GreaterThan(domainprop, searchprop));
                            break;
                        case ContentFilterActions.Less:
                            result = Expression.AndAlso(result, Expression.LessThan(domainprop, searchprop));
                            break;
                        case ContentFilterActions.Like:
                            result = Expression.AndAlso(result, Expression.Call(domainprop, typeof(string).GetMethod("Contains"), searchprop));
                            break;
                        case ContentFilterActions.StartsWith:
                            result = Expression.AndAlso(result, Expression.Call(domainprop, typeof(string).GetMethods().Where(x=>x.Name=="StartsWith" && x.GetParameters().Count()==1).First(), searchprop));
                            break;
                        case ContentFilterActions.NotEquals:
                            result = Expression.AndAlso(result, Expression.NotEqual(domainprop, searchprop));
                            break;
                    }
                }
            }
            while (result.CanReduce)
            {
                result = result.Reduce();
            }
            var final = Expression.Lambda<Func<TDomain, bool>>(result, domain);
            return final;
        }
    }
}
