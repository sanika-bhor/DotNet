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


        public int GetSubjectId(string subjectName)
        {
            return _repository.GetSubjectId(subjectName);
        }

        public int GetConceptId(String conceptName)
        {
            return _repository.GetConceptId(conceptName);
        }
        public bool InsertDataInDB()
        {
            return _repository.InsertDataInDB();
        }

        public int GetSubjectConceptId(string subjectName, string conceptName)
        {
            return _repository.GetSubjectConceptId(subjectName, conceptName);
        }


    }
}