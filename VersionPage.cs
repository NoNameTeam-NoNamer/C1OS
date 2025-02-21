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
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Microsoft.UI.Dispatching;
using Newtonsoft.Json.Linq;
using Microsoft.WindowsAPICodePack.Shell;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace C1OS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VersionPage : Page
    {
        private readonly HttpClient _httpClient = new();
        private StorageFolder _downloadsFolder;
        private string _latestDownloadUrl;
        private string _currentVersion;
        private string PATH;

        public VersionPage()
        {
            this.InitializeComponent();
            InitializeVersionInfo();
            InitializeHttpClient();
        }

        private void InitializeVersionInfo()
        {
            var packageVersion = Package.Current.Id.Version;
            _currentVersion = $"{packageVersion.Major}.{packageVersion.Minor}.{packageVersion.Build}";
        }

        private void InitializeHttpClient()
        {
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("C1OS-Updater/1.0");

        }

        private async void OpenGithub(object sender, RoutedEventArgs e)
        {
            const string releasesUrl = "https://github.com/NoNameTeam-NoNamer/C1OS/releases";
            var uri = new Uri(releasesUrl);

            try
            {
                var success = await Launcher.LaunchUriAsync(uri);

                if (!success)
                {
                    ShowErrorDialog("�޷����������������Ĭ�����������");
                }
            }
            catch (System.Exception ex)
            {
                ShowErrorDialog($"������ʧ��: {ex.Message}");
            }
        }

        private async void CheckUpdate(object sender, RoutedEventArgs e)
        {
            try
            {
                DownloadUpdate.Visibility = Visibility.Collapsed;
                DownloadOpener.Visibility = Visibility.Collapsed;
                UpdateFeedBack.Text = "���ڼ�����......";

                var (isUpdateAvailable, latestVersion, downloadUrl) = await CheckForUpdateAsync();

                DispatcherQueue.TryEnqueue(() =>
                {
                    if (isUpdateAvailable)
                    {
                        UpdateFeedBack.Text = $"�����°汾 {latestVersion}��";
                        DownloadUpdate.Visibility = Visibility.Visible;
                        DownloadUpdate.IsEnabled = true;
                        _latestDownloadUrl = downloadUrl;
                    }
                    else
                    {
                        UpdateFeedBack.Text = "��ǰ�������°汾";
                    }
                });
            }
            catch (Exception ex)
            {
                UpdateFeedBack.Text = $"������ʧ��: {ex.Message}";
            }
        }

        private async Task<(bool isUpdateAvailable, string latestVersion, string downloadUrl)> CheckForUpdateAsync()
        {
            var response = await _httpClient.GetAsync(
                "https://api.github.com/repos/NoNameTeam-NoNamer/C1OS/releases/latest");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var release = JObject.Parse(content);

            var latestVersion = release["tag_name"]?.ToString().TrimStart('v');
            var assets = release["assets"] as JArray;
            var downloadUrl = assets?[0]?["browser_download_url"]?.ToString();

            if (string.IsNullOrEmpty(latestVersion))throw new Exception("��Ч�İ汾��Ϣ");

            return (IsNewerVersion(latestVersion), latestVersion, downloadUrl);
        }

        private bool IsNewerVersion(string latestVersion)
        {
            var current = Version.Parse(_currentVersion);
            var latest = Version.Parse(latestVersion);
            return latest > current;
        }

        private async void DownloadUpdatePack(object sender, RoutedEventArgs e)
        {
            try
            {
                DownloadUpdate.IsEnabled = false;
                UpdateFeedBack.Text = "����������......";
                if (string.IsNullOrEmpty(_latestDownloadUrl))
                {
                    UpdateFeedBack.Text = "����������Ч";
                    return;
                }

                _downloadsFolder ??= await StorageFolder.GetFolderFromPathAsync(
                    Microsoft.WindowsAPICodePack.Shell.KnownFolders.Downloads.Path);

                var fileName = Path.GetFileName(new Uri(_latestDownloadUrl).LocalPath);
                var targetFile = await _downloadsFolder.CreateFileAsync(
                    fileName, CreationCollisionOption.GenerateUniqueName);

                using (var response = await _httpClient.GetAsync(
                    _latestDownloadUrl, HttpCompletionOption.ResponseHeadersRead))
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = await targetFile.OpenStreamForWriteAsync())
                {
                    var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                    var buffer = new byte[128 * 1024];
                    var totalBytesRead = 0L;
                    var bytesRead = 0;

                    while ((bytesRead = await stream.ReadAsync(buffer)) > 0)
                    {
                        await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead));
                        totalBytesRead += bytesRead;

                        if (totalBytes > 0)
                        {
                            var progress = (double)totalBytesRead / totalBytes;
                            UpdateFeedBack.Text =
                                $"���ؽ���: {progress:P0} ({totalBytesRead / 1024}KB / {totalBytes / 1024}KB)";
                        }
                    }
                }
                DownloadUpdate.Visibility = Visibility.Collapsed;
                DownloadOpener.Visibility = Visibility.Visible;
                PATH = targetFile.Path;
                UpdateFeedBack.Text = $"������ɣ��ļ��ѱ�������{PATH}\n" +
                    "���ѹ������.msix��װ��\n�޷��򿪾�ʹ��powershell����install.ps1�ļ�\n�����Ϸ���װӦ�ð�װ����";

            }
            catch (Exception ex)
            {
                UpdateFeedBack.Text = $"����ʧ��: {ex.Message}";
                DownloadUpdate.Visibility = Visibility.Collapsed;
            }
        }

        private void OpenUpdatePack(object sender, RoutedEventArgs e)
        {
            // ����Դ��������ѡ���ļ�
            var processInfo = new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = $"/select, \"{PATH}\""
            };
            Process.Start(processInfo);
        }


        private async void AddInstaller(object sender, RoutedEventArgs e)
        {
            // ʹ��Microsoft Store��Э��URL
            var storeUri = new System.Uri("ms-windows-store://pdp/?ProductId=9NBLGGH4NNS1");

            try
            {
                // ʹ��Windows.System.Launcher�����̵�
                var success = await Launcher.LaunchUriAsync(storeUri);

                if (!success)
                {
                    // �������ʧ�ܣ������ϲ��ᷢ����
                    ShowErrorDialog("�޷���Microsoft Store");
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                // ����ɰ�Windows�ļ���������
                await TryLegacyLaunch();
            }
            catch (System.Exception ex)
            {
                ShowErrorDialog($"��������{ex.Message}");
            }
        }

        private static async Task TryLegacyLaunch()
        {
            try
            {
                // ���÷�����ʹ�þɰ��̵�Э��
                var legacyUri = new System.Uri("ms-windows-store:PDP?PFN=Microsoft.DesktopAppInstaller_8wekyb3d8bbwe");
                await Launcher.LaunchUriAsync(legacyUri);
            }
            catch
            {
                // ���ջ��˵���ҳ���̵�
                var webUri = new System.Uri("https://apps.microsoft.com/detail/9NBLGGH4NNS1");
                await Launcher.LaunchUriAsync(webUri);
            }
        }

        private async void ShowErrorDialog(string message)
        {
            ContentDialog dialog = new()
            {
                Title = "����ʧ��",
                Content = message,
                CloseButtonText = "ȷ��",
                XamlRoot = Content.XamlRoot
            };

            await dialog.ShowAsync();
        }
    }
}
