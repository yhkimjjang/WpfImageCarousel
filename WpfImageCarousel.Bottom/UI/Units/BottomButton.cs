using System.Windows;
using System.Windows.Controls;

namespace WpfImageCarousel.Bottom.UI.Units
{
    public class BottomButton : Button
    {
        static BottomButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BottomButton), new FrameworkPropertyMetadata(typeof(BottomButton)));
        }
    }
}
