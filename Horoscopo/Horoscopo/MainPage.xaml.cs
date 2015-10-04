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
            salvarHoroscopo();
            CarregarHoroscopo();
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

            PivotContato.SelectedIndex = 1;

        }
    }
}