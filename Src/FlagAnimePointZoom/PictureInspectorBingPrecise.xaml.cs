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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PictureInspectorBingPrecise.xaml
    /// </summary>
    public partial class PictureInspectorBingPrecise : UserControl
    {
    // A dependency property for the picture source
    public static readonly DependencyProperty PictureSourceProperty =
        DependencyProperty.Register("PictureSource", typeof(ImageSource), typeof(PictureInspectorBingPrecise), new PropertyMetadata(null));

    // A dependency property for the picture info
    public static readonly DependencyProperty PictureInfoProperty =
        DependencyProperty.Register("PictureInfo", typeof(string), typeof(PictureInspectorBingPrecise), new PropertyMetadata(null));

    // A routed event for when the picture is zoomed
    public static readonly RoutedEvent PictureZoomedEvent =
        EventManager.RegisterRoutedEvent("PictureZoomed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PictureInspectorBingPrecise));

    // A routed event for when the picture is moved
    public static readonly RoutedEvent PictureMovedEvent =
        EventManager.RegisterRoutedEvent("PictureMoved", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PictureInspectorBingPrecise));

    // The default scale factor for zooming
    const double DefaultScaleFactor = 0.1;

    // The maximum scale factor for zooming
    const double MaxScaleFactor = 5;

    // The current scale factor
    double _currentScaleFactor = 1;

    // The flag for indicating if the mouse button is pressed
    bool _isMousePressed = false;

    // The previous mouse position
    Point _previousMousePosition;

    public PictureInspectorBingPrecise()
    {
      InitializeComponent();

      // Set the data context to this usercontrol
      this.DataContext = this;

      // Register the mouse event handlers
      this.MouseWheel += OnMouseWheel;
      this.MouseMove += OnMouseMove;
      this.MouseDown += OnMouseDown;
      this.MouseUp += OnMouseUp;
    }

    // A property for getting or setting the picture source
    public ImageSource PictureSource
    {
      get { return (ImageSource)GetValue(PictureSourceProperty); }
      set { SetValue(PictureSourceProperty, value); }
    }

    // A property for getting or setting the picture info
    public string PictureInfo
    {
      get { return (string)GetValue(PictureInfoProperty); }
      set { SetValue(PictureInfoProperty, value); }
    }

    // An event for when the picture is zoomed
    public event RoutedEventHandler PictureZoomed
    {
      add { AddHandler(PictureZoomedEvent, value); }
      remove { RemoveHandler(PictureZoomedEvent, value); }
    }

    // An event for when the picture is moved
    public event RoutedEventHandler PictureMoved
    {
      add { AddHandler(PictureMovedEvent, value); }
      remove { RemoveHandler(PictureMovedEvent, value); }
    }

    // A method for handling the mouse wheel event
    void OnMouseWheel(object sender, MouseWheelEventArgs e)
    {
      // Check if the shift key is pressed
      if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
      {
        // Check if the mouse wheel is moved forward (zoom in)
        if (e.Delta > 0)
        {
          // Check if the current scale factor is less than the maximum scale factor
          if (_currentScaleFactor < MaxScaleFactor)
          {
            // Increase the current scale factor by the default scale factor
            _currentScaleFactor += DefaultScaleFactor;

            // Apply the scaling transformation to the image
            Scale.ScaleX = _currentScaleFactor;
            Scale.ScaleY = _currentScaleFactor;

            // Raise the picture zoomed event
            RaiseEvent(new RoutedEventArgs(PictureZoomedEvent));
          }
        }
        else // The mouse wheel is moved backward (zoom out)
        {
          // Check if the current scale factor is greater than one
          if (_currentScaleFactor > 1)
          {
            // Decrease the current scale factor by the default scale factor
            _currentScaleFactor -= DefaultScaleFactor;

            // Apply the scaling transformation to the image
            Scale.ScaleX = _currentScaleFactor;
            Scale.ScaleY = _currentScaleFactor;

            // Raise the picture zoomed event
            RaiseEvent(new RoutedEventArgs(PictureZoomedEvent));
          }
        }
      }
    }

    // A method for handling the mouse move event
    void OnMouseMove(object sender, MouseEventArgs e)
    {
      // Check if the mouse button is pressed and the current scale factor is greater than one
      if (_isMousePressed && _currentScaleFactor > 1)
      {
        // Get the current mouse position
        Point currentMousePosition = e.GetPosition(this);

        // Calculate the mouse movement delta
        double deltaX = currentMousePosition.X - _previousMousePosition.X;
        double deltaY = currentMousePosition.Y - _previousMousePosition.Y;

        // Calculate the translation offset based on the mouse movement delta and the current scale factor
        double offsetX = deltaX / _currentScaleFactor;
        double offsetY = deltaY / _currentScaleFactor;

        // Apply the translation transformation to the image
        Translate.X += offsetX;
        Translate.Y += offsetY;

        // Update the previous mouse position
        _previousMousePosition = currentMousePosition;

        // Raise the picture moved event
        RaiseEvent(new RoutedEventArgs(PictureMovedEvent));
      }
    }

    // A method for handling the mouse down event
    void OnMouseDown(object sender, MouseButtonEventArgs e)
    {
      // Check if the left mouse button is pressed
      if (e.LeftButton == MouseButtonState.Pressed)
      {
        // Set the mouse button flag to true
        _isMousePressed = true;

        // Capture the mouse input
        this.CaptureMouse();

        // Get and store the current mouse position
        _previousMousePosition = e.GetPosition(this);
      }
    }

    // A method for handling the mouse up event
    void OnMouseUp(object sender, MouseButtonEventArgs e)
    {
      // Check if the left mouse button is released
      if (e.LeftButton == MouseButtonState.Released)
      {
        // Set the mouse button flag to false
        _isMousePressed = false;

        // Release the mouse input
        this.ReleaseMouseCapture();
      }
    }
  }
}