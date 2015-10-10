using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Horoscopo.Resources;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace Horoscopo
{
    public partial class MainPage : PhoneApplicationPage
    {
        bool isNewInstance = true;
        private object textBoxBackgroundImage;
        Horoscopo horoscopo;

        // Constructor
        public MainPage()
        {
            conectar();
            InitializeComponent();
            CarregarHoroscopo();
                    
        }

        //Faz o select do Horoscopo e carrega na lista
      void CarregarHoroscopo()
        {
           
            using (var db = new HoroscopoContext())
            {
                var resultado = (from Horoscopo in db.signos
                                 select Horoscopo).ToList();

                listaHoroscopo.ItemsSource = resultado;

            }

        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ApplicationBar = this.Resources["appBar"] as ApplicationBar;

            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    this.ApplicationBar.IsVisible = false;
                    break;

                case 1:
                    this.ApplicationBar.IsVisible = true;
                    break;
            }
        }

        public void conectar()
        {
            WebClient webClient = new WebClient();
            webClient.OpenReadCompleted += WebClient_OpenReadCompleted;
            webClient.OpenReadAsync(new Uri("http://mftc.cf/everton/horoscopo.xml"));


        }

        private void WebClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {


            XDocument doc = XDocument.Load(e.Result);


            using (var db = new HoroscopoContext())
            {

                foreach (var item in doc.Descendants("signo"))
                {

                    Horoscopo horoscopo = new Horoscopo();
                    horoscopo.Nome = (string)item.Element("nome");
                    horoscopo.Data = (string)item.Element("periodo");
                    horoscopo.Mensagem = (string)item.Element("msg");
                    horoscopo.Icone = (string)item.Element("icone");
                    //  horoscopo.Icone = "/Assets/Icon/" + i + ".png";

                    db.signos.InsertOnSubmit(horoscopo);
                    db.SubmitChanges();

                }

            }

            CarregarHoroscopo();
        }

     




        //Seleciona o signo e joga a pagina 2 do Pivot
        private void listaHoroscopo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            ListBox lst = (ListBox)sender;
            horoscopo = (Horoscopo)lst.SelectedItem;
            txtNome.Text = horoscopo.Nome;
            txtData.Text = horoscopo.Data;
            txtMsg.Text = horoscopo.Mensagem;

       /*     Uri uri = new Uri(horoscopo.Icone, UriKind.Relative);
            BitmapImage ic = new BitmapImage(uri);
            iconedetalhe.Source = ic;*/
            PivotHoroscopo.SelectedIndex = 1;

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            State["LISTA"] = listaHoroscopo.ItemsSource;
            State["NOME"] = txtNome.Text;
            State["DATA"] = txtData.Text;
            State["MSG"] = txtMsg.Text;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (isNewInstance)
            {
                if (this.NavigationContext.QueryString.ContainsKey("CustomerTile"))
                {
                    var name = this.NavigationContext.QueryString["CustomerTile"];
                    select_horoscopo(name);
                    this.PivotHoroscopo.SelectedIndex = 1;

                }
                else
                {
                    if (State.ContainsKey("NOME"))
                        txtNome.Text = State["NOME"].ToString();
                }

            }
        }

        private void Create_Tile_Click(object sender, EventArgs e)
        {
            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("CustomerTile=" + txtNome.Text));
            if (TileToFind == null) { 
                StandardTileData NewTileData = new StandardTileData
                {
                    BackTitle = txtNome.Text,
                    BackgroundImage = new Uri(horoscopo.Icone, UriKind.Relative)
                };

                ShellTile.Create(new Uri("/MainPage.xaml?CustomerTile=" + txtNome.Text, UriKind.Relative), NewTileData);
            }
        }

        private void select_horoscopo(string name)
        {
            foreach(Horoscopo o in listaHoroscopo.ItemsSource)
            {
                if (o.Nome.Equals(name))
                {
                    txtNome.Text = o.Nome;
                    txtData.Text = o.Data;
                    txtMsg.Text = o.Mensagem;
                }

            }
        }

    }

}