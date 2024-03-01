using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Threading;
using WpfImageCarousel.Support.Local.Helpers;
using WpfImageCarousel.Support.Local.Models;

namespace WpfImageCarousel.Main.Local.ViewModels;

public partial class WpfImageCarouselMainViewViewModel : ObservableObject
{
    private ImageInfoManager _imageInfoManger;    
    private DispatcherTimer _timer;

    [ObservableProperty]
    private string imagePath;

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="imageInfoManger"></param>
    public WpfImageCarouselMainViewViewModel(ImageInfoManager imageInfoManger)
    {
        _imageInfoManger = imageInfoManger;
        InitialImagePath();
        InitialTimer();
    }

    /// <summary>
    /// 초기 이미지 정보 조회
    /// </summary>
    private void InitialImagePath()
    {
        ImageInfo? imageInfo = _imageInfoManger.NextImage();
        if(imageInfo != null)
        {
            ImagePath = imageInfo.LocalPath;
        }
    }

    /// <summary>
    /// Timer 초기화
    /// </summary>
    private void InitialTimer()
    {
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(20);
        _timer.Tick += ChangeImageTimer;
        _timer.Start();
    }

    /// <summary>
    /// Timer의 인터벌 시간이 되면 이미지를 변경함
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ChangeImageTimer(object? sender, EventArgs e)
    {
        ImageInfo? imageInfo = _imageInfoManger.NextImage();
        if (imageInfo != null)
        {
            ImagePath = imageInfo.LocalPath;
        }
    }
}
