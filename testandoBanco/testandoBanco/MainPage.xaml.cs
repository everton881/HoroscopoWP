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
            salvarAluno();



        }


        void carregarAluno()
        {

            using (var db = new AlunoContext())
            {

             
                var resultado = (from Aluno in db.alunos
                                 select Aluno).ToList();

                txtNome.Text = resultado.FirstOrDefault().Nome;
                txtLocal.Text = resultado.FirstOrDefault().Local;
                txtTurma.Text = resultado.FirstOrDefault().Turma;

            }

         
        }

        void salvarAluno()
        {

            Aluno aluno = new Aluno
            {

                Nome = "Everton",
                Local = "Paulista",
                Turma = "A"
            };


            using (var db = new AlunoContext())
            {
                db.alunos.InsertOnSubmit(aluno);
                db.SubmitChanges();



            }

        }
    }
}