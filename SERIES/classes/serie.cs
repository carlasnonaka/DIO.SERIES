namespace SERIES
{
    public class serie : entidades
    {
        //Atributos
        public serie(int id,genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }
        private genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido {get; set;}

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: "+ this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo() 
        {
            return this.Titulo;
        }

         public string retornaDescricao() 
        {
            return this.Descricao;
        }
         public int retornaAno() 
        {
            return this.Ano;
        }
        public genero retornaGenero()
        {
            return this.Genero;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public bool Excluir()
        {
            return this.Excluido = true;
        }
        public bool AtualizarExclusao()
        {
            return this.Excluido = false;
        }

    }
}