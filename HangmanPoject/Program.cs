using System;


namespace HangmanProject;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Welcome to Hangman game!");
        Console.WriteLine("I hope you will enjoy this game");

        // List of words-car names
        List<string> cars = new List<string> { "Audi", "Benz", "Ford", "Honda", "Hyundai", "Tesla", };
        // Way to choose a random word from the list
        Random random = new Random();
        string selectedWord = cars[random.Next(cars.Count)];
        string lowerCaseSelectedWord = selectedWord.ToLower();
        //check the lenghth of the selected word
        int wordLength = selectedWord.Length;
        string replacer = "";

        replacer = new String('_', wordLength);
        Console.WriteLine($"The secret word is within: {replacer}");

        //Initializing variables
        const int LIMIT = 10;
        const int START = 0;
        int position = 0;
        char userInputletter;
        char guessedLetter;
        int check = 0;

        for (int i = START; i < LIMIT; i++)
        {
            bool presentLetter = false;
            Console.WriteLine("Hey enter your guess letter");
            userInputletter = Console.ReadLine()[0];
            guessedLetter = char.ToLower(userInputletter);
            Console.WriteLine($"You guessed {guessedLetter}");

            for (check = 0; check < wordLength; check++)
            {
                if (lowerCaseSelectedWord[check] == guessedLetter)
                {
                    position = check;
                    presentLetter = true;
                }
            }
            if (i < LIMIT && presentLetter != true)
            {
                Console.WriteLine($"The letter {guessedLetter} is not in the secret word");
            }
            if (i < LIMIT && presentLetter == true)
            {
                Console.WriteLine($"The letter {guessedLetter} is in the secret word");
                Console.WriteLine($"The letter {guessedLetter} is found at position {position}");
                char[] currentCharacters = replacer.ToCharArray();
                currentCharacters[position] = guessedLetter;
                replacer = string.Concat(currentCharacters);
                Console.WriteLine($"The progress is  {replacer}");
            }

            if (replacer == lowerCaseSelectedWord)
            {
                Console.WriteLine($"You guessed  {selectedWord} and it is the correct word, Conglatulation");
                return;
            }

            if (i < LIMIT)
            {
                Console.WriteLine("Try again");
            }

            if (i == LIMIT)
            {
                Console.WriteLine($"This is your last guess You guess");
            }
        }

        Console.WriteLine($"The word is {selectedWord}.");
        return;
    }
}