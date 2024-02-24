using System;


namespace Codecool.EinsenhowerMatrix
{
    
    public class EisenhowerMain
    {
       
        public void Run()
        {
            bool run = true;
            TodoMatrix matrix = new TodoMatrix();
            while (run)
            {
                Console.WriteLine(matrix.ToString());
                Console.WriteLine("Eisenhower Matrix");
                Console.WriteLine("1. Dodaj zadanie");
                Console.WriteLine("2. Oznacz zadanie jako zrobione");
                Console.WriteLine("3. Wyświetl macierz");
                Console.WriteLine("0. Zakończ");

                Console.Write("Wybierz opcję: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddItem(matrix);
                        break;

                    case "2":
                        // Oznacz zadanie jako zrobione
                        
                        break;

                    case "3":
                       
                        Console.WriteLine(matrix.ToString());
                        break;

                    case "0":
                        
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                        break;
                }

                Console.WriteLine();
            }
        }
        private void AddItem(TodoMatrix matrix)
        {
            Console.Write("Podaj tytuł zadania: ");
            string title = Console.ReadLine();
            bool validDate = false;
            while (!validDate)
            {
                Console.Write("Podaj deadline zadania (YYYY-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime deadline))
                {
                    validDate = true;
                }
                else
                {
                    Console.WriteLine("Błędny format daty.");
                }
                bool validAnswer = false;

                while (!validAnswer)
                {
                    Console.WriteLine("Czy zadanie jest ważne (T/N): ");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "t" || answer.ToLower() == "n")
                    {
                        matrix.AddItem(title, deadline, answer.ToLower() == "t");
                        Console.WriteLine("Zadanie dodane.");
                        validAnswer = true;
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa odpowiedź. Wprowadź 'T' lub 'N'.");
                    }
                }
            }
        }
    }
}