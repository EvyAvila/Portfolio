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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Page
    {
        MainWindow window = (MainWindow)Application.Current.MainWindow;
        private World theWorldo;

        public GameOver(World tw)
        {
            InitializeComponent();
            theWorldo = tw;
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            FinalText.Text = ShowResult();
        }

        private string ShowResult()
        {
            string output = "";

            output += $"Game Over!";
            output += "\nCredits:\n\nCreated by Evy Avila\n\nHelped and Playtested by:\nJanell Baxter\nTyler Campo\nAdrian Leon\nJesse White";

            return output;
        }


    }
}
