using System.IO;
using WpfImageCarousel.Support.Local.Models;

namespace WpfImageCarousel.Support.Local.Helpers;

/// <summary>
/// ImageInfo 관리 기능 수행
/// </summary>
public class ImageInfoManager
{
    private readonly LocalImageLoader _imageLoader;
    private int _imageIndex;
    private IList<ImageInfo>? _imageInfos;
    
    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="imageLoader"></param>
    public ImageInfoManager(LocalImageLoader imageLoader)
    {
        _imageLoader = imageLoader;
        InitialImageRoot().Wait();
        InitImageInfos();
    }

    public int TotalImageCount { get; private set; }

    public string ImageRoot { get; set; }

    /// <summary>
    /// Image Root 초기화
    /// </summary>
    /// <returns></returns>
    private async Task InitialImageRoot()
    {
        ImageRoot = await _imageLoader.DownloadImagesToStringPathAsync();
    }

    /// <summary>
    /// Image 출력 순서를 초기화 시킴
    /// </summary>
    private void InitialImageOrder()
    {
        _imageIndex = -1;
        TotalImageCount = _imageInfos!.Count;
    }

    /// <summary>
    /// ImageInfo 데이터 생성 
    /// </summary>
    public void InitImageInfos() 
    {   
        if (Directory.Exists(ImageRoot) == false)
        {
            Directory.CreateDirectory(ImageRoot);
        }
        
        _imageInfos = Directory.GetFileSystemEntries(ImageRoot)
            .Select(entry => new ImageInfo
            {
                Name = Path.GetFileName(entry),
                Extension = Path.GetExtension(entry),
                LocalPath = entry
            })
            .ToList();

        InitialImageOrder();
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
