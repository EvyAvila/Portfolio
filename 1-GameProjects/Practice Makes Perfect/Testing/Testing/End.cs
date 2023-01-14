using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;


using Pastel;
using Color = System.Drawing.Color;

namespace FinalGame
{
    class End
    {
        public string EndingGood { get; private set; }
        public string EndingBad { get; private set; }
        public string EndingSick { get; private set; }

        public void GoodEnding()
        {
            WriteLine("You got to the competition and played amazing..");
            WriteLine("One of the best performances you've ever played..");
            WriteLine("At the end of the day, the results showed...");
            EndingGood = ReadLine();
            WriteLine("\nYou won the competition!!!");
            WriteLine("Congradulations! You won the award and invested your award money into your music career. A dream come true!".Pastel("#ffdc42"));
            ReadKey();
        }

        public void Sick()
        {
            WriteLine("You got to the competiton and played");
            WriteLine("You aren't feeling so well.");
            WriteLine("It wasn't your best performance, but you still gave it your all.");
            WriteLine("At the end of the day, the results showed...");
            EndingSick = ReadLine();
            WriteLine("Someone else won the competition and the award.");
            WriteLine("You are upset, but know you gave it your best shot.");
            WriteLine("The award money could have helped you start your music career.");
            WriteLine("Game Over...".Pastel("#7a4500"));
            ReadKey();
        }

        public void Entry()
        {
            WriteLine("You made it to the competition and are about to enter.");
            WriteLine("However, you brought the wrong item with you and aren't allowed into the building.");
            WriteLine("Since you don't have it, you can't perform and lose the opportunity to win the award.");
            WriteLine("Game Over...".Pastel("#7a0c00"));
            ReadKey();
        }

        public void BadEnding()
        {
            WriteLine("It was clear that you prioritized one thing over the other, instead of keeping balance in your life");
            WriteLine("You tried playing your best, but it was clear to the judges what they thought of you..");
            WriteLine("At the end of the day, the results showed...");
            EndingBad = ReadLine();
            WriteLine("You didn't win the competition nor were you a runner-up.");
            WriteLine("You felt very disappointed and decided to stop playing your instrument forever..");
            WriteLine("Game Over...".Pastel("#662eff"));
            ReadKey();
        }
    }
}

