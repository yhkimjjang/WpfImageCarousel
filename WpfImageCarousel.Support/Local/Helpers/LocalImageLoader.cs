using System.IO;
using WpfImageCarousel.Support.Enums;

namespace WpfImageCarousel.Support.Local.Helpers;

/// <summary>
/// PC에 저장되어 있는 Image를 로드하는 기능 수행
/// </summary>
public class LocalImageLoader : IImageLoder
{
    private readonly string _root = "";

    public LocalImageLoader()
    {
        _root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    }

    /// <summary>
    /// Image를 다운로드 받아서 임시 디렉토리에 저장 후 해당 경로 전달
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ValueTask<string> DownloadImagesToStringPathAsync()
    {
        return ValueTask.FromResult(Path.Combine(_root, FolderNames.WpfImageCarousel.ToString()));
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
