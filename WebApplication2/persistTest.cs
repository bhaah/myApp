using System.IO;
using WebApplication2.LogicLayer;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication2
{
    public class persistTest
    {
        private string path;
        private string connectionString;
        public persistTest()
        {
            path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "stamDataBase.db"));
            connectionString = $"Data Source={path}; Version=3; ";
        }
        private void convertValToPar(SQLiteCommand command, string valuestring, object par)
        {
            SQLiteParameter param = new SQLiteParameter(valuestring, par);
            command.Parameters.Add(param);
        }
        public void persist(int number)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                int res = -1;

                try
                {
                    command.CommandText = $"INSERT INTO stam (col) VALUES ( @numVal ) ";

                    convertValToPar(command, @"numVal", number);

                    connection.Open();
                    command.Prepare();
                    res = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(command.CommandText);
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
        }
    }
}
