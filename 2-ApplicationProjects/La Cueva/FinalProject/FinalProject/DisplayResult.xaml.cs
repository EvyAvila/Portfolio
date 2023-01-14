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
using static FinalProject.EcosystemWorld;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for DisplayResult.xaml
    /// </summary>
    public partial class DisplayResult : Page
    {
        MainWindow window = (MainWindow)Application.Current.MainWindow;
        
        private World theWorldo;
       
        //World tw
        public DisplayResult(World tw)
        {
            InitializeComponent();
            theWorldo = tw;
        }

        /*
         public string Message()
        {
            string output = "";

            //DisplayingMessage.Text = output += "That is all for the prototype! :) \nThere will be future updates!";

            output += "Insert details";
            //DisplayingMessage.Text = output += $"Your current inventory: \n{vendor.ShowPlayerInventory()} ";
            DisplayingMessage.Text = output;
            
            return output;
        }
         */


        public string TheNotebook()
        {
            string output = "";
            DisplayingMessage.Text = output += window.pl.ShowNotebook();
            return output;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            //To change image for button, go to Brush, TileBrush
            NavigationService.Navigate(theWorldo);
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //Message();
            TheNotebook();

        }
    }
}
