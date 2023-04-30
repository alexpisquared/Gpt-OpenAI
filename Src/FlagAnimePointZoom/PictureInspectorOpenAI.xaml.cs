using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1;

public partial class PictureInspectorOpenAI : UserControl
{

  public PictureInspectorOpenAI() => InitializeComponent();

  double _scale = 1.0;
  void ZoomablePicture_MouseWheel(object sender, MouseWheelEventArgs e)
  {
    _scale *= (e.Delta > 0 ? 1.1 : 0.9);

    wmp.RenderTransform = new ScaleTransform(_scale, _scale);
    wmp.RenderTransformOrigin = new Point(e.GetPosition(wmp).X / wmp.ActualWidth, e.GetPosition(wmp).Y / wmp.ActualHeight);
  }
}