using Newtonsoft.Json;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Represents the parameters required for logging in using an email address.
/// </summary>
public class LoginEmailRequestModel
{
    /// <summary>
    /// Gets or sets the email address for login.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password for login. The password is automatically hashed using MD5 if not provided as a hashed string.
    /// </summary>
    [JsonProperty("password")]
    public string Password
    { get; set; }
}
