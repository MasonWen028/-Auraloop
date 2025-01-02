namespace NeteaseCloudMusicApi_SDK.Models.Dtos
{
    public class ApiResponse
    {
        public int status { get; set; }

        public object data { get; set; }

        public string[] cookie { get; set; }
    }
}
