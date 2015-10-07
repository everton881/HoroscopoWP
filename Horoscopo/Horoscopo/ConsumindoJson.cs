using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Horoscopo
{
    public class ConsumindoJson
    {
      
        public void conectar()
        {
            WebClient webClient = new WebClient();
            webClient.OpenReadCompleted += WebClient_OpenReadCompleted;
            webClient.OpenReadAsync(new Uri("http://mftc.cf/everton/horoscopo.xml"));
       

        }

        private void WebClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {

            List<Horoscopo> listaHoroscopo = new List<Horoscopo>();
            XDocument doc = XDocument.Load(e.Result);
         
            using (var db = new HoroscopoContext())
            {
               
                foreach (var item in doc.Descendants("signo"))
                {
                    Horoscopo horoscopo = new Horoscopo();
                    horoscopo.Nome = (string)item.Element("nome");
                    horoscopo.Data = (string)item.Element("data");
                    horoscopo.Mensagem = (string)item.Element("msg");
                   
                    // horoscopo.Icone = "/Assets/Icon/" + i + ".png";
                  
                    db.signos.InsertOnSubmit(horoscopo);
                    db.SubmitChanges();

                }
               
            }
            
            
        }

    }

        



    
}
