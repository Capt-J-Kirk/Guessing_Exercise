using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace String_Guessing_Exercise
{
    class Input {
        public string inputConditions;
        public string inputString;
        public string regExString;

        public Input() {
        }

        public Input(string inputConditions) {
            this.inputConditions = inputConditions;
        }

        public Input(string inputString, string regExString) {
            this.inputString = inputString;
            this.regExString = regExString;
        }

        public Input(string inputConditions, string inputString, string regExString) {
            this.inputConditions = inputConditions;
            this.inputString = inputString;
            this.regExString = regExString;
        }

        public void DisplayInputConditions() {
            Console.WriteLine(inputConditions + "\n");
        }

        public bool TestInputSyntax() {
            bool inputValidity = false;
            Match m = Regex.Match(inputString, regExString);

            if (!m.Success) {
                Console.Clear();
                Console.WriteLine("Your input didnt follow the correct format, please try again.");
                if (inputConditions != null) Console.WriteLine(inputConditions + "\n");
                else Console.WriteLine("\n");
            }
            else inputValidity = true;
            return inputValidity;
        }

        public bool TestAnswer() {
            bool answerFound;
            Match m = Regex.Match(inputString, regExString);

            if (m.Success) answerFound = true;
            else answerFound = false;
            
            return answerFound;
        }




    }

}
