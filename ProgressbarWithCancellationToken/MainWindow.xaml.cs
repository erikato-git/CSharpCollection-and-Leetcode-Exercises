using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ProgressbarWithCancellationToken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource _tokenSource = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;

            var progress = new Progress<int>(value => 
            {
                _progressBar.Value = value;     // The progressbar will update from Report in LoopThroughNumbers
                StatusTextbox.Text = $"{value}%";
            });

            // LoopThroughNumbers is encapsulated in a try-cath because of the CancellationToken
            try
            {
                await Task.Run(() => LoopThroughNumbers(100, progress, token));
                StatusTextbox.Text = "Completed";
            }
            catch (OperationCanceledException ex)
            {
                StatusTextbox.Text = "Cancelled";
            }
            finally
            {
                _tokenSource.Dispose();
            }
        }

        private void LoopThroughNumbers(int count, IProgress<int> progress, CancellationToken cancellationToken)
        {
            for (int i = 0; i <= count; i++)
            {
                Thread.Sleep(100);
                var percentComplete = (i * 100) / count;
                progress.Report(percentComplete);

                if(cancellationToken.IsCancellationRequested)           // Polling
                {
                    cancellationToken.ThrowIfCancellationRequested();   // Most recommended handling
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _tokenSource.Cancel();
        }
    }
}
