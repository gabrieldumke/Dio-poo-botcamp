using System;

namespace DIO.Livros
{
    public class Livro : EntidadeBase
    {
        // Atributos
		private Materia Materia { get; set; }
		private string Titulo { get; set; }
		private string Assunto { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Livro(int id, Materia materia, string titulo, string assunto, int ano)
		{
			this.Id = id;
			this.Materia = materia;
			this.Titulo = titulo;
			this.Assunto = assunto;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Materia: " + this.Materia + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Assunto: " + this.Assunto + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}