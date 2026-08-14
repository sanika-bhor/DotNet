using System.Data;
using System.Data.Common;
using System.Text.Json;
using DataHelper.Repository.Interface;


namespace DataHelper.Repository.Implementation
{
    public class FileIoRepository<T> : IFileIoRepository<T>
    {

        public List<T> data = new List<T>();
        // string _file = "data.csv";
        public List<T> ReadDataFromCSV(string _file, Func<string[], T> createObject)
        {
            data.Clear(); // start fresh
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

                    T newObj = createObject(columns.ToArray());

                    data.Add(newObj);
                }
            }

            return data;
        }
        // public bool WriteDataToCSV(string _file,List<T> tObj)
        // {
        //     bool status = false;
        //     try
        //     {
        //         using (StreamWriter streamWriter = new StreamWriter(_file, true))
        //         {
        //             foreach (T obj in tObj)
        //             {
        //                 streamWriter.WriteLine(obj.ToString());
        //                 status = true;
        //             }
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e.Message);
        //     }
        //     return status;
        // }


        public bool WriteDataToCSV(
                   string file,
                   List<T> tobj)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(file, false))
                {
                    foreach (T obj in tobj)
                    {
                        streamWriter.WriteLine(obj?.ToString());
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool WriteDataToJSON(string _file, List<T> t)
        {
            try
            {
                string json = JsonSerializer.Serialize(t);

                File.WriteAllText(_file, json);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<T> ReadDataFromJSON(string _file)
        {
            string json = File.ReadAllText(_file);

            List<T> tobj =
                JsonSerializer.Deserialize<List<T>>(json);

            return tobj;
        }


    }
}