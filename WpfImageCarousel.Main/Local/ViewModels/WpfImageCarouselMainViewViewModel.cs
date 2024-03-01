using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using WpfImageCarousel.Support.Local.Helpers;
using WpfImageCarousel.Support.Local.Models;

namespace WpfImageCarousel.Main.Local.ViewModels;

public class WpfImageCarouselMainViewViewModel : ObservableObject
{
    private ImageInfoManager _imageInfoManger;
    private string _imagePath;

    public event PropertyChangingEventHandler? PropertyChanging;

    public string ImagePath 
    {
        get
        {
            return _imagePath;
        }
        set
        {
            _imagePath = value;
            OnPropertyChanged(nameof(ImagePath));
        }
    }

    public WpfImageCarouselMainViewViewModel(ImageInfoManager imageInfoManger)
    {
        _imageInfoManger = imageInfoManger;
        InitialImagePath();
    }

    private void InitialImagePath()
    {
        ImageInfo? imageInfo = _imageInfoManger.NextImage();
        if(imageInfo != null)
        {
            ImagePath = imageInfo.LocalPath;
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }


}
