namespace HRExpert.Organization.Data.Models
{
    public enum DocumentStatusEnum
    {
        //Черновик
        Draft = 1,
        //Выгружен в 1С
        SendedTo1C =2,
        //В процессе согласования
        WorkInProgress = 3,
        //Отменен
        Cancelled = 4
    }
}
