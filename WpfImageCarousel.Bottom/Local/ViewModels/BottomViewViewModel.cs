using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using Prism.Events;
using System.Windows;
using WpfImageCarousel.Support.Events;
using WpfImageCarousel.Support.Local.Helpers;

namespace WpfImageCarousel.Bottom.Local.ViewModels;

public partial class BottomViewViewModel
{
    private readonly RollingTimer _rollingTimer;
    private readonly IEventAggregator _eventAggregator;

    public BottomViewViewModel(RollingTimer rollingTimer, IEventAggregator ea)
    {
        _rollingTimer = rollingTimer;
        _eventAggregator = ea;

        InitialRollingTimer();
    }

    /// <summary>
    /// Rolling Timer 세팅
    /// </summary>
    private void InitialRollingTimer()
    {
        _rollingTimer.AddRollingTimer(TimeSpan.FromSeconds(5));
        _rollingTimer.AddEventHander(TickRollingTimer);
    }

    /// <summary>
    /// Timer 이벤트
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TickRollingTimer(object? sender, EventArgs e)
    {
        _eventAggregator.GetEvent<ImageChangedEvent>().Publish();
    }

    /// <summary>
    /// Start Buton 이벤트 처리
    /// </summary>
    [RelayCommand]
    private void StartRollingTimer()
    {
        _rollingTimer.Start();
    }

    /// <summary>
    /// Stop Button 이벤트 처리
    /// </summary>
    [RelayCommand]
    private void StopRollingTimer()
    {
        _rollingTimer.Stop();
    }

    /// <summary>
    /// 폴더 선택 이벤트 처리
    /// <br/> 폴더를 선택시 폴더명을 Publish 함.
    /// </summary>
    [RelayCommand]
    private void SearchLocalImageFolder()
    {
        var dialog = new OpenFolderDialog();
        var result = dialog.ShowDialog();
        if(result == true)
        {
            string name = dialog.FolderName;
            _eventAggregator.GetEvent<ImageDirectoryChangedEvent>().Publish(name);
        }
    }

    /// <summary>
    /// 다운로드 이벤트 처리
    /// </summary>
    [RelayCommand]
    private void DownloadImage()
    {
        Console.WriteLine("Download Image");
    }

    /// <summary>
    /// Application 종료
    /// </summary>
    [RelayCommand]
    private void CloseWindow()
    {
        var result = MessageBox.Show("종료 하시겠습니까?", "종료", MessageBoxButton.OKCancel);
        if (result == MessageBoxResult.OK) 
        {
            Application.Current.Shutdown();
        }
    }
}
