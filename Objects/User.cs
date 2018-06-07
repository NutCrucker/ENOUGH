using SeleniumingIT.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT
{
    public class User
    {
        public string email { get; set; }
        public string password { get; set; }
        public Post post { get; set; }
        private Method method = new Method();

        public void Init()
        {
            setEmail();
            setPass();
            setPost();
        }
        public void setEmail()
        {
            Console.WriteLine("Please insert your Email: ");
            email = Console.ReadLine();
        }
        public void setPass()
        {
            Console.WriteLine("Please insert your Password: ");
            password = Console.ReadLine();
        }
        public void setPost()
        {
            post = new Post();
            post.Init();
        }
        public Group[] Groups()
        {
            return post.groups;
        }
    }
}
