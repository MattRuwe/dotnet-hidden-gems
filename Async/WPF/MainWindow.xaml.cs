using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            tbText.Text = SynchronizationContext.Current?.ToString() ?? "Default Sync Context";
        }

        private async void BtnClick_OnClick(object sender, RoutedEventArgs e)
        {
            await MyAsyncMethod();
        }

        private async Task MyAsyncMethod()
        {
            var client = new HttpClient();
            var content = await client.GetAsync("https://api.ipify.org?format=json").ConfigureAwait(false);

            tbText.Text = await content.Content.ReadAsStringAsync().ConfigureAwait(false);
        }


        private void Deadlock()
        {
            async Task OperationOnContext()
            {
                await Task.Delay(1000);
            }

            OperationOnContext().Wait(); //Never wait on async methods in a UI thread
        }

        private void BtnDeadlock_OnClick(object sender, RoutedEventArgs e)
        {
            Deadlock();
        }
    }
}
