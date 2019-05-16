using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Klarna.Rest.Core.Commuication
{
    internal static class ApiUrlHelper
    {
        public static string GetApiUrlForController(string baseApiUrl, string controller, string append = null,
	        IDictionary<string, object> parameters = null)
        {
            var controllerUri = $"{baseApiUrl.TrimEnd('/')}/{controller.TrimStart('/')}{(!string.IsNullOrEmpty(append) ? $"/{append}" : string.Empty)}";

            if (parameters == null || parameters.Count == 0)
                return controllerUri;

            return $"{controllerUri}{(controllerUri.IndexOf('?') > -1 ? "&" : "?")}{parameters.ToQueryString()}";
        }

        private static string ToQueryString(this IDictionary<string, object> nvc)
        {
            return string.Join("&",
                nvc.Keys.Select(a => a + "=" + nvc[a]));
        }
    }
}
