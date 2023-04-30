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
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Cube1.xaml
    /// </summary>
    public partial class Cube1 : UserControl
    {
        public Cube1()
        {
            InitializeComponent();
        }void viewport3D1_MouseWheel(object sender, MouseWheelEventArgs e)
    {
      // Get the current position of the camera
      Point3D position = camMain.Position;

      // Create a scale transform to adjust the zoom level based on the mouse wheel delta
      ScaleTransform3D scale = new ScaleTransform3D(1 + e.Delta / 1000.0, 1 + e.Delta / 1000.0, 1 + e.Delta / 1000.0);

      // Apply the scale transform to the camera position
      position = scale.Transform(position);

      // Set the new position of the camera
      camMain.Position = position;
    }
    }
}
