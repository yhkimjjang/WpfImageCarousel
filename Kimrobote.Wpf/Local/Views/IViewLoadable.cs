namespace Kimrobote.Wpf.Local.Views;

/// <summary>
/// Window OnLoad 이벤트에 대한 처리 인터페이스
/// </summary>
public interface IViewLoadable
{
    void OnLoaded(IViewable view);
}
