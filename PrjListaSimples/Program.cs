using PrjListaSimples;

ItensList list = new ItensList();

int Menu()
{
    int opcao;
    bool repita;
    do
    {
        repita = false;

        Console.Write("Lista Simples" +
                    "\nEscolha uma opção de 1 a 4:" +
                    "\n[1] Inserir na lista" +
                    "\n[2] Imprimir lista" +
                    "\n[3] Remover da lista" +
                    "\n[4] Sair do programa" +
                    "\nDigite sua escolha: ");

        if (!int.TryParse(Console.ReadLine(), out opcao))
        {
            Console.Clear();
            Console.WriteLine("Opção não encontrada. Escolha novamente!\n");
            repita = true;
        }

    } while (repita);

    return opcao;
}


int valor, opcao;

do
{
    opcao = Menu();

    switch (opcao)
    {
        case 1:
            Console.Write("\nDigite um número para inserir: ");
            if (int.TryParse(Console.ReadLine(), out valor))
            {
                Item item = new(valor);
                list.Insert(item);
                Console.Clear();
                Console.WriteLine("\nItem inserido com sucesso!\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nApenas números são aceitos!\n");
            }
            break;

        case 2:
            list.Print();
            Console.WriteLine("\nPressione uma tecla para continuar...\n");
            Console.ReadKey();
            Console.Clear();
            break;

        case 3:
            list.Print();
            Console.Write("\nDigite um número para remover: ");
            if (int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Clear();
                list.Remove(valor);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nApenas números são aceitos!\n");
            }
            break;

        case 4:
            Console.WriteLine("\nTchau!\n");
            break;

        default:
            Console.Clear();
            Console.WriteLine("Opção fora do limite. Escolha uma opção entre 1 e 4!\n");
            break;
    }

} while (opcao != 4);
