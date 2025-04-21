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
using Windows.Media.SpeechSynthesis;
using System.Timers;
using Microsoft.UI.Xaml.Media.Animation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Windows.ApplicationModel.ConversationalAgent;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using Windows.Storage;
using Windows.ApplicationModel.Activation;
using System.Speech;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;   
using System.Speech.AudioFormat;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace C1OS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CallPage : Page
    {
        int id = 34;
        int stop = 0;
        bool Mode = false;
        byte Speed = 75;
        string Speaker = null;
        DispatcherTimer dispatcherTimer;

#pragma warning disable IDE0044 // Ìí¼ÓÖ»¶ÁÐÞÊÎ·û
        private static System.Speech.Synthesis.SpeechSynthesizer speaker = new();
#pragma warning restore IDE0044 // Ìí¼ÓÖ»¶ÁÐÞÊÎ·û
        readonly List<string> names = ["ÍõÕ¹²©", "»Æî£", "ÀîÃÏáÉ", "¹ù×¿ÑÔ", "Áõçì", "³Â³¿", "ÍôÎõÈó", "Ð»¶«á¯", "ÉÐÑÅº­", "ÀîÃ×¼Ñ", "·½ÀÖæ©", "ÕÅÑÐçù", "ÎÂÐÒê¿", "ÁõóãÈã", "½¯²¯Òæ", "Ñî×Ó½¡", "ÓÈÓÅ½­Óï", "ÎâÏþÑÅ", "ÕÅÔóÑó", "ÉÛîì", "Óà¼Ñºè", "ÁºË¬", "Ò¶ÒÀÍ®", "ÁõåûÏª", "ÂÞÓîº²", "Íõñ´Ìì", "³ÂÁ¦À¤", "ÎéÊËæ¼", "ñÒÈôêØ", "ÂíÎõæÂ", "ÀîÁÕ´ï", "µËÒµ·«", "ËÎÕ×Ïé", "ËïÓï³¿", "ÍõÓÆÈ½"];

        public CallPage()
        {
            this.InitializeComponent();
            speaker.SetOutputToDefaultAudioDevice();
        }
        async Task ReadCallMode()
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
                    Mode = true;
                }
                else
                {
                    Mode = false;
                }

            }
            catch (Exception)
            {
                // ModeS not found
                Mode = false ;
            }
        }

        async Task ReadCallSpeed()
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
                try
                {
                    Speed = Convert.ToByte(SpeedS);
                }
                catch (Exception)
                {
                    Speed = 75;
                }
                }
            catch (Exception)
            {
                // SpeedS not found
                Speed = 75;
            }
        }

        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, Speed);
            //IsEnabled defaults to false
            dispatcherTimer.Start();
            //IsEnabled should now be true after calling start
        }

        void DispatcherTimer_Tick(object sender, object e)
        {
            if (stop == 0)
            {
                if(Mode == true)
                {
                    Random ran = new();
                    id = ran.Next(0, 34);
                }
                else
                {
                    id += 1;
                    if (id >34 || id < 0)
                    {
                        id = 0;
                    }
                }
                NameOut.Text = names[id];
            }
            else
            {
                if (stop == 1 || stop == 3)
                {
                    stop += 1;
                    NameOut.Visibility = Visibility.Collapsed;
                }
                else
                {
                    stop += 1;
                    NameOut.Visibility = Visibility.Visible;
                    if (stop >= 4)
                    { 
                        dispatcherTimer.Stop();
                        stop = 0;
                        Caller.Visibility = Visibility.Visible;
                    }
                }

            }
        }

        private async void CALL(object sender, RoutedEventArgs e)
        {
            await CALL_Task();
        }

        private async Task CALL_Task()
        {
            await ReadCallMode();
            await ReadCallSpeed();
            await ReadSpeaker();
            await ReadSpeakerVolume();
            await ReadSpeakerRate();
            if (Caller.Content.ToString() == "µãÃû")
            {
                NameOut.Visibility = Visibility.Visible;
                Caller.Content = "Í£";
                DispatcherTimerSetup();
                speaker.SpeakAsyncCancelAll();
            }
            else
            {
                stop = 1;
                Caller.Visibility = Visibility.Collapsed;
                Caller.Content = "µãÃû";
                speaker.SpeakAsync(NameOut.Text);
            }
        }

        async Task ReadSpeaker()
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

        static async Task ReadSpeakerVolume()
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

        static async Task ReadSpeakerRate()
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



