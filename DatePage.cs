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
using System.Security.Cryptography;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace C1OS
{
    public class Timer
    {
        public string Name { get; set; }
        public DateTime ArrivalDateTime { get; set; }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DatePage : Page
    {
        DispatcherTimer dispatcherTimer;
        DateTime arrivalDateTime = DateTime.Now;
        TimeSpan dif;
        private readonly List<Timer> Timers = [];

        public DatePage()
        {
            this.InitializeComponent();
            // Set minimum to the current year.
            arrivalDatePicker.MinYear = DateTimeOffset.Now;
            arrivalDatePicker.SelectedDate = DateTime.Now.Date;
            arrivalTimePicker.SelectedTime = DateTime.Now.TimeOfDay;
            DispatcherTimerSetup();
        }

        private void SelectTimer(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ArrivalTimePicker_SelectedTimeChanged(TimePicker sender, TimePickerSelectedValueChangedEventArgs args)
        {
            if (arrivalTimePicker.SelectedTime != null)
            {
                arrivalDateTime = new DateTime(arrivalDateTime.Year, arrivalDateTime.Month, arrivalDateTime.Day,
                                               args.NewTime.Value.Hours, args.NewTime.Value.Minutes, args.NewTime.Value.Seconds);
            }
        }

        private void OpenEditor(object sender, RoutedEventArgs e)
        {
            if(TimerEditor.Visibility != Visibility.Visible)
            { TimerEditor.Visibility = Visibility.Visible;}
            else { TimerEditor.Visibility = Visibility.Collapsed; }
        }
        private void Create(object sender, RoutedEventArgs e)
        {
            if (VerifyDateIsFuture(arrivalDateTime) == true)
            {
                if (TimerNameSet.Text != String.Empty)
                {
                    arrivalText.Text = "设置成功！\n功能开发中，计时器不会保存！";
                    Timer x = new()
                    {
                        Name = TimerNameSet.Text,
                        ArrivalDateTime = arrivalDateTime
                    };
                    Timers.Add(x);
                    TimerSelect.ItemsSource = null;
                    TimerSelect.ItemsSource = Timers;
                }
                else 
                {
                    arrivalText.Text = "请输入名称！";
                }
            }
            else
            {
                arrivalText.Text = "指定时间应当晚于现在！";
            }


        }

        private void ArrivalDatePicker_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            if (arrivalDatePicker.SelectedDate != null)
            {
                    arrivalDateTime = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day,
                                                   arrivalDateTime.Hour, arrivalDateTime.Minute, arrivalDateTime.Second);
            }
        }

        private static bool VerifyDateIsFuture(DateTime date)
        {
            if (date > DateTime.Now)
            {
                return true;
            }
            return false;
        }

        private void ClearDateButton_Click(object sender, RoutedEventArgs e)
        {
            arrivalDateTime = DateTime.Now;
            arrivalDatePicker.SelectedDate = DateTime.Now.Date;
            arrivalTimePicker.SelectedTime = DateTime.Now.TimeOfDay;
            arrivalText.Text = string.Empty;
            TimerNameSet.Text = string.Empty;
        }
        // 预估死亡时间 2025.6.18 8:30
        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            //IsEnabled defaults to false
            dispatcherTimer.Start();
            //IsEnabled should now be true after calling start
        }

        void Tick(object sender, object e)
        {
            if (VerifyDateIsFuture(new DateTime(2025, 6, 18, 8, 30, 0)) == true)
            {
                dif = new DateTime(2025, 6, 18, 8, 30, 0) - DateTime.Now;
                DeadTimeOutput.Text = $"距离 中考 还有{dif.Days}天{dif.Hours}时{dif.Minutes}分{dif.Seconds}秒";

            }
            else 
            {
                dif = DateTime.Now - new DateTime(2025, 6, 18, 8, 30, 0);
                DeadTimeOutput.Text = $"距离 中考 已过{dif.Days}天{dif.Hours}时{dif.Minutes}分{dif.Seconds}秒";
            }
            if (Timers.Count > 0)
            {
                foreach (Timer timer in Timers) 
                {
                    DateTime time = timer.ArrivalDateTime;
                    String name = timer.Name;
                    if (VerifyDateIsFuture(time) == true)
                    {
                        dif = time - DateTime.Now;
                        DeadTimeOutput.Text += $"\n距离 {name} 还有{dif.Days}天{dif.Hours}时{dif.Minutes}分{dif.Seconds}秒";

                    }
                    else
                    {
                        dif = DateTime.Now - time;
                        DeadTimeOutput.Text += $"\n距离 {name} 已过{dif.Days}天{dif.Hours}时{dif.Minutes}分{dif.Seconds}秒";
                    }
                }
            }
        }
    }
}
