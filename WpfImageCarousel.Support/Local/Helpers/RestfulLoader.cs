using System.IO;

namespace WpfImageCarousel.Support.Local.Helpers;

/// <summary>
/// Restful API 방식으로 서버로부터 이미지를 받아오는 기능 수행함
/// </summary>
internal class RestfulLoader : IImageLoder
{
    /// <summary>
    /// Image를 다운로드 받아서 임시 디렉토리에 저장 후 해당 경로 전달
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ValueTask<string> DownloadImagesToStringPathAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Image를 다운로드 받아서 메모리 스트림으로 전달
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<Stream> DownloadImagesToStramAsync()
    {
        throw new NotImplementedException();
    }
}
