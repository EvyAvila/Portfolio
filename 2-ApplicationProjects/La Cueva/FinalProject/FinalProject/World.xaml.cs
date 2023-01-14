using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static FinalProject.EcosystemWorld;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for World.xaml
    /// </summary>
    /// 
   
    public partial class World : Page
    {
        #region TheClassesCalling
        MainWindow window = (MainWindow)Application.Current.MainWindow;
        
        EcosystemWorld EW = new EcosystemWorld();
        Producer pr = new Producer();
        Consumer cn = new Consumer();
        Decomposer dc = new Decomposer();

        TheWeather TW = new TheWeather();


        #endregion

        
        #region Clock
        DispatcherTimer timer;
        TimeSpan timeSpan;

        private void GameLoop()
        {
            
            DayCounter.Text = $"Day: {EW.currentDay}";

            //Getting even number from https://www.includehelp.com/dot-net/print-even-and-odd-numbers-from-1-to-30-in-c-sharp.aspx
            CheckIfAllCreaturesDies();
            if (EW.currentDay > 1)
            {
                if (window.pl.Health <= 0 )
                {
                    End();
                    return;
                }
                else if(window.pl.Sleep <= 0)
                {
                    End();
                    return;
                }
                else if (window.pl.Hunger <= 0)
                {
                    End();
                    return;
                }
                window.pl.ChangeIndicator();
                window.pl.RengereateEnergy();
            }

            if (EW.currentDay > 1 && EW.currentDay % 2 == 0)
            {
                
                if(EW.TheEntities[0].Amount !=0)
                {
                    pr.CornBeingEaten(EW.TheEntities);
                    cn.CornWormsRegeneration(EW.TheEntities);
                }

                if(EW.TheEntities[1].Amount != 0)
                {
                    pr.CottonBeingEaten(EW.TheEntities);
                    cn.CottonWormsRegeneration(EW.TheEntities);
                }
                
                if(EW.TheEntities[2].Amount != 0)
                {
                    cn.CornWormsBeingEaten(EW.TheEntities);
                    if(EW.TheEntities[2].Amount == 0 && EW.TheEntities[3].Amount != 0)
                    {
                        cn.CottonWormsBeingEaten(EW.TheEntities);
                        cn.BatRegneration(EW.TheEntities);
                    }

                    cn.BatRegneration(EW.TheEntities);
                }
                else if(EW.TheEntities[3].Amount != 0)
                {
                    cn.CottonWormsBeingEaten(EW.TheEntities);
                    if (EW.TheEntities[3].Amount == 0 && EW.TheEntities[2].Amount != 0)
                    {
                        cn.CornWormsBeingEaten(EW.TheEntities);
                        cn.BatRegneration(EW.TheEntities);
                    }

                    cn.BatRegneration(EW.TheEntities);
                }

                if(EW.TheEntities[4].Amount != 0)
                {
                    cn.BatBeingEaten(EW.TheEntities);
                    cn.HawkRegneration(EW.TheEntities);
                }

                dc.BeetleOneGoUp(EW.TheEntities);
                dc.BeetleTwoGoUp(EW.TheEntities);
              
            }
            else if(EW.currentDay > 1 && EW.currentDay%2 != 0)
            {

                pr.RegenerateCorn(EW.TheEntities);
                pr.RegenerateCotton(EW.TheEntities);
                cn.HawkDies(EW.TheEntities);
                TW.theIndex++;
            }

            
            EW.currentDay++;
            Counter();
           
            PlayerIndicator.Text = window.pl.DisplayPlayer();
            PlayerEnergyPoints.Text = window.pl.ShowPlayerHealthPoints();

            AmountOne.Text = EW.DisplayEachNumberPartOne();            
            AmountTwo.Text = EW.DisplayEachNumberPartTwo();

            DisplayWeather.Text = TW.ShowWeather();

        }

        private void Counter()
        {
            //DispatchTimer example by kmatyaszek (https://stackoverflow.com/users/1410998/kmatyaszek)
            timeSpan = TimeSpan.FromSeconds(15);

            timer = new DispatcherTimer(
                new TimeSpan(0, 0, 1),
                DispatcherPriority.Normal,
                delegate
                {
                    if (timeSpan == TimeSpan.Zero)
                    {
                        timer.Stop();
                        GameLoop();
                    }
                    timeSpan = timeSpan.Add(TimeSpan.FromSeconds(-1));
                },
                Application.Current.Dispatcher);

            timer.Start();
        }
        #endregion

        public World()
        {
            InitializeComponent();
            EW.TheEntities = LoadEntities("../data/updated_final_data.xml");
            GameLoop();
        }

        int index = 0;
        private void CottonAmount_Loaded(object sender, RoutedEventArgs e)
        {
            //DataContext = EW.TheEntities[index];
            //Naming.Text = pr.GetProducer();
        }

        #region Buttons
        //Button to use Fertilizer button
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {   
            index = 0;
            if (window.pl.FertilizerAmount == 0)
            { }
            else
            {
                window.pl.RemoveFertilizer();
                EW.TheEntities[index].Amount += 15;
                EW.TheEntities[1].Amount += 15;
            }

            DisplayToUseTest.Text = window.pl.ShowPlayerInventory();
            AmountOne.Text = EW.DisplayEachNumberPartOne();
        }

        //Button to use Moth item
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            index = 2;
            if (window.pl.MothAmount == 0)
            { }
            else
            {
                window.pl.RemoveMoth();
                EW.TheEntities[index].Amount += 12;
                EW.TheEntities[3].Amount += 12;
            }
            DisplayToUseTest.Text = window.pl.ShowPlayerInventory();
            AmountOne.Text = EW.DisplayEachNumberPartOne();
        }

        //Not in use
        private void Picture_Loaded(object sender, RoutedEventArgs e)
        {
            //Personal Note:
            //DO NOT DELETE! It will break the whole project if - private void Picture_Loaded(object sender, RoutedEventArgs e) is deleted

            //DataContext = EW.images[imageIndex];

            //Picture.Source = new BitmapImage(new Uri("pack://application:,,,/media/" + imagePath + ".png"));

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            //Reference from https://stackoverflow.com/questions/2820357/how-do-i-exit-a-wpf-application-programmatically
            Application.Current.Shutdown();
        }

        private void NoteBookButton_Click(object sender, RoutedEventArgs e)
        {
            //Code from https://stackoverflow.com/questions/49767595/how-to-navigate-to-previous-page-in-wpf-but-keep-the-data
            //Needed to keep data when returing back to page
            var theNotebook = new DisplayResult(this);
            NavigationService.Navigate(theNotebook);
        }

    
        private void StoreButton_Click(object sender, RoutedEventArgs e)
        {
            var thestore = new TheStore(this);
            NavigationService.Navigate(thestore);
        }
        #endregion
        
        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            PlayerIndicator.Text = window.pl.DisplayPlayer();
            PlayerEnergyPoints.Text = window.pl.ShowPlayerHealthPoints();

            DisplayToUseTest.Text = window.pl.ShowPlayerInventory();
        
            NamingOne.Text = EW.DisplayEachName();
            AmountOne.Text = EW.DisplayEachNumberPartOne();

            NamingTwo.Text = EW.DisplayEachNamePartTwo();
            AmountTwo.Text = EW.DisplayEachNumberPartTwo();

            DisplayWeather.Text = TW.ShowWeather();

        }

        #region AddingButtonsForPlayer
        private void HungerButton_Click(object sender, RoutedEventArgs e)
        {
            if(window.pl.PlayerEnergy > 0)
            {
                window.pl.AddHunger();
                window.pl.LowerEnergy();
                PlayerEnergyPoints.Text = window.pl.ShowPlayerHealthPoints();
                PlayerIndicator.Text = window.pl.DisplayPlayer();
            }
            else if(window.pl.PlayerEnergy == 0)  {   }
        }

        private void SleepButton_Click(object sender, RoutedEventArgs e)
        {
            if (window.pl.PlayerEnergy > 0)
            {
                window.pl.AddSleep();
                window.pl.LowerEnergy();
                PlayerEnergyPoints.Text = window.pl.ShowPlayerHealthPoints();
                PlayerIndicator.Text = window.pl.DisplayPlayer();
            }
            else if (window.pl.PlayerEnergy == 0)  {    }
        }

        private void HealthButton_Click(object sender, RoutedEventArgs e)
        {
            if (window.pl.PlayerEnergy > 0)
            {
                window.pl.AddHealth();
                window.pl.LowerEnergy();
                PlayerEnergyPoints.Text = window.pl.ShowPlayerHealthPoints();
                PlayerIndicator.Text = window.pl.DisplayPlayer();
            }
            else if (window.pl.PlayerEnergy == 0)  {    }
        }
        #endregion

        #region MoreButtonsToPress
        //Button to harvest Cotton
        private void TakeAwayButton_Click(object sender, RoutedEventArgs e)
        {
            index = 1;
            if (EW.TheEntities[index].Amount == 0)
            {

            }
            else
            {
                EW.TheEntities[index].Amount += -1;
                window.ven.CottonAmount += 1;
            }

            DisplayToUseTest.Text = window.pl.ShowPlayerInventory();
            AmountOne.Text = EW.DisplayEachNumberPartOne();
          
        }

        //Button to use Rabbit item
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            index = 4;
            if(window.pl.RabbitAmount == 0)
            {
                
            }
            else
            {
                window.pl.RemoveRabbit();
                EW.TheEntities[index].Amount += 8;
            }
            
            DisplayToUseTest.Text = window.pl.ShowPlayerInventory();

            
            AmountTwo.Text = EW.DisplayEachNumberPartTwo();
            /*
            if (index == 0)
            {
                if(window.pl.FertilizerAmount == 0)
                {
                    //Nothing happens
                }
                else
                {
                    window.pl.RemoveFertilizer();
                    EW.TheEntities[0].Amount += 15;
                }
                          
            }
            else if(index == 1)
            {
                if(window.pl.FertilizerAmount  == 0)
                {
                    //Nothing happens
                }
                else
                {
                    window.pl.RemoveFertilizer();
                    EW.TheEntities[1].Amount += 15;
                }
            }
            else if(index == 4)
            {
                if(window.pl.MothAmount == 0)
                {

                }
                else
                {
                    window.pl.RemoveMoth();
                    EW.TheEntities[2].Amount += 12;
                    EW.TheEntities[3].Amount += 12;
                }
            }
            else if(index == 5)
            {
                if(window.pl.RabbitAmount == 0)
                {

                }
                else
                {
                    window.pl.RemoveRabbit();
                    EW.TheEntities[4].Amount += 8;
                }
            }


            DisplayToUseTest.Text = window.pl.ShowPlayerInventory();
            DataContext = EW.TheEntities[index];
            */
        }

        private void HarvestCornButton_Click(object sender, RoutedEventArgs e)
        {
            index = 0;
            if (EW.TheEntities[index].Amount == 0)
            {  }
            else
            {
                EW.TheEntities[index].Amount += -1;
                window.ven.CornAmount += 1;
            }
            DisplayToUseTest.Text = window.pl.ShowPlayerInventory();
            AmountOne.Text = EW.DisplayEachNumberPartOne();
        }

        private void HarvestBeetleOne_Click(object sender, RoutedEventArgs e)
        {
            index = 6;
            if (EW.TheEntities[index].Amount == 0)
            { }
            else
            {
                EW.TheEntities[index].Amount += -1;
                window.ven.BeetleOneAmount += 1;
            }
            DisplayToUseTest.Text = window.pl.ShowPlayerInventory();
            AmountTwo.Text = EW.DisplayEachNumberPartTwo();
        }

        private void HarvestBeetleTwo_Click(object sender, RoutedEventArgs e)
        {
            index = 7;
            if (EW.TheEntities[index].Amount == 0)
            { }
            else
            {
                EW.TheEntities[index].Amount += -1;
                window.ven.BeetleTwoAmount += 1;
            }
            DisplayToUseTest.Text = window.pl.ShowPlayerInventory();
            AmountTwo.Text = EW.DisplayEachNumberPartTwo();
        }
        #endregion
        private void End()
        {
            var theNotebook = new GameOver(this);
            NavigationService.Navigate(theNotebook);
        }

        private void CheckIfAllCreaturesDies()
        {
            if(EW.TheEntities[0].Amount == 0 && EW.TheEntities[1].Amount == 0 && EW.TheEntities[2].Amount == 0 && EW.TheEntities[3].Amount == 0 && EW.TheEntities[4].Amount == 0 && EW.TheEntities[5].Amount == 0 && EW.TheEntities[6].Amount == 0 && EW.TheEntities[7].Amount == 0)
            {
                var theNotebook = new GameOver(this);
                NavigationService.Navigate(theNotebook);
                return;
            }
        }
    }
}
