using System.Windows;
using System.Windows.Controls;

namespace KimRobote.Wpf.UI.Units
{
    public class KimRoboteImage : Control
    {
        static KimRoboteImage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KimRoboteImage), new FrameworkPropertyMetadata(typeof(KimRoboteImage)));
        }
    }
}
