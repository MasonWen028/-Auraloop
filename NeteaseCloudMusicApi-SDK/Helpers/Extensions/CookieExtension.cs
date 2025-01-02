using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

public static class CookieExtension
{
    /// <summary>
    /// Converts request cookies into a dictionary.
    /// </summary>
    /// <param name="httpContextAccessor">The IHttpContextAccessor instance.</param>
    /// <returns>A dictionary of cookie key-value pairs.</returns>
    public static Dictionary<string, string> GetCookiesAsDictionary(this IHttpContextAccessor httpContextAccessor)
    {
        var cookies = httpContextAccessor.HttpContext?.Request.Cookies;
        return cookies?.ToDictionary(cookie => cookie.Key, cookie => cookie.Value) ?? new Dictionary<string, string>();
    }

    /// <summary>
    /// Converts request cookies into a serialized string.
    /// </summary>
    /// <param name="httpContextAccessor">The IHttpContextAccessor instance.</param>
    /// <returns>A string representation of cookies in "key=value" format.</returns>
    public static string GetCookiesAsString(this IHttpContextAccessor httpContextAccessor)
    {
        var cookieDictionary = httpContextAccessor.GetCookiesAsDictionary();
        return string.Join("; ", cookieDictionary.Select(kvp => $"{kvp.Key}={kvp.Value}"));
    }
}
