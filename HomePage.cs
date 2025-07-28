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
using Windows.Devices.Enumeration;
using Microsoft.UI.Xaml.Media.Animation;
using Windows.Storage;
using Microsoft.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace C1OS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public bool Motto;
        DispatcherTimer dispatcherTimer;
        public HomePage()
        {
            this.InitializeComponent();
            DispatcherTimerSetup();
        }

        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 5000);
            //IsEnabled defaults to false
            dispatcherTimer.Start();
            //IsEnabled should now be true after calling start
        }

        public static string GetRandom(string[] arr)
        {
            Random ran = new();
            int n = ran.Next(arr.Length - 1);
            return arr[n];
        }

        void DispatcherTimer_Tick(object sender, object e)
        {
            ReadMotto();
            if (Motto == true)
            {
                MottoShow.Text = GetRandom(Mottos);
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
                    Motto = true;
                    MottoShow.Visibility = Visibility.Visible;
                }
                else
                {
                    Motto = false;
                    MottoShow.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception)
            {
                // OpenS not found
                Motto = false;
                MottoShow.Visibility = Visibility.Collapsed;
            }
        }

        //Write mottos here!
        readonly string[] Mottos = [
        "梦开始的地方",
        "Just do it.",
        "青春没有售价，扣1复活牢大",
        "No Pain,No Gain.",
        "Impossible is nothing.",
        "学习，思考，实践，反思",
        "静·净·敬·劲·竞·进",
        "为中华之崛起而读书",
        "想要主播内卷年级前10的课程",
        "思想迸发",
        "不只是一个系统",
        "回忆是最好的教训",
        "勇于做出决断，才能拥抱美好",
        "语文大师，文以载道",
        "物理大师，格物致知",
        "鸿运当头陆陆陆",
        "不以物喜，不以己悲",
        "主线任务：奋斗初三   ◎进行中",
        "上亚迪初三，品勤劳人生",
        "你准备好 桌面清空 了吗？",
        "背书！",
        "你可以的！再过一学年你就要去高中更刻苦地学习了！",
        "👆🤓我有一计",
        "科技助力学习",
        "风雨过后是彩虹，勤奋过后是回报",
        "再不内卷就要被23456789班〿〿〿〿了",
        "别催了，新版本在做了",
        "请开始你的表演",
        "谨防以下三种诈骗：考试难度预估，作业量减少，体育老师的“最后”",
        "相信自己，依靠自己，你的世界由你体验，就要由你做主",
        "休息2.5s，让我想想What can I say?",
        "初三努力一年，才能适应更努力的高中",
        "告别过去，奋斗当下，迎接未来"];


    }
}
