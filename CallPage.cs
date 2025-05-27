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
using System.Diagnostics;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace C1OS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CallPage : Page
    {
        int id = 34,stop = 0;
        bool Mode = false, isSpinning, a = false, b = false, c = false, d = false, CallVersion;
        byte Speed = 75;
        string Speaker = null;
        DispatcherTimer dispatcherTimer;

#pragma warning disable IDE0044 // ���ֻ�����η�
        private static System.Speech.Synthesis.SpeechSynthesizer speaker = new();
#pragma warning restore IDE0044 // ���ֻ�����η�
        private readonly List<string> names = ["��չ��", "���", "������", "��׿��", "����", "�³�", "������", "л���", "���ź�", "���׼�", "�����", "������", "�����", "������", "������", "���ӽ�", "���Ž���", "������", "������", "����", "��Ѻ�", "��ˬ", "Ҷ��ͮ", "����Ϫ", "���", "�����", "������", "�����", "������", "������", "���մ�", "��ҵ��", "������", "���ﳿ", "����Ƚ"];
        // ������Դ��ȡ�����к��ֳ�
        private readonly List<char> characterPool = [];
        private readonly Random random = new();
        private char[] currentChars = new char[4];
        private DispatcherTimer spinTimer;
        public CallPage()
        {
            this.InitializeComponent();
            InitializeCharacterPool();
            InitializeReels();
            speaker.SetOutputToDefaultAudioDevice();
            // Initialize spinTimer with a default value
            spinTimer = new DispatcherTimer();
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

        async Task ReadCallVersion()
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
               Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFile CallVersionData = await localFolder.GetFileAsync("CallVersionSetting.ini");
                String VersionS = await FileIO.ReadTextAsync(CallVersionData);
                // Data is contained in VersionS
                if (VersionS == "True")
                {
                    CallVersion = true;
                }
                else
                {
                    CallVersion = false;
                }

            }
            catch (Exception)
            {
                // VersionS not found
                CallVersion = false;
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
            dispatcherTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(Speed) };
            dispatcherTimer.Tick += (s, e) => DispatcherTimer_Tick();
            //IsEnabled defaults to false
            dispatcherTimer.Start();
            //IsEnabled should now be true after calling start
        }

        void DispatcherTimer_Tick()
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
            await ReadCallVersion();
            await ReadCallSpeed();
            await ReadSpeaker();
            await ReadSpeakerVolume();
            await ReadSpeakerRate();
            if (Caller.Content.ToString() == "����")
            {
                Caller.Content = "ͣ";
                speaker.SpeakAsyncCancelAll();
                if (CallVersion == false)
                {
                    NameOut.Visibility = Visibility.Visible;
                    FlipViews.Visibility = Visibility.Collapsed;
                    DispatcherTimerSetup();
                }
                else {
                    NameOut.Visibility = Visibility.Collapsed;
                    FlipViews.Visibility = Visibility.Visible; 
                    StartSpin(); }
            }
            else
            {
                if (CallVersion == false)
                {
                    Caller.Visibility = Visibility.Collapsed;
                    stop = 1;
                    speaker.SpeakAsync(NameOut.Text);
                }
                else { Caller.IsEnabled = false; await StopSpin(); }
                Caller.Content = "����";
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

        //New Version
        // ������Դ��ȡ���к��֣�ȥ�أ�
        private void InitializeCharacterPool()
        {
            foreach (var name in names)
            {
                foreach (var c in name)
                {
                    if (!characterPool.Contains(c))
                        characterPool.Add(c);
                }
            }
        }

        // ��ʼ��ת�̿ؼ�
        private void InitializeReels()
        {
            InitializeReel(Reel1);
            InitializeReel(Reel2);
            InitializeReel(Reel3);
            InitializeReel(Reel4);
        }

        // ���ô�ֱ����Ч��
        // �޸�ItemsPanelTemplate��ʼ��
        private static void InitializeReel(FlipView reel)
        {
            if (reel == null) return;

            reel.ItemsSource = new List<char> { ' ' };
            reel.SelectedIndex = 0;

            // ǿ��ˢ�²���
            reel.UpdateLayout();
        }

        private void StartSpin()
        {
            if (isSpinning) return;
            isSpinning = true;
            a = b = c = d = false;
            var name = names[random.Next(names.Count)];
            PrepareReels(name);
            StartSpinning();
        }


        // ���ȱʧ��GetReel����
        private FlipView GetReel(int index) => index switch
        {
            0 => Reel1,
            1 => Reel2,
            2 => Reel3,
            3 => Reel4,
            _ => Reel1
        };

        // ���Shuffle����ʵ��
        private void Shuffle(List<char> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }

        private void PrepareReels(string name)
        {
            // ����Ŀ���ַ�����
            currentChars = name.Length switch
            {
                2 => [' ', name[0], name[1], ' '],
                3 => [' ', name[0], name[1], name[2]],
                4 => name.ToCharArray(),
                _ => [' ', ' ', ' ', ' ']
            };

            // Ϊÿ��ת������������ݣ�������Դ���ֳس�ȡ��
            var allChars = currentChars.Concat(GetRandomCharacters()).ToList();
            Shuffle(allChars);

            _ = UpdateReel(Reel1, allChars);
            _ = UpdateReel(Reel2, allChars);
            _ = UpdateReel(Reel3, allChars);
            _ = UpdateReel(Reel4, allChars);
        }

        // ������Դ���ֳػ�ȡ����ַ�
        private List<char> GetRandomCharacters()
        {
            if (characterPool.Count == 0) return [];

            return [.. Enumerable.Range(0, 35).Select(_ => characterPool[random.Next(characterPool.Count)])];
        }

        private async Task UpdateReel(FlipView reel, List<char> chars)
        {
            reel.ItemsSource = chars;
            await Task.Delay(50); // ÿ��ת��ֹͣ���
            reel.SelectedIndex = random.Next(chars.Count);
        }

        private void StartSpinning()
        {
            spinTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(Speed*0.75) };
            spinTimer.Tick += (s, e) => FastSpin();
            spinTimer.Start();
        }

        // ����ֹͣ��ť�¼�����
        private async Task StopSpin()
        {
            if (!isSpinning) return;
            await StopSpinning();
            isSpinning = false;
            Caller.IsEnabled = true;
        }

        private void FastSpin()
        {
            bool e = false;
            if (a == false)
            {
                SpinReel(Reel1);
                e = true;
            }
            if (b == false)
            {
                SpinReel(Reel2);
                e = true;
            }
            if (c == false)
            {
                SpinReel(Reel3);
                e = true;
            }
            if (d == false)
            {
                SpinReel(Reel4);
                e = true;
            }
            if (e == false)
            {
                spinTimer.Stop();
            }
        }

        private void SpinReel(FlipView reel)
        {
            if (reel?.Items?.Count == 0 || reel == null) return;

            try
            {
                var newIndex = (reel.SelectedIndex + random.Next(1, 3)) % reel.Items.Count;
                reel.SelectedIndex = Math.Clamp(newIndex, 0, reel.Items.Count - 1);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"��ת�쳣: {ex.Message}");
            }
        }

        private async Task StopSpinning()
        {
            var stopOrder = currentChars.Count(c => c != ' ') switch
            {
                2 => [0, 3, 1, 2], // ������ֹͣ˳��
                3 => [0, 1, 2, 3],  // ������
                4 => [0, 1, 2, 3],  // ������
                _ => new[] { 0, 1, 2, 3 }
            };

            foreach (var index in stopOrder)
            {
                if (index == 0) { a = true; }
                else if (index == 1) { b = true; }
                else if (index == 2) { c = true; }
                else if (index == 3) { d = true; }
                var reel = GetReel(index);
                var targetChar = currentChars[index];
                // ֹͣ��ǰת�̲��ȴ�
                _ = StopSingleReel(reel, targetChar);
                await Task.Delay(Speed*15); // ÿ��ת��ֹͣ���
                speaker.SpeakAsyncCancelAll();
            }
        }

        private static async Task StopSingleReel(FlipView reel, char targetChar)
        {
            if (reel?.ItemsSource is not IList<char> items) return;

            int targetIndex = items.IndexOf(targetChar);
            if (targetIndex == -1) return;

            // ��λ��Ŀ��λ��
            reel.SelectedIndex = targetIndex;
            await Task.Delay(75); // ÿ��ת��ֹͣ���
            speaker.SpeakAsync(targetChar.ToString());
        }

    }
}



