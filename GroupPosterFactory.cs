using System;

namespace SeleniumingIT
{
    internal class GroupPosterFactory
    {
        internal static GroupPoster GetGroupPoster()
        {
            return new GroupPoster(DriverLoad.LoadChromeDriver());
        }
    }
}