using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT.Objects
{
    public class FakeUser:User
    {
        public new FakePost post { get; set; }
        
        public void Init(string email, string password, string path)
        {
            setEmail(email);
            setPass(password);
            setPost(path);
        }
        public void setEmail(string email)
        {
            Console.WriteLine("Please insert your Email: ");
            this.email = email;
        }
        public void setPass(string pass)
        {
            Console.WriteLine("Please insert your Password: ");
            password = pass;
        }
        public void setPost(string path)
        {
            post = new FakePost();
            post.Init(path);
        }
        public new Group[] Groups()
        {
            return post.groups;
        }

    }
}
