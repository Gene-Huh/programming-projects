using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_social_networking
{
    class UserInterface
    {
        private string GREETING = "Welcome to the Social Network";
        private string HELP = "Type HELP for instructions. EXIT to quit.";

        public void start()
        {
            string userInput = "";
            Console.WriteLine(GREETING);
            Console.WriteLine(HELP);
            userInput = Console.ReadLine();
            while (userInput.ToLower() != "exit")
            {
                commandParser(userInput);
                userInput = Console.ReadLine();
            }
        }

        public void commandParser(string cmd)
        {
            if (cmd == "help")
            {
                help();
            }
        }

        private void help()
        {
            string POSTING = String.Format("{0,-25} : {1}", "TO POST A MESSAGE", "<user-name> -> <message>");
            string READING = String.Format("{0,-25} : {1}", "TO READ USER MESSAGES", "<user-name>");
            string FOLLOWING = String.Format("{0,-25} : {1}", "TO FOLLOW ANOTHER USER", "<user-name> follows <another-user>");
            string WALL = String.Format("{0,-25} : {1}", "TO VIEW USER WALL", "<user-name> wall");

            List<string> helpTerms = new List<string>()
            {
                POSTING,
                READING,
                FOLLOWING,
                WALL
            };

            foreach (string item in helpTerms)
            {
                Console.WriteLine(item);
            }

        }


    }
}
