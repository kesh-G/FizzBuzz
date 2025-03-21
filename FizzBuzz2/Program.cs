// FIZZ BUZZ

/* PSEUDOKOD
 * 
 * Skriv ut information om hur spelet fungerar.
 * Be användaren skriva in en startsiffra mellan 1 och 20.
 * Skriv ut ett felmeddelande om användaren skriver in en ogiltig siffra.
 * Spara siffran i en variabel.
 * 
 * Skapa en tom sträng.
 * I en for-loop: skapa en ny sträng med 10 siffror i stigande ordning
 * från inputsiffran.
 * 
 * Om siffran som skapas är delbar med 3 och 5:
 *  Ersätt siffran med "fizz buzz"
 * Om siffran är delbar med 3:
 *  Ersätt siffran med "fizz".
 * Om siffran är delbar med 5:
 *  Ersätt siffran med "buzz".
 * Annars:
 *  Skriv ut siffran.
 * 
 * Splitta strängen till en array.
 * Hämta en random siffra mellan 1 och 10.
 * Skriv ut varje siffra/ord men ersätt siffran/ordet med index av den
 * random siffran med ett frågetecken.
 * 
 * Be användaren skriva ut vad innehållet i frågetecknet ska vara.
 * Konvertera input till lowecase och jämför med det rätta svaret.
 * Skriv ut "Rätt" eller "Fel" samt vad rätt svar var.
 * 
 */


using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FizzBuzz2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call method that writes instructions to the console
            DisplayInstrucitons();

            // Set min and max numbers in sequence by difficulty
            (int minNumber, int maxNumber) = SetDifficulty();

            // Call method that handles the start number
            int startNumber = GetStartNumber(minNumber, maxNumber);

            // If the user has entered a correct number
            if (startNumber >= minNumber && startNumber <= maxNumber)
            {
                // Create fizz buzz list
                List<string> fizzBuzzList = CreateFizzBuzzList(startNumber);

                // Call the method that creates a random number
                int randomNumber = CreateRandomNumber();

                // Write fizz buzz list with random question mark replacement
                DisplayFizzBuzz(startNumber, fizzBuzzList, randomNumber);

                // Handle user guess
                HandleGuess(fizzBuzzList, randomNumber);
            }
            // Print an error message if the user inputs an invalid number
            else
                Console.WriteLine($"You have entered an incorrect number. " +
                    $"Enter a number between {minNumber} and {maxNumber}.");
        }

        
        // DISPLAY INSTRUCTIONS
        private static void DisplayInstrucitons()
        {
            Console.WriteLine("Let's Play FIZZ BUZZ!\n");
            Console.WriteLine("Here are the rules:");
            Console.WriteLine("1. You will be shown a sequence of 10 numbers.");
            Console.WriteLine("2. If a number is dividable by 3, " + 
                "it's replaced with 'fizz'.");
            Console.WriteLine("3. If a number is dividable by 5, " +
                "it's replaced with 'buzz'.");
            Console.WriteLine("4. If a number is dividable by both 3 and 5, " +
                "it's replaced with 'fizz buzz'.");
            Console.WriteLine("Your job is to replace the question mark with " +
                "the correct answer.\n");
        }


        // SET DIFFICULTY
        private static (int min, int max) SetDifficulty()
        {
            // Ask the user to select difficulty
            Console.WriteLine("Start with selecting a difficulty. " +
                "Enter 1 for Easy, 2 for Medium and 3 for Hard.");
            Console.Write("Enter number: ");
            string difficulty = Console.ReadLine() ?? "";

            // Create a switch expression that handles the difficulty range
            int minNumber = difficulty switch
            {
                "1" => 1,
                "2" => 20,
                "3" => 40,
                _ => 1
            };

            int maxNumber = minNumber + 20;

            // If an invalid number is entered, write an error message
            if (difficulty != "1" && difficulty != "2" && difficulty != "3")
                Console.WriteLine("Invalid choice, difficulty set to easy.");

            return (minNumber, maxNumber);
        }


        // GET START NUMBER
        private static int GetStartNumber(int minNumber, int maxNumber)
        {
            Console.Write($"Enter a start number between " +
                $"{minNumber} and {maxNumber}: ");

            // Save user input in a variable and create an int version
            int startNumber = int.Parse(Console.ReadLine() ?? "");

            return startNumber;
        }


        // CREATE FIZZ BUZZ LIST
        private static List<string> CreateFizzBuzzList(int number)
        {
            // Set start number
            int startNumber = number;

            // Create an empty list
            List<string> fizzBuzzList = new List<string>();

            // Add 10 items to the list
            for (int i = 0; i < 10; i++)
            {
                int newNumber = startNumber + i;

                if (newNumber % 3 == 0 && newNumber % 5 == 0)
                    fizzBuzzList.Add("fizz buzz");
                else if (newNumber % 3 == 0)
                    fizzBuzzList.Add("fizz");
                else if (newNumber % 5 == 0)
                    fizzBuzzList.Add("buzz");
                else
                    fizzBuzzList.Add(Convert.ToString(newNumber));
            }

            return fizzBuzzList;
        }


        // CREATE RANDOM NUMBER
        private static int CreateRandomNumber()
        {
            // Create a random number between 1 and 9
            Random random = new Random();
            int randomNumber = random.Next(1, 10);

            return randomNumber;
        }

        
        // DISPLAY FIZZ BUZZ
        private static void DisplayFizzBuzz(int startNumber,
            List<string> fizzBuzzList,
            int randomNumber)
        {
            // Print each number and replace random number with "?"
            Console.WriteLine("\nHere is your Fizz Buzz sequence:");
            for (int i = 0; i < fizzBuzzList.Count; i++)
            {
                if (i == randomNumber)
                    Console.WriteLine("?");
                else
                    Console.WriteLine(fizzBuzzList[i]);
            }
        }

        
        // HANDLE GUESS
        private static void HandleGuess(List<string> fizzBuzzList,
            int randomNumber)
        {
            // Handle user guess input
            Console.Write("\nEnter your guess: ");
            string userGuess = Console.ReadLine() ?? "";
            string correctAnswer = fizzBuzzList[randomNumber];

            // Convert guess to lowercase, compare with answer, & print result
            if (userGuess.ToLower() == correctAnswer)
                Console.WriteLine("CORRECT! You're a genius!");
            else
                Console.WriteLine($"Incorrect :( " +
                    $"The correct answer was: {correctAnswer}");
        }
    }
}