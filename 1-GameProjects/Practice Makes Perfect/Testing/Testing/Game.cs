using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;


using Pastel;
using Color = System.Drawing.Color;

namespace FinalGame
{
    class Game
    {        
        int Practice;
        public int Health { get; private set; }

        bool HasIdentification = false;

        private Random RandGenerator = new Random();

        string PlayerInstrument;
        public Game (string playerInstrument)
        {
            PlayerInstrument = playerInstrument;
        }

        public void ChoiceOutcome()
        {
            Practice = 0;
            Health = 4;

            // Art by Veronica Karlsson

            // Help from Mike Hadley on seperating prompt for color
            string prompt = @"
  _____                 ____               
 |  __ \               / __ \            _ 
 | |  | | __ _ _   _  | |  | |_ __   ___(_)
 | |  | |/ _` | | | | | |  | | '_ \ / _ \  
 | |__| | (_| | |_| | | |__| | | | |  __/_ 
 |_____/ \__,_|\__, |  \____/|_| |_|\___(_)
                __/ |                      
               |___/                       
".Pastel("#0071bd");

            prompt += @"
    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)".Pastel("#ffa3fc");

            
            prompt += @$"

You want to practice as much as you can, but you are faced with an issue..
You accidentally slipped on the floor and landed on your wrist.
You have a slight pain and don't know if you should get it checked out or let it be.
Will you:
".Pastel("#ffcb8f");

            string[] options = { "Get it checked out", "Let it be and practice" };
            MenuOptions mainMenu = new MenuOptions(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    int chanceHeal = RandGenerator.Next(0, 2);
                    if (chanceHeal == 0)
                    {
                        WriteLine("You saw the doctor, no sprains or fractures. You are able to practice!");
                        Practice += 2;
                        Health++;
                    }
                    else
                    {
                        WriteLine("You got it checked, but you have to rest for the day. Thus missing a day of practicing.");
                        Health++;
                    }
                    break;
                case 1:
                    WriteLine("You just stretched your wrist and the pain went away a little. You seemed fine and went to practice.");
                    Practice++;
                    Health--;
                    break;
            }

            WriteLine($"\nPratice time total: {Practice} hours");
            WriteLine($"Health statues: {Health}");
            WaitForKey();

            // Art by Normand Veilleux
            string dayTwo = @"
  _____                _______             
 |  __ \              |__   __|          _ 
 | |  | | __ _ _   _     | |_      _____(_)
 | |  | |/ _` | | | |    | \ \ /\ / / _ \  
 | |__| | (_| | |_| |    | |\ V  V / (_) | 
 |_____/ \__,_|\__, |    |_| \_/\_/ \___(_)
                __/ |                      
               |___/                       
".Pastel("##00a4bd");

            dayTwo += @"

                .aadddbbbbaa,       ,adddbbbbaaa.
             .ad""          ""\bbmdd/""           ""ba.
          ., d""                 `""'                 ""b,.
       ., ad""                                         ""ba,.
    ., amd""  __..,,,aaaaaadddddddMbbbbbbbaaaaaaa,,,..__  ""bma,.
, am8888ca8""""""''                                ``""""8ac88888ma,
""""""]8a.                                               .a8[""""""
      ""8ba.                                           .ad8""'
        `""8bma,.                                .,amd88""'
            `""""88bmm======================mmd88""""'
                        `""""""""""""""""""""""'
".Pastel("#ffa3fc");

            dayTwo += @"
A new day, and you are determined to practice today.
However, you have a pain in your mouth and don't know what is causing it.
It hurts when you open your mouth or chew anything.
You consider going to the dentist, but don't know if you should just take over the counter medication.
Will you: 
".Pastel("#ffcb8f");
            string[] optionTwo = { "Go to the dentist", "Take over the counter pain medication and practice" };
            MenuOptions Two = new MenuOptions(dayTwo, optionTwo);
            int selectedIndexTwo = Two.Run();

            switch (selectedIndexTwo)
            {
                case 0:
                    int chanceHeal = RandGenerator.Next(0, 2);
                    if (chanceHeal == 0)
                    {
                        WriteLine("It turns out it's a wisdom tooth infection! Luckily, the dentist prescribed antibiotics and pain medications that will ease the pain quickly. \nThe pain went away and you had enough time to practice!");
                        Practice += 2;
                        Health++;
                    }
                    else
                    {
                        WriteLine("You got it checked, and turns out it's a wisdom tooth infection. However, the dentist tells you not to play your instrument. \nThey suggest you put either a heating or cooling pack on your face besides taking the medication prescribed. Thus missing a day of practicing.");
                        Health++;
                    }
                    break;
                case 1:
                    WriteLine("You took some over the counter pain medication you found in your house. The pain is still there but is tolerable and allows you to practice.");
                    Practice++;
                    Health--;
                    break;
            }

            WriteLine($"\nPratice time total: {Practice} hours");
            WriteLine($"Health statues: {Health}");
            WaitForKey();


            //Art created with http://asciiflow.com/
            string dayThree = @"
  _____                _______ _                     
 |  __ \              |__   __| |                  _ 
 | |  | | __ _ _   _     | |  | |__  _ __ ___  ___(_)
 | |  | |/ _` | | | |    | |  | '_ \| '__/ _ \/ _ \  
 | |__| | (_| | |_| |    | |  | | | | | |  __/  __/_ 
 |_____/ \__,_|\__, |    |_|  |_| |_|_|  \___|\___(_)
                __/ |                                
               |___/                                 
".Pastel("#00bd8a");

            dayThree += @"

+ -----+          +-----+
 |     |          |     |
 +--------+    +--------+
       |  |    |  |
       +--+    +--+
+-------------------------+
|         |    |          |
|         |    |          |
|         |    |          |
+---------+    +----------+
+---------+    +----------+
|         |    |          |
|         |    |          |
|         |    |          |
+---------+----+----------+

".Pastel("#ffa3fc");

            dayThree += @"
The competition is getting closer, which means less time before the big day.
You get a call to meet with a friend who is celebrating their birthday.
However, they live very far and traffic can be a nightmare.
You want to attend but don't know if you'll make it back early enough to practice.
Will you: 
".Pastel("#ffcb8f");
            string[] optionThree = { "Go to the party", "Decline the invitation and practice" };
            MenuOptions Three = new MenuOptions(dayThree, optionThree);
            int selectedIndexThree = Three.Run();

            switch (selectedIndexThree)
            {
                case 0:
                    int chanceHeal = RandGenerator.Next(0, 2);
                    if (chanceHeal == 0)
                    {
                        WriteLine("You went to the party and had a great time! You left the party early enough to beat traffic and made it home to practice!");
                        Practice += 2;
                        Health++;
                    }
                    else
                    {
                        WriteLine("You partied all night with your friend. You had a great time but didn't get to practice.");
                        Health++;
                    }
                    break;
                case 1:
                    WriteLine("You declined the invitation and feel bad for missing, but practice anyway. Your friend felt sad that you didn't go.");
                    Practice++;
                    Health--;
                    break;
            }

            WriteLine($"\nPratice time total: {Practice} hours");
            WriteLine($"Health statues: {Health}");
            WaitForKey();



            //Art created with http://asciiflow.com/
            string dayFour = @"
  _____                ______                 
 |  __ \              |  ____|              _ 
 | |  | | __ _ _   _  | |__ ___  _   _ _ __(_)
 | |  | |/ _` | | | | |  __/ _ \| | | | '__|  
 | |__| | (_| | |_| | | | | (_) | |_| | |   _ 
 |_____/ \__,_|\__, | |_|  \___/ \__,_|_|  (_)
                __/ |                         
               |___/                          
".Pastel("#00bd00");

            dayFour += @"
+----------------------------------+
|                                  |
|                                  |
|                                  |
|      +----+        +-----+       |
|                                  |
|                                  |
|                                  |
|                                  |
|                                  |
|     +--------------------+       |
|     |                    |       |
|     |                    |       |
|     |                    +-------+
+-----+                    |       |
|     |                    |       |
|     |                    |       |
|     +--------------------+       |
+----------------------------------+

".Pastel("#ffa3fc");

            dayFour += @"
You wake up in the morning not feeling that great.
You have a runny nose and a slight fever, resulting in a cold.
It's best to rest for the day, but with the competition you don't know if you should just take medicine.
Will you: 
".Pastel("#ffcb8f");
            string[] optionFour = { "Rest in bed for the day", "Find some medicine and practice" };
            MenuOptions Four = new MenuOptions(dayFour, optionFour);
            int selectedIndexFour = Four.Run();

            switch (selectedIndexFour)
            {
                case 0:
                    int chanceHeal = RandGenerator.Next(0, 2);
                    if (chanceHeal == 0)
                    {
                        WriteLine("You rested for the day and were able to recover sooner! Feeling better, you decided to practice");
                        Practice += 2;
                        Health++;
                    }
                    else
                    {
                        WriteLine("You rested for the day, but didn't get better until late at night. It was too late to practice, so you just went to sleep for the night");
                        Health++;
                    }
                    break;
                case 1:
                    WriteLine("You found some medicine and took it. Your were feeling a bit better and decided to practice.");
                    Practice++;
                    Health--;
                    break;
            }

            WriteLine($"\nPratice time total: {Practice} hours");
            WriteLine($"Health statues: {Health}");
            WaitForKey();

            string dayFive = @"
 _____                ______ _             
 |  __ \              |  ____(_)          _ 
 | |  | | __ _ _   _  | |__   ___   _____(_)
 | |  | |/ _` | | | | |  __| | \ \ / / _ \  
 | |__| | (_| | |_| | | |    | |\ V /  __/_ 
 |_____/ \__,_|\__, | |_|    |_| \_/ \___(_)
                __/ |                       
               |___/                           
".Pastel("#6ebd00");

            dayFive += @"
        __________
       1          1
       1          1
       1          1
  ____ 1     ____ 1
 /    \1    /    \1
1      1   1      1
 \____/     \____/

".Pastel("#ffa3fc");

            dayFive += @$"
Your {PlayerInstrument} has a leak, meaning you can't play that well. You need to get it checked out.
You know two places you can take it to in order to get it fixed.
At the music shop, you may need to leave your instrument for several hours.
You also know a specialist who might have time to get your instrument fixed.
Will you: 
".Pastel("#ff5100");
            string[] optionFive = { "Go to the specialist", "Go to the shop" };
            MenuOptions Five = new MenuOptions(dayFive, optionFive);
            int selectedIndexFive = Five.Run();

            switch (selectedIndexFive)
            {
                case 0:
                    int chancePractice = RandGenerator.Next(0, 2);
                    if (chancePractice == 0)
                    {
                        WriteLine($"You went to the specialist and luckily was free to get your {PlayerInstrument} fixed within a few hours!");
                        Practice += 2;
                    }
                    else
                    {
                        WriteLine($"You went to the specialist, but have to leave your {PlayerInstrument} overnight since they were busy with other instruments.");
                    }
                    break;
                case 1:
                    WriteLine($"Since the shop receives many instruments per day, you had to wait severl hours for your {PlayerInstrument}. You only practice for a short amount of time.");
                    Practice++;
                    break;
            }

            WriteLine($"\nPratice time total: {Practice} hours");
            WriteLine($"Health statues: {Health}");
            WaitForKey();

            string daySix = @$"
  _____                 _____ _         
 |  __ \               / ____(_)     _  
 | |  | | __ _ _   _  | (___  ___  _(_) 
 | |  | |/ _` | | | |  \___ \| \ \/ /   
 | |__| | (_| | |_| |  ____) | |>  < _  
 |_____/ \__,_|\__, | |_____/|_/_/\_(_) 
                __/ |                   
               |___/                    

+-----------------------------------+
|                                   |
|                                   |
|   X   X                           |
     X X         {PlayerInstrument} 
|     X    +-----------------+      |
|    X X                            |
|   X   X                           |
|                                   |
|                                   |
|   X   X                           |
|    X X       Music Sheet          |
|     X    +-----------------+      |
|    X X                            |
|   X   X                           |
|                                   |
|                                   |
|   X   X                           |
|    X X             ?              |
|     X    +------------------+     |
|    X X                            |
|   X   X                           |
|                                   |
+-----------------------------------+


The day of the competition has arrived.
You get ready and have to make sure you have everything you need.
Otherwise, you won't be able to participate in the competition.

Which item will you take to the competition? 
".Pastel("#adbd00");

            WriteLine("");

            string[] optionSix = { "Metronome", "ID Card", "Water Bottle" };
            MenuOptions Six = new MenuOptions(daySix, optionSix);
            int selectedIndexSix = Six.Run();

            switch (selectedIndexSix)
            {
                case 0:
                    WriteLine($"You grabbed the {optionSix[0]} and head out to the competition.");
                    break;
                case 1:
                    WriteLine($"You grabbed the {optionSix[1]} and head out to the competition.");
                    HasIdentification = true;
                    break;
                case 2:
                    WriteLine($"You grabbed the {optionSix[2]} and head out to the competition.");
                    break;
            }
            WaitForKey();

            if (Practice >= 5 && Health >= 5 && HasIdentification)
            {
                End goodEnding = new End();
                goodEnding.GoodEnding();
            }
            else if (Practice >= 4 && Health <= 4 && HasIdentification)
            {
                End sickEnding = new End();
                sickEnding.Sick();
            }
            else if(!HasIdentification)
            {
                End noEntry = new End();
                noEntry.Entry();
            }
            else
            {
                End badEnding = new End();
                badEnding.BadEnding();
            }


        }

        private void WaitForKey()
        {
            ReadKey();
            Clear();
        }
    }
}

