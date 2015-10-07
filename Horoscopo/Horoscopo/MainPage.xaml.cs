﻿using System;
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
        bool isNewInstance = true;
        // Constructor
        public MainPage()
        {

            ConsumindoJson consumir = new ConsumindoJson();
            consumir.conectar();
            InitializeComponent();
        //   salvarHoroscopo();
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

     

        //Seleciona o signo e joga a pagina 2 do Pivot
        private void listaHoroscopo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            ListBox lst = (ListBox)sender;
            Horoscopo horoscopo = (Horoscopo)lst.SelectedItem;
            txtNome.Text = horoscopo.Nome;
            txtData.Text = horoscopo.Data;
            txtMsg.Text = horoscopo.Mensagem;

       /*     Uri uri = new Uri(horoscopo.Icone, UriKind.Relative);
            BitmapImage ic = new BitmapImage(uri);
            iconedetalhe.Source = ic;
            PivotContato.SelectedIndex = 1;*/

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
                if (State.ContainsKey("NOME"))
                {

                    txtNome.Text = State["NOME"].ToString();
                }
            }
        }


    }
}