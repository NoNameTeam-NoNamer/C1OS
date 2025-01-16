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
using System.CodeDom.Compiler;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Windows.Storage;
using Windows.Devices.Enumeration;
using System.Threading;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace C1OS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CardPage : Page
    {
        readonly List<string> names = ["王展博","黄睿","李孟嵘","郭卓言","刘珈","陈晨","汪熙润","谢东岑","尚雅涵","李米佳","方乐姗","张研琦","温幸昕","刘筱茹","蒋帛益","杨子健","尤优江语","吴晓雅","张泽洋","邵铎","余佳鸿","梁爽","叶依彤","刘妍溪","罗宇翰","王翊天","陈力坤","伍仕婕","褚若曦","马熙媛","李琳达","邓业帆","宋兆祥","孙语晨","王悠冉"];
        readonly List<int> numbers = [];
        List<string> print = [];
        string Speaker = null;
#pragma warning disable IDE0044 // 添加只读修饰符
        private static System.Speech.Synthesis.SpeechSynthesizer speaker = new();
#pragma warning restore IDE0044 // 添加只读修饰符
        public CardPage()
        {
            this.InitializeComponent();
            ReadSpeaker();
            ReadSpeakerVolume();
            ReadSpeakerRate();
            speaker.SetOutputToDefaultAudioDevice();
            GenerateNumbers();
        }

        private void SelectName(object sender, SelectionChangedEventArgs e)
        {
            if (StyledGrid.SelectedIndex != -1)
            {
                switch (print[StyledGrid.SelectedIndex])
                {
                    case "⟳":
                        GenerateNumbers();
                        break;

                    case "?":
                        print[StyledGrid.SelectedIndex] = names[numbers[StyledGrid.SelectedIndex]];
                        speaker.SpeakAsyncCancelAll();
                        speaker.SpeakAsync(print[StyledGrid.SelectedIndex]);
                        StyledGrid.ItemsSource = null;
                        StyledGrid.ItemsSource = print;
                        break;

                    case "⊙":
                        print[StyledGrid.SelectedIndex] = names[numbers[StyledGrid.SelectedIndex]];
                        StyledGrid.ItemsSource = null;
                        StyledGrid.ItemsSource = print;
                        break;

                    default:
                        print[StyledGrid.SelectedIndex] = "⊙";
                        StyledGrid.ItemsSource = null;
                        StyledGrid.ItemsSource = print;
                        break;
                }
            }
        }

        public static IEnumerable<int>
  GenerateNoDuplicateRandom(int minValue, int maxValue)
        {
            return Enumerable.Range(minValue, maxValue).OrderBy(g => Guid.NewGuid());
        }

        void GenerateNumbers() 
        {
            numbers.Clear();
            IEnumerable<int> ran = GenerateNoDuplicateRandom(0, 35);
            print = [];
            foreach (int i in ran)
            {
                numbers.Add(i);
                print.Add("?");
            }
            print.Add("⟳");
            StyledGrid.ItemsSource = print;
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
                Speaker = await FileIO.ReadTextAsync(SpeakerData);
                // Data is contained in file
                if (Speaker != null)
                {
                    speaker.SelectVoice(Speaker);
                }
            }
            catch (Exception) { }
        }

        static async void ReadSpeakerVolume()
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
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }
        }

        static async void ReadSpeakerRate()
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
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
