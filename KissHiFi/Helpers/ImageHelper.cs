using System;
using System.Web.Mvc;

namespace KissHiFi.Helpers
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper html, string imagePath, string alt)
        {
            var currentUrl = new UrlHelper(html.ViewContext.RequestContext);

            var imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", currentUrl.Content(imagePath));
            imgTagBuilder.MergeAttribute("alt", alt);
            string imgHtml = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            return MvcHtmlString.Create(imgHtml);
        }

        public static MvcHtmlString Image(this HtmlHelper html, string imagePath, string alt, string cssClass)
        {
            var currentUrl = new UrlHelper(html.ViewContext.RequestContext);

            var imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", currentUrl.Content(imagePath));
            imgTagBuilder.MergeAttribute("alt", alt);
            imgTagBuilder.MergeAttribute("class",cssClass);
            string imgHtml = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            return MvcHtmlString.Create(imgHtml);
        }
    }
}