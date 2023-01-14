using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;


using Pastel;
using Color = System.Drawing.Color;

using System.Media;

namespace FinalGame
{
    class Player
    {
        string Name;
        public string Instrument { get; private set; }

        private string MusicListPath = "MusicList.txt";
        
        public void Start()
        {
            Title = "Practice Makes Perfect";

            WindowHeight = LargestWindowHeight;
            WindowWidth = LargestWindowWidth;

            SoundPlayer intro = new SoundPlayer("Argonne - Zachariah Hickman.wav");
            intro.Load();
            intro.PlayLooping();
            Introduction();
        }
        
        public void Introduction()
        {
          

            string prompt = @"
  _____                _   _            __  __       _               _____           __          _   
 |  __ \              | | (_)          |  \/  |     | |             |  __ \         / _|        | |   
 | |__) | __ __ _  ___| |_ _  ___ ___  | \  / | __ _| | _____  ___  | |__) |__ _ __| |_ ___  ___| |_ 
 |  ___/ '__/ _` |/ __| __| |/ __/ _ \ | |\/| |/ _` | |/ / _ \/ __| |  ___/ _ \ '__|  _/ _ \/ __| __|
 | |   | | | (_| | (__| |_| | (_|  __/ | |  | | (_| |   <  __/\__ \ | |  |  __/ |  | ||  __/ (__| |_ 
 |_|   |_|  \__,_|\___|\__|_|\___\___| |_|  |_|\__,_|_|\_\___||___/ |_|   \___|_|  |_| \___|\___|\__|
                                                                                                    
              .,,,.
           .;;;;;;;;;,
          ;;;'    `;;;,
         ;;;'      `;;;
         ;;;        ;;;
         ;;;.      ;;;'
         `;;;.    ;;;'
          `;;;.  ;;;'
           `;;',;;'
            ,;;;'
         ,;;;',;' ...,,,,...
      ,;;;'    ,;;;;;;;;;;;;;;,
   ,;;;'     ,;;;;;;;;;;;;;;;;;;,
  ;;;;'     ;;;',,,   `';;;;;;;;;;
 ;;;;,      ;;   ;;;     ';;;;;;;;;
;;;;;;       '    ;;;      ';;;;;;;
;;;;;;            .;;;      ;;;;;;;
;;;;;;,            ;;;;     ;;;;;;'
 ;;;;;;,            ;;;;   .;;;;;'
  `;;;;;;,           ;;;; ,;;;;;'
   `;;;;;;;,,,,,,,,,, ;;;; ;;;'
      `;;;;;;;;;;;;;;; ;;;; '
          ''''''''''''' ;;;.
               .;;;.    `;;;.
              ;;;; '     ;;;;
              ;;;;,,,..,;;;;;
              `;;;;;;;;;;;;;'
                `;;;;;;;;;'                                                                                                          

".Pastel("#7400e0");
            prompt += @"

Will you win this music competition or will you stop making music forever?
".Pastel("#1acdff");

            string[] options = { "Play", "About", "Credits", "Exit" };
            MenuOptions mainMenu = new MenuOptions(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    Story();
                    break;
                case 1:
                    Clear();
                    About();
                    break;
                case 2:
                    Clear();
                    Credits();
                    break;
                case 3:
                    Clear();
                    Exit();
                    break;
            }
        }

        private void Story()
        {
            WriteLine("Please enter your name...");
            Name = ReadLine().Trim();
            Clear();

            string[] instrumentchoice = { "Flute", "Oboe", "Clarinet", "Bassoon", "Saxophone", "Trumpet", "French Horn", "Trombone", "Tuba" };
            Random rnd = new Random();
            int rand = rnd.Next(instrumentchoice.Length);
            Instrument = instrumentchoice[rand];

            List<Player> music = new List<Player>();
            string[] lines = File.ReadAllLines(MusicListPath);
            for (int i = 0; i < lines.Length; i += 1)
            {
                string title = lines[i];
            }

            // Border from https://www.asciiart.eu/art-and-design/borders with slight alteration
            WriteLine($@"
   _.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._.-=-._
.-'---      - ---     --     ---   -----   - --       ----  ----   -     ---`-.
             You have been playing the {Instrument} for several years now.         
(                         A passion you greatly enjoy.                        )
 )               One day, you hear about a competition coming up.            (
(                This competition will award the winner $10,000.             )
 )                The competition is in six days from now.                  (
(                        You need to balance your time                        )
 )             with practicing and overall health if you want to win.        (
                     You sign up, writting down your name: {Name}                 
 )                        and must remember to bring:                        (
(                                 ID Card                                     )
                                Your {Instrument}                                            
(                             Your music sheet                                )
 )                                                                           (
(___       _       _       _       _       _       _       _       _       ___)
    (__  _) ( __ _) (__  _) (__ _ ) `-._.-' ( _ __) (_  __) (_ __ ) (_  __)
    ( _ __) (_  __) (__ __) `-._.-'         `-._.-' (__ __) (__  _) (__ _ )
    (__  _) (_ _ _) `-._.-'                         `-._.-' (_ _ _) (_  __)
    (_ ___) `-._.-'                                         `-._.-' (___ _)
    `-._.-'                                                         `-._.-'
            ".Pastel("#9effbd"));

            WaitForKey();

            if (Instrument == instrumentchoice[0])
            {
                SoundPlayer flutePlaying = new SoundPlayer($"{lines[0]}");
                flutePlaying.Load();
                flutePlaying.PlayLooping();
                Game story = new Game(Instrument);
                story.ChoiceOutcome();

            }
            if (Instrument == instrumentchoice[1])
            {
                SoundPlayer oboePlaying = new SoundPlayer($"{lines[1]}");
                oboePlaying.Load();
                oboePlaying.PlayLooping();
                Game story = new Game(Instrument);
                story.ChoiceOutcome();
            }
            if (Instrument == instrumentchoice[2])
            {
                SoundPlayer clarinetPlaying = new SoundPlayer($"{lines[2]}");
                clarinetPlaying.Load();
                clarinetPlaying.PlayLooping();
                Game story = new Game(Instrument);
                story.ChoiceOutcome();
            }
            if (Instrument == instrumentchoice[3])
            {
                SoundPlayer bassoonPlaying = new SoundPlayer($"{lines[3]}");
                bassoonPlaying.Load();
                bassoonPlaying.PlayLooping();
                Game story = new Game(Instrument);
                story.ChoiceOutcome();
            }
            if (Instrument == instrumentchoice[4])
            {
                SoundPlayer saxophonePlaying = new SoundPlayer($"{lines[4]}");
                saxophonePlaying.Load();
                saxophonePlaying.PlayLooping();
                Game story = new Game(Instrument);
                story.ChoiceOutcome();
            }
            if (Instrument == instrumentchoice[5])
            {
                SoundPlayer trumpetPlaying = new SoundPlayer($"{lines[5]}");
                trumpetPlaying.Load();
                trumpetPlaying.PlayLooping();
                Game story = new Game(Instrument);
                story.ChoiceOutcome();
            }
            if (Instrument == instrumentchoice[6])
            {
                SoundPlayer frenchhornPlaying = new SoundPlayer($"{lines[6]}");
                frenchhornPlaying.Load();
                frenchhornPlaying.PlayLooping();
                Game story = new Game(Instrument);
                story.ChoiceOutcome();
            }
            if (Instrument == instrumentchoice[7])
            {
                SoundPlayer TrombonePlaying = new SoundPlayer($"{lines[7]}");
                TrombonePlaying.Load();
                TrombonePlaying.PlayLooping();
                Game story = new Game(Instrument);
                story.ChoiceOutcome();
            }
            if (Instrument == instrumentchoice[8])
            {
                SoundPlayer tubaPlaying = new SoundPlayer($"{lines[8]}");
                tubaPlaying.Load();
                tubaPlaying.PlayLooping();
                Game story = new Game(Instrument);
                story.ChoiceOutcome();
            }
        }

        private void About()
        {
            WriteLine("Practice Makes Perfect by Evy Avila");
            WriteLine("Final Game project for Introduction to Programming at Columbia College Chicago.");

            WriteLine("\n====================================================================================\n");

            WriteLine("You are about to enter a music competition and have five days to prepare.");
            WriteLine("You must balance your time with practicing and maintaining good health.");

            WriteLine("\n\nPress any key to return to the main screen...".Pastel("#a2958b"));
            ReadKey();
            Introduction();
        }

        private void Credits()
        {
            WriteLine("Coding:");
            WriteLine("\t Some coding help from previous assignments and help from Instructor Mike Hadley.");

            WriteLine("\nPlay Testing:");
            WriteLine("\t Play testing from friend outside of class and parent.");
            WriteLine("\t Review and comments from peers.");

            WriteLine("\nMusic:");
            WriteLine("\t Free Music Archive : Relent - Clarinet");
            WriteLine("\t Free Music Archive: Song Of The Volga Boatmen - Trombone");
            WriteLine("\t Free Music Archive: Brass Chorale and Motet - French Horn");
            WriteLine("\t MUSOPEN : Vivaldi Concerto for Bassoon in a minor, RV 498 - Bassoon");
            WriteLine("\t YouTube Audio library: The Two Seasons - Flute");
            WriteLine("\t YouTube Audio library: It Came Upon a MidNight Clear - Oboe");
            WriteLine("\t YouTube Audio library: Moonlight Haze - Saxophone");
            WriteLine("\t YouTube Audio library: Salute To A New Beginning - Trumpet");
            WriteLine("\t YouTube Audio library: Tuba Waddle - Tuba");
            WriteLine("\t YouTube Audio library: Argonne - Zachariah Hickman - Intro");

            WriteLine("\nArt:");
            WriteLine("\tHand - Art by Veronica Karlsson");
            WriteLine("\tLips - Art by Normand Veilleux");
            WriteLine("\tMusicNotation - Art from https://www.asciiart.eu/");
            WriteLine("\tGift - Art created with http://asciiflow.com/");
            WriteLine("\tSick - Art created with http://asciiflow.com/");
            WriteLine("\tList - Art created with http://asciiflow.com/");
            WriteLine("\tDays and Title - Text Art created with http://patorjk.com/software/taag/");


            WriteLine("\n\nPress any key to return to the main screen...".Pastel("#a2958b"));
            ReadKey();
            Introduction();
        }

        private void Exit()
        {
            Write("Come back next time!".Pastel("#605b80"));
            ReadKey(true);
        }

        private void WaitForKey()
        {
            ReadKey();
            Clear();
        }
    }
}

