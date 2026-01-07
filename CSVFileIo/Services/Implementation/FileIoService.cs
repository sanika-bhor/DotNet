using CSVFileIo.Entity;
using CSVFileIo.Repository.Interface;

namespace CSVFileIo.Repository.Implementation
{
    public class FileIoService :IFileIoService
    {
        private readonly FileIoRepository _repository;
        public FileIoService(FileIoRepository repository)
        {
            _repository=repository;
        }
        public List<Question> ReadDataFromCSV()
        {
           return _repository.ReadDataFromCSV();
        }
        public bool WriteDataToCSV(List<Question> questions)
        {
           return _repository.WriteDataToCSV(questions);
        }

       
    }
}