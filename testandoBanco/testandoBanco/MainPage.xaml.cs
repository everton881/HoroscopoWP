using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using testandoBanco.Resources;

namespace testandoBanco
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
           carregarAluno();

            //salvarAluno();



        }


        void carregarAluno()
        {

            using (var db = new AlunoContext())
            {

             
                var resultado = (from Aluno in db.alunos
                                 select Aluno).ToList();

                listaAluno.ItemsSource = resultado;

            }

         
        }

       /* void salvarAluno()
        {

            Aluno aluno = new Aluno
            {

                Nome = "Seila",
                Local = "paulista",
                Turma = "A"
            };


            using (var db = new AlunoContext())
            {
                db.alunos.InsertOnSubmit(aluno);
                db.SubmitChanges();
                
            }

            carregarAluno();

        }*/

        private void listaAluno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lst;
            lst = (ListBox)sender;
           Aluno al = (Aluno)lst.SelectedItem;
            string nome1 = al.Nome;
            string local = al.Local;
            string turma = al.Turma;
            Descricaoteste desc = new Descricaoteste();
            //desc.carregarAluno();
            desc.nome = nome1;
           
           // MessageBox.Show(nome + local + turma);

            
         NavigationService.Navigate(new Uri("/Descricaoteste.xaml", UriKind.Relative));

        }
    }
}