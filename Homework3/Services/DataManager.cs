using Homework3.Models;

namespace Homework3.Services
{
    public class DataManager : IDataManager
    {
        public IStudentRepository StudentRepository { get; set; }

        public DataManager(UniversityContext context)
        {
            StudentRepository = new StudentRepository(context);
        }

    }
}
