using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Xml;

namespace HorribleSubsParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer CheckTimer;
        System.Windows.Threading.DispatcherTimer Cloudflarewaiter;
        ObservableCollection<Anime> animes = new ObservableCollection<Anime>();
        public MainWindow()
        {
            InitializeComponent();
            loadAnime();
            AnimeList.ItemsSource = animes;
            Resolution.Items.Add("480p");
            Resolution.Items.Add("720p");
            Resolution.Items.Add("1080p");
            Resolution.SelectedIndex = 0;
            CheckTimer = new System.Windows.Threading.DispatcherTimer();
            CheckTimer.Tick += CheckHorribleSubs;
            CheckTimer.Interval = new TimeSpan(0,0,1);
            CheckTimer.Start();
        }

        private void CheckHorribleSubs(object sender, EventArgs e)
        {
            if(animes.Count()>0)
            {
                //browsertest = new WebBrowser();
                browsertest.Navigated += WebPageNavigated;
                Uri uri = new Uri("http://horriblesubs.info/",UriKind.RelativeOrAbsolute);
                browsertest.Navigate(uri);
            }
            CheckTimer.Interval = new TimeSpan(0, 10, 0);
        }

        private void WebPageNavigated(object sender, NavigationEventArgs e)
        {
            Cloudflarewaiter = new System.Windows.Threading.DispatcherTimer();
            Cloudflarewaiter.Interval = CheckTimer.Interval = new TimeSpan(0, 0, 30);
            Cloudflarewaiter.Tick += CloudFlareWaited;
            Cloudflarewaiter.Start();
        }

        private void CloudFlareWaited(object sender, EventArgs e)
        {
            Cloudflarewaiter.Stop();
            dynamic doc = browsertest.Document;
            var htmlText = doc.documentElement.outerHTML;
            MessageBox.Show(htmlText);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addAnime_Click(object sender, RoutedEventArgs e)
        {
            Anime newAnime = new Anime();
            newAnime.name = AddAnime.Text;
            newAnime.resolution = Resolution.SelectedIndex;
            newAnime.episode = 1;
            animes.Add(newAnime);
            saveAnime();

        }
        public void saveAnime()
        {
            var path = Directory.GetCurrentDirectory() + "/Anime.xml";

            System.Xml.Serialization.XmlSerializer xmlserializer = new System.Xml.Serialization.XmlSerializer(animes.GetType());
            System.IO.FileStream file = System.IO.File.Create(path);
            xmlserializer.Serialize(file, animes);
            file.Close();
        }
        public void loadAnime()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/Anime.xml"))
            {
                var path = Directory.GetCurrentDirectory() + "/Anime.xml";
                FileStream fs = new FileStream(path, FileMode.Open);
                System.Xml.Serialization.XmlSerializer xmlserializer = new System.Xml.Serialization.XmlSerializer(animes.GetType());


                XmlReader reader = XmlReader.Create(fs);
                animes = (ObservableCollection<Anime>)xmlserializer.Deserialize(reader);
                fs.Close();
            }
        }

        private void removeAnime_Click(object sender, RoutedEventArgs e)
        {
            animes.RemoveAt(AnimeList.SelectedIndex);
            saveAnime();
        }
    }
    public class Anime
    {
        public string name;
        public int resolution;
        public int episode;
        public override string ToString()
        {
            string reso = "";
            switch(resolution)
            {
                case 0:
                    reso = "480p";
                    break;
                case 1:
                    reso = "720p";
                    break;
                case 2:
                    reso = "1080p";
                    break;
            }
            return name + "@" + reso;
        }
    }

}
