using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Media.Animation;
using Windows.Storage;
using Windows.Media.SpeechSynthesis;
using Microsoft.VisualBasic;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using System.Collections.ObjectModel;
using static C1OS.SettingsPage;
using System.Diagnostics;
using Windows.ApplicationModel;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using Application = Microsoft.UI.Xaml.Application;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace C1OS
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    // C# Code

    // CustomDataObject class definition:
    public class Project
    {
        public string Name { get; set; }
        public string ImageLocation { get; set; }
    }

    public sealed partial class SettingsPage : Page
    {
        double CallSpeed;
        bool CallSpeeedSliderOff = true;
        bool SpeakerLoading = false;
        bool NoNameTeam = false;
        bool Fun = false;
        bool Moving = false;
        private readonly List<Project> Projects = [];
        private readonly List<String> Speakers = [];
        private static readonly System.Speech.Synthesis.SpeechSynthesizer speaker = new();

        public SettingsPage()
        {
            this.InitializeComponent();
            speaker.SetOutputToDefaultAudioDevice();
            ReadCallSpeed();
            ReadLD();
            ReadMotto();
            ReadCallMode();
            ReadBGOpacity();
            PopulateProjects();
            PopulateSpeakers();
            ReadSpeakerVolume();
            ReadSpeakerRate();
            ReadDefaultPage();
            ReadSpeaker();
        }

        private void PopulateSpeakers()
        {
            using System.Speech.Synthesis.SpeechSynthesizer synth = new();
            // Output information about all of the installed voices.
            foreach (InstalledVoice voice in synth.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;
                if (voice.Enabled == true)
                {
                    Speakers.Add(info.Name);
                }
            }
            SpeakerSelect.ItemsSource = Speakers;
        }

        private void Speak(object sender, RoutedEventArgs e)
        {
            speaker.SpeakAsyncCancelAll();
            if (SpeakerInput.Text == "//No Name Team//")
            {
                NoNameTeam = true;
                PopulateProjects();
                SpeakerInput.Text = "指令已执行！";
            }
            else if(SpeakerInput.Text == "//Fun//")
            {
                Fun = true;
                PopulateProjects();
                SpeakerInput.Text = "指令已执行！";
            }
            else if(SpeakerInput.Text == "//Moving//")
            {
                Moving = true;
                PopulateProjects();
                SpeakerInput.Text = "指令已执行！";
            }
            else if (SpeakerInput.Text == "//Stop//")
            {
                NoNameTeam = false;
                Fun = false;
                Moving = false;
                PopulateProjects();
                SpeakerInput.Text = "指令已执行！";
            }
            else if (SpeakerInput.Text == "//All114514//")
            {
                NoNameTeam = true;
                Fun = true;
                Moving = true;
                PopulateProjects();
                SpeakerInput.Text = "指令已执行！";
            }
            if (SpeakerInput.Text != "")
            {
                speaker.SpeakAsync(SpeakerInput.Text);
            }
            else
            {
                speaker.SpeakAsync("欢迎使用壹班专用系统！Welcome to use C1OS!");
            }
        }

        private void PopulateProjects()
        {
            Projects.Clear();
            Project newProject = new()
            {
                Name = "班徽图案-亮",
                ImageLocation = "ms-appx:///Assets/Backgrounds/White Circle Square.png"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "班徽图案-暗",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Black Circle Square.png"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "班徽图案-蓝",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Blue Circle Square.png"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "黑板",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Blackboard.jpeg"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "蓝色幕布",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Blue Backdrop.jpg"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "红色幕布",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Red Backdrop.jpg"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "地球",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Earth.jpg"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "星际",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Stars.png"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "实验室",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Lab.png"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "粒子艺术",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Particle Arts.png"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "自然",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Tree.png"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "科技",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Technology.png"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "像素星空",
                ImageLocation = "ms-appx:///Assets/Backgrounds/Minecraft End Gateway.png"
            };
            Projects.Add(newProject);

            newProject = new Project
            {
                Name = "系统",
                ImageLocation = "ms-appx:///Assets/Backgrounds/No Name System Background.png"
            };
            Projects.Add(newProject);

            if (NoNameTeam == true)
            {
                newProject = new Project
                {
                    Name = "某个不想起名的人",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/No Name Team/No Namer.jpg"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "另一个不想起名的人",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/No Name Team/Another No Namer.png"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "K Train & M Train",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/No Name Team/K Train & M Train.jpg"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "某个不想起名的团队商标",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/No Name Team/No Name Team.png"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "某个不想起名的团队A",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/No Name Team/No Namers A.png"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "某个不想起名的团队B",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/No Name Team/No Namers B.png"
                };
                Projects.Add(newProject);
            }
            if (Moving == true)
            {
                newProject = new Project
                {
                    Name = "某个不想起名的人（动图）",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Moving/Morax.gif"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "另一个不想起名的人（动图1）",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Moving/Haagentus1.gif"
                };
                Projects.Add(newProject);
            }
            if (Fun == true) 
            {
                newProject = new Project
                {
                    Name = "包子",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/boots.jfif"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "月亮",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/Moon.jpg"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "肥虫",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/fc.png"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "满灯先生",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/mdxs.png"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "罗哥",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/lxs.jpg"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "鼠妇",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/sf.jpg"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "大亚湾",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/dyw.jpg"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "德邦快递",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/wjband.jpg"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "毛毛",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/mm.jpg"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "齐白石",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/jby.jpg"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "SD",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/sd.png"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "男神",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/xdc.png"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "毕汉平",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/bhp.gif"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "李智聪",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/lzc.jpg"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "蓝叶林",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/lyl.gif"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "夏祥富",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/xxf.gif"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "强召娟",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/qzj.gif"
                };
                Projects.Add(newProject);

                newProject = new Project
                {
                    Name = "唐雪",
                    ImageLocation = "ms-appx:///Assets/Backgrounds/Fun/tx.gif"
                };
                Projects.Add(newProject);
            }
            StyledGrid.ItemsSource = Projects;
            ReadBG();
        }

        // 方法用于获取Uri的路径
        public static string GetUriPath(string UriPath)
        {
            // 获取当前应用的包
            _ = Package.Current;
            // 获取资源图片的Uri
            Uri uri = new(UriPath);
            // 将Uri转换为StorageFile
            StorageFile file = StorageFile.GetFileFromApplicationUriAsync(uri).AsTask().Result;
            // 获取文件的完整路径
            return file.Path;
        }

        private async void SetBackground(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (StyledGrid.SelectedIndex != -1)
                {
                    string Path = GetUriPath(Projects[StyledGrid.SelectedIndex].ImageLocation);
                    StorageFile file1 = await StorageFile.GetFileFromPathAsync(Path);
                    BitmapImage bitmapImage = new();
                    FileRandomAccessStream stream = (FileRandomAccessStream)await file1.OpenAsync(FileAccessMode.Read);
                    await bitmapImage.SetSourceAsync(stream);
                    MainWindow.backgroundImage.ImageSource = bitmapImage;
                    SaveBG(Path);
                }
                else
                {
                    MainWindow.backgroundImage.ImageSource = null;
                    SaveBG(null);
                }
            }
            catch {
                MainWindow.backgroundImage.ImageSource = null;
                SaveBG(null);
            }
        }

        private async void ChangeDefaultPage(object sender, RoutedEventArgs e)
        {
            var option = ((MenuFlyoutItem)sender).Tag.ToString();
            DefautPageOutput.Text = ((MenuFlyoutItem)sender).Text;
            _ =
   Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile DefaultPageData = await localFolder.CreateFileAsync("DefaultPageSetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(DefaultPageData, option);
        }

        async void ReadDefaultPage()
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
               Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFile DefaultPageData = await localFolder.GetFileAsync("DefaultPageSetting.ini");
                DefautPageOutput.Text = await FileIO.ReadTextAsync(DefaultPageData) switch
                {
                    "C1OS.HomePage" => "主页",
                    "C1OS.CallPage" => "点名",
                    "C1OS.RingPage" => "考试",
                    "C1OS.DatePage" => "倒计时",
                    "C1OS.CardPage" => "抽签",
                    "C1OS.MorePage" => "更多",
                    "C1OS.EarthOnline" => "天眼地图",
                    "C1OS.PTable" => "元素周期表",
                    "C1OS.Translator" => "翻译",
                    "C1OS.HelpPage" => "帮助",
                    "C1OS.VersionPage" => "版本",
                    "C1OS.SettingsPage" => "设置",
                    _ => "主页",
                };
            }
            catch (Exception)
            {
                DefautPageOutput.Text = "主页";
            }
        }

        private void ChangeSpeaker(object sender, SelectionChangedEventArgs e)
        {
            if (SpeakerLoading != true)
            {
                try
                {
                    if (SpeakerSelect.SelectedIndex != -1)
                    {
                        speaker.SpeakAsyncCancelAll();
                        speaker.SelectVoice(Speakers[SpeakerSelect.SelectedIndex]);
                        Speak(sender, e);
                        SaveSpeaker(Speakers[SpeakerSelect.SelectedIndex]);
                    }
                    else
                    {
                        Speak(sender, e);
                        SaveSpeaker(null);
                    }
                }
                catch
                {
                    Speak(sender, e);
                    SaveSpeaker(null);
                }
            }
            else { SpeakerLoading = false; }
        }

        public static async void SaveSpeaker(string Speaker)
        {
            _ =
   Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile SpeakerData = await localFolder.CreateFileAsync("SpeakerSetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(SpeakerData, Speaker);
        }

        private async void ChangeAppBackground(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileOpenPicker();
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(MainWindow.current);
            WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".bmp");
            filePicker.FileTypeFilter.Add(".gif");
            filePicker.FileTypeFilter.Add(".tiff");
            filePicker.FileTypeFilter.Add(".ico");
            filePicker.FileTypeFilter.Add(".jxr");
            var file = await filePicker.PickSingleFileAsync();
            if (file != null)
            {
                BitmapImage bitmapImage = new();
                FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.Read);
                await bitmapImage.SetSourceAsync(stream);
                MainWindow.backgroundImage.ImageSource = bitmapImage;
                SaveBG(file.Path);
            }
        }

        public static async void SaveBG(string file)
        {
            _ =
   Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile BGData = await localFolder.CreateFileAsync("BGSetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(BGData, file);
        }

        public static async void SaveLD(byte LD)
           {
            _ =
   Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;

            String LDS = LD.ToString();

            StorageFile LDData = await localFolder.CreateFileAsync("LDSetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(LDData, LDS);
        }

        public static async void SaveMotto(bool Open)
        {
            _ =
    Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;

            String OpenS = Open.ToString();

            StorageFile MottoData = await localFolder.CreateFileAsync("MottoSetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(MottoData, OpenS);
        }

        public void ChangeAppBackgroundColor(object sender, RoutedEventArgs e)
        {
            if(EnableAppColor.IsChecked == true)
            {
                AppColorSet.Visibility = Visibility.Visible;
            }
            else 
            {
                AppColorSet.Visibility= Visibility.Collapsed;
            }
        
        }

            public static Color GetColorArgb(string strcolor)
        {
            _ = strcolor.Split(',');
            List<string> list = [.. strcolor.Split(',')];
            byte A = Convert.ToByte(list[0]);
            byte R = Convert.ToByte(list[1]);
            byte G = Convert.ToByte(list[2]);
            byte B = Convert.ToByte(list[3]);
            return Color.FromArgb(A, R, G, B);
        }

        public async void SaveColor(object sender, ColorChangedEventArgs e)
        {   
            
            string Argb = AppColorSet.Color.A.ToString() + "," + AppColorSet.Color.R.ToString() + "," + AppColorSet.Color.G.ToString() + "," + AppColorSet.Color.B.ToString();
            _ =
    Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;

            String ColorS = Argb.ToString();

            StorageFile ColorData = await localFolder.CreateFileAsync("ColorSetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ColorData, ColorS);
        }

        public static async void SaveCallMode(bool Mode)
        {
            _ =
    Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;

            String ModeS = Mode.ToString();

            StorageFile CallModeData = await localFolder.CreateFileAsync("CallModeSetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(CallModeData, ModeS);
        }

        public static async void SaveCallSpeed(byte Speed)
        {
            _ =
    Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;

            String SpeedS = Speed.ToString();

            StorageFile CallSpeedData = await localFolder.CreateFileAsync("CallSpeedSetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(CallSpeedData, SpeedS);
        }

        public async void SetBGOpacity(object sender, RoutedEventArgs e)
        {
            _ =
    Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;

            MainWindow.backgroundImage.Opacity = BGOpacitySlider.Value;

            String BGOS = BGOpacitySlider.Value.ToString();

            StorageFile BGOData = await localFolder.CreateFileAsync("BGOpacitySetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(BGOData, BGOS);
        }

        async void ReadBGOpacity()
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
            BGOpacitySlider.Value = BGO;
        }

        private void Light(object sender, RoutedEventArgs e)
        { 
                    if (MainWindow.current.Content is FrameworkElement rootElement)
                    {
                        rootElement.RequestedTheme = ElementTheme.Light;
                    }
            SaveLD(2);
        }
        private void Dark(object sender, RoutedEventArgs e)
        {
            if (MainWindow.current.Content is FrameworkElement rootElement)
            {
                rootElement.RequestedTheme = ElementTheme.Dark;
            }
            SaveLD(1);
        }
        private void LDSystem(object sender, RoutedEventArgs e)
        {
            if (MainWindow.current.Content is FrameworkElement rootElement)
            {
                rootElement.RequestedTheme = ElementTheme.Default;
            }
            SaveLD(0);
        }

        private void CallModeSelect(object sender, RoutedEventArgs e)
        {
            if (CallModeSelector.IsOn == true)
            {
                SaveCallMode(true);
            }
            else
            {
                SaveCallMode(false);
            }
        }

        private void MottoSelect(object sender, RoutedEventArgs e)
        {
            if (MottoSelector.IsOn == true)
            {
                SaveMotto(true);
            }
            else
            {
                SaveMotto(false);
            }
        }

        private void SetCallSpeed(object sender, RoutedEventArgs e)
        {
            if (CallSpeeedSliderOff == true)
            { 
                CallSpeeedSliderOff = false;
            }
            else
            {
                SaveCallSpeed((byte)CallSpeedSlider.Value);
            }

        }

        private async void SetDefult()
        {
            LButton.IsChecked = false;
            DButton.IsChecked = false;
            LDSButton.IsChecked = true;
            CallModeSelector.IsOn = false;
            CallSpeedSlider.Value = 75;
            MottoSelector.IsOn = false;
            BGOpacitySlider.Value = 0.5;
            StyledGrid.SelectedIndex = -1;
            SpeakerVolumeSlider.Value = 100;
            SpeakerRateSlider.Value = 0;
            DefautPageOutput.Text = "主页";
            _ =
   Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile DefaultPageData = await localFolder.CreateFileAsync("DefaultPageSetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(DefaultPageData, "C1OS.HomePage");

            NoNameTeam = false;
            Fun = false;
            Moving = false;
            PopulateProjects();
        }

        private async void OpenDefult(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new()
            {
                // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
                XamlRoot = this.XamlRoot,
                Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                Title = "恢复默认？",
                Content = "将把所有设置恢复到默认状态，此操作不可逆，确认继续？",
                PrimaryButtonText = "我知道我在做什么！",
                CloseButtonText = "取消",
                DefaultButton = ContentDialogButton.Primary,
            };
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                SetDefult();
            }
        }

        async void ReadCallSpeed()
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFile CallSpeedData = await localFolder.GetFileAsync("CallSpeedSetting.ini");
                String SpeedS = await FileIO.ReadTextAsync(CallSpeedData);
                // Data is contained in SpeedS
                CallSpeed = double.Parse(SpeedS);
                CallSpeeedSliderOff = true;
                CallSpeedSlider.Value = CallSpeed;
            }
            catch (Exception)
            {
                // SpeedS not found
                CallSpeedSlider.Value = 75;
            }
        }

        async void ReadCallMode()
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
               Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFile CallModeData = await localFolder.GetFileAsync("CallModeSetting.ini");
                String ModeS = await FileIO.ReadTextAsync(CallModeData);
                // Data is contained in ModeS
                if (ModeS == "True")
                {
                    CallModeSelector.IsOn = true;
                }
                else
                {
                    CallModeSelector.IsOn = false;
                }

            }
            catch (Exception)
            {
                // ModeS not found
                CallModeSelector.IsOn = false;
            }
        }

        async void ReadMotto()
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
               Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFile MottoData = await localFolder.GetFileAsync("MottoSetting.ini");
                String OpenS = await FileIO.ReadTextAsync(MottoData);
                // Data is contained in OpenS
                if (OpenS == "True")
                {
                    MottoSelector.IsOn = true;
                }
                else
                {
                    MottoSelector.IsOn = false;
                }

            }
            catch (Exception)
            {
                // OpenS not found
                MottoSelector.IsOn = false;
            }
        }


        async void ReadLD()
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
                    LButton.IsChecked = true;
                    DButton.IsChecked = false;
                    LDSButton.IsChecked = false;
                }
                else if (LDS == "1")
                {
                    LButton.IsChecked = false;
                    DButton.IsChecked = true;
                    LDSButton.IsChecked = false;
                }
                else
                {
                    LButton.IsChecked = false;
                    DButton.IsChecked = false;
                    LDSButton.IsChecked = true;
                }

            }
            catch (Exception)
            {
                LButton.IsChecked = false;
                DButton.IsChecked = false;
                LDSButton.IsChecked = true;
                SaveLD(0);
            }
        }

        public async void SetSpeakerVolume(object sender, RoutedEventArgs e)
        {
            _ =
    Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;

            speaker.Volume = Convert.ToInt16(SpeakerVolumeSlider.Value);

            

            String SpeakerVolumeS = speaker.Volume.ToString();

            StorageFile SpeakerVolumeData = await localFolder.CreateFileAsync("SpeakerVolumeSetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(SpeakerVolumeData, SpeakerVolumeS);
        }

        public async void SetSpeakerRate(object sender, RoutedEventArgs e)
        {
            _ =
    Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;

            speaker.Rate = Convert.ToInt16(SpeakerRateSlider.Value);
            String SpeakerRateS = speaker.Rate.ToString();

            StorageFile SpeakerRateData = await localFolder.CreateFileAsync("SpeakerRateSetting.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(SpeakerRateData, SpeakerRateS);
        }

        async void ReadSpeakerVolume()
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
               Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFile SpeakerVolumeData = await localFolder.GetFileAsync("SpeakerVolumeSetting.ini");
                String SpeakerVolumeS = await FileIO.ReadTextAsync(SpeakerVolumeData);
                // Data is contained in SpeedS
                try
                {
                    speaker.Volume = Convert.ToInt16(SpeakerVolumeS);
                    SpeakerVolumeSlider.Value = speaker.Volume;
                }
                catch (Exception)
                {
                    SpeakerVolumeSlider.Value = 100;
                }
            }
            catch (Exception)
            {
                SpeakerVolumeSlider.Value = 100;
            }
        }
        
        async void ReadSpeakerRate()
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
               Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFile SpeakerRateData = await localFolder.GetFileAsync("SpeakerRateSetting.ini");
                String SpeakerRateS = await FileIO.ReadTextAsync(SpeakerRateData);
                // Data is contained in SpeedS
                try
                {
                    speaker.Rate = Convert.ToInt16(SpeakerRateS);
                    SpeakerRateSlider.Value = speaker.Rate;
                }
                catch (Exception)
                {
                    SpeakerRateSlider.Value = 0;
                }
            }
            catch (Exception)
            {
                SpeakerRateSlider.Value = 0;
            }
        }

        async void ReadBG()
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
               Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFile BGData = await localFolder.GetFileAsync("BGSetting.ini");
                String file = await FileIO.ReadTextAsync(BGData);
                // Data is contained in SpeedS
                try
                {
                    List<string> Locations = [];
                    foreach (Project x in Projects)
                    {
                        Locations.Add(GetUriPath(x.ImageLocation));
                    }
                    StyledGrid.SelectedIndex = Locations.FindIndex(x => x != null && x == file);
                }
                catch (Exception)
                {
                    StyledGrid.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {
                StyledGrid.SelectedIndex = -1;
            }
        }

         async void ReadSpeaker()
         {
             try
             {
                Windows.Storage.ApplicationDataContainer localSettings =
              Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFile SpeakerData = await localFolder.GetFileAsync("SpeakerSetting.ini");
                string Speaker = await FileIO.ReadTextAsync(SpeakerData);
                // Data is contained in SpeedS
                 try
                 {
                    SpeakerLoading = true;
                    SpeakerSelect.SelectedIndex = Speakers.IndexOf(Speaker);
                    if (SpeakerSelect.SelectedIndex == -1)
                    {
                        SpeakerLoading = false;
                    }
                 }
                 catch (Exception)
                 {
                     SpeakerSelect.SelectedIndex = -1;
                 }
             }
             catch (Exception)
             {
                SpeakerSelect.SelectedIndex = -1;
            }
         }
    }
}
