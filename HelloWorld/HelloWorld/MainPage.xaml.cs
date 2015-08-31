
using Windows.UI.Xaml;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls;
using System.Xml;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            this.InitializeComponent();

           

        }

        private void inputButton_Click(object sender, RoutedEventArgs e)
        {
            greetingOutput.Text = "Hello mr. Scholar and gentleman " + nameInput.Text + "!" + " How are you?";
        }
            

        
    }
}
