using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)


        {
            // Variaveis que seram utilizadas
            string cod, nome_produto, categoria_produto, voltar="s";
            double preco_produto, peso_produto;
            
            // Tela Inicial
            while (voltar =="s"){
                Console.Clear();
           Console.ForegroundColor = ConsoleColor.Green;
           Console.BackgroundColor = ConsoleColor.White;
           Console.WriteLine(" ██╗██████╗ ██╗██████╗     ███████╗██╗  ██╗███████╗");
           Console.WriteLine(" ██║██╔══██╗██║██╔══██╗    ██╔════╝╚██╗██╔╝██╔════╝");
           Console.WriteLine(" ██║██████╔╝██║██║  ██║    █████╗   ╚███╔╝ █████╗  ");
           Console.WriteLine(" ██║██╔══██╗██║██║  ██║    ██╔══╝   ██╔██╗ ██╔══╝  ");
           Console.WriteLine(" ██║██████╔╝██║██████╔╝ ██╗███████╗██╔╝ ██╗███████╗");
           Console.WriteLine(" ╚═╝╚═════╝ ╚═╝╚═════╝  ╚═╝╚══════╝╚═╝  ╚═╝╚══════╝");
           Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("");
            Console.Write("Cadastro de Produtos");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("█████████████████ MENU DE OPÇÕES█████████████████    ");
            Console.WriteLine("█                                               █    ");
            Console.WriteLine("█ 1 - Cadastrar Um Produto                      █    ");
            Console.WriteLine("█                                               █    ");
            Console.WriteLine("█ 2 - Alterar Um Produto                        █    ");
            Console.WriteLine("█                                               █    ");
            Console.WriteLine("█ 3 - Excluir Um Produto                        █    ");
            Console.WriteLine("█                                               █    ");
            Console.WriteLine("█ 4 - Consultar a Tabela de Produtos            █    ");
            Console.WriteLine("█                                               █    ");
            Console.WriteLine("█████████████████████████████████████████████████    ");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Digite o Numero Da Opção Desejada: ");
             var leitura = Console.ReadLine();

          
            //TELA Para cadastro de produtos
            if (leitura == "1")
            {
                Console.Clear(); 
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("Cadastrar Um Produto");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("╔════════════════════════╗");
                Console.Write("║♦ Entre Com o Codigo Do Produto (Lembrando Codigo Unico): ");
                Console.ForegroundColor = ConsoleColor.White;
                cod = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("║♦ Entre Com o Nome Do Produto: ");
                Console.ForegroundColor = ConsoleColor.White;
                nome_produto = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("║♦ Entre Com a Categoria Do Produto: ");
                Console.ForegroundColor = ConsoleColor.White;
                categoria_produto = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("║♦ Entre Com o Preço Do Produto: ");
                Console.ForegroundColor = ConsoleColor.White;
                preco_produto = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("║♦ Entre Com o Peso Do Produto (Em Gramas): ");
                Console.ForegroundColor = ConsoleColor.White;
                peso_produto = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╚════════════════════════╝");
                
                
                              
                // Abrindo A Conexão e Usando Comandos SQL 
                NpgsqlConnection conn = new NpgsqlConnection("Server=rajje.db.elephantsql.com;Port=5432;User Id=knitjysu;Password=OTU-dClsm2AUQ4Xjn5cJlU9HiCmMOeYL;Database=knitjysu;");           
                conn.Open();       
                // Comando SQL
                string cmdSeleciona = "insert into produtos(cod_prod,nome_prod,cat_prod,pre_prod,peso_prod) values ('" + cod + "','" + nome_produto + "','" + categoria_produto + "','" + preco_produto + "','" + peso_produto + "')";
                // Aplicação do Comando
                NpgsqlCommand Lcmd = new NpgsqlCommand(cmdSeleciona, conn);
                Lcmd.ExecuteReader();
                conn.Close();
                Console.WriteLine("Produto " + "'" + nome_produto + "'" + " Cadastrado Com Êxito!");
                //estrutura pra voltar a TELA INICIAL
                Console.Write("Deseja voltar para o menu:(S/N) ");
                voltar = Console.ReadLine();
            }


            //TELA Para ver os produtos cadastrados
            if (leitura == "4")
            {
                Console.Clear();         



            // Abrindo A Conexão e Usando Comandos SQL 
            NpgsqlConnection conn = new NpgsqlConnection("Server=rajje.db.elephantsql.com;Port=5432;User Id=knitjysu;Password=OTU-dClsm2AUQ4Xjn5cJlU9HiCmMOeYL;Database=knitjysu;");           
            conn.Open();
            // Comando SQL
             string cmdSeleciona = "Select * from produtos";
            // Aplicação do Comando
            NpgsqlCommand Lcmd = new NpgsqlCommand(cmdSeleciona, conn);
            NpgsqlDataReader lect = Lcmd.ExecuteReader();

           //Tabela Dos Produtos 

          

                      
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Produtos Cadastrados");
                Console.WriteLine("");
                Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████");
                Console.WriteLine(String.Format("█{0, -15}{1, -25}{2, -16}R$ {3, -16}(G){4, -16}{5, -1}█", "CÓDIGO", "NOME", "CATEGORIA", "PREÇO", "PESO", ""));
                Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████");

                    while (lect.Read())
                {
                    Console.WriteLine(String.Format("█{0, -15}{1, -25}{2, -16}R$ {3, -16}(G){4, -16}{5, -1}█", lect["cod_prod"], lect["nome_prod"], lect["cat_prod"], lect["pre_prod"], lect["peso_prod"], ("")));
                }


                Console.ResetColor();
                conn.Close();
                Console.Write("Deseja voltar para o menu:(S/N) ");
                voltar = Console.ReadLine();
            }

            // TELA para alterar um produto
            if (leitura == "2")
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("Alterar Produtos");
               

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔════════════════════════╗");
                Console.Write("║♦ Entre com o Codigo Do Produto:");
                Console.ForegroundColor = ConsoleColor.White;
                cod = Console.ReadLine();
                Console.Clear();




                // Abrindo A Conexão e Usando Comandos SQL
                NpgsqlConnection conn = new NpgsqlConnection("Server=rajje.db.elephantsql.com;Port=5432;User Id=knitjysu;Password=OTU-dClsm2AUQ4Xjn5cJlU9HiCmMOeYL;Database=knitjysu;");           
                conn.Open();
                // Comando SQL para procurar o produto pelo COD
                string cmdSeleciona = "Select * from produtos where cod_prod='" + cod + "'";
                // Aplicação do Comando
                NpgsqlCommand Lcmd = new NpgsqlCommand(cmdSeleciona, conn);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
               // Inserindo Novas Info


                 if (lect.Read())
                {
                        

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("║♦ Entre Com o Nome Do Produto: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        nome_produto = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("║♦ Entre Com a Categoria Do Produto: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        categoria_produto = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("║♦ Entre Com o Preço Do Produto: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        preco_produto = double.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("║♦ Entre Com o Peso Do Produto: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        peso_produto = double.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("╚════════════════════════╝");
                                              
                           

                // Abrindo A Conexão e Usando Comandos SQL
                NpgsqlConnection conn1 = new NpgsqlConnection("Server=rajje.db.elephantsql.com;Port=5432;User Id=knitjysu;Password=OTU-dClsm2AUQ4Xjn5cJlU9HiCmMOeYL;Database=knitjysu;");           
                conn1.Open();
                 // Comando SQL Para atuliazar a tabela com novas info
                string cmdupdate = "update produtos set nome_prod='"+nome_produto+"', cat_prod= '"+categoria_produto+"', pre_prod= '"+preco_produto+ "', peso_prod= '"+peso_produto+"'  where cod_prod='" + lect["cod_prod"] + "'";
                 // Aplicação do Comando
                NpgsqlCommand Ucmd = new NpgsqlCommand(cmdupdate, conn1);
                Ucmd.ExecuteReader();
                conn1.Close();
                conn.Close();
                Console.Write("Deseja voltar para o menu:(S/N) ");
                voltar = Console.ReadLine();
                   
                }
                else
                {
                    Console.WriteLine("Produto Não Encontrado!");
                    Console.Write("Deseja voltar para o menu:(S/N) ");
                    voltar = Console.ReadLine();

                }
               





            // TELA para Excluir um produto
            }
            if (leitura == "3")
            {
                Console.Clear(); 
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Excluir Um Produto");
                

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("♦ Entre com o código do Produto: ");
                Console.ForegroundColor = ConsoleColor.White;
                cod = Console.ReadLine();





                // Abrindo A Conexão e Usando Comandos SQL
                NpgsqlConnection conn = new NpgsqlConnection("Server=rajje.db.elephantsql.com;Port=5432;User Id=knitjysu;Password=OTU-dClsm2AUQ4Xjn5cJlU9HiCmMOeYL;Database=knitjysu;");
                conn.Open();
               //Procurando o produto pelo cod
                string cmdSeleciona = "Select * from produtos where cod_prod='" + cod + "'";
              //Execução do comando
                NpgsqlCommand Lcmd = new NpgsqlCommand(cmdSeleciona, conn);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
              


                if (lect.Read())
                {
                    string desejaexcluir="";
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("♦ Tem certeza que deseja excluir o Produto  '" + lect["nome_prod"] + "'?(S/N) ");
                    Console.ForegroundColor = ConsoleColor.White;
                    desejaexcluir = Console.ReadLine();
                    

                    if (desejaexcluir == "s")
                    {

                        // Abre conexão novamente
                        NpgsqlConnection conn1 = new NpgsqlConnection("Server=rajje.db.elephantsql.com;Port=5432;User Id=knitjysu;Password=OTU-dClsm2AUQ4Xjn5cJlU9HiCmMOeYL;Database=knitjysu;");
                        conn1.Open();
                        // Comando para deletar da tabela
                        string cmdupdate = "delete from  produtos where cod_prod='" + lect["cod_prod"] + "'";

                        NpgsqlCommand Ucmd = new NpgsqlCommand(cmdupdate, conn1);
                        Ucmd.ExecuteReader();
                        conn1.Close();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Deseja voltar para o menu:(S/N) ");
                        Console.ForegroundColor = ConsoleColor.White;
                        voltar = Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("Deseja voltar para o menu:(S/N) ");
                        voltar = Console.ReadLine();
                    }


                }
                else
                {
                    Console.WriteLine("Registro Do Produto Não Encontrado!");
                    Console.Write("Deseja voltar para o menu:(S/N) ");
                    voltar = Console.ReadLine();

                }

                    







            }

          
         


        }
    }
    }
}
