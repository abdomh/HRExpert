using HRExpert.Core.Abstractions;
namespace HRExpert.Core.DTO
{
    public class IdNameDto:IIdName
    {
        public IdNameDto()
        { }
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
