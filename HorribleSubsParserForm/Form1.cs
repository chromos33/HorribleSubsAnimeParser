using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Gecko;
using Gecko.Events;
using HtmlAgilityPack;
using System.Threading;

namespace HorribleSubsParserForm
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        BindingList<Anime> animes = new BindingList<Anime>();
        GeckoWebBrowser geckoWebBrowser;
        public Form1()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            geckoWebBrowser = new GeckoWebBrowser { Dock = DockStyle.Fill };
            geckoWebBrowser.DocumentCompleted += DocumentCompleted;
            loadAnime();
            AnimeList.DataSource = animes;
            timer.Interval = 1000;
            timer.Tick += CheckAnime;
            timer.Start();
        }

        private void DocumentCompleted(object sender, GeckoDocumentCompletedEventArgs e)
        {
            GeckoDocument test = geckoWebBrowser.Document;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(test.Body.InnerHtml);
            bool update = false;
            foreach(var node in doc.DocumentNode.Descendants("div").Where(x=>x.Attributes["class"] != null && x.Attributes["class"].Value.ToLower().Contains("release-links")))
            {
                foreach(Anime anime in animes)
                {
                    if (node.Attributes["class"].Value.ToString().ToLower().Contains(anime.classname().ToLower()))
                    {
                        var links = node.Descendants("a").Where(x => x.Attributes["href"] != null && x.Attributes["href"].Value.ToString().Contains("uploaded"));
                        if(links.Count()>0)
                        {
                            Clipboard.SetText(links.First().Attributes["href"].Value.ToString());
                            anime.episode++;
                            update = true;
                            // i don't care about UI I just want it to wait for an arbitrary amount of time so JDownloader can react
                            Thread.Sleep(2500);
                        }
                    }
                }
            }
            if(update)
            {
                saveAnime();
            }
        }

        private void CheckAnime(object sender, EventArgs e)
        {
            timer.Interval = 10 * 60 * 1000;
            if(animes.Count() > 0)
            {
                geckoWebBrowser.Navigate("http://horriblesubs.info/");
            }
        }
        
        

        private void AddAnime_Click(object sender, EventArgs e)
        {
            Anime newAnime = new Anime();
            newAnime.name = Anime.Text;
            newAnime.resolution = Resolution.SelectedIndex;
            newAnime.episode = 1;
            animes.Add(newAnime);
            saveAnime();
        }

        private void RemoveAnime_Click(object sender, EventArgs e)
        {
            animes.RemoveAt(AnimeList.SelectedIndex);
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
                animes = (BindingList<Anime>)xmlserializer.Deserialize(reader);
                fs.Close();
            }
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
            switch (resolution)
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
        public string classname()
        {
            string sEpisode = "";
            if(episode<10)
            {
                sEpisode = "0" + episode.ToString();
            }
            else
            {
                sEpisode = episode.ToString();
            }
            string reso = "";
            switch (resolution)
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
            return name + "-" + sEpisode + "-" + reso;
        }
    }
}
