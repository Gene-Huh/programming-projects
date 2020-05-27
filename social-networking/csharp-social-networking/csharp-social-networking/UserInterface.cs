using csharp_social_networking.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_social_networking
{
    class UserInterface
    {
        private string GREETING = "Welcome to the Social Network";
        private string HELP = "Type HELP for instructions. EXIT to quit.";
        private Dictionary<string, User> Users;

        public void start()
        {
            UserListDAO userList = new UserListDAO();
            Users = userList.getUsers();

            string userInput = "";
            Console.WriteLine(GREETING);
            Console.WriteLine(HELP);
            userInput = Console.ReadLine();
            while (userInput.ToLower() != "exit")
            {
                printList(commandParser(userInput));
                userInput = Console.ReadLine();
            }
        }

        public List<string> commandParser(string inputString)
        {
            List<string> displayList = new List<string>();
            if (inputString.ToLower() == "help")
            {
                displayList = getHelpTerms();
            }
            else if (inputString != null || inputString != "")
            {
                List<string> splitInputString = new List<string>(inputString.Split(' '));
                string username = splitInputString[0];
                if (Users.TryGetValue(username, out User user))
                {
                    if (splitInputString.Count == 1)
                    {
                        displayList = user.getUserMessages();
                    }
                    else if (splitInputString.Contains("->"))
                    {
                        StringBuilder postText = new StringBuilder();
                        postText.AppendJoin(' ', splitInputString.GetRange(2, splitInputString.Count - 2));

                        user.postMessage(postText.ToString());
                        displayList.Add($"{username} POSTED {postText.ToString()}");
                    }
                    else if (splitInputString[1] == "wall")
                    {
                        // call getWall method
                    }
                    else if (splitInputString[1].ToLower() == "follows")
                    {
                        // call setFollowingUser
                    }
                    //user list method logic
                }


            };

            return displayList;
        }

        private List<String> getHelpTerms()
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
            return helpTerms;
        }

        private void printList(List<string> listToPrint)
        {
            if (listToPrint.Count != 0 || listToPrint != null)
            {
                foreach (string item in listToPrint)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Nothing to display");
            }
        }

    }
}
