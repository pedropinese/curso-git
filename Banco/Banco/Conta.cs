using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Banco
{
    class Conta
    {
        public double saldo { get; set; }
        public string usuario { get; set; }
        public int numero { get; set; }

        StreamWriter escritor;
        StreamReader leitor;
        Conta c;
        List<Conta> listaContas;

        public Conta(double saldo, string usuario, int numero)
        {
            this.saldo = saldo;
            this.usuario = usuario;
            this.numero = numero;
        }

        public Conta()
        {
        }

        public List<Conta> ler_arquivo()
        {
            using (leitor = new StreamReader("C:\\Users\\pedro.pinese\\Desktop\\Pedro\\C#\\Teste_VS_Console\\Banco\\Banco\\contas.txt", Encoding.Default))
            {
                string[] linhas = leitor.ReadToEnd().Split('\n');
                listaContas = new List<Conta>();
                if (linhas[0] == "")
                {
                }
                else
                {
                    foreach (string l in linhas)
                    {
                        int i = 0;
                        string[] item = l.Split('|');
                        if (item[i] != "")
                        {
                            c = new Conta();
                            c.numero = Convert.ToInt32(item[0]);
                            c.usuario = item[1];
                            c.saldo = Convert.ToDouble(item[2]);
                            listaContas.Add(c);
                        }
                    }
                }
                return listaContas;
            }
        }

        public void cria(Conta c)
        {
            Console.Write("Numero da conta:");
            c.numero = Int32.Parse(Console.ReadLine());
            Console.Write("Nome:");
            c.usuario = Console.ReadLine();
            c.saldo = 0;
            using (escritor = new StreamWriter("C:\\Users\\pedro.pinese\\Desktop\\Pedro\\C#\\Teste_VS_Console\\Banco\\Banco\\contas.txt", true))
            {
                escritor.WriteLine("{0}|{1}|{2}", c.numero, c.usuario, c.saldo);
            }
        }
        public void deposita(Conta c)
        {
            Console.Write("Valor para deposito: R$");
            double deposito = double.Parse(Console.ReadLine());
            c.saldo = c.saldo + deposito;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deposito realizado com sucesso!");
            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla..");
            Console.ReadKey();
            //atualizar valor no arquivo
    }

    public void saca(Conta c)
    {
        Console.Write("Valor para saque: R$");
        double saque = double.Parse(Console.ReadLine());
        if (c.saldo > saque)
        {
            c.saldo = c.saldo - saque;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saque realizado com sucesso!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Saldo insuficiente!");
            Console.ResetColor();
            string escolha = "x";
            while (escolha != "n" && escolha != "N")
            {
                Console.WriteLine("\nDeseja consultar o saldo? (s/n)");
                escolha = Console.ReadLine();
                if (escolha == "s" || escolha == "S")// se eu clicar em sim
                {
                    Console.WriteLine("Saldo atual: {0}", c.saldo);
                    escolha = "n";
                }
                //se nao for nem sim e nem nao
                else if (escolha != "s" && escolha != "S" && escolha != "n" && escolha != "N")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    escolha = "n";
                    Console.ReadKey();
                }
            }



        }
        Console.ResetColor();
        Console.WriteLine("\nPressione qualquer tecla..");
        Console.ReadKey();
    }

    public void numero_invalido()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Numero inválido!");
        Console.ResetColor();
        Console.WriteLine("\nPressione qualquer tecla..");
        Console.ReadKey();
    }

}
}
