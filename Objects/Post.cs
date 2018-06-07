using SeleniumingIT.Methods;
using System;
using System.Collections.Generic;
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
        public void Init()
        {
            setPath();
            setGroups();
        }
        public void setPath()
        {
            path = method.GetPath();
        }
        public void setGroups()
        {
            groups = method.SetGroups();
        }
    }
}
