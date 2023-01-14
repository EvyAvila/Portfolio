using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalProject
{
    
    public class Vendor : Entity, ICurrency
    {
        #region TheFields
        
        public int PlayerMoney = 50;
        private int itemPrices;        
        public int TheItemPrice { get => itemPrices; set => itemPrices = value; }
        
        public int ThePlayerWallet {get => PlayerMoney; set => PlayerMoney = value;  }

        public string _TheItemName;
        public int _TheItemAmount;

        public int CornAmount;
        public int CottonAmount;
        public int BeetleOneAmount;
        public int BeetleTwoAmount;

        #endregion

        #region DisplayingVendorMessages

        public string FirstMessage()
        {
            string output = "Welcome to my shop! I have some stuff I can sell with a good price. Feel free to explore. " +
                "\n\nEach bag contains certain amount for each purchase.\n\nYou may also sell whatever you may have in your inventory.";

            //\n\nYou may also sell whatever you may have in your inventory.

            return output;
        }

        public string AcceptedPurchaseMessage()
        {
            string output = "Thank you for purchasing!";
            return output;
        }

        public string UnableToPurchaseMessage()
        {
            string output = "Sorry, you can not make that purchase";
            return output;
        }
       
        #endregion

        public string ThePlayerCurrency()
        {
            string output = "";
            output += $"You have {ThePlayerWallet.ToString("c")}";
            return output;
        }

        //public List<Item> PurchasedInventory = new List<Item>();

        public Vendor() { }

        #region DisplayShow
        public string ShowEachItemName()
        {
            string output = "";
            output += $"{ItemsToUse.Fertilizer}\t\t       {ItemsToUse.Moth}\t\t             \t{ItemsToUse.Rabbit}";
            return output;
        }

        public string ShowEachPrice()
        {
            string output = "";
            output += $"{DisplayFertilizerPrice()}\t\t      {DisplayMothPrice()}\t\t   {DisplayRabbitPrice()}";
            return output;
        }
        
        public string SellingPriceOutcome()
        {
            string output = "";
            output += "Corn = $2.00\nCotton = $2.00\nDermestid Beetle = $10.00\nGuano Beetle = $15.00";

            return output;
        }
        
        #endregion
        
        #region PurchasMethods

        public void FerterlizerPurchased()
        {
            ThePlayerWallet = PlayerMoney - 12;
        }

        public void MothPurchased()
        {
            ThePlayerWallet = PlayerMoney - 24;
        }

        public void RabbitPurchased()
        {
            ThePlayerWallet = PlayerMoney - 36;
        }
        #endregion

        #region DisplayingPrices

        public string DisplayFertilizerPrice()
        {
            string output = "";
            itemPrices = 12;

            output += TheItemPrice.ToString("c");

            return output;
        }

        public string DisplayMothPrice()
        {
            string output = "";
            itemPrices = 24;

            output += TheItemPrice.ToString("c");

            return output;
        }

        public string DisplayRabbitPrice()
        {
            string output = "";

            itemPrices = 36;

            output += TheItemPrice.ToString("c");

            return output;
        }
        #endregion

        #region Selling
        public void SellCorn()
        {
            if(CornAmount > 0)
            {
                CornAmount--;
                ThePlayerWallet = PlayerMoney + 2;
            }
        }
        public void SellCotton()
        {
            if (CottonAmount > 0)
            {
                while (CottonAmount > 0)
                {
                    CottonAmount--;
                    ThePlayerWallet = PlayerMoney + 2;
                }
            }

        }
        public void SellBeetleOne()
        {
            if (BeetleOneAmount > 0)
            {
                while (BeetleOneAmount > 0)
                {
                    BeetleOneAmount--;
                    ThePlayerWallet = PlayerMoney + 10;
                }
            }
        }
        public void SellBeetleTwo()
        {
            if (BeetleTwoAmount > 0)
            {
                while (BeetleTwoAmount > 0)
                {
                    BeetleTwoAmount--;
                    ThePlayerWallet = PlayerMoney + 15;
                }
            }
        }
        #endregion
    }
}
