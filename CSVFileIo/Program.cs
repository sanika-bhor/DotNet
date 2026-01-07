// See https://aka.ms/new-console-template for more information
using CSVFileIo.Entity;
using CSVFileIo.Repository.Implementation;
using CSVFileIo.Repository.Interface;

Console.WriteLine("Hello, World!");

FileIoRepository fileIoRepository = new FileIoRepository();
FileIoService fileIoService= new FileIoService(fileIoRepository);
List<Question> questions =fileIoService.ReadDataFromCSV();
foreach(Question question in questions)
{
    Console.WriteLine(question.Id.ToString()+","+question.Concept + "," + question.Subject + "," + question.Title + "," + question.A + "," + question.B + "," + question.C + "," + question.D + "," + question.AnswerKey + "," + question.DifficultyLevel + "," + question.CreatedBy);
}
