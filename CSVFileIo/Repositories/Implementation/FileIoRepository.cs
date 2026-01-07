using CSVFileIo.Entity;

namespace CSVFileIo.Repository.Implementation
{
    public class FileIoRepository
    {

        public List<Question> questions=new List<Question>();
        string _file="data.csv";
        public List<Question> ReadDataFromCSV()
        {
            StreamReader streamReader=new StreamReader(_file);
            string line;
            while((line = streamReader.ReadLine())!=null)
            {
                string[] column=line.Split(',');
                Question question=new Question();
                question.Id=int.Parse(column[0]);
                question.Concept=column[1];
                question.Subject=column[2];
                question.Title=column[3];
                question.A=column[4];
                question.B=column[5];
                question.C=column[6];
                question.D=column[7];
                question.AnswerKey=column[8];
                question.CreatedBy=column[9];
                
                questions.Add(question);
            }
            return questions;
        }
        public void WriteDataToCSV(List<Question> questions)
        {
            
        }

    }
}