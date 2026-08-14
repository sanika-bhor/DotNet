// See https://aka.ms/new-console-template for more information

using CSVFileIO.Entity;
using DataHelper.Repository.Implementation;
using DataHelper.Repository.Interface;

Console.WriteLine("Hello, World!");

FileIoRepository<Candidate> fileIoRepository = new FileIoRepository<Candidate>();
FileIoService<Candidate> fileIoService = new FileIoService<Candidate>(fileIoRepository);

List<Candidate> candidates = fileIoService.ReadDataFromCSV("./Data/CSV/users/candidates.csv", columns => new Candidate
{
    Id = int.Parse(columns[0]),
    Name = columns[1],
    Email = columns[2],
    AppliedPosition = columns[3],
    SkillsMatch = int.Parse(columns[4]),
    ExperienceLevel = columns[5],
    AssessmentScore = int.Parse(columns[6]),
    InterviewStatus = columns[7],
    ApplicationDate = DateTime.Parse(columns[8])
});


candidates.Add(new Candidate
{
    Id = 5,
    Name = "Sneha Kulkarni",
    Email = "sneha.kulkarni@transflower.in",
    AppliedPosition = "Software Engineer",
    SkillsMatch = 90,
    ExperienceLevel = "junior",
    AssessmentScore = 87,
    InterviewStatus = "pending",
    ApplicationDate = new DateTime(2026, 3, 25)
});

fileIoService.WriteDataToCSV("./Data/CSV/users/candidates.csv",candidates);
foreach (Candidate candidate in candidates)
{
    Console.WriteLine(candidate.ToString());
}

Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");

// Question newquestion = new Question
// {
//     Id = 3,
//     Concept = "Inheritance",
//     Subject = "C#",
//     Title = "Which keyword is used to inherit a class in C#?",
//     A = "implements",
//     B = "extends",
//     C = ":",
//     D = "inherits",
//     AnswerKey = "C",
//     DifficultyLevel = "Easy",
//     CreatedBy = "Admin"
// };

// List<Question> jsonquestions = fileIoService.ReadDataFromJSON("./Data/");
// jsonquestions.Add(newquestion);
// bool insertJsonQuestion = fileIoService.WriteDataToJSON(jsonquestions);
// if (insertJsonQuestion)
// {
//     Console.WriteLine("Question inserted in json file");
// }
// else
// {
//     Console.WriteLine("Question not inserted in json file");
// }
// foreach (Question question in jsonquestions)
// {
//     Console.WriteLine(question.Id.ToString() + "," + question.Concept + "," + question.Subject + "," + question.Title + "," + question.A + "," + question.B + "," + question.C + "," + question.D + "," + question.AnswerKey + "," + question.DifficultyLevel + "," + question.CreatedBy);
// }
// Console.WriteLine("");


// List<Question> newQuestions = new List<Question>();
// newQuestions.Add(new Question(16, "MainMethod", "C#", "Main method is", "Optional", "Entry point", "Abstract", "Overloaded", "B", "Easy", "Admin"));
// newQuestions.Add(new Question(17, "MainMethod", "C#", "Main method is", "Optional", "Entry point", "Abstract", "Overloaded", "B", "Easy", "Admin"));

// bool status =fileIoService.WriteDataToCSV(newQuestions);
// if(status)
// {
//     Console.WriteLine("questions added to the file");
// }
// else
// {
//     Console.WriteLine("questions not added to the file");
// }


// Console.WriteLine("");
// if(fileIoService.InsertDataInDB())
// {
//     Console.WriteLine("data inserted into the database");
// }
// else
// {
//     Console.WriteLine("something went wrong");
// }



// 