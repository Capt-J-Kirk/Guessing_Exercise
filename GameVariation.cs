using System;
using System.Collections.Generic;
using System.Text;

namespace String_Guessing_Exercise
{
    class GameVariation {
        public string description;
        public List<string> solutions;

        public GameVariation() { 
        }

        public GameVariation(string description, List<string> solutions) {
            this.description = description;
            this.solutions = solutions;
        }


    }
}
