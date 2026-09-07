# Angles Desktop

Angles 的 WinUI 3 桌面壳 —— 把 2MB 的 [angles-cli](https://github.com/angleschina/angles-cli) agent 端到 Windows 11 桌面上。

![#2DD4BF](https://img.shields.io/badge/build-GitHub%20Actions-2DD4BF)
![win x64](https://img.shields.io/badge/platform-win11-blue)

## 这是什么

- **形态**：WinUI 3（.NET 8 · Windows App SDK）unpackaged 桌面应用
- **界面**：Windows 11 风（Mica 材质、圆角卡片控件）
- **图标**：全部 Lucide SVG（不含 emoji / Symbol 字体图标），随包作为 `Assets/*.svg`
- **愿景**：聊天、文件操作与图形界面工作区围绕 angles API 展开，core 仍是原生 Rust CLI

## 从源码构建

仓库自身不带 Windows 工具链，编译全交给 GitHub Actions：

```bash
# Actions 手动触发 → 下载 Angles-Desktop artifact 解压即用
dotnet publish Angles.Desktop/Angles.Desktop.csproj -c Release -r win-x64 --self-contained true
```

产物为**免安装 unpackaged exe**（不含 .msix 签名要求），在 Windows 10 19041+ / 11 运行。

## 目录

```
Angles.Desktop/
├── Angles.Desktop.csproj   # WinUI3 unpackaged 项目
├── App.xaml(.cs)           # 应用入口
├── MainWindow.xaml(.cs)    # 主窗口（lucide 图标于 Assets/）
└── Assets/                 # lucide SVG 图标源文件
```

## 图标来源

图标逐条来自 [lucide-icons/lucide](https://github.com/lucide-icons/lucide)（ISC），保留原 SVG 路径，运行期以 `SvgImageSource` 实时着色加载。
