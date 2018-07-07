using System;

namespace SeleniumingIT
{
    internal class GroupPoster
    {
        BrowserUtil browserUtil = new BrowserUtil();
        FacebookUtil facebookUtil = new FacebookUtil();

        internal void StartPosting(RunDetails runDetails)
        {
            browserUtil.EnterFacebook();
            facebookUtil.LoginToAccount();
            facebookUtil.SearchForGroup();
            facebookUtil.EnterGroup();
            facebookUtil.PostMessage();

            if (!facebookUtil.IsPostSucceeded())
            {
                throw new PostingFaildException();
            }
        }

    }
}