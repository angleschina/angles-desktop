using System;
using System.IO;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Angles.Desktop;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Title = "Angles Desktop";
        SetSystemBackdrop();

        IconAsync("braces", LogoIcon);
        IconAsync("play", StartIcon);
        IconAsync("settings", SettingsIcon);

        System.AppDomain.CurrentDomain.UnhandledException += (_, e) =>
            StatusText.Text = "core 未启动：" + e.ExceptionObject;
        StatusText.Text = "standby — Angles core not launched yet";
    }

    private void SetSystemBackdrop()
    {
        try
        {
            SystemBackdrop = new Microsoft.UI.Xaml.Media.MicaBackdrop();
        }
        catch
        {
            // 回退：普通背景即可，不影响运行
        }
    }

    /// <summary>从输出目录载 lucide svg 到指定 Image；失败则忽略该图标。</summary>
    private async void IconAsync(string name, Image img)
    {
        try
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Assets", name + ".svg");
            var file = await StorageFile.GetFileFromPathAsync(path);
            using var stream = await file.OpenReadAsync();

            var svg = new SvgImageSource();
            using (var mem = new InMemoryRandomAccessStream())
            {
                await RandomAccessStream.CopyAsync(stream, mem);
                mem.Seek(0);
                await svg.SetSourceAsync(mem);
            }
            img.Source = svg;
        }
        catch
        {
            // 图标缺失不该拖垮应用
        }
    }
}
