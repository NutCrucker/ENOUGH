using SeleniumingIT.Methods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT.Objects
{
    public class Post
    {
        public string path { get; set; }
        public Group[] groups { get; set; }
        private SimpleMethods method = new SimpleMethods();
        public void Build(string path, Group[] groups)
        {
            this.path = path;
            this.groups = groups;
        }
        public void init()
        {
            setPath();
            setGroups();
        }
        public string TestPath(string path)
        {
            try
            {
                File.ReadAllText(path);
                return path;
            }
            catch
            {
                throw new Exception("Incorrect path");
            }
        }
        public void setPath()
        {
            Console.WriteLine("Please insert the path of the message you would like to post: ");
            path = Console.ReadLine();
            try
            {
                File.ReadAllText(path);
            }
            catch
            {
                Console.WriteLine("Not a valid path!");
                setPath();
            }
        }
        public void setGroups()
        {
            groups = method.SetGroups();
        }
    }
}
