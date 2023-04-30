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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for RotatorFlatWindow.xaml
    /// </summary>
    public partial class RotatorFlatWindow : Window
    {
        public RotatorFlatWindow()
        {
            InitializeComponent();
      StartAnimations();
    }

    void StartAnimations()
    {
      DoubleAnimation outerEllipseAnimation = new DoubleAnimation();
      outerEllipseAnimation.From = 0;
      outerEllipseAnimation.To = 360;
      outerEllipseAnimation.Duration = new Duration(TimeSpan.FromSeconds(10));
      outerEllipseAnimation.RepeatBehavior = RepeatBehavior.Forever;

      DoubleAnimation innerEllipseAnimation = new DoubleAnimation();
      innerEllipseAnimation.From = 0;
      innerEllipseAnimation.To = 360;
      innerEllipseAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
      innerEllipseAnimation.RepeatBehavior = RepeatBehavior.Forever;

      DoubleAnimation rectangleAnimation = new DoubleAnimation();
      rectangleAnimation.From = 0;
      rectangleAnimation.To = 360;
      rectangleAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
      rectangleAnimation.RepeatBehavior = RepeatBehavior.Forever;

      outerEllipseTransform.BeginAnimation(RotateTransform.AngleProperty, outerEllipseAnimation);
      innerEllipseTransform.BeginAnimation(RotateTransform.AngleProperty, innerEllipseAnimation);
      rectangleTransform.BeginAnimation(RotateTransform.AngleProperty, rectangleAnimation);
    }
  }
}