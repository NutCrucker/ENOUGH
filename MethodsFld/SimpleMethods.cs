using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT.Methods
{
    public class SimpleMethods
    {
        
        public string[] Answers = { "Y", "N" };
        public bool ValidateGroup()
        {
            string Valid = ValidAnswer();
            if (Valid == "Y") return true;
            return false;
        }
        public string ValidAnswer()
        {
            Console.WriteLine("Is this the group you wanted to post at?[Y/N]");
            string answer = Console.ReadLine();
            while (!Answers.Contains(answer))
            {
                Console.WriteLine("Invalid Answer! Is this the group you wanted to post at?[Y/N]");
                answer = Console.ReadLine();
            }
            return answer;
        }
        public string GetPath()
        {
            Console.WriteLine("Please insert the path of the message you would like to post: ");
            return Console.ReadLine();
        }
        public Group[] SetGroups()
        {
            Group[] groups = new Group[getNumOfGroups()];
            for (int i = 0; i < groups.Length; i++)
            {
                groups[i] = new Group();
                groups[i].name = getGroupName();
            }
            return groups;
        }
        public string getGroupName()
        {
            Console.WriteLine("Please Write the names (can be partial) of the groups you would like to post at: [to press N]");
            return Console.ReadLine();
        }
        public int getNumOfGroups()
        {
            int NumOfGroups;
            Console.WriteLine("In how much groups would you like to post?");
            if (Int32.TryParse(Console.ReadLine(), out NumOfGroups)) { }
            else
            {
                while (!Int32.TryParse(Console.ReadLine(), out NumOfGroups))
                {
                    Console.WriteLine("Invalid Answer, In how much groups would you like to post?");
                }
            }
            return NumOfGroups;
        }
    }
}
