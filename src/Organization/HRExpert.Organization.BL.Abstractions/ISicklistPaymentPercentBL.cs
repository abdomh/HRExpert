using System.Collections.Generic;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.BL.Abstractions
{
    public interface ISicklistPaymentPercentBL
    {
        List<SicklistPaymentPercentDto> List();
    }
}