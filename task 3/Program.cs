namespace task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[0];
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("P - Print numbers");
                Console.WriteLine("A - Add a number");
                Console.WriteLine("M - Display mean of the numbers");
                Console.WriteLine("S - Display the smallest number");
                Console.WriteLine("L - Display the largest number");
                Console.WriteLine("C - Clear the list");
                Console.WriteLine("Q - Quit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "P":
                        PrintNumbers(numbers);
                        break;

                    case "A":
                        numbers = AddNumber(numbers);
                        break;

                    case "M":
                        DisplayMean(numbers);
                        break;

                    case "S":
                        DisplaySmallest(numbers);
                        break;

                    case "L":
                        DisplayLargest(numbers);
                        break;

                    case "C":
                        numbers = ClearArray();
                        break;

                    case "Q":
                        Console.WriteLine("Goodbye!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Unknown selection, please try again.");
                        break;
                }
            }
        }

        static void PrintNumbers(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                Console.WriteLine("[] - the list is empty.");
            }
            else
            {
                Console.Write("[");
                int i = 0;
                while (i < numbers.Length)
                {
                    Console.Write(numbers[i]);
                    if (i < numbers.Length - 1)
                    {
                        Console.Write(" ");
                    }
                    i++;
                }
                Console.WriteLine("]");
            }
        }

        static int[] AddNumber(int[] numbers)
        {
            int num;
            bool validInput = false;

            do
            {
                Console.Write("Enter a number to add: ");
                string input = Console.ReadLine();
                if (IsValidInteger(input, out num))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            } while (!validInput);

            int[] newNumbers = new int[numbers.Length + 1];
            int i = 0;
            while (i < numbers.Length)
            {
                newNumbers[i] = numbers[i];
                i++;
            }
            newNumbers[numbers.Length] = num;

            Console.WriteLine($"{num} added.");
            return newNumbers;
        }

        static void DisplayMean(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                Console.WriteLine("Can't calculate the mean - no data.");
            }
            else
            {
                int total = 0;
                int i = 0;

                while (i < numbers.Length)
                {
                    total += numbers[i];
                    i++;
                }

                double mean = (double)total / numbers.Length;
                Console.WriteLine($"The mean is {mean:F2}.");
            }
        }

        static void DisplaySmallest(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                Console.WriteLine(" Don't find the smallest number  - list is empty.");
            }
            else
            {
                int smallest = numbers[0];
                int i = 1;

                while (i < numbers.Length)
                {
                    if (numbers[i] < smallest)
                    {
                        smallest = numbers[i];
                    }
                    i++;
                }

                Console.WriteLine($"The smallest number is {smallest}.");
            }
        }

        static void DisplayLargest(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                Console.WriteLine(" Don't find the largest number - list is empty.");
            }
            else
            {
                int largest = numbers[0];
                int i = 1;

                while (i < numbers.Length)
                {
                    if (numbers[i] > largest)
                    {
                        largest = numbers[i];
                    }
                    i++;
                }

                Console.WriteLine($"The largest number is {largest}.");
            }
        }

        static int[] ClearArray()
        {
            Console.WriteLine("The list has been cleared.");
            return [];
        }

        
        static bool IsValidInteger(string input, out int result)
        {
            result = 0;
            foreach (char c in input)
            {
                if (!char.IsDigit(c) && c != '-' && c != '+')
                    return false;
            }

            try
            {
                result = int.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
