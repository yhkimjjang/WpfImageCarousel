using System.Windows;
using System.Windows.Controls;

namespace KimRobote.Wpf.UI.Units
{
    public class KimRoboteButton : Button
    {
        static KimRoboteButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KimRoboteButton), new FrameworkPropertyMetadata(typeof(KimRoboteButton)));
        }
    }
}
