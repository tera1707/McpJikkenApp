using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using SharedProject;

namespace McpJikkenAppWindow
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const string pipeName = "MyPipeName";
            var pipe = new PipeServerClient();
            // サーバー側: 非同期で受信待ち
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    // 受信＋応答
                    string received = await pipe.WaitForStringAndRespondAsync(pipeName, (req) =>
                    {
                        var rcv = req.Split(',');
                        if (rcv.Length < 3) return "ERROR";

                        var getset = rcv[0];
                        var kind = rcv[1];
                        var val = rcv[2];

                        string response = "";
                        Dispatcher.Invoke(() =>
                        {
                            if (getset == "Get")
                            {
                                if (kind == "Arm")
                                {
                                    response = $"{(int)ArmPower.Value}";
                                }
                                else if (kind == "Leg")
                                {
                                    response = $"{(int)LegPower.Value}";
                                }
                            }
                            else // set
                            {
                                if (kind == "Arm")
                                {
                                    ArmPower.Value = int.Parse(val);
                                    response = "0";
                                }
                                else if (kind == "Leg")
                                {
                                    LegPower.Value = int.Parse(val);
                                    response = "0";
                                }
                            }
                        });

                        Thread.Sleep(1000);

                        return response;
                    });
                }
            });
        }
    }
}