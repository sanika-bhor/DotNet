using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using Model.Catalog;
using System.Text.Json;

namespace FileManager.FileOperation
{
    public class FileOperation
    {
        public List<Product> products=new List<Product>();
        public void SaveDataToFile( string filename)
        {
            products=[
                new Product (1,"Product1","cardfgsm",10.2,20 ),
                new Product (2,"Product2","cardfgsm",10.2,20 )
            ];
            FileStream stream=new FileStream(filename, FileMode.OpenOrCreate);

            JsonSerializer.Serialize(stream,products);
            // BinaryWriter binaryWriter=new BinaryWriter(stream);
            // BinaryFormatter formatter = new BinaryFormatter();
            // formatter.Serialize(stream, products);
            stream.Close();
        }

        public List<Product> GetDataFromFile(string filename)
        {
            FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);

            // products=JsonSerializer.Deserialize<List<Product>>(stream);
            // BinaryReader binaryReader = new BinaryReader(stream);
            // // read the data from the stream
            // string data = binaryReader.ReadString();
            // binaryReader.Close();
            // stream.Close();
            return products;
            // BinaryFormatter bf=new BinaryFormatter();
            // bf.Serialize(stream);
        }
    }
}