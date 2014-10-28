using System;
using System.Web.Mvc;

namespace KissHiFi.Helpers
{
    public static class ActionImageHelper
    {
        public static MvcHtmlString ActionImage(this HtmlHelper html, string imagePath, string alt, string cssClass,
                                                string action, string controllerName, object routeValues)
        {
            var currentUrl = new UrlHelper(html.ViewContext.RequestContext);
            
            var imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src",currentUrl.Content(imagePath));
            imgTagBuilder.MergeAttribute("alt",alt);
            imgTagBuilder.MergeAttribute("class",cssClass);
            string imgHtml = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            var anchorTagBuilder = new TagBuilder("a");
            anchorTagBuilder.MergeAttribute("href",currentUrl.Action(action, controllerName, routeValues));
            anchorTagBuilder.InnerHtml = imgHtml;
            string anchorHtml = anchorTagBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }
    }
}