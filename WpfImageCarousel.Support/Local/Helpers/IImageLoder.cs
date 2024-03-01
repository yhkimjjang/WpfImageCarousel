using System.IO;

namespace WpfImageCarousel.Support.Local.Helpers;

public interface IImageLoder
{
    /// <summary>
    /// Image를 다운로드 받아서 임시 디렉토리에 저장 후 해당 경로 전달
    /// </summary>
    /// <returns></returns>
    ValueTask<string> DownloadImagesToStringPathAsync();

    /// <summary>
    /// Image를 다운로드 받아서 메모리 스트림으로 전달
    /// </summary>
    /// <returns></returns>
    Task<Stream> DownloadImagesToStramAsync();
}
