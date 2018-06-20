using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT.Methods
{
    public class fakeSimpleMethods:SimpleMethods
    {

        public bool ValidateGroup(string answer)
        {
            if (answer == "Y") return true;
            return false;
        }
        public string ValidAnswer_Y()
        {
            Console.WriteLine("Is this the group you wanted to post at?[Y/N]");
            string answer = "Y";
            while (!Answers.Contains(answer))
            {
                Console.WriteLine("Invalid Answer! Is this the group you wanted to post at?[Y/N]");
                answer = Console.ReadLine();
            }
            return answer;
        }
        public string ValidAnswer_N()
        {
            Console.WriteLine("Is this the group you wanted to post at?[Y/N]");
            string answer = "N";
            while (!Answers.Contains(answer))
            {
                Console.WriteLine("Invalid Answer! Is this the group you wanted to post at?[Y/N]");
                answer = Console.ReadLine();
            }
            return answer;
        }
        public bool ValidAnswer_Invalid()
        {
            Console.WriteLine("Is this the group you wanted to post at?[Y/N]");
            string answer = "F";
            if (!Answers.Contains(answer))
            {
                return true;
            }
            else return false;
        }
        public string GetPath(string path)
        {
            try
            {
                File.ReadAllText(path);
                return path;
            }
            catch
            {
                Console.WriteLine("Not valid path!");
                return null;
            }
        }
        public new string getGroupName()
        {
            return "X";
        }
        public new int getNumOfGroups()
        {
            return 3;
        }
        public new Group[] SetGroups()
        {
            Group[] groups = new Group[getNumOfGroups()];
            for (int i = 0; i < groups.Length; i++)
            {
                groups[i] = new Group();
                groups[i].name = getGroupName();
            }
            return groups;
        }
    }
}

