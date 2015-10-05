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

namespace Horoscopo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            ConsumindoJson consumir = new ConsumindoJson(listaHoroscopo);
            InitializeComponent();
            salvarHoroscopo();
            CarregarHoroscopo();
           carregaicone();
            //consumir.conectar();
        }




        void CarregarHoroscopo()
        {

            using (var db = new HoroscopoContext())
            {
                var resultado = (from Horoscopo in db.signos
                                 select Horoscopo).ToList();

                listaHoroscopo.ItemsSource = resultado;

            }

          
          
        }


        void carregaicone()
        {

            List<Horoscopo> listaIcones = new List<Horoscopo>();
            Horoscopo horo = new Horoscopo();
            for (int i = 0; i <= 11; i++)
            {
                string icc = "/Assets/Icon/"+ i +".png";
                Uri uri = new Uri(icc, UriKind.Relative);
                BitmapImage icone = new BitmapImage(uri);
                Image img = new Image();
                img.Source = icone;
                horo.Icone =icone.ToString();
                listaIcones.Add(horo);
                listaHoroscopo.ItemsSource = listaIcones;
            }

        }

           void salvarHoroscopo()
           {

               Horoscopo horoscopo = new Horoscopo();
               horoscopo.Nome = "touro";
            horoscopo.Data = "20/06/2015";
            horoscopo.Mensagem = "BBBBBBBBBBBB";
               

               using(var db = new HoroscopoContext())
               {
                   db.signos.InsertOnSubmit(horoscopo);
                   db.SubmitChanges();
                CarregarHoroscopo();

            }

           }


        private void listaHoroscopo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            ListBox lst = (ListBox)sender;
            Horoscopo horoscopo = (Horoscopo)lst.SelectedItem;
            txtNome.Text = horoscopo.Nome;
            txtData.Text = horoscopo.Data;
            txtMsg.Text = horoscopo.Mensagem;

            Uri uri = new Uri(horoscopo.Icone, UriKind.Relative);
            BitmapImage ic = new BitmapImage(uri);
            iconedetalhe.Source = ic;
            PivotContato.SelectedIndex = 1;

        }
    }
}