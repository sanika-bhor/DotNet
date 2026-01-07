using CSVFileIo.Entity;

namespace CSVFileIo.Repository.Implementation
{
    public class FileIoRepository
    {

        public List<Question> questions = new List<Question>();
        string _file = "data.csv";public List<Question> ReadDataFromCSV()
{
    questions.Clear(); // start fresh
    using (StreamReader streamReader = new StreamReader(_file))
    {
        string line;

       
     
        while ((line = streamReader.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            // Split on comma, but handle Title in quotes
            List<string> columns = new List<string>();
            bool insideQuotes = false;
            string current = "";

            foreach (char c in line)
            {
                if (c == '"')
                {
                    insideQuotes = !insideQuotes; // toggle
                }
                else if (c == ',' && !insideQuotes)
                {
                    columns.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }
            columns.Add(current); // add last column

            if (columns.Count < 11)
                continue; // skip malformed lines

            Question question = new Question
            {
                Id = int.Parse(columns[0]),
                Concept = columns[1],
                Subject = columns[2],
                Title = columns[3], // Title without quotes
                A = columns[4],
                B = columns[5],
                C = columns[6],
                D = columns[7],
                AnswerKey = columns[8],
                DifficultyLevel = columns[9],
                CreatedBy = columns[10]
            };

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
                        streamWriter.WriteLine(question.Id + "," + question.Concept + "," + question.Subject + "," + "\"" + question.Title + "\"," + question.A + "," + question.B + "," + question.C + "," + question.D + "," + question.AnswerKey + "," + question.DifficultyLevel + "," + question.CreatedBy);
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