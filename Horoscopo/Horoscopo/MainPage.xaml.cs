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

namespace Horoscopo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            ConsumindoJson consumir = new ConsumindoJson(listaHoroscopo);
            InitializeComponent();
            // salvarHoroscopo();
            CarregarHoroscopo();
            consumir.conectar();
        }




        void CarregarHoroscopo()
        {

            using (var db = new HoroscopoContext())
            {
                var resultado = (from Horoscopo in db.signos
                                 select Horoscopo).ToList();

                listaHoroscopo.ItemsSource = resultado;

            }


            /* List<Horoscopo> horoscopoLista = new List<Horoscopo>();
             Horoscopo horoscopo = new Horoscopo
             {

                 Nome = "Áries"
             };
             Horoscopo horoscopo2 = new Horoscopo
             {

                 Nome = "Touro"
             };
             horoscopoLista.Add(horoscopo);
             horoscopoLista.Add(horoscopo2);


             listaHoroscopo.ItemsSource = horoscopoLista;*/
        }


        /*   void salvarHoroscopo()
           {

               Horoscopo horoscopo = new Horoscopo();
               horoscopo.Nome = "Aries";

               using(var db = new HoroscopoContext())
               {
                   db.signos.InsertOnSubmit(horoscopo);
                   db.SubmitChanges();


               }

           }*/


        private void listaHoroscopo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/DescricaoHoroscopo.xaml", UriKind.Relative));

        }
    }
}