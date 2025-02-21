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
using Windows.Storage;
using System.Diagnostics.Eventing.Reader;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace C1OS
{
    public class Timer
    {
        public string Name { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public bool AutoDelete { get; set; }
        public TimeSpan DeleteTime { get; set; }
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
        int Selected = -1;

        public DatePage()
        {
            this.InitializeComponent();
            // Set minimum to the current year.
            arrivalDatePicker.MinYear = DateTimeOffset.Now;
            arrivalDatePicker.SelectedDate = DateTime.Now.Date;
            arrivalTimePicker.SelectedTime = DateTime.Now.TimeOfDay;
            Read();
            DispatcherTimerSetup();
        }

        private void SelectTimer(object sender, SelectionChangedEventArgs e)
        {
            if (TimerSelect.SelectedIndex == -1)
            {
                EditButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
            else
            {
                EditButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
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
            { 
                TimerEditor.Visibility = Visibility.Visible;
                Editor.Visibility = Visibility.Collapsed;
                DeadTimeOutput.Visibility = Visibility.Collapsed;
                EditorOpener.Content = "�رձ༭��";
            }
            else 
            {
                TimerEditor.Visibility = Visibility.Collapsed;
                DeadTimeOutput.Visibility = Visibility.Visible;
                TimerSelect.SelectedIndex = -1;
                Selected = -1;
                EditorOpener.Content = "�༭��ʱ��";
            }
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            TimerSelect.SelectedIndex = -1;
            Selected = -1;
            Editor.Visibility = Visibility.Visible;
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            Selected = TimerSelect.SelectedIndex;
            Editor.Visibility = Visibility.Visible;
            arrivalDatePicker.SelectedDate = Timers[Selected].ArrivalDateTime;
            arrivalTimePicker.SelectedTime = new TimeSpan(Timers[Selected].ArrivalDateTime.Hour, Timers[Selected].ArrivalDateTime.Minute, Timers[Selected].ArrivalDateTime.Second);
            TimerNameSet.Text = Timers[Selected].Name;
            
            if (Timers[Selected].AutoDelete == true)
            {
                AutoDeleteChecker.IsChecked = true;
                DeleteTimeEditor.Visibility = Visibility.Visible;
                DeleteDaySet.Value = Timers[Selected].DeleteTime.Days;
                DeleteTimePicker.SelectedTime = new TimeSpan(Timers[Selected].DeleteTime.Hours, Timers[Selected].DeleteTime.Minutes, Timers[Selected].DeleteTime.Seconds);
            }
            else
            {
                AutoDeleteChecker.IsChecked = false;
                DeleteTimeEditor.Visibility = Visibility.Collapsed;
                DeleteDaySet.Value = 0;
                DeleteTimePicker.SelectedTime = TimeSpan.Zero;
            }
        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            Selected = TimerSelect.SelectedIndex;
            ContentDialog dialog = new()
            {
                // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
                XamlRoot = this.XamlRoot,
                Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                Title = $"��ȷ��Ҫɾ����ʱ����",
                Content = $"��ɾ����ʱ����{Timers[Selected].Name}�����˲��������棡",
                PrimaryButtonText = "ȷ��",
                CloseButtonText = "ȡ��",
                DefaultButton = ContentDialogButton.Primary
            };

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Timers.RemoveAt(Selected);
                Save();
                TimerSelect.ItemsSource = null;
                TimerSelect.ItemsSource = Timers;
                TimerSelect.SelectedIndex = -1;
                Selected = -1;
            }
        }

        private void HideEditor(object sender, RoutedEventArgs e)
        {
            Editor.Visibility = Visibility.Collapsed;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (VerifyDateIsFuture(arrivalDateTime) == true)
            {
                if (TimerNameSet.Text != String.Empty)
                {
                    if (TimerNameSet.Text.Contains('��'))
                    {
                        arrivalText.Text = "�����в��������������(U+3000,ȫ�ǿո�)��";
                        return;
                    }
                    Timer x = new()
                    {
                        Name = TimerNameSet.Text,
                        ArrivalDateTime = arrivalDateTime
                    };
                    if (AutoDeleteChecker.IsChecked == true)
                    {
                        x.AutoDelete = true;
                        x.DeleteTime = DeleteTimePicker.Time;
                        if (DeleteDaySet.Text != null)
                        {
                            x.DeleteTime += new TimeSpan((int)Math.Round(DeleteDaySet.Value),0,0,0);
                        }
                    }
                    else
                    {
                        x.AutoDelete = false;
                        x.DeleteTime = new TimeSpan(0);
                    }
                    if (Selected == -1)
                    { Timers.Add(x); }
                    else 
                    { Timers[Selected] = x; }
                    Save();
                    TimerSelect.ItemsSource = null;
                    TimerSelect.ItemsSource = Timers;
                    arrivalText.Text = "";
                    Editor.Visibility = Visibility.Collapsed;
                }
                else 
                {
                    arrivalText.Text = "���������ƣ�";
                }
            }
            else
            {
                arrivalText.Text = "ָ��ʱ��Ӧ���������ڣ�";
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

        private void OpenAutoDeleteEditor(object sender, RoutedEventArgs e)
        {
            DeleteTimeEditor.Visibility = Visibility.Visible;
        }

        private void CloseAutoDeleteEditor(object sender, RoutedEventArgs e)
        {
            DeleteTimeEditor.Visibility = Visibility.Collapsed;
        }

        private void ClearDateButton_Click(object sender, RoutedEventArgs e)
        {
            arrivalDateTime = DateTime.Now;
            arrivalDatePicker.SelectedDate = DateTime.Now.Date;
            arrivalTimePicker.SelectedTime = DateTime.Now.TimeOfDay;
            arrivalText.Text = string.Empty;
            TimerNameSet.Text = string.Empty;
        }
        // Ԥ������ʱ�� 2025.6.16 8:30
        private void DispatcherTimerSetup()
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
                dif = new DateTime(2025, 6, 16, 8, 30, 0) - DateTime.Now;
                DeadTimeOutput.Text = $"���� �п� ����{dif.Days}��{dif.Hours}ʱ{dif.Minutes}��{dif.Seconds}��";

            }
            else 
            {
                dif = DateTime.Now - new DateTime(2025, 6, 16, 8, 30, 0);
                DeadTimeOutput.Text = $"���� �п� �ѹ�{dif.Days}��{dif.Hours}ʱ{dif.Minutes}��{dif.Seconds}��";
            }
            if (Timers.Count > 0)
            {
                for (var i = 0;i < Timers.Count;i++) 
                {
                    Timer timer = Timers[i];
                    DateTime time = timer.ArrivalDateTime;
                    String name = timer.Name;
                    if (VerifyDateIsFuture(time) == true)
                    {
                        dif = time - DateTime.Now;
                        DeadTimeOutput.Text += $"\n���� {name} ����{dif.Days}��{dif.Hours}ʱ{dif.Minutes}��{dif.Seconds}��";

                    }
                    else
                    {
                        dif = DateTime.Now - time;
                        if (timer.AutoDelete == true && timer.DeleteTime <= dif)
                        {
                            if (Selected == -1)
                            {
                                Selected = Timers.IndexOf(timer);
                                Timers.RemoveAt(Selected);
                                Save();
                                Selected = -1;
                                TimerSelect.ItemsSource = null;
                                TimerSelect.ItemsSource = Timers;
                                i--;
                            }
                        }
                        else { DeadTimeOutput.Text += $"\n���� {name} �ѹ�{dif.Days}��{dif.Hours}ʱ{dif.Minutes}��{dif.Seconds}��"; }
                    }
                }
            }
        }

        public async void Save()
        {
            _ =
    Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                 Windows.Storage.ApplicationData.Current.LocalFolder;

            string DateS = null;
            foreach (Timer timer in Timers)
            {
                DateS += timer.Name;
                DateS += "��";
                DateS += timer.ArrivalDateTime.ToString();
                DateS += "��";
                if (timer.AutoDelete == false)
                {
                    DateS += "*";
                    DateS += "��";
                }
                else 
                {
                    DateS += timer.DeleteTime.ToString();
                    DateS += "��";
                }
            }


            StorageFile DateData = await localFolder.CreateFileAsync("Date.ini",
               CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(DateData, DateS);
        }

        private async void Read()
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings =
               Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                     Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFile DateData = await localFolder.GetFileAsync("Date.ini");
                String DateS = await FileIO.ReadTextAsync(DateData);
                // Data is contained in DateS
                try
                {
                    String[] Data = DateS.Split("��");
                    if ((Data.Length-1) % 3 == 0)
                    {
                        for (int i = 0; i < Data.Length - 1;)
                        {
                            Timer s = new()
                            {
                                Name = Data[i]
                            };
                            i++;
                            s.ArrivalDateTime = Convert.ToDateTime(Data[i]);
                            i++;
                            if (Data[i] == "*")
                            {
                                s.AutoDelete = false;
                                s.DeleteTime = TimeSpan.Zero;
                            }
                            else
                            {
                                s.AutoDelete = true;
                                s.DeleteTime = TimeSpan.Parse(Data[i]);
                            }
                            i++;
                            Timers.Add(s);
                        }
                    }
                    TimerSelect.ItemsSource = null;
                    TimerSelect.ItemsSource = Timers;
                }
                catch (Exception){}
            }
            catch (Exception){}
        }
    }
}
