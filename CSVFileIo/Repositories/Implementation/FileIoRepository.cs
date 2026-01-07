using CSVFileIo.Entity;

namespace CSVFileIo.Repository.Implementation
{
    public class FileIoRepository
    {

        public List<Question> questions = new List<Question>();
        string _file = "data.csv";
        public List<Question> ReadDataFromCSV()
        {
            using (StreamReader streamReader = new StreamReader(_file))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] column = line.Split(',');
                    Question question = new Question();
                    question.Id = int.Parse(column[0]);
                    question.Concept = column[1];
                    question.Subject = column[2];
                    question.Title = column[3];
                    question.A = column[4];
                    question.B = column[5];
                    question.C = column[6];
                    question.D = column[7];
                    question.AnswerKey = column[8];
                    question.DifficultyLevel = column[9];
                    question.CreatedBy = column[10];

                    questions.Add(question);
                }
            }
            return questions;
        }
        public bool WriteDataToCSV(List<Question> NewQuestions)
        {
            bool status = false;
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(_file, true))
                {
                    foreach (Question question in NewQuestions)
                    {
                        streamWriter.WriteLine(question.Id + "," + question.Concept + "," + question.Subject + "," + question.Title + "," + question.A + "," + question.B + "," + question.C + "," + question.D + "," + question.AnswerKey + "," + question.DifficultyLevel + "," + question.CreatedBy);
                        status=true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return status;
        }

    }
}