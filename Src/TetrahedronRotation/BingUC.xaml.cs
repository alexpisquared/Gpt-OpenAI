using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TetrahedronRotation;
public partial class BingUC : UserControl  //GPT: Create a Viewport3D XAML elemnt of .NET 6.0 version of a tetrahedron rotating around 2 axises driven by AxisAngleRotation3D with 2 different durations with tab size of 1 and without comments and images\Image1.jpg displayed on all the surfaces.
{
  public BingUC()
  {
    InitializeComponent();

    rotate0.BeginAnimation(AxisAngleRotation3D.AngleProperty, new DoubleAnimation(0, 360, TimeSpan.FromSeconds(3)) { RepeatBehavior = RepeatBehavior.Forever });
    rotate1.BeginAnimation(AxisAngleRotation3D.AngleProperty, new DoubleAnimation(0, 360, TimeSpan.FromSeconds(5)) { RepeatBehavior = RepeatBehavior.Forever });
    rotate2.BeginAnimation(AxisAngleRotation3D.AngleProperty, new DoubleAnimation(0, 360, TimeSpan.FromSeconds(7)) { RepeatBehavior = RepeatBehavior.Forever }); 
  }

  private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
  {
    // Pause the animation and change the angle manually
    //myBeginStoryboard.Pause();
    //myRotateTransform3D.Rotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), slider.Value);
  }
}