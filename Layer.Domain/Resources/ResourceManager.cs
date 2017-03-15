using System.Text.RegularExpressions;

namespace Layer.Domain.Resources
{
    public static class ResourceManager
    {
        public static string GetString(string resourceKey, params object[] formatParams)
        {
            if (string.IsNullOrEmpty(resourceKey)) return "";
            var resourceString = AppResource.ResourceManager.GetString(resourceKey);
            var result = resourceString != null ? (formatParams.Length > 0 ? string.Format(resourceString, formatParams) : resourceString) : resourceKey;
            return new Regex("{\\d+}").Replace(result, "");
        }
    }
}
