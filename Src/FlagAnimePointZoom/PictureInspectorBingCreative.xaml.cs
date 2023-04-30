using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1;

public partial class PictureInspectorBingCreative : UserControl
{
  const double ZoomFactor = 0.1, MinScale = 0.1, MaxScale = 10.0;
  double _scale = 1.0;
  Point _position = new(0, 0);
  Point _previousMousePosition;
  bool _isDragging = false;


  public PictureInspectorBingCreative()
  {
    InitializeComponent();

    this.MouseWheel += OnMouseWheel;
    this.MouseMove += OnMouseMove;
    this.MouseDown += OnMouseDown;
    this.MouseUp += OnMouseUp;
    this.MouseLeave += OnMouseLeave;

    UpdateTransform();
  }

  void OnMouseWheel(object sender, MouseWheelEventArgs e)
  {
    // Get the mouse position relative to the image
    var mousePosition = e.GetPosition(Image);

    // Calculate the new scale factor based on the mouse wheel delta
    var newScale = _scale + (e.Delta > 0 ? ZoomFactor : -ZoomFactor);

    newScale = Math.Min(Math.Max(newScale, MinScale), MaxScale);

    var ratio = newScale / _scale; // Calculate the ratio of the new and old scale factors

    // Update the position of the image based on the mouse position and the ratio
    _position.X = mousePosition.X - ratio * (mousePosition.X - _position.X);
    _position.Y = mousePosition.Y - ratio * (mousePosition.Y - _position.Y);

    // Update the scale factor
    _scale = newScale;

    // Update the transform of the image
    UpdateTransform();
  }

  void OnMouseMove(object sender, MouseEventArgs e)
  {
    // Get the current mouse position relative to the image
    var mousePosition = e.GetPosition(Image);

    // Check if the mouse button is pressed
    if (_isDragging)
    {
      // Calculate the delta of the mouse movement
      var delta = mousePosition - _previousMousePosition;

      // Update the position of the image based on the delta
      _position.X += delta.X;
      _position.Y += delta.Y;

      // Update the transform of the image
      UpdateTransform();
    }

    // Store the previous mouse position
    _previousMousePosition = mousePosition;
  }

  void OnMouseDown(object sender, MouseButtonEventArgs e)
  {
    // Set the flag to indicate that the mouse button is pressed
    _isDragging = true;

    // Capture the mouse to receive events even when it leaves the usercontrol
    _ = this.CaptureMouse();
  }

  void OnMouseUp(object sender, MouseButtonEventArgs e)
  {
    // Release the flag to indicate that the mouse button is released
    _isDragging = false;

    // Release the mouse capture
    this.ReleaseMouseCapture();
  }

  void OnMouseLeave(object sender, MouseEventArgs e)
  {
    // Release the flag to indicate that the mouse button is released
    _isDragging = false;

    // Release the mouse capture
    this.ReleaseMouseCapture();
  }

  void UpdateTransform()
  {
    // Create a new transform group for the image
    var transformGroup = new TransformGroup();

    // Add a scale transform with the current scale factor
    transformGroup.Children.Add(new ScaleTransform(_scale, _scale));

    // Add a translate transform with the current position
    transformGroup.Children.Add(new TranslateTransform(_position.X, _position.Y));

    // Apply the transform group to the image
    Image.RenderTransform = transformGroup;
  }
}
