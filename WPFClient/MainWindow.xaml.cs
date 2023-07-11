using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.CodeDom;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;


        public MainWindow()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7283/chathub")
                .WithAutomaticReconnect()
                .Build();

            connection.Reconnecting += (sender) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    var newMessage = "Attempting to reconnect ...";
                    messages.Items.Add(newMessage);
                });

                return Task.CompletedTask;    // Indicator that satify connection.Reconnecting  
            };

            connection.Reconnected += (sender) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    var newMessage = "Reconnected to the server ...";
                    messages.Items.Clear();     // clear all old message
                    messages.Items.Add(newMessage);     // start new message list here
                });

                return Task.CompletedTask;
            };

            connection.Closed += (sender) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    var newMessage = "Connection closed";
                    messages.Items.Add(newMessage);
                    openConnection.IsEnabled = true;    // Button openConnection
                    sendMessage.IsEnabled = false;       // Button sendMessage
                });

                return Task.CompletedTask;
            };


        }

        private async void openConnection_Click(object sender, RoutedEventArgs e)
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var newMessage = $"{user}: {message}";
                messages.Items.Add(newMessage);


            });

            try
            {
                await connection.StartAsync();
                messages.Items.Add("Connection started ...");
                openConnection.IsEnabled = false;       // connection is already open, make sure not to try to open the connection again 
                sendMessage.IsEnabled = true;
            }
            catch (Exception ex)
            {
                messages.Items.Add(ex.Message);
            }
        }

        private async void sendMessage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // broadcast message
                await connection.InvokeAsync("SendMessage", "WPF Client", messageInput.Text);
            }
            catch (Exception ex)
            {
                messages.Items.Add(ex.Message);
            }
        }

    }

    // Go to master-sln-file > Set startup projects > choose BlazorServer and WPFClient > Run

}
