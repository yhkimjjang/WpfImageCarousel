using System.IO;
using WpfImageCarousel.Support.Local.Models;

namespace WpfImageCarousel.Support.Local.Helpers;

/// <summary>
/// ImageInfo 관리 기능 수행
/// </summary>
public class ImageInfoManager
{
    private readonly LocalImageLoader _imageLoader;
    private IList<ImageInfo>? _imageInfos;
    private int _imageIndex;
    
    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="imageLoader"></param>
    public ImageInfoManager(LocalImageLoader imageLoader)
    {
        _imageLoader = imageLoader;
        InitImageInfos().Wait();

        _imageIndex = -1;
        TotalImageCount = _imageInfos!.Count;
    }

    public int TotalImageCount { get; init; }

    /// <summary>
    /// ImageInfo 데이터들을 만듬
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private async Task InitImageInfos() 
    {
        string imageRoot = await _imageLoader.DownloadImagesToStringPathAsync();
        if (Directory.Exists(imageRoot) == false)
        {
            Directory.CreateDirectory(imageRoot);
        }
        
        _imageInfos = Directory.GetFileSystemEntries(imageRoot)
            .Select(entry => new ImageInfo
            {
                Name = Path.GetFileName(entry),
                Extension = Path.GetExtension(entry),
                LocalPath = entry
            })
            .ToList();
    }

    /// <summary>
    /// 다음 이미지를 요청함.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ImageInfo? NextImage() 
    {
        if (TotalImageCount == 0 && _imageIndex == -1)
            return null;

        _imageIndex += 1;

        if(_imageIndex == TotalImageCount)
            _imageIndex = 0;

        return _imageInfos![_imageIndex];
    }

    /// <summary>
    /// 이전 이미지를 요청함.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ImageInfo? PrevImage()
    {
        if (TotalImageCount == 0 && _imageIndex == -1)
            return null;

        _imageIndex -= 1;

        if (_imageIndex < 0)
            _imageIndex = TotalImageCount - 1;

        return _imageInfos![_imageIndex];
    }
}
