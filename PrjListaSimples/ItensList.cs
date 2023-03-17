using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjListaSimples
{
    internal class ItensList
    {
        public Item Begin { get; set; }
        public Item End { get; set; }

        public ItensList()
        {
            Begin = null;
            End = null;
        }

        public bool IsEmpty()
        {
            return Begin == null ? true : false;
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nLista Vazia.\n");
            }
            else
            {
                Console.Write("\nValor(es) da lista:");
                Item aux = Begin;
                while (aux != null)
                {
                    Console.Write(aux.ToString());
                    aux = aux.Next;
                }
                Console.WriteLine();
            }
        }

        public Item Find(Item f)
        {
            Item aux = Begin;
            Item aux2 = Begin.Next;

            while (aux2.Value < f.Value && aux2 != null)
            {
                aux = aux.Next;
                aux2 = aux2.Next;
            }

            return aux;
        }

        public void Insert(Item i)
        {
            if (IsEmpty())
            {
                Begin = i;
                End = i;
            }
            else
            {
                if (i.Value <= Begin.Value)
                {
                    InsertFirst(i);
                }
                else
                {
                    if (i.Value >= End.Value)
                    {
                        InsertLast(i);
                    }
                    else
                    {
                        InsertMiddle(i);
                    }
                }

            }
        }
        public void InsertFirst(Item i)
        {
            i.Next = Begin;
            Begin = i;
        }
        public void InsertLast(Item i)
        {
            End.Next = i;
            End = i;
        }

        public void InsertMiddle(Item i)
        {
            Item aux = Find(i);
            i.Next = aux.Next;
            aux.Next = i;
        }

        public void Remove(int value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nLista vazia. Impossivel remover\n");
            }
            else
            {
                if (value < Begin.Value || value > End.Value)
                    Console.WriteLine("\nItem fora da lista\n");
                else
                {
                    Item aux = new(value);

                    if (aux.Value == Begin.Value)
                    {
                        RemoveFirst(aux);
                        Console.WriteLine("\nRemovido com sucesso!\n");
                    }
                    else
                    {
                        if (aux.Value == End.Value)
                        {
                            RemovetLast(aux);
                            Console.WriteLine("\nRemovido com sucesso!\n");
                        }
                        else
                        {
                            RemoveMiddle(aux);
                        }
                    }

                }

            }
        }
        private void RemoveFirst(Item i)
        {
            Begin = Begin.Next;
        }
        private void RemovetLast(Item i)
        {
            i = Find(i);
            i.Next = null;
            End = i;
        }

        private bool RemoveMiddle(Item i)
        {
            Item aux = Find(i);

            if (aux.Next.Value != i.Value)
            {
                Console.WriteLine("\nItem não encontrado\n");
                return false;
            }

            i = aux.Next;
            aux.Next = i.Next;

            return true;
        }
    }
}
