using System;
using System.Collections.Generic;
using System.Text;

namespace String_Guessing_Exercise
{
    class GuessingGame {

        public void StartGame() {
            Console.Clear();
            Intro();
        }

        public void Intro() {
            string inputString;
            Input inputCondition1 = new Input("1 for Easy (11 attempts),\n2 for Medium (7 attempts),\n3 for Hard (3 attempts)");
            Input testDifficulty;
            int difficulty;

            Console.Clear();
            Console.Write("This is a guessing game. ");
            Console.WriteLine("You have to guess a name.\n");
            Console.WriteLine("It doesn't matter if you use lower case or CAPITALS\n");
            Console.WriteLine("To begin you have to input the difficulty level:");
            inputCondition1.DisplayInputConditions();
            do {
                inputString = Console.ReadLine();
                testDifficulty = new Input(inputCondition1.inputConditions, inputString, @"^[1|2|3]{1}$" );
            }
            while (testDifficulty.TestInputSyntax() == false);
            difficulty = short.Parse(testDifficulty.inputString);
            GameMainLoop(difficulty);
        }


        void GameMainLoop(int difficulty) {
            int[] maxAttempts = new int[4] {0, 11, 7, 3 };
            int attempts = 0;
            bool solutionNotFound = true;
            Input answer = new Input();

            List<GameVariation> variations = new List<GameVariation>();
            variations.Add(new GameVariation("You must guess the name of a Nordic God or Goddess", new List<string>() { "Thor", "Heimdal", "Baldur", "Hel", "Yggdrasil", "Sif", "Freja" } ));
            variations.Add(new GameVariation("You must guess the name of a Greek God or Goddess", new List<string>() { "Heracles", "Zeus", "Morpheus", "Hermes", "Aether", "Ares", "Atlas", "Poseidon" }));
            variations.Add(new GameVariation("You must guess the surname of a famous Hollywood Actress", new List<string>() { "Monroe", "Loren", "Taylor", "Berry", "Roberts", "Jolie", "Kidman" }));
            variations.Add(new GameVariation("You must guess the surname of a present Danish Minister", new List<string>() { "Frederiksen", "Wammen", "Kofod", "Hækkerup", "Bødskov", "Heunicke", "Bramsen" }));
            variations.Add(new GameVariation("You must guess the surname of a famous Tennisplayer", new List<string>() { "Nadal", "Federer", "Mcenroe", "Williams", "Sharapova", "Navratilova", "Hingis" }));

            int randomVariation = RandomInt(0, variations.Count);
            int solutionCount = variations[randomVariation].solutions.Count;
            string randomSolution = variations[randomVariation].solutions[RandomInt(0, solutionCount)];
            do {
                Console.Clear();
                if (attempts > 0) Console.WriteLine("Sorry your answer was not the correct one.\n");
                Console.WriteLine(variations[randomVariation].description + "\n");
                Console.WriteLine("You have " + (maxAttempts[difficulty]-attempts) + " attempts out of " + maxAttempts[difficulty] + " left.\n");
                answer.inputString = Console.ReadLine();
                answer.regExString = string.Format(@"(?i)\b{0}\b", randomSolution);
                Console.WriteLine(answer.regExString);
                if (answer.TestAnswer()) solutionNotFound = false;
                attempts++;
            }
            while (attempts < maxAttempts[difficulty] && solutionNotFound);

            Input playAgain = new Input();
            Console.Clear();
            if (solutionNotFound == false) Console.WriteLine("Congratulations you found the correct name !\n");
            else Console.WriteLine("You didn't find the correct answer.\n");
            Console.WriteLine("Do you want to play again? (y/n)\n");
            playAgain.inputString = Console.ReadLine();
            playAgain.regExString = @"(?i)[y]";
            if (playAgain.TestAnswer()) Intro();
            else Environment.Exit(0);
        }

        public int RandomInt(int min, int max) {
            Random _random = new Random();
            int myInt = _random.Next(min, max);
            return myInt;
        }




    }
}
