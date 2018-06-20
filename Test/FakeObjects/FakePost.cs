using SeleniumingIT.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT.Objects
{
    public class FakePost:Post
    {
        private fakeSimpleMethods method = new fakeSimpleMethods();
        public void Init(string path)
        {
            setPath(path);
            setGroups();
        }
        public void setPath(string path)
        {
            this.path = method.GetPath(path);
        }
        public new void setGroups()
        {
            groups = method.SetGroups();
        }
    }
}
