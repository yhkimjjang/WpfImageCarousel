using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace KimRobote.Wpf.UI.Units;

/// <summary>
/// Region Control
/// </summary>
public class KimRoboteRegion : ContentControl
{
    /// <summary>
    /// Region Name을 입력 받을 수 있는 프로퍼티 생성
    /// </summary>
    public static DependencyProperty RegionNameProperty = DependencyProperty.Register(nameof(RegionName),
        typeof(string), typeof(KimRoboteRegion), new PropertyMetadata(ContentNamePropertyChanged));

    /// <summary>
    /// Region Name이 변경될 때 Region을 등록
    /// </summary>
    /// <param name="d"></param>
    /// <param name="e"></param>
    private static void ContentNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if(e.NewValue is string str && str != string.Empty)
        {
            IRegionManager rm = RegionManager.GetRegionManager(Application.Current.MainWindow);
            RegionManager.SetRegionName((KimRoboteRegion)d, str);
            RegionManager.SetRegionManager(d, rm);
        }
    }

    public string RegionName
    {
        get => (string)GetValue(RegionNameProperty);
        set => SetValue(RegionNameProperty, value);
    }

    static KimRoboteRegion()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(KimRoboteRegion), new FrameworkPropertyMetadata(typeof(KimRoboteRegion)));
    }

    public KimRoboteRegion() { }
}
