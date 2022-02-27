using CadastroDeMusicas.Enums;
using System;

namespace CadastroDeMusicas.Classes
{
    public class Musica : EntidadeBase
    {
        public Musica(int id, Genero genero, string titulo, string descrição, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descrição = descrição;
            Ano = ano;
            Excluido = false;
            CriadoEm = AtualizadoEm = DateTime.Now;
        }

        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descrição { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        private DateTime CriadoEm { get; set; }
        private DateTime AtualizadoEm { get; set; }

        public override string ToString()
        {
            var retorno = "";

            retorno += $"Gênero: {Genero}{Environment.NewLine}";
            retorno += $"Titulo: {Titulo}{Environment.NewLine}";
            retorno += $"Descrição: {Descrição}{Environment.NewLine}";
            retorno += $"Ano: {Ano}{Environment.NewLine}";
            retorno += $"Excluido: {Excluido}";

            return retorno;
        }

        public string RetornaTitulo()
        {
            return Titulo;
        }

        public int RetornaId()
        {
            return Id;
        }
        public bool RetornaExcluido()
        {
            return Excluido;
        }

        public void Exclui()
        {
            Excluido = true;
            AtualizadoEm = DateTime.Now;
        }
    }
}

