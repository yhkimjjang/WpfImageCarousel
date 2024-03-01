namespace KimRobote.Wpf.Local.Application;

public class KimRoboteViewModelCollection
{
    public Dictionary<string, Type> ViewModelCollection {  get; init; }

    public KimRoboteViewModelCollection()
    {
        ViewModelCollection = new Dictionary<string, Type>();
    }

    /// <summary>
    /// ViewModel을 View에 매칭시킴
    /// </summary>
    /// <typeparam name="TViewModel">ViewModel</typeparam>
    /// <param name="viewType">View</param>
    public void Register<TViewModel>(Type viewType) where TViewModel : class
    {
        string className = viewType.ToString();
        ViewModelCollection.Add(className, typeof(TViewModel));
    }
}
