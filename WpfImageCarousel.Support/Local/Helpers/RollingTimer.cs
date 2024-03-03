using System.Windows.Threading;

namespace WpfImageCarousel.Support.Local.Helpers;

public class RollingTimer
{
    private DispatcherTimer _timer;

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="interval">인터벌 시간</param>
    public RollingTimer()
    {
        _timer = new DispatcherTimer();
    }

    /// <summary>
    /// 이벤트 시간 등록
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="handler"></param>
    public void AddRollingTimer(TimeSpan interval)
    {
        _timer.Interval = interval;
    }

    /// <summary>
    /// 이벤트 추가
    /// </summary>
    /// <param name="handler"></param>
    public void AddEventHander(EventHandler handler)
    {
        _timer.Tick += handler;
    }

    /// <summary>
    /// Timer Start
    /// </summary>
    public void Start()
    {
        if (_timer.Interval == TimeSpan.Zero)
            throw new ArgumentException("Rolling Timer not Intervla");

        _timer.Start();
    }

    /// <summary>
    /// Timer Stop
    /// </summary>
    public void Stop()
    {
        _timer.Stop();
    }
}
