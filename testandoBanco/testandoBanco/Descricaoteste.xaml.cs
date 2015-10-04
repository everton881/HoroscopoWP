using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace testandoBanco
{
    public partial class Descricaoteste : PhoneApplicationPage
    {
        public string nome;

        public Descricaoteste()
        {
            InitializeComponent();
            //carregarAluno();
            Aluno al = new Aluno();

            al.Nome = this.nome;

            txtNome.Text = nome;
            txtLocal.Text = al.Local;
            txtTurma.Text = al.Turma;


            MessageBox.Show(al.Nome + al.Local + al.Turma);

        }


     



         public void carregarAluno (string nome)
          {

           


              /*  using (var db = new AlunoContext())
                     {

                         var resultado = (from Aluno in db.alunos
                                          select Aluno).ToList();

                         txtNome.Text = resultado.FirstOrDefault().Nome;
                         txtLocal.Text = resultado.FirstOrDefault().Local;
                         txtTurma.Text = resultado.FirstOrDefault().Turma;

                     }*/



          }
  

    }



}