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
using System.Timers;
using Windows.Media.Core;
using Windows.Media.Playback;
using System.ComponentModel.Design;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace C1OS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RingPage : Page
    {
        int ReadyTime = 0;
        int TestTime = 0;
        int ReadyTimeNow = 0;
        int TestTimeNow = 0;
        DispatcherTimer TestTimer;
        double fun = 0;
#pragma warning disable IDE0052 // ɾ��δ����˽�г�Ա
        int fun2;
#pragma warning restore IDE0052 // ɾ��δ����˽�г�Ա
        string fun3;
        byte step = 0;
        DateTime arrivalDateTime = DateTime.Now;
        TimeSpan dif;
        private readonly MediaPlayer mediaPlayer = new();

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
            TimerEditor.Visibility = Visibility.Visible;
            ReadyTimeImput.Visibility = Visibility.Collapsed;
        }

        private void CloseEditor(object sender, RoutedEventArgs e)
        {
            TimerEditor.Visibility = Visibility.Collapsed;
            ReadyTimeImput.Visibility = Visibility.Visible;
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
        }






        public void Ring(byte which)
        {
            if (which == 0)
            {
                mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/���Ծ�ԭ��.wav"));
                mediaPlayer.Play();
            }
            else if (which == 1)
            {
                mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/��ս��ʼ.wav"));
                mediaPlayer.Play();
            }
            else if (which == 2)
            {
                mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/��ս��������15����.wav"));
                mediaPlayer.Play();
            }
            else if (which == 3)
            {
                mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/��ս����.wav"));
                mediaPlayer.Play();
            }

        }

        public async void TestStart()
        {
            bool canConvert;
            canConvert = double.TryParse(TestTimeImput.Text ,out fun);
            if (TestTimeImput.Text == "" || TestTimeImput.Text == "0")
            {
                ContentDialog InvaildTestTime_Is0 = new()
                {
                    XamlRoot = this.XamlRoot,
                    Title = "��Ч�Ŀ���ʱ����",
                    Content = "�������뿼��ʱ����������ʱ��������Ϊ0��",
                    CloseButtonText = "֪����"
                };
                await InvaildTestTime_Is0.ShowAsync();
            }
            else if (canConvert == true)
            {
                bool canConvertInt;
                fun = Double.Parse(TestTimeImput.Text);
                fun *= 60;
                fun3 = fun.ToString();
                canConvertInt = int.TryParse(fun3, out fun2);
                if (canConvertInt == false)
                {
                    ContentDialog InvaildTestTime_CannotConvertInt = new()
                    {
                        XamlRoot = this.XamlRoot,
                        Title = "��Ч�Ŀ���ʱ����",
                        Content = "С��λ�����������ֵ����",
                        CloseButtonText = "֪����"
                    };
                    await InvaildTestTime_CannotConvertInt.ShowAsync();
                }
                else
                {
                    TestTime = int.Parse(fun3);
                    if (TestTime < 0)
                    {
                        ContentDialog InvaildTestTime_SmallerThan0 = new()
                        {
                            XamlRoot = this.XamlRoot,
                            Title = "��Ч�Ŀ���ʱ����",
                            Content = "����������һ��������",
                            CloseButtonText = "֪����"
                        };
                        await InvaildTestTime_SmallerThan0.ShowAsync();
                    }
                    else if (TestTime > 64800)
                    {
                        ContentDialog InvaildTestTime_TooBig = new()
                        {
                            XamlRoot = this.XamlRoot,
                            Title = "��Ч�Ŀ���ʱ����",
                            Content = "����ʱ��̫���ˣ���������18h����",
                            CloseButtonText = "֪����"
                        };
                        await InvaildTestTime_TooBig.ShowAsync();
                    }
                    else
                    {
                        HideAll();
                        Closer.Visibility = Visibility.Visible;
                        if (step == 1)
                        {
                            Ring(0);
                            ReadyTimeNow = ReadyTime;
                            TestTimer = new DispatcherTimer();
                            TestTimer.Tick += TestTimer_Tick;
                            TestTimer.Interval = new TimeSpan(0, 0, 1);
                            TestTimer.Start();
                            StepFowarder.Visibility = Visibility.Visible;
                            ReadyTimeShow.Visibility = Visibility.Visible;
                            DateTime time = DateTime.Now + new TimeSpan(0, 0, ReadyTime);
                            TextOutput.Text = $"׼���У�\n({Math.Floor((double)ReadyTimeNow/60)}����/{ReadyTime/60}���ӣ�Ԥ��{time}������)";
                        }
                        else if (step == 2)
                        {
                            if (TestTime > 925)
                            {
                                TestTimeNow = TestTime;
                                TestTimer = new DispatcherTimer();
                                TestTimer.Tick += TestTimer_Tick;
                                TestTimer.Interval = new TimeSpan(0, 0, 1);
                                TestTimer.Start();
                                Stoper.Visibility = Visibility.Visible;
                                TestTimeShow.Visibility = Visibility.Visible;
                                DateTime time = DateTime.Now + new TimeSpan(0, 0, TestTime);
                                TextOutput.Text = $"�����У�\n({Math.Floor((double)TestTimeNow/60)}����/{TestTime/60}���ӣ�Ԥ��{time}�վ�)";
                            }
                            else
                            {
                                step = 3;
                                TestTimeNow = TestTime;
                                TestTimer = new DispatcherTimer();
                                TestTimer.Tick += TestTimer_Tick;
                                TestTimer.Interval = new TimeSpan(0, 0, 1);
                                TestTimer.Start();
                                Stoper.Visibility = Visibility.Visible;
                                TestTimeShow.Visibility = Visibility.Visible;
                                DateTime time = DateTime.Now + new TimeSpan(0, 0, TestTime);
                                TextOutput.Text = $"�����У�\n({Math.Floor((double)TestTimeNow / 60)}����/{TestTime / 60}���ӣ�Ԥ��{time}�վ�)";
                            }
                            Ring(1);
                            
                        }

                    }
                }
            }
            else
            {
                ContentDialog InvaildTestTime_NotDouble = new()
                {
                    XamlRoot = this.XamlRoot,
                    Title = "��Ч�Ŀ���ʱ����",
                    Content = "������һ����Ч����ֵ��>0��֧������С����",
                    CloseButtonText = "֪����"
                };

                await InvaildTestTime_NotDouble.ShowAsync();
            }

        }

        void TestTimer_Tick(object sender, object e)
        {
            if (step == 1)
            {
                ReadyTimeNow -= 1;
                ReadyTimeShow.Value = (double)ReadyTimeNow / ReadyTime * 100;
                if (ReadyTimeNow <= 0)
                {
                    DateTime time = DateTime.Now + new TimeSpan(0, 0, TestTime);
                    TextOutput.Text = $"�����У�\n({Math.Floor((double)TestTimeNow / 60)}����/{TestTime / 60}���ӣ�Ԥ��{time}�վ�)";
                    ReadyTimeShow.Visibility = Visibility.Collapsed;
                    TestTimeShow.Visibility = Visibility.Visible;
                    StepFowarder.Visibility = Visibility.Collapsed;
                    Stoper.Visibility = Visibility.Visible;
                    if (TestTime > 925)
                    {
                        step = 2;
                        TestTimeNow = TestTime;
                    }
                    else
                    {
                        step = 3;
                        TestTimeNow = TestTime;
                    }
                    Ring(1);
                }
                
            }
            else if (step == 2)
            {
                TestTimeNow -= 1;
                TestTimeShow.Value = (double)TestTimeNow / TestTime * 100 ;
                if (TestTimeNow <= 925)
                {
                    step = 3;
                    Ring(2);
                }
             }
            else if (step == 3)
            {
                TestTimeNow -= 1;
                TestTimeShow.Value = (double)TestTimeNow / TestTime * 100;
                if (TestTimeNow <= 0)
                {
                    TextOutput.Text = "����ʱ������·���ť������";
                    TestTimeShow.Visibility = Visibility.Collapsed;
                    AppearAll();
                    Ring(3);
                    step = 0;
                    TestTimer.Stop();
                    Stoper.Visibility = Visibility.Collapsed;
                    Closer.Visibility = Visibility.Collapsed;
                }
                
            }
            else
            {
                throw new Exception("Timer ticked on a invaild step!(Clicked the button too quickly?)");
            }
        }

        public RingPage()
        {
            this.InitializeComponent();
            // Set minimum to the current year.
            arrivalDatePicker.MinYear = DateTimeOffset.Now;
            arrivalDatePicker.SelectedDate = DateTime.Now.Date;
            arrivalTimePicker.SelectedTime = DateTime.Now.TimeOfDay;
        }

        private async void Start(object sender, RoutedEventArgs e)
        {
            if (TestTimeSetState.IsChecked == true)
            {
                if (VerifyDateIsFuture(arrivalDateTime) == true)
                {
                    dif = arrivalDateTime - DateTime.Now;
                    ReadyTime = (int)Math.Round(dif.TotalSeconds);
                    step = 1;
                    TestStart();
                }
                else
                {
                    ContentDialog InvaildReadyTime_CannotConvertInt = new()
                    {
                        XamlRoot = this.XamlRoot,
                        Title = "��Ч�Ŀ�����ʱ��",
                        Content = "ָ��ʱ��Ӧ���������ڣ�",
                        CloseButtonText = "֪����"
                    };
                    await InvaildReadyTime_CannotConvertInt.ShowAsync();
                }
            }
            else 
            {
                ReadyTimeShow.Value = 100;
                TestTimeShow.Value = 100;
                bool canConvert;
                canConvert = double.TryParse(ReadyTimeImput.Text, out fun);
                if (ReadyTimeImput.Text == "" || ReadyTimeImput.Text == "0")
                {
                    ReadyTime = 0;
                    step = 2;
                    TestStart();
                }
                else if (canConvert == true)
                {
                    bool canConvertInt;
                    fun = Double.Parse(ReadyTimeImput.Text);
                    fun *= 60;
                    fun3 = fun.ToString();
                    canConvertInt = int.TryParse(fun3, out fun2);
                    if (canConvertInt == false)
                    {
                        ContentDialog InvaildReadyTime_CannotConvertInt = new()
                        {
                            XamlRoot = this.XamlRoot,
                            Title = "��Ч�Ŀ�ǰʱ����",
                            Content = "С��λ�����������ֵ����",
                            CloseButtonText = "֪����"
                        };
                        await InvaildReadyTime_CannotConvertInt.ShowAsync();
                    }
                    else
                    {
                        ReadyTime = int.Parse(fun3);
                        if (ReadyTime < 0)
                        {
                            ContentDialog InvaildReadyTime_SmallerThan0 = new()
                            {
                                XamlRoot = this.XamlRoot,
                                Title = "��Ч�Ŀ�ǰʱ����",
                                Content = "����������һ��������",
                                CloseButtonText = "֪����"
                            };
                            await InvaildReadyTime_SmallerThan0.ShowAsync();
                        }
                        else if (ReadyTime > 1800)
                        {
                            ContentDialog InvaildReadyTime_TooBig = new()
                            {
                                XamlRoot = this.XamlRoot,
                                Title = "��Ч�Ŀ�ǰʱ����",
                                Content = "��ǰʱ��̫���ˣ�������1h���뿼�Ƕ�ʱ������",
                                CloseButtonText = "֪����"
                            };
                            await InvaildReadyTime_TooBig.ShowAsync();
                        }
                        else
                        {
                            step = 1;
                            TestStart();
                        }
                    }
                }
                else
                {
                    ContentDialog InvaildReadyTime_NotDouble = new()
                    {
                        XamlRoot = this.XamlRoot,
                        Title = "��Ч�Ŀ�ǰʱ����",
                        Content = "������һ����Ч����ֵ����0��֧������С������Ҳ�������ս��ÿ�ǰ׼��ʱ��",
                        CloseButtonText = "֪����"
                    };

                    await InvaildReadyTime_NotDouble.ShowAsync();
                }
            }
        }


        void HideAll()
        { 
            TestTimeImput.Visibility = Visibility.Collapsed;
            ReadyTimeImput.Visibility = Visibility.Collapsed;
            TestTimeSetState.Visibility = Visibility.Collapsed;
            TimerEditor.Visibility = Visibility.Collapsed;
            Caller.Visibility = Visibility.Collapsed;
        }
        void AppearAll()
        {
            TestTimeImput.Visibility = Visibility.Visible;
            ReadyTimeImput.Visibility = Visibility.Visible;
            TestTimeSetState.Visibility = Visibility.Visible;
            TestTimeSetState.IsChecked = false;
            Caller.Visibility = Visibility.Visible;
        }
        private void StepFoward(object sender, RoutedEventArgs e)
        {
            ReadyTimeShow.Visibility = Visibility.Collapsed;
            TestTimeShow.Visibility = Visibility.Visible;
            StepFowarder.Visibility = Visibility.Collapsed;
            Stoper.Visibility = Visibility.Visible;
            if (TestTime > 925)
            {
                step = 2;
                TestTimeNow = TestTime;
            }
            else
            {
                step = 3;
                TestTimeNow = TestTime;
            }
            Ring(1);
            DateTime time = DateTime.Now + new TimeSpan(0, 0, TestTime);
            TextOutput.Text = $"�����У�\n({Math.Floor((double)TestTimeNow / 60)}����/{TestTime / 60}���ӣ�Ԥ��{time}�վ�)";
        }
        private void Stop(object sender, RoutedEventArgs e)
        {
            TestTimeShow.Visibility = Visibility.Collapsed;
            AppearAll();
            Ring(3);
            step = 0;
            TestTimer.Stop();
            Stoper.Visibility = Visibility.Collapsed;
            Closer.Visibility = Visibility.Collapsed;
            TextOutput.Text = "����ʱ������·���ť������";
        }
        private void Close(object sender, RoutedEventArgs e)
        { 
        TestTimer.Stop();
            AppearAll();
            TestTimeShow.Visibility = Visibility.Collapsed;
            ReadyTimeShow.Visibility = Visibility.Collapsed;
            StepFowarder.Visibility = Visibility.Collapsed;
            Stoper.Visibility = Visibility.Collapsed;
            Closer.Visibility = Visibility.Collapsed;
            TextOutput.Text = "����ʱ������·���ť������";
            mediaPlayer.Pause();
        }
    }
}
