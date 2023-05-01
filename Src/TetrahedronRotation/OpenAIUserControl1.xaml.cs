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
public partial class OpenAIUserControl1 : UserControl
{
  DoubleAnimation rotationAnimation;

  public OpenAIUserControl1()
  {
    InitializeComponent();

    // Set up the rotation animation
    rotationAnimation = new DoubleAnimation();
    rotationAnimation.From = 0;
    rotationAnimation.To = 360;
    rotationAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
    rotationAnimation.RepeatBehavior = RepeatBehavior.Forever;

    // Start the rotation animation
    RotateTetrahedron();
  }

  private void RotateTetrahedron_Error()
  {
    // Create a new BitmapImage for each image
    BitmapImage image1 = new BitmapImage(new Uri("pack://application:,,,/Images/image1.jpg"));
    BitmapImage image2 = new BitmapImage(new Uri("pack://application:,,,/Images/image2.jpg"));
    BitmapImage image3 = new BitmapImage(new Uri("pack://application:,,,/Images/image3.jpg"));
    BitmapImage image4 = new BitmapImage(new Uri("pack://application:,,,/Images/image4.jpg"));
    BitmapImage image5 = new BitmapImage(new Uri("pack://application:,,,/Images/image5.jpg"));

    // Set the images as the material's brush
    ((DiffuseMaterial)((GeometryModel3D)tetrahedron).Material).Brush = new ImageBrush(image1);
    ((DiffuseMaterial)((GeometryModel3D)tetrahedron).Material).Brush = new ImageBrush(image2);
    ((DiffuseMaterial)((GeometryModel3D)tetrahedron).Material).Brush = new ImageBrush(image3);
    ((DiffuseMaterial)((GeometryModel3D)tetrahedron).Material).Brush = new ImageBrush(image4);
    ((DiffuseMaterial)((GeometryModel3D)tetrahedron).Material).Brush = new ImageBrush(image5);

    // Create a rotation transform and apply it to the ModelVisual3D
    RotateTransform3D rotationTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0));
    tetrahedron.Transform = rotationTransform;

    // Create a storyboard and add the rotation animation to it
    Storyboard storyboard = new Storyboard();
    storyboard.Children.Add(rotationAnimation);
    Storyboard.SetTarget(rotationAnimation, rotationTransform);
    Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath(RotateTransform3D.RotationProperty));

    // Start the storyboard
    storyboard.Begin();
  }
  void RotateTetrahedron_2()
  {
    // Create a new BitmapImage for each image
    BitmapImage image1 = new BitmapImage(new Uri("pack://application:,,,/Images/Image1.jpg"));
    BitmapImage image2 = new BitmapImage(new Uri("pack://application:,,,/Images/Image2.jpg"));
    BitmapImage image3 = new BitmapImage(new Uri("pack://application:,,,/Images/Image3.jpg"));
    BitmapImage image4 = new BitmapImage(new Uri("pack://application:,,,/Images/Image4.jpg"));
    BitmapImage image5 = new BitmapImage(new Uri("pack://application:,,,/Images/Image5.jpg"));

    // Set the images as the material's brush
    ((DiffuseMaterial)((GeometryModel3D)tetrahedron).Material).Brush = new ImageBrush(image1);

    // Create a rotation transform and apply it to the ModelVisual3D
    RotateTransform3D rotationTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0));
    tetrahedron.Transform = rotationTransform;

    // Create a QuaternionAnimation and add it to a Storyboard
    QuaternionAnimation rotationAnimation = new QuaternionAnimation();
    rotationAnimation.From = new Quaternion(new Vector3D(0, 1, 0), 0);
    rotationAnimation.To = new Quaternion(new Vector3D(0, 1, 0), 360);
    rotationAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
    rotationAnimation.RepeatBehavior = RepeatBehavior.Forever;

    Storyboard storyboard = new Storyboard();
    storyboard.Children.Add(rotationAnimation);

    // Set the target of the animation to the Rotation property of the RotateTransform3D
    Storyboard.SetTarget(rotationAnimation, rotationTransform);
    Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath(RotateTransform3D.RotationProperty));

    // Start the storyboard
    storyboard.Begin();
  }
  void RotateTetrahedron()
  {
    // Create a new BitmapImage for each image
    BitmapImage image1 = new BitmapImage(new Uri("pack://application:,,,/Images/Image1.jpg"));
    BitmapImage image2 = new BitmapImage(new Uri("pack://application:,,,/Images/Image2.jpg"));
    BitmapImage image3 = new BitmapImage(new Uri("pack://application:,,,/Images/Image3.jpg"));
    BitmapImage image4 = new BitmapImage(new Uri("pack://application:,,,/Images/Image4.jpg"));
    BitmapImage image5 = new BitmapImage(new Uri("pack://application:,,,/Images/Image5.jpg"));

    // Set the images as the material's brush
    ((DiffuseMaterial)((GeometryModel3D)tetrahedron).Material).Brush = new ImageBrush(image1);

    // Create a rotation transform and apply it to the ModelVisual3D
    RotateTransform3D rotationTransform = new RotateTransform3D();
    QuaternionRotation3D rotation = new QuaternionRotation3D(new Quaternion(new Vector3D(0, 1, 0), 0));
    rotationTransform.Rotation = rotation;
    tetrahedron.Transform = rotationTransform;

    // Create a QuaternionAnimation and add it to a Storyboard
    QuaternionAnimation rotationAnimation = new QuaternionAnimation();
    rotationAnimation.From = new Quaternion(new Vector3D(0, 1, 0), 0);
    rotationAnimation.To = new Quaternion(new Vector3D(0, 1, 0), 360);
    rotationAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
    rotationAnimation.RepeatBehavior = RepeatBehavior.Forever;

    Storyboard storyboard = new Storyboard();
    storyboard.Children.Add(rotationAnimation);

    // Set the target of the animation to the Quaternion property of the QuaternionRotation3D
    Storyboard.SetTarget(rotationAnimation, rotation);
    Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath(QuaternionRotation3D.QuaternionProperty));

    // Start the storyboard
    storyboard.Begin();
  }
}
