namespace Homework3.Services
{
    public interface IDataManager
    {
        IStudentRepository StudentRepository { get; set; }
    }
}
