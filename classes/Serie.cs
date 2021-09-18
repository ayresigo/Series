namespace Series
{
    public class Serie : Base
    {
        private Genero genero {get; set;}
        private string titulo {get; set;}
        private string descricao {get; set;}
        private int ano {get; set;}

        private bool excluido {get; set;}

        
        public Serie(int id, Genero genero, string titulo, string descricao, int ano) {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
        }

        public override string ToString() {
            string retorno = "\n";
            retorno += "[ #ID "+id+" ]\n";
            retorno += "Gênero: " + this.genero + "\n";
            retorno += "Titulo: " + this.titulo + "\n";
            retorno += "Descrição: " + this.descricao + "\n";
            retorno += "Ano de Estréia: " + this.ano + "\n";
            retorno += "Excluido: " + this.excluido + "\n";
            return retorno;
        }

        public void AtualizarGenero(Genero genero) {
            this.genero = genero;
        }
        public void AtualizarTitulo(string titulo) {
            this.titulo = titulo;
        }
        public void AtualizarDescricao(string descricao) {
            this.descricao = descricao;
        }
        public void AtualizarAno(int ano) {
            this.ano = ano;
        }
        public void Excluir() {
            this.excluido = true;
        }
        public int RetornaId() {
            return this.id;
        }
        public string RetornaTitulo() {
            return this.titulo;
        }
        public bool Excluido() {
            return this.excluido;
        }
        public void ToggleExcluir() {
            if (this.excluido == true) {
                this.excluido = false;
            } else {
                this.excluido = true;
            }
        }
    }
}