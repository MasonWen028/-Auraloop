using Microsoft.AspNetCore.Http;

/// <summary>
/// when upload by cloud through form-data
/// </summary>
public class SongUploadRequestModel
{
    /// <summary>
    /// The music file to be uploaded.
    /// </summary>
    public IFormFile SongFile { get; set; }
}
