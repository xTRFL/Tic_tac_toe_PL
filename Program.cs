using System;

namespace Projekt
{
    class Plansza
    {
        private char[] plansza = new char[9];
        public char wygrany;
        public Plansza()
        {
            char pom = '1';
            for (int i = 0; i < 9; i++)
            {
                plansza[i] = pom;
                pom++;
            }
        }
        public void czysc()
        {
            char pom = '1';
            for (int i = 0; i < 9; i++)
            {
                plansza[i] = pom;
                pom++;
            }
        }
        public void wypisz()
        {
            int pom = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {plansza[pom]} ");
                    if (j != 2)
                        Console.Write('|');
                    else
                        Console.Write('\n');
                    pom++;
                }
                if (i != 2)
                    Console.WriteLine("---+---+---");
            }
        }
        public bool wygrana(out char wygrany_symbol)
        {
            wygrany_symbol = ' ';
            //Poziomo
            if (plansza[0] == plansza[1] && plansza[0] == plansza[2])
            {
                wygrany_symbol = plansza[0];
                return true;
            }
            if (plansza[3] == plansza[4] && plansza[3] == plansza[5])
            {
                wygrany_symbol = plansza[3];
                return true;
            }
            if (plansza[6] == plansza[7] && plansza[6] == plansza[8])
            {
                wygrany_symbol = plansza[6];
                return true;
            }
            //Pionowo
            if (plansza[0] == plansza[3] && plansza[0] == plansza[6])
            {
                wygrany_symbol = plansza[0];
                return true;
            }
            if (plansza[1] == plansza[4] && plansza[1] == plansza[7])
            {
                wygrany_symbol = plansza[1];
                return true;
            }
            if (plansza[2] == plansza[5] && plansza[2] == plansza[8])
            {
                wygrany_symbol = plansza[2];
                return true;
            }
            //Na ukos
            if (plansza[0] == plansza[4] && plansza[0] == plansza[8])
            {
                wygrany_symbol = plansza[0];
                return true;
            }
            if (plansza[2] == plansza[4] && plansza[2] == plansza[6])
            {
                wygrany_symbol = plansza[2];
                return true;
            }
            for(int i = 0; i < 9; i++)
            {
                if (plansza[i] != 'X' || plansza[i] != 'O')
                    return false;
            }
            return true;
        }
        public void rozgrywka()
        {
            int pom;
            Console.WriteLine("Gra rozpoczeta.");
            while(!wygrana(out wygrany))
            {
                Console.WriteLine("Ruch Krzyzyka:");
                Console.WriteLine("Wybierz pole:");
                wypisz();
                pom = Convert.ToInt32(Console.ReadLine()) - 1;
                if (plansza[pom] != 'X' && plansza[pom] != 'O')
                    plansza[pom] = 'X';
                if (wygrana(out wygrany))
                    break;
                Console.WriteLine("Ruch Kolka:");
                Console.WriteLine("Wybierz pole:");
                wypisz();
                pom = Convert.ToInt32(Console.ReadLine());
                if (plansza[pom-1] != 'X' && plansza[pom-1] != 'O')
                    plansza[pom-1] = 'O';
            }
            if (wygrany == 'X')
                Console.WriteLine("Wygral Krzyzyk. Gratulacje!");
            else if (wygrany == 'O')
                Console.WriteLine("Wygralo Kolko. Gratulacje!");
            else
                Console.WriteLine("Remis.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Plansza Plan = new Plansza();
            bool czy_gramy = true;
            string odpowiedz;
            while(czy_gramy)
            {
                Console.WriteLine("Witam w grze w Kolko i Krzyzyk.");
                Plan.rozgrywka();
                Plan.czysc();
                Console.WriteLine("Czy chcesz grac dalej? (Tak/Nie)");
                odpowiedz = Console.ReadLine();
                while (odpowiedz != "Tak" && odpowiedz != "Nie")
                {
                    Console.WriteLine("Nie rozpoznaje odpowiedzi. Podaj ponownie: ");
                    odpowiedz = Console.ReadLine();
                }
                if (odpowiedz == "Nie")
                    czy_gramy = false;
            }
            Console.WriteLine("Dziekuje za gre.");
        }
    }
}