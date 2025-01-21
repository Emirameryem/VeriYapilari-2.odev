using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriYapilariOdev_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Liste liste = new Liste();
            int sayi, indis;

            int secim = menu();
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("sayı: "); sayi = int.Parse(Console.ReadLine());
                        liste.basaEkle(sayi); break;
                    case 2:
                        Console.Write("sayı: "); sayi = int.Parse(Console.ReadLine());
                        liste.sonaEkle(sayi); break;
                    case 3:
                        Console.Write("indis: "); indis = int.Parse(Console.ReadLine());

                        Console.Write("sayı: "); sayi = int.Parse(Console.ReadLine());
                        liste.arayaEkle(indis, sayi); break;
                    case 0: break;

                    case 4: liste.bastanSil(); break;
                    case 5: liste.sondanSil(); break;
                    case 6:
                        Console.Write("indis: "); indis = int.Parse(Console.ReadLine());
                        liste.aradanSil(indis); break;

                    default:
                        Console.WriteLine("hatalı seçim!");
                        break;
                }
                Console.Clear();
                liste.yazdir();
                secim = menu();

            }



            Console.ReadLine();
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("\n\n1- başa ekle ");
            Console.WriteLine("2- sona ekle ");
            Console.WriteLine("3- araya ekle ");
            Console.WriteLine("4- baştan sil  ");
            Console.WriteLine("5- sondan sil ");
            Console.WriteLine("6- aradan sil ");
            Console.WriteLine("0- çıkış ");
            Console.Write("seçiniz: ");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }




    class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }

    }

    class Liste
    {
        Node head;
        Node tail;
        public Liste()
        {
            head = null;
            tail = null;
        }

        public void basaEkle(int data)
        {
            Node eleman = new Node(data);

            if (head == null)
            {
                head = tail = eleman;
                tail.next = head;
                Console.WriteLine("liste oluşturuldu, ilk eleman eklendi");

            }
            else
            {
                eleman.next = head;
                head = eleman;
                tail.next = head;
                Console.WriteLine("başa eleman eklendi");
            }

        }

        public void sonaEkle(int data)
        {
            Node eleman = new Node(data);

            if (head == null)
            {
                head = tail = eleman;
                tail.next = head;
                Console.WriteLine("liste oluşturuldu, ilk eleman eklendi");

            }
            else
            {
                tail.next = eleman;
                tail = eleman;

                tail.next = head;
                Console.WriteLine("sona eleman eklendi");
            }

        }

        public void arayaEkle(int indis, int data)
        {
            Node eleman = new Node(data);

            if (head == null && indis == 0)
            {
                head = tail = eleman;
                tail.next = head;
                Console.WriteLine("liste oluşturuldu, ilk eleman eklendi");

            }
            else if (head != null && indis == 0)
            {
                basaEkle(data);
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                int i = 0;

                while (temp != tail)
                {
                    if (i == indis)
                    {
                        temp2.next = eleman;
                        eleman.next = temp;
                        Console.WriteLine("araya eklendi");
                        i++;
                        break;
                    }

                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                if (i == indis)
                {
                    temp2.next = eleman;
                    eleman.next = temp;
                    Console.WriteLine("araya eklendi");

                }
            }

        }

        public void yazdir()
        {


            if (head == null)
            {
                Console.WriteLine("liste boş");

            }
            else
            {
                Node temp = head;
                Console.Write("baş -> ");
                while (temp != tail)
                {
                    Console.Write(temp.data + " -> ");
                    temp = temp.next;
                }
                Console.Write(temp.data + " son ");
            }

        }


        public void bastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("liste boş");
            }
            else if (head.next == head)
            {
                head = tail = null;
                Console.WriteLine("liste boşaldı");
            }
            else
            {
                head = head.next;
                tail.next = head;
                Console.WriteLine("baştan eleman silindi ");
            }
        }

        public void sondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("liste boş");
            }
            else if (head.next == head)
            {
                head = tail = null;
                Console.WriteLine("liste boşaldı");
            }
            else
            {
                Node temp = head;
                while (temp.next != tail)
                {
                    temp = temp.next;
                }
                temp.next = null;
                tail = temp;
                temp.next = head;
                Console.WriteLine("sondan eleman silindi ");
            }
        }

        public void aradanSil(int indis)
        {
            if (head == null)
            {
                Console.WriteLine("liste boş");
            }
            else if (head.next == head && indis == 0)
            {
                head = tail = null;
                Console.WriteLine("liste boşaldı");
            }
            else if (head.next != head && indis == 0)
            {
                bastanSil();
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                int i = 0;

                while (temp != tail)
                {
                    if (i == indis)
                    {
                        temp2.next = temp.next;
                        Console.WriteLine("aradan eleman silindi");
                        i++;
                        break;

                    }

                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                if (i == indis)
                {
                    sondanSil();
                }



            }
        }
    }
}
