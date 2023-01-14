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
    /// Interaction logic for TheStore.xaml
    /// </summary>
    /// 

    public partial class TheStore : Page
    {
        MainWindow window = (MainWindow)Application.Current.MainWindow;

        private World theWorldo;

        //World tw
        public TheStore(World tw)
        {
            InitializeComponent();
            theWorldo = tw;
        }

        #region TheButtons
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(theWorldo);
            
        }

        private void FertPurchase_Click(object sender, RoutedEventArgs e)
        {
           
            if (window.ven.ThePlayerWallet > 12)
            {
                Speaking.Text = window.ven.AcceptedPurchaseMessage();
                window.ven.FerterlizerPurchased();
                window.pl.FertilizerAmount += 10;

                ThePlayerMoney.Text = window.ven.ThePlayerCurrency();
                //Testing.Text = window.ven.ShowPlayerInventory();

            }
            else if (window.ven.ThePlayerWallet < 12 || window.ven.ThePlayerWallet == 0)
            {
                Speaking.Text = window.ven.UnableToPurchaseMessage();
                ThePlayerMoney.Text = window.ven.ThePlayerCurrency();
            }
        }

        private void MothPurchase_Click(object sender, RoutedEventArgs e)
        {
            
            if (window.ven.ThePlayerWallet > 24)
            {
                Speaking.Text = window.ven.AcceptedPurchaseMessage();
                window.ven.MothPurchased();
                window.pl.MothAmount += 8;

                ThePlayerMoney.Text = window.ven.ThePlayerCurrency();
                //Testing.Text = window.ven.ShowPlayerInventory();

            }
            else if (window.ven.ThePlayerWallet < 24 || window.ven.ThePlayerWallet == 0)
            {
                Speaking.Text = window.ven.UnableToPurchaseMessage();
                ThePlayerMoney.Text = window.ven.ThePlayerCurrency();
            }
        }

        private void RabbitPurchase_Click(object sender, RoutedEventArgs e)
        {
            
            if (window.ven.ThePlayerWallet > 36)
            {
                Speaking.Text = window.ven.AcceptedPurchaseMessage();
                window.ven.RabbitPurchased();
                window.pl.RabbitAmount += 4;

                ThePlayerMoney.Text = window.ven.ThePlayerCurrency();
                //Testing.Text = window.ven.ShowPlayerInventory();

            }
            else if (window.ven.ThePlayerWallet < 36 || window.ven.ThePlayerWallet == 0)
            {
                Speaking.Text = window.ven.UnableToPurchaseMessage();
                ThePlayerMoney.Text = window.ven.ThePlayerCurrency();
            }
        }

        #endregion
        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ThePlayerMoney.Text = window.ven.ThePlayerCurrency();
            Speaking.Text = window.ven.FirstMessage();

            ItemNames.Text = window.ven.ShowEachItemName();
            ItemPrices.Text = window.ven.ShowEachPrice();

            SellingSign.Text = window.ven.SellingPriceOutcome();
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            if(window.ven.CornAmount == 0)
            {
                Testing.Text = "You don't have any to sell";
            }
            else
            {
                Testing.Text = "Thanks for doing business!";
                window.ven.SellCorn();
            }

            ThePlayerMoney.Text = window.ven.ThePlayerCurrency();
            
        }

        private void SellCottonButton_Click(object sender, RoutedEventArgs e)
        {
            if (window.ven.CottonAmount == 0)
            {
                Testing.Text = "You don't have any to sell";
            }
            else
            {
                Testing.Text = "Thanks for doing business!";
                window.ven.SellCotton();
            }

            ThePlayerMoney.Text = window.ven.ThePlayerCurrency();
        }

        private void SellBeetleOneButton_Click(object sender, RoutedEventArgs e)
        {
            if (window.ven.BeetleOneAmount == 0)
            {
                Testing.Text = "You don't have any to sell";
            }
            else
            {
                Testing.Text = "Thanks for doing business!";
                window.ven.SellBeetleOne();
            }

            ThePlayerMoney.Text = window.ven.ThePlayerCurrency();
        }

        private void SellBeetleTwo_Click(object sender, RoutedEventArgs e)
        {
            if (window.ven.BeetleTwoAmount == 0)
            {
                Testing.Text = "You don't have any to sell";
            }
            else
            {
                Testing.Text = "Thanks for doing business!";
                window.ven.SellBeetleTwo();
            }

            ThePlayerMoney.Text = window.ven.ThePlayerCurrency();
        }
    }
}
