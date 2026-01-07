using CSVFileIo.Entity;

namespace CSVFileIo.Repository.Interface
{
    public interface IFileIoRepository
    {
       
        public List<Question> ReadDataFromCSV();
        public void WriteDataToCSV(List<Question> questions);
        
    }
}