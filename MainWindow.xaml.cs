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
             Uris= new List<string>();
             foreach (var sdata in content.Uris)
             {
                 Uris.Add(sdata.Title);
             }
             
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddUri_Click(object sender, RoutedEventArgs e)
        {
            string typ = "POST";
            if (RadioButtonGet.IsChecked == true)
            {
                typ = "GET";
            }
            var ld = new Dictionary<string,string>();
            ld.Add("Content-Type", "application/json");
            content.addUri(new UriData{body = body.Text, Uri=uri.Text, headers = ld, type=typ, Title=uriName.Text});
            Uris.Add(uriName.Text);
            lbUris.ItemsSource = content.Uris;


        }

        private void Test_OnClick(object sender, RoutedEventArgs e)
        {
            UriData uriData;
            var wc = new WebClient();
            if (lbUris.HasItems && lbUris.SelectedIndex >= 0)
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
                try
                {
                    string reply = wc.DownloadString(li.Uri);
                    tbResult.Text = reply;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private void testSomthing_Click(object sender, RoutedEventArgs e)
        {
            //Uris = new List<string>();
            //lbUris.DataContext = Uris;

           



        }

       

        private void lbUris_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(lbUris.SelectedItems[0]);
            var data = (UriData) lbUris.SelectedItems[0];
            uri.Text = data.Uri;
            uriName.Text = data.Title;
            if (data.type == "POST")
                RadioButtonPost.IsChecked = true;
            else
            {
                RadioButtonGet.IsChecked = true;
            }

            body.Text = data.body;
        }
    }
}
