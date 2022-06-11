using System;
using System.Web;
using System.Web.Mvc;

public static class UrlExtensions
{
    public static string Content(this UrlHelper urlHelper, string contentPath, bool toAbsolute = false)
    {
        var path = urlHelper.Content(contentPath);
        Uri url = new Uri(HttpContext.Current.Request.Url, path);

        UriBuilder uriBuilder = new UriBuilder(url.AbsoluteUri);
        uriBuilder.Port = -1;
        uriBuilder.Scheme = "http"; //TO UNCOMMENT
        return toAbsolute ? uriBuilder.Uri.ToString() : path;
    }

    public static string GetSubDomain(this Uri url, bool includeHost = true, GetSubDomainEnum getSubDomainOption = GetSubDomainEnum.ExcludeWWW)
    {
        if (url.HostNameType == UriHostNameType.Dns)
        {
            string host = url.Host;
            if (host.Split('.').Length > 2)
            {
                int lastIndex = host.LastIndexOf(".");
                int index = host.LastIndexOf(".", lastIndex - 1);
                string subdomain = host.Substring(0, index);
                if (getSubDomainOption == GetSubDomainEnum.ExcludeWWW && subdomain.ToLowerInvariant().Equals("www"))
                    return null;

                if (includeHost)
                    return host;

                return subdomain;
            }
        }
        return null;
    }

    public enum GetSubDomainEnum
    {
        ExcludeWWW,
        IncludeWWW
    };

}