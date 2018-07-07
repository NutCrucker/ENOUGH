using SeleniumingIT.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT
{
    public class Run
    {
        static void Main(string[] args)
        {
            Method method = new Method();

            method.StartPosting(new User());
            System.Windows.Forms.Application.Exit();


            UserInterrogator userInterrogator = new UserInterrogator();

            RunDetails runDetails = userInterrogator.AskUserForDetails();
            GroupPoster groupPoster = GroupPosterFactory.GetGroupPoster();

            //groupPoster.StartPosting(runDetails);

            
        }
    }
}
