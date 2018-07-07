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
        public string Email { get; set; }
        public string Password { get; set; }
        public Post Post { get; set; }
        private Method method = new Method();
        public void Build(string email,string password,Post post)
        {
            this.Email = email;
            this.Password = password;
            this.Post = post;
        }
        public void Init()
        {
            SetEmail();
            SetPass();
            SetPost();
        }
        public void SetEmail()
        {
            Console.WriteLine("Please insert your Email: ");
            Email = Console.ReadLine();
        }
        public void SetPass()
        {
            Console.WriteLine("Please insert your Password: ");
            Password = Console.ReadLine();
        }
        public void SetPost()
        {
            Post = new Post();
            Post.init();
        }
    }
}
