using CSVFileIo.Entity;
using CSVFileIo.Repository.Interface;

namespace CSVFileIo.Repository.Implementation
{
    public class FileIoService
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
        public void WriteDataToCSV(List<Question> questions)
        {
            _repository.ReadDataFromCSV();
        }

    }
}