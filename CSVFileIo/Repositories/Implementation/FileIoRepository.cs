using System.Data;
using System.Data.Common;
using CSVFileIo.Entity;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;

namespace CSVFileIo.Repository.Implementation
{
    public class FileIoRepository
    {

        public List<Question> questions = new List<Question>();
        string _file = "data.csv";
        public List<Question> ReadDataFromCSV()
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
                        status = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return status;
        }


        public int GetSubjectId(string subjectName)
        {
            int subjectId = 0;
            string connectionCommand = @"server=localhost;port=3306;user=root;password=password;database=AssessmentDB";
            MySqlConnection dbConnection = new MySqlConnection();
            MySqlCommand dbCommandcmd = new MySqlCommand();
            dbConnection.ConnectionString = connectionCommand;
            dbCommandcmd.Connection = dbConnection;
            dbConnection.Open();

            dbCommandcmd.Parameters.Clear();
            string subjectIdQuery = "select id from subjects where title=@subjectName";
            dbCommandcmd.CommandText = subjectIdQuery;
            dbCommandcmd.Parameters.AddWithValue("@subjectName", subjectName);
            using (IDataReader idReader = dbCommandcmd.ExecuteReader())
            {
                idReader.Read();

                subjectId = int.Parse(idReader["id"].ToString());
                if (subjectId <= 0)
                {
                    throw new Exception("Subject not found");
                }
               
            }
            return subjectId;
        }

        public int GetConceptId(String conceptName)
        {
            int conceptId = 0;
            string connectionCommand = @"server=localhost;port=3306;user=root;password=password;database=AssessmentDB";
            MySqlConnection dbConnection = new MySqlConnection();
            MySqlCommand dbCommandcmd = new MySqlCommand();
            dbConnection.ConnectionString = connectionCommand;
            dbCommandcmd.Connection = dbConnection;
            dbConnection.Open();

            //conceptid
            dbCommandcmd.Parameters.Clear();
            string conceptIdQuery = "select id from concepts where title=@conceptName";
            dbCommandcmd.CommandText = conceptIdQuery;
            dbCommandcmd.Parameters.AddWithValue("conceptName", conceptName);
            using (IDataReader idReader = dbCommandcmd.ExecuteReader())
            {
                idReader.Read();
                conceptId = int.Parse(idReader["id"].ToString());
                if (conceptId <= 0)
                {
                    throw new Exception("Concept not found");
                }
            }
            return conceptId;
        }

        
        public bool InsertDataInDB()
        {

            int subjectId = 0;
            int conceptId = 0;
            bool status = false;
            try
            {
                string connectionCommand = @"server=localhost;port=3306;user=root;password=password;database=AssessmentDB";
                MySqlConnection dbConnection = new MySqlConnection();
                MySqlCommand dbCommandcmd = new MySqlCommand();

                dbConnection.ConnectionString = connectionCommand;
                dbCommandcmd.Connection = dbConnection;
                dbConnection.Open();

                foreach (Question insertquestion in questions)
                {
                    subjectId=GetSubjectId(insertquestion.Subject);
                    conceptId=GetConceptId(insertquestion.Concept);

                    Console.WriteLine("" + insertquestion.Title);
                    Console.WriteLine("subject id: " + subjectId);
                    Console.WriteLine("Concept id: " + conceptId);
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