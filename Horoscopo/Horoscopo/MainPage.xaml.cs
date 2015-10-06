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
           // ConsumindoJson consumir = new ConsumindoJson(listaHoroscopo);
            InitializeComponent();
            salvarHoroscopo();
            CarregarHoroscopo();
           //carregaicone();
            //consumir.conectar();
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

           void salvarHoroscopo()
           {

               Horoscopo horoscopo = new Horoscopo();
               horoscopo.Nome = "Cancer";
            horoscopo.Data = "20/06/2015";
            horoscopo.Mensagem = "ASDFGGGG";
            horoscopo.Icone =  "/Assets/Icon/" + 2 + ".png";

               using (var db = new HoroscopoContext())
               {
                   db.signos.InsertOnSubmit(horoscopo);
                   db.SubmitChanges();
                CarregarHoroscopo();

            }

           }

        //Seleciona o signo e joga a pagina 2 do Pivot
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