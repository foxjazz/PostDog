using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
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

namespace PostDog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    
    public partial class MainWindow : Window
    {
        public Content content;
        public List<string> Uris;
        public MainWindow()
        {
            content = new Content();
           
            
            InitializeComponent();
             lbUris.ItemsSource = content.Uris;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string typ = "POST";
            if (RadioButtonGet.IsChecked == true)
            {
                typ = "GET";
            }
            var ld = new Dictionary<string,string>();
            ld.Add("Content-Type", "application/json");
            content.addUri(new UriData{body = body.Text, Uri=uri.Text, headers = ld, type=typ});

        }

        private void Test_OnClick(object sender, RoutedEventArgs e)
        {
            UriData uriData;
            var wc = new WebClient();
            if (lbUris.HasItems && lbUris.SelectedIndex > 0)
            {
                uriData = content.Uris[lbUris.SelectedIndex];
            }
            else
            {
                return;
            }
            var li = (UriData)lbUris.SelectedItems[0];
            var dvalue =  li.headers.First();
            
            wc.Headers.Add(dvalue.Key, dvalue.Value);
            if (li.type == "POST")
            {
                var response = wc.UploadData(li.Uri, li.type, GetBytes(li.body));
                tbResult.Text = Encoding.UTF8.GetString(response);
            }
            else
            {
                string reply = wc.DownloadString(li.Uri);
                tbResult.Text = reply;
            }


        }
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
