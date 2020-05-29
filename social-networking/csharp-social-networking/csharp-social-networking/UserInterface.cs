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
        private UserListDAO userList = new UserListDAO();

        public void start()
        {
            Users = userList.getUsers();
            if (Users.Count == 0)
            {
                IUserListDAO mockUsers = new MockUserDAO(); //No way of creating new users, so initial run must include basic users.
                Users = mockUsers.getUsers();
            }

            string userInput = "";
            Console.WriteLine(GREETING);
            Console.WriteLine(HELP + "\n");
            bool isExit = false;
            do
            {
                Console.Write("> ");
                userInput = Console.ReadLine();
                try
                {
                    if (userInput.ToLower() == "exit")
                    {
                        isExit = true;
                    }
                    else if (userInput.ToLower() == "help")
                    {
                        printList(getHelpTerms());
                        Console.WriteLine();
                    }
                    else if (userInput.ToLower() == "save")
                    {
                        Console.WriteLine(userList.SaveFile(Users));
                    }
                    else if (userInput.ToLower() == "list")
                    {
                        displayUsers();
                    }
                    else
                    {
                        printList(commandParser(userInput));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("There is something wrong with your input. Please try again.");
                }

            }
            while (!isExit);
        }

        public List<string> commandParser(string inputString)
        {
            List<string> displayList = new List<string>();
            if (inputString != null && inputString != "")
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
                }
                else if (splitInputString.Contains("create"))
                {
                    User newUser = new User(username);
                    Users.Add(username, newUser);
                    displayList.Add($"{username} successfully created.");
                }
                else
                {
                    Console.WriteLine("That user could not be found. Here's the current list of users:");
                    displayUsers();
                    displayList.Add("Please choose a valid user");
                }
            }
            return displayList;
        }

        private List<String> getHelpTerms()
        {
            string POSTING = String.Format("{0,-25} : {1}", "TO POST A MESSAGE", "<user-name> -> <message>");
            string READING = String.Format("{0,-25} : {1}", "TO READ USER MESSAGES", "<user-name>");
            string FOLLOWING = String.Format("{0,-25} : {1}", "TO FOLLOW ANOTHER USER", "<user-name> follows <another-user>");
            string WALL = String.Format("{0,-25} : {1}", "TO VIEW USER WALL", "<user-name> wall");
            string SAVE = String.Format("{0,-25} : {1}", "TO SAVE ALL", "save");
            string CREATE = String.Format("{0,-25} : {1}", "TO CREATE NEW USER", "<user-name> create");
            string LIST = String.Format("{0,-25} : {1}", "TO LIST ALL USERS", "list");

            List<string> helpTerms = new List<string>()
            {
                POSTING,
                READING,
                FOLLOWING,
                WALL,
                CREATE,
                LIST,
                SAVE
            };
            return helpTerms;
        }

        private void displayUsers()
        {
            foreach (KeyValuePair<string, User> entry in Users)
            {
                Console.WriteLine((entry.Key));
            }
            Console.WriteLine();
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
