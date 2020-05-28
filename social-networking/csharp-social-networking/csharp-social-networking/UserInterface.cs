using csharp_social_networking.DAL;
using csharp_social_networking.Models;
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
            Console.WriteLine(HELP + "\r\n");
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
            if (inputString != null || inputString != "")
            {
                if (inputString.ToLower() == "help")
                {
                    displayList = getHelpTerms();
                }
                else
                {
                    List<string> splitInputString = new List<string>(inputString.Trim().Split(' '));
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
                            if (splitInputString.Count > 3)
                            {
                                postText.AppendJoin(' ', splitInputString.GetRange(2, splitInputString.Count - 2));
                            }
                            displayList.Add(user.postMessage(postText.ToString()));
                        }
                        else if (splitInputString[1] == "wall")
                        {
                            displayList = user.getWall();
                        }
                        else if (splitInputString[1].ToLower() == "follows")
                        {
                            if (Users.TryGetValue(splitInputString[2], out User followedUser))
                            {
                                displayList.Add(user.followUser(followedUser));
                            }
                            else
                            {
                                Console.WriteLine("User you want to follow does not exist or you typed it incorrectly.");
                            };

                        }
                        //user list method logic
                    }
                    else
                    {
                        displayList.Add("That user could not be found");
                    }
                };
            }
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
            if (listToPrint.Count != 0 && listToPrint != null)
            {
                foreach (string item in listToPrint)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Try typing a valid command. HELP for a list of commands");
            }
        }

    }
}
