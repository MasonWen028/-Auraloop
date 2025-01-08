
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public class AvatarUploadRequestModel
{
    public IFormFile ImageData { get; set; }
}
