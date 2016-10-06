using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.DTO
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ContentFilterAttribute:Attribute
    {
        public string ModelPropertyName { get; set; }
        public ContentFilterActions CheckAction { get; set; }
    }
    public enum ContentFilterActions
    {
        Equals,
        Less,
        Great,
        LessOrEquals,
        GreatOrEquals,
        NotEquals,
        Like,
        StartsWith
    }
}
