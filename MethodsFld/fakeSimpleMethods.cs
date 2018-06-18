using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT.Methods
{
    public class fakeSimpleMethods
    {

        public string[] Answers = { "Y", "N" };
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
                return "";
            }
        }
    }
}

