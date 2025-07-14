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
                    string received = await pipe.WaitForStringAsync(pipeName);

                    // 受信データ：「Arm,100」「Leg,30」という感じで、スライダの種類と値を指定される
                    var rcv = received.Split(',');

                    var kind = rcv[0];
                    var val = rcv[1];

                    await Dispatcher.InvokeAsync(() =>
                    {
                        if (kind == "Arm")
                        {
                            ArmPower.Value = int.Parse(val);
                        }
                        else //(kind == Leg)
                        {
                            LegPower.Value = int.Parse(val);
                        }
                    });
                }
            });
        }
    }
}