using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace GptFeeder;
public partial class GptFeederWindow : Window
{
  public GptFeederWindow() => InitializeComponent();

  int current = 0, ttl = 0, curPos = 0;
  const int max = 4000;

  void OnSplit(object sender, RoutedEventArgs e)
  {
    Task.Run(() => Console.Beep(333, 3333));
  }
  void OnClose(object sender, RoutedEventArgs e) => Close();
  void OnZoom(object sender, System.Windows.Input.MouseWheelEventArgs e) => ((TextBox)sender).FontSize += (e.Delta < 0 && ((TextBox)sender).FontSize > 1) ? -1 : +1;

  void OnNext(object sender, RoutedEventArgs e)
  {
    var ini = (current++ == 0) ? $"Concatenate the following {ttl} messages: " : $"Message {current}: ";
    var len = max - ini.Length;
    if (curPos + len < Src.Text.Length)
      Stp.Text = $"{ini}{Src.Text.Substring(curPos, len)}";
    else
    {
      Stp.Text = $"{ini}{Src.Text[curPos..]}";
      current = curPos = 0;
      System.Media.SystemSounds.Asterisk.Play();
    }

    curPos += len;

    Clipboard.SetText(Stp.Text);

    Rpt.Text = $"{current} / {ttl}   {curPos} / {Src.Text.Length}";
  }
  void OnTextChanged(object sender, TextChangedEventArgs e)
  {
    if (Rpt is null) return; Rpt.Text = $"{Src.Text.Length} chars ";

    ttl = (Src.Text.Length + 100) / max;
  }
}