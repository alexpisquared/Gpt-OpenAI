using System.Windows;
using System.Windows.Controls;

namespace GptFeeder;
public partial class GptFeederWindow : Window
{
  public GptFeederWindow() => InitializeComponent();

  int current = 0, ttl = 0, l = 0;

  void OnSplit(object sender, RoutedEventArgs e) { }
  void OnClose(object sender, RoutedEventArgs e) => Close();

  private void OnZoom(object sender, System.Windows.Input.MouseWheelEventArgs e)
  {
    var textbox = sender as TextBox;
    if (textbox != null)
    {
      double currentSize = textbox.FontSize;
      if (e.Delta > 0)
      {
        textbox.FontSize = currentSize + 1;
      }
      else
      {
        textbox.FontSize = currentSize - 1;
      }
    }
  }

  void OnNext(object sender, RoutedEventArgs e)
  {
    if (current++ == 0)
    {
      var s = $"Concatenate this and next {ttl} messages: ";
      l = 2000 - s.Length;
      Stp.Text = s + Src.Text[..l];
    }
    else
    {
      var s = $"Message {current}: ";
      var l2 = 2000 - s.Length;
      if (l + l2 < Src.Text.Length)
        Stp.Text = s + Src.Text.Substring(l, l2);
      else
      {
        Stp.Text = s + Src.Text[l..]; current = l = 0; 
        System.Media.SystemSounds.Asterisk.Play();
      }

      l += l2;
    }

    Clipboard.SetText(Stp.Text);
    Rpt.Text = $"{current} / {ttl}   {l} / {Src.Text.Length}";
  }
  void OnTextChanged(object sender, TextChangedEventArgs e)
  {
    if (Rpt is null) return; Rpt.Text = $"{Src.Text.Length} chars ";

    ttl = (Src.Text.Length + 100) / 2000;
  }
}
