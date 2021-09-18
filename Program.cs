using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string op = LerOpcao();

            while (op != "X") {
                switch(op) {
                    case "1":
                        ListarSerie();
                        break;

                    case "2":
                        InserirSerie();
                        break;
                    
                    case "3":
                        EditarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        BuscarSerie().ToString();
                        Console.ReadLine();
                        break;

                    case "X":
                        break;
                        
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                op = LerOpcao();
            }
        }

        private static Serie BuscarSerie(int idSerie = -1)
        { 
            Console.Clear();
            Console.WriteLine("[ BUSCAR SERIES ]");
            if (idSerie == -1) {
                Console.WriteLine("Digite o ID da série: ");
                idSerie = int.Parse(Console.ReadLine());
            }

            var lista = repositorio.Lista();
            foreach (var serie in lista)
            {
                if (serie.RetornaId() == idSerie) {
                    Console.WriteLine(serie.ToString());
                    return serie;
                }                    
            }
            
            Console.WriteLine("ID " + idSerie + " não encontrado.");
            Console.ReadLine();
            return null;
        }
        public static void ListarSerie() {
            Console.Clear();
            Console.WriteLine("[ LISTAR SERIES ]");

            var lista = repositorio.Lista();

            foreach (var serie in lista)
            {
                if(!serie.Excluido()) {
                    Console.WriteLine();
                    Console.WriteLine("#ID: " + serie.RetornaId() + "\nTitulo: " + serie.RetornaTitulo() + ".");      
                }
            }

            Console.ReadLine();
        }
        public static bool ValidarBusca(int id) {
            var lista = repositorio.Lista();
            foreach (var serie in lista)
            {
                if (serie.RetornaId() == id)
                    return true;
            }
            return false;
        }
        public static void ExcluirSerie() {
            Console.Clear();
            Console.WriteLine("[ EXCLUIR SERIE ]");
            Console.WriteLine("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());
            if (ValidarBusca(idSerie)) {
                repositorio.Exclui(idSerie);
            } else {
                Console.WriteLine("ID " + idSerie + " não encontrado.");
            }            
        }
        public static void EditarSerie() {
            Console.Clear();
            Console.WriteLine("[ EDITAR SERIE ]");
            Console.WriteLine("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            if (ValidarBusca(idSerie)) {
                Console.WriteLine();
                Serie serie = BuscarSerie(idSerie); 
                Console.WriteLine();
                Console.WriteLine("Qual atributo deseja editar?");
                Console.WriteLine("1 -> Genero");
                Console.WriteLine("2 -> Titulo");
                Console.WriteLine("3 -> Descricao");
                Console.WriteLine("4 -> Ano de Estréia");
                Console.WriteLine("5 -> Excluir/Restaurar");
                Console.WriteLine("* Para voltar, digite qualquer valor.");
                Console.WriteLine();
                string op = Console.ReadLine();
                
                switch(op) {
                    case "1":
                        Console.WriteLine("Lista de gêneros: ");
                        foreach (int i in Enum.GetValues(typeof(Genero)))
                        {
                            Console.WriteLine(i + " - " + Enum.GetName(typeof(Genero), i));
                        }

                        Console.WriteLine();
                        Console.WriteLine("Digite o ID do gênero desejado: ");
                        int generoInput = int.Parse(Console.ReadLine());
                        if (generoInput < 0 || generoInput > Enum.GetNames(typeof(Genero)).Length) {
                            generoInput = 0;
                        }
                        serie.AtualizarGenero((Genero)generoInput);
                        Console.WriteLine();
                        Console.WriteLine(BuscarSerie(idSerie));
                        break;

                    case "2":
                        Console.WriteLine("Informe o Titulo da série: ");
                        string tituloInput = Console.ReadLine();  
                        serie.AtualizarTitulo(tituloInput);
                        Console.WriteLine();
                        Console.WriteLine(BuscarSerie(idSerie));
                        break;

                    case "3":
                        Console.WriteLine("Informe a Descricao da série: ");
                        string descricaoInput = Console.ReadLine();
                        serie.AtualizarDescricao(descricaoInput);
                        Console.WriteLine();
                        Console.WriteLine(BuscarSerie(idSerie));
                        break;

                    case "4":
                        Console.WriteLine("Informe o Ano de Estréia da série: ");
                        int anoInput = int.Parse(Console.ReadLine());
                        serie.AtualizarAno(anoInput);
                        Console.WriteLine();
                        Console.WriteLine(BuscarSerie(idSerie));
                        break;
                    
                    case "5":
                        serie.ToggleExcluir();
                        Console.WriteLine(BuscarSerie(idSerie));
                        break;

                    default:
                        break;
                }
            } else {
                Console.WriteLine("ID " + idSerie + " não encontrado.");
            }
            Console.WriteLine();
        }
        public static void InserirSerie() {
            Console.Clear();
            Console.WriteLine("[ INSERIR SERIE ]");
            Console.WriteLine("Lista de gêneros: ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine(i + " - " + Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine();
            Console.WriteLine("Digite o ID do gênero desejado: ");
            int generoInput = int.Parse(Console.ReadLine());
            if (generoInput < 0 || generoInput > Enum.GetNames(typeof(Genero)).Length) {
                generoInput = 0;
            }        

            Console.WriteLine("Informe o Titulo da série: ");
            string tituloInput = Console.ReadLine();  

            Console.WriteLine("Informe a Descricao da série: ");
            string descricaoInput = Console.ReadLine();

            Console.WriteLine("Informe o Ano de Estréia da série: ");
            int anoInput = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie (id: repositorio.ProximoId(),
                                        genero: (Genero)generoInput,
                                        titulo: tituloInput,
                                        descricao: descricaoInput,
                                        ano: anoInput);

            repositorio.Insere(novaSerie);
        }
        public static string LerOpcao() {
            Console.Clear();
            Console.WriteLine("[ MENU PRINCIPAL ]");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("1 -> Listar");
            Console.WriteLine("2 -> Inserir");
            Console.WriteLine("3 -> Editar");
            Console.WriteLine("4 -> Excluir");
            Console.WriteLine("5 -> Buscar");
            Console.WriteLine();
            Console.WriteLine("X -> Sair");
            Console.WriteLine();
            string op = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return op;
        }
    }
}
