using ABI.Windows.UI;
using Microsoft.UI;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.ApplicationSettings;
using Windows.UI.WindowManagement;
using WinRT;
using WinRT.Interop;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace C1OS
{

    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable CA2211 // 非常量字段应当不可见
        public static MainWindow current;
#pragma warning restore CA2211 // 非常量字段应当不可见
#pragma warning restore IDE0079 // 请删除不必要的忽略
        private readonly Microsoft.UI.Windowing.AppWindow m_AppWindow;
        private Microsoft.UI.Windowing.AppWindow GetAppWindowForCurrentWindow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            Microsoft.UI.WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return Microsoft.UI.Windowing.AppWindow.GetFromWindowId(wndId);
        }
        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "一班专用系统";
            m_AppWindow = GetAppWindowForCurrentWindow();
            var titleBar = m_AppWindow.TitleBar;
            // Hide system title bar.
            titleBar.ExtendsContentIntoTitleBar = true;
            titleBar.PreferredHeightOption = TitleBarHeightOption.Tall;
            titleBar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(0,0,0,0);
            NavView.Margin = new Thickness(0,titleBar.Height,0,0);
            AppTitleBar.Margin = new Thickness(12, titleBar.Height / 4, 12, titleBar.Height / 4);
            current = this;
            backgroundImage = ApplicationBackgroundImage;
            _ = Windows.Storage.ApplicationData.Current.LocalSettings;
            _ = Windows.Storage.ApplicationData.Current.LocalFolder;
            ReadLD();
            ReadBG();
            ReadBGOpacity();
        }
#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable CA2211 // 非常量字段应当不可见
        public static ImageBrush backgroundImage;
#pragma warning restore CA2211 // 非常量字段应当不可见
#pragma warning disable IDE0079 // 请删除不必要的忽略
        static async void ReadLD()
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
               Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFile LDData = await localFolder.GetFileAsync("LDSetting.ini");
                String LDS = await FileIO.ReadTextAsync(LDData);
                // Data is contained in LDS
                if (LDS == "2")
                {
                    if (MainWindow.current.Content is FrameworkElement rootElement)
                    {
                        rootElement.RequestedTheme = ElementTheme.Light;
                    }
                }
                else if (LDS == "1")
                {
                    if (MainWindow.current.Content is FrameworkElement rootElement)
                    {
                        rootElement.RequestedTheme = ElementTheme.Dark;
                    }
                }
                else
                {
                    if (MainWindow.current.Content is FrameworkElement rootElement)
                    {
                        rootElement.RequestedTheme = ElementTheme.Default;
                    }
                }

            }
            catch (Exception)
            {
                  if (MainWindow.current.Content is FrameworkElement rootElement)
                  {
                       rootElement.RequestedTheme = ElementTheme.Default;
                  }
            }
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private async void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // You can also add items in code.


            // Add handler for ContentFrame navigation.
            ContentFrame.Navigated += On_Navigated;
                try
                {
                    Windows.Storage.ApplicationDataContainer localSettings =
                   Windows.Storage.ApplicationData.Current.LocalSettings;
                    Windows.Storage.StorageFolder localFolder =
                         Windows.Storage.ApplicationData.Current.LocalFolder;

                    StorageFile DefaultPageData = await localFolder.GetFileAsync("DefaultPageSetting.ini");
                string DefaultPage = await FileIO.ReadTextAsync(DefaultPageData);
                if (DefaultPage == "")
                {
                    DefaultPage = "C1OS.HomePage";
                }
                var x = await FileIO.ReadTextAsync(DefaultPageData) switch
                {
                    "C1OS.HomePage" => 0,
                    "C1OS.CallPage" => 1,
                    "C1OS.RingPage" => 2,
                    "C1OS.DatePage" => 3,
                    "C1OS.CardPage" => 4,
                    "C1OS.MorePage" => 5,
                    "C1OS.EarthOnline" => 6,
                    "C1OS.PTable" => 7,
                    "C1OS.Translator" => 8,
                    "C1OS.HelpPage" => 9,
                    "C1OS.VersionPage" => 10,
                    "C1OS.SettingsPage" => 11,
                    _ => 0,
                };
                NavView.SelectedItem = NavView.MenuItems[x];
                Type navPageType = Type.GetType(DefaultPage);
                NavView_Navigate(navPageType, new DrillInNavigationTransitionInfo());
            }
                catch (Exception)
                {
                NavView.SelectedItem = NavView.MenuItems[0];
                NavView_Navigate(typeof(HomePage), new DrillInNavigationTransitionInfo());
            }
            // NavView doesn't load any page by default, so load home page.
            
            // If navigation occurs on SelectionChanged, this isn't needed.
            // Because we use ItemInvoked to navigate, we need to call Navigate
            // here to load the home page.
            
        }

        private void NavView_ItemInvoked(NavigationView sender,
                                         NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                NavView_Navigate(typeof(SettingsPage), args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                Type navPageType = Type.GetType(args.InvokedItemContainer.Tag.ToString());
                NavView_Navigate(navPageType, args.RecommendedNavigationTransitionInfo);
            }
        }



        private void NavView_Navigate(
            Type navPageType,
            NavigationTransitionInfo transitionInfo)
        {
            ArgumentNullException.ThrowIfNull(transitionInfo);
            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            Type preNavPageType = ContentFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (navPageType is not null && !Type.Equals(preNavPageType, navPageType))
            {
                ContentFrame.Navigate(navPageType, null, new DrillInNavigationTransitionInfo());
            }
        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            NavView.IsBackEnabled = ContentFrame.CanGoBack;

            if (ContentFrame.SourcePageType == typeof(SettingsPage))
            {
                // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag.
                NavView.SelectedItem = (NavigationViewItem)NavView.SettingsItem;
                NavView.Header = "设置";
            }
            else if (ContentFrame.SourcePageType != null)
            {
                // Select the nav view item that corresponds to the page being navigated to.
                NavView.SelectedItem = NavView.MenuItems
                            .OfType<NavigationViewItem>()
                            .First(i => i.Tag.Equals(ContentFrame.SourcePageType.FullName.ToString()));

                NavView.Header =
                    ((NavigationViewItem)NavView.SelectedItem)?.Content?.ToString();

            }
        }

        static async void ReadBG()
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
               Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFile BGData = await localFolder.GetFileAsync("BGSetting.ini");
                String file = await FileIO.ReadTextAsync(BGData);
                // Data is contained in file
                if (file != null)
                {
                    
                    StorageFile file1 = await StorageFile.GetFileFromPathAsync(file);
                    BitmapImage bitmapImage = new();
                    FileRandomAccessStream stream = (FileRandomAccessStream)await file1.OpenAsync(FileAccessMode.Read);
                    await bitmapImage.SetSourceAsync(stream);
                    MainWindow.backgroundImage.ImageSource = bitmapImage;
                }
                else
                {
                    MainWindow.backgroundImage.ImageSource = null;
                }

            }
            catch (Exception)
            {
                MainWindow.backgroundImage.ImageSource = null;
            }
        }

        static async void ReadBGOpacity()
        {
            double BGO;
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
               Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;
                
                StorageFile BGOData = await localFolder.GetFileAsync("BGOpacitySetting.ini");
                String BGOS = await FileIO.ReadTextAsync(BGOData);
                // Data is contained in SpeedS
                try
                {
                    BGO = Convert.ToDouble(BGOS);
                }
                catch (Exception)
                {
                    BGO = 0.5;
                }
            }
            catch (Exception)
            {
                // BGOS not found
                BGO = 0.5;
            }
            MainWindow.backgroundImage.Opacity = BGO;
        }



    }

}


