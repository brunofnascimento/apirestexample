using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class UsuarioModel
    {

        private int codigo;
        private string nome;
        private string cpf;

        public UsuarioModel()
        {
        }

        public UsuarioModel(int codigo, string nome, string cpf)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.CPF = cpf;
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string CPF
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }


    }
}