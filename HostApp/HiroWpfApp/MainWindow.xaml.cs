using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Microsoft.AspNet.SignalR.Client;

namespace HiroWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IHubProxy HubProxy { get; set; }
        private const string ServerUri = "http://localhost:8888";
        public HubConnection Connection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ConnectAsync();
        }

        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerUri);
            Connection.Closed += Connection_Closed;      
            
            HubProxy = Connection.CreateHubProxy("HiroHub");          
            HubProxy.On<string>("ShowTime", (message) => Dispatcher.Invoke(() => TimeText.Content = message));                            
                       
            try
            {
                await Connection.Start();
            }
            catch (Exception e)
            {
                TimeText.Content = "Unable to connect to server: Start server before connecting clients.";                
                return;
            }
        }

        private void Connection_Closed()
        {
            var dispatcher = Application.Current.Dispatcher;
            dispatcher.Invoke(() => HiroImage.Visibility = Visibility.Visible);
            dispatcher.Invoke(() => TimeText.Content = "You have been disconnected.");
        }
    }
}
