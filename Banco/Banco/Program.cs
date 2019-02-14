using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = 999, x, y;
            var listaContas = new List<Conta>();
            Conta c_princ = new Conta();
            while (op != 0)
            {
                Console.Clear();
                Console.WriteLine("\t\tBANCO\n\n1- Criar conta\n2- Consultar saldo\n3- Deposito\n4- Saque\n5- Contas existentes\n6- Transferencia\n0- Sair");
                op = Int32.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("\t\tBANCO - Criar\n\n");
                            Conta c = new Conta();
                            listaContas = c.ler_arquivo();
                            x = 0;
                            if(listaContas.Count == 0)
                            {
                                c.cria(c);
                                listaContas.Add(c);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Conta criada!!");
                                Console.ResetColor();
                                Console.WriteLine("Pressione qualquer tecla..");
                                Console.ReadKey();
                                break;
                            }
                            foreach (Conta conta in listaContas)
                            {
                                if (c.numero == conta.numero)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Conta já existe!");
                                    Console.ResetColor();
                                    Console.WriteLine("\nPressione qualquer tecla..");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    x++;
                                    if (x == listaContas.Count)
                                    {
                                        c.cria(c);
                                        listaContas.Add(c);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Conta criada!!");
                                        Console.ResetColor();
                                        Console.WriteLine("Pressione qualquer tecla..");
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("\t\tBANCO - Saldo\n\n");
                            Console.Write("Entre com o numero da conta:");
                            int numero_consulta = Int32.Parse(Console.ReadLine());
                            listaContas = c_princ.ler_arquivo();
                            if (listaContas.Count == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Nenhuma conta cadastrada!");
                                Console.ResetColor();
                                Console.WriteLine("\nPressione qualquer tecla..");
                                Console.ReadKey();
                            }
                            else
                            {
                                x = 0;
                                foreach (Conta c in listaContas)
                                {
                                    if (numero_consulta == c.numero)
                                    {
                                        Console.WriteLine("Saldo: {0}", c.saldo.ToString("C"));
                                        Console.WriteLine("\n Pressione qualquer tecla..");
                                        Console.ReadKey();
                                        break;
                                    }
                                    else
                                    {
                                        x++;
                                        if (x == listaContas.Count)
                                        {
                                            c.numero_invalido();
                                        }
                                    }
                                }
                                break;
                            }
                            break;
                        }

                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("\t\tBANCO - Deposito\n\n");
                            Console.Write("Entre com o numero da conta:");
                            int numero_consulta = Int32.Parse(Console.ReadLine());
                            listaContas = c_princ.ler_arquivo();
                            if (listaContas.Count == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Nenhuma conta cadastrada!\nPressione qualquer tecla..");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                            else
                            {
                                x = 0;
                                foreach (Conta c in listaContas)
                                {
                                    if (numero_consulta == c.numero)
                                    {
                                        c.deposita(c);
                                        break;
                                    }
                                    else
                                    {
                                        x++;
                                        if (x == listaContas.Count)
                                        {
                                            c.numero_invalido();
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("\t\tBANCO - Saque\n\n");
                            Console.Write("Entre com o numero da conta:");
                            int numero_consulta = Int32.Parse(Console.ReadLine());
                            listaContas = c_princ.ler_arquivo();
                            if (listaContas.Count == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Nenhuma conta cadastrada!\nPressione qualquer tecla..");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                            else
                            {
                                x = 0;
                                foreach (Conta c in listaContas)
                                {
                                    if (numero_consulta == c.numero)
                                    {
                                        c.saca(c);
                                        break;
                                    }
                                    else
                                    {
                                        x++;
                                        if (x == listaContas.Count)
                                        {
                                            c.numero_invalido();
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("\t\tBANCO - Contas\n\n");
                            listaContas = c_princ.ler_arquivo();
                            foreach (Conta conta in listaContas)
                            {
                                Console.Write("_____________________________\n");
                                Console.WriteLine("Nº Conta: {0}\nNome: {1}", conta.numero, conta.usuario);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("\t\tBANCO - Transferencia\n\n");
                            Console.Write("Conta remetente:");
                            int remetente = Int32.Parse(Console.ReadLine());
                            listaContas = c_princ.ler_arquivo();
                            if (listaContas.Count == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Nenhuma conta cadastrada!");
                                Console.ResetColor();
                                Console.WriteLine("\nPressione qualquer tecla..");
                                Console.ReadKey();
                            }
                            else
                            {
                                x = 0;
                                foreach (Conta c_reme in listaContas)
                                {
                                    if (remetente == c_reme.numero)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\t\tBANCO - Transferencia\n\n");
                                        Console.Write("Conta destinatario:");
                                        int dest = Int32.Parse(Console.ReadLine());
                                        y = 0;
                                        foreach (Conta c_dest in listaContas)
                                        {
                                            if (remetente == dest)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("\t\tBANCO - Transferencia\n\n");
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.Write("Impossivel realizar transferencia para a mesma conta");
                                                Console.ResetColor();
                                            }
                                            else if (dest == c_dest.numero)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("\t\tBANCO - Transferencia\n\n");
                                                Console.Write("Valor:");
                                                double valor = double.Parse(Console.ReadLine());
                                                if (c_reme.saldo > valor)
                                                {
                                                    c_reme.saldo = c_reme.saldo - valor;
                                                    c_dest.saldo = c_dest.saldo + valor;
                                                    Console.Clear();
                                                    Console.WriteLine("\t\tBANCO - Transferencia\n\n");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("Transferencia realizada com sucesso!");
                                                    Console.ResetColor();
                                                    Console.WriteLine("\nPressione qualquer tecla..");
                                                    Console.ReadKey();
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\t\tBANCO - Transferencia\n\n");
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.Write("Saldo abaixo do valor da tranferencia!");
                                                    Console.ResetColor();
                                                    Console.WriteLine("\nPressione qualquer tecla..");
                                                    Console.ReadKey();
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                y++;
                                                if (y == listaContas.Count)
                                                {
                                                    c_dest.numero_invalido();
                                                }
                                            }
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        x++;
                                        if (x == listaContas.Count)
                                        {
                                            c_reme.numero_invalido();
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case 0:
                        {
                            Console.Clear();
                            Console.WriteLine("\t\tBANCO - Sair\n\n");
                            Console.WriteLine("Ate logo!\n Pressione qualquer tecla..");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("\t\tBANCO - Erro\n\n");
                            Console.WriteLine("Opcao invalida!\n Pressione qualquer tecla..");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
    }
}
