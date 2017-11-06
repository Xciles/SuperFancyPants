using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpTheading
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        private async void InfoButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();

            var result = await client.GetStringAsync("http://www.google.com");

            result = result.Substring(0, 200);

            ListBoxItem itm = new ListBoxItem();
            itm.Content = result;

            ListBox.Items.Add(itm);
        }

        private async void InfoButton2_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await Task.Delay(10_000);

            ListBoxItem itm = new ListBoxItem();
            itm.Content = "Na 10 seconden!";

            ListBox.Items.Add(itm);
            //Text.Text = "aaaa";
        }
    }
}