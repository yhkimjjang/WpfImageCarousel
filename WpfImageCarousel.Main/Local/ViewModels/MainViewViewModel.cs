using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Threading;
using WpfImageCarousel.Support.Local.Helpers;
using WpfImageCarousel.Support.Local.Models;

namespace WpfImageCarousel.Main.Local.ViewModels;

public partial class MainViewViewModel : ObservableObject
{
    private ImageInfoManager _imageInfoManger;    
    private RollingTimer _rollingTimer;

    [ObservableProperty]
    private string imagePath;

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="imageInfoManger"></param>
    /// <param name="rollingTimer"></param>
    public MainViewViewModel(ImageInfoManager imageInfoManger, RollingTimer rollingTimer)
    {
        _imageInfoManger = imageInfoManger;
        _rollingTimer = rollingTimer;

        InitialImagePath();
        StartTimer();
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
    /// 이미지 롤링 Timer 시작함
    /// </summary>
    private void StartTimer()
    {
        _rollingTimer.AddRollingTimer(TimeSpan.FromSeconds(10));
        _rollingTimer.AddEventHander(ChangeImageTimer);
        _rollingTimer.Start();
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
