using CSVFileIo.Entity;

namespace CSVFileIo.Repository.Interface
{
    public interface IFileIoRepository
    {

        public List<Question> ReadDataFromCSV();
        public bool WriteDataToCSV(List<Question> questions);
        public bool InsertDataInDB();

        public int GetSubjectId(string subjectName);

        public int GetConceptId(string conceptName);

        public int GetSubjectConceptId(string subjectName,string conceptName);
    }
}