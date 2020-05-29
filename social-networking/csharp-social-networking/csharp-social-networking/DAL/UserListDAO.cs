using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace csharp_social_networking.DAL
{
    public class UserListDAO : IUserListDAO
    {
        private string FilePath = "UserList";
        private IFormatter formatter = new BinaryFormatter();

        public string SaveFile(Dictionary<string, User> userList)
        {
            string successMessage = "Save SUCCESSFUL!";
            string failMessage = "Save FAILED!";

            //string jsonString;
            //jsonString = JsonSerializer.Serialize(userList);
            
            try
            {
                using(Stream stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
                {
                    formatter.Serialize(stream, userList);
                }
                //File.WriteAllText(FilePath, jsonString);
                return successMessage;
            }
            catch (Exception e)
            {
                return failMessage;
                throw e;
            }
        }

        public Dictionary<string, User> getUsers()
        {
            Dictionary<string, User> loadedFile = new Dictionary<string, User>();
            try
            {
                using(Stream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    loadedFile = (Dictionary<string, User>)formatter.Deserialize(stream);
                }
                //string jsonString = File.ReadAllText(FilePath);
                //loadedFile = JsonSerializer.Deserialize<(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Failed to load file");
            }
            return loadedFile;
        }
    }
}
