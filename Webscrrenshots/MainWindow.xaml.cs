using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
using MessageBox = System.Windows.Forms.MessageBox;

namespace Webscrrenshots
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String url;
        public MainWindow()
        {
            InitializeComponent();

        }
        private void MenuItem_Click(object sender, RoutedEventArgs e) //random
        {
            web(String.Empty);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) //id
        {
            if (id.Text.Contains("http"))
            {
                web(id.Text);
                
            }
            else
            {
                web("https://prnt.sc/" + id.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e) ///exit
        {
            this.Close();
        }

        void web(String adress)
        {
            if (adress == String.Empty)
            {
                System.Random rnd = new System.Random();
                adress = RandomString(2) + rnd.Next(0, 9) + rnd.Next(0, 9) + rnd.Next(0, 9) + rnd.Next(0, 9);
                adress = "https://prnt.sc/" + adress;
                try
                {
                    /*System.Windows.Forms.WebBrowser web = new System.Windows.Forms.WebBrowser();
                    web.Navigate(new Uri(adress));
                    web.ScriptErrorsSuppressed = true;*/
                    WebBrowser web = Web;
                    web.Navigate(new Uri(adress));
                    url = adress;
                    HideScriptErrors(ref web, true);
                    id.Text = adress;
                    Web = web;
                }
                catch(ObjectDisposedException e)
                {

                }
                
            }
            else
            {
                Web.Navigate(new Uri(adress));
            }

        }

        private string RandomString(Int64 Length)
        {
            ArrayList alp = new ArrayList();
            alp.Add("a");
            alp.Add("b");
            alp.Add("c");
            alp.Add("d");
            alp.Add("e");
            alp.Add("f");
            alp.Add("g");
            alp.Add("h");
            alp.Add("i");
            alp.Add("j");
            alp.Add("k");
            alp.Add("l");
            alp.Add("m");
            alp.Add("n");
            alp.Add("o");
            alp.Add("p");
            alp.Add("q");
            alp.Add("r");
            alp.Add("s");
            alp.Add("t");
            alp.Add("u");
            alp.Add("v");
            alp.Add("w");
            alp.Add("x");
            alp.Add("y");
            alp.Add("z");

            System.Random rnd = new System.Random();
            StringBuilder Temp = new StringBuilder();
            int random = 0;
            for (Int64 i = 0; i < Length; i++)
            {
                random = rnd.Next(0, (alp.Count - 1));
                Temp.Append(alp[random]);
            }
            return Temp.ToString();
        }

        public void HideScriptErrors(ref WebBrowser wb, bool Hide)
        {
            System.Reflection.FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            object objComWebBrowser = fiComWebBrowser.GetValue(wb);
            if (objComWebBrowser == null) return;
            objComWebBrowser.GetType().InvokeMember("Silent", System.Reflection.BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e) //load
        {
            web(String.Empty);
        }

        private void Web_Navigated(object sender, NavigationEventArgs e)
        {

        }


        private void Web_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Web_KeyDown(object sender, KeyEventArgs e)
        {
            
           
        }

        private void Web_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F1)
            {
                web(String.Empty);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Web.GoBack();
        }
    }
    
}
