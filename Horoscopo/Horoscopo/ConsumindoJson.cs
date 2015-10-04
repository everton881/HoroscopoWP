using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Horoscopo
{
    public class ConsumindoJson
    {
        ListBox lista;

        public ConsumindoJson(ListBox lista)
        {

            this.lista = lista;

        }

        public void conectar()
        {
            WebClient webClient = new WebClient();
            webClient.OpenReadCompleted += WebClient_OpenReadCompleted;
            webClient.OpenReadAsync(new Uri("http://developers.agenciaideias.com.br/horoscopo/json"));
           


        }

        private void WebClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {

            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(HoroscopoJson));
            HoroscopoJson consumir = (HoroscopoJson)json.ReadObject(e.Result);


            


               Horoscopo horoscopo = new Horoscopo
                {
                    Nome = consumir.nome,
                    Data = consumir.data,
                    Mensagem = consumir.msg

                };
                

                Console.Write("jsonnnnn" + horoscopo);
          

                  using (var db = new HoroscopoContext())
                   {
                       db.signos.InsertOnSubmit(horoscopo);
                       db.SubmitChanges();


                   }


            }




        }



    
}
