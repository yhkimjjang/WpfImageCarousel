using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Events;
using WpfImageCarousel.Support.Events;
using WpfImageCarousel.Support.Local.Helpers;
using WpfImageCarousel.Support.Local.Models;

namespace WpfImageCarousel.Main.Local.ViewModels;

public partial class MainViewViewModel : ObservableObject
{
    private ImageInfoManager _imageInfoManger;

    [ObservableProperty]
    private string imagePath;

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="imageInfoManger"></param>
    /// <param name="ea"></param>
    public MainViewViewModel(ImageInfoManager imageInfoManger, IEventAggregator ea)
    {
        _imageInfoManger = imageInfoManger;
        InitialImagePath();

        // EventAgreator가 전달하는 이벤트 Subscribe
        ea.GetEvent<ImageChangedEvent>().Subscribe(ChangeImagePath);
        ea.GetEvent<ImageDirectoryChangedEvent>().Subscribe(ChangeDirectoryPath);
    }

    /// <summary>
    /// 이미지 디렉토리를 변경 했을 때 이벤트 처리
    /// </summary>
    /// <param name="root"></param>
    private void ChangeDirectoryPath(string root)
    {
        _imageInfoManger.ImageRoot = root;
        _imageInfoManger.InitImageInfos();
        InitialImagePath();
    }

    /// <summary>
    /// 초기 이미지 정보 조회
    /// </summary>
    private void InitialImagePath()
    {
        ImageInfo? imageInfo = _imageInfoManger.NextImage();
        if (imageInfo != null)
        {
            ImagePath = imageInfo.LocalPath;
        }
    }

    /// <summary>
    /// 이미지 번경 이벤트 처리
    /// </summary>
    void ChangeImagePath()
    {
        ImageInfo? imageInfo = _imageInfoManger.NextImage();
        if (imageInfo != null)
        {
            ImagePath = imageInfo.LocalPath;
        }
    }
}
