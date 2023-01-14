using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Consumer : Entity
    {
        //corn worm = 2
        //cotton worm = 3
        //bat = 4
        //hawk = 5

        public int ChangeValue;
        public int TheValueDifference;

        #region CornWorms
        public string CornWormsBeingEaten(List<Entity> TheWorms)
        {
            string output = "";
            ChangeValue = 2;
            TheValueDifference = 10;
            BeingEaten(TheWorms);
            return output;
        }

        public string CornWormsRegeneration(List<Entity> TheWorms)
        {
            string output = "";
            ChangeValue = 2;
            TheValueDifference = 20;
            ChangingValue(TheWorms);
            return output;
        }
        #endregion

        #region CottonWorms
        public string CottonWormsBeingEaten(List<Entity> TheWorms)
        {
            string output = "";
            ChangeValue = 3;
            TheValueDifference = 10;
            BeingEaten(TheWorms);
            return output;
        }
        public string CottonWormsRegeneration(List<Entity> TheWorms)
        {
            string output = "";
            ChangeValue = 3;
            TheValueDifference = 20;
            ChangingValue(TheWorms);
            return output;
        }

        #endregion

        #region Bats
        public string BatBeingEaten(List<Entity> TheBat)
        {
            string output = "";
            ChangeValue = 4;
            TheValueDifference = 5;
            BeingEaten(TheBat);
            return output;
        }
        public string BatRegneration(List<Entity> TheBats)
        {
            string output = "";
            ChangeValue = 4;
            TheValueDifference = 10;
            ChangingValue(TheBats);
            return output;

        }
        #endregion

        #region Hawks
        public string HawkDies(List<Entity> TheHawk)
        {
            string output = "";
            ChangeValue = 5;
            TheValueDifference = 1;
            BeingEaten(TheHawk);
            return output;
        }
        public string HawkRegneration(List<Entity> TheHawk)
        {
            string output = "";
            ChangeValue = 5;
            TheValueDifference = 5;
            ChangingValue(TheHawk);
            return output;
        }

        #endregion

        //Used for if_they_can_repopulate algorithm 
        public void ChangingValue(List<Entity> theChanging)
        {
            if (theChanging[ChangeValue].Amount > 0)
            {
                theChanging[ChangeValue].Amount += TheValueDifference;
            }
            else if (theChanging[ChangeValue].Amount == 0)
            {
                try
                {
                    if (theChanging[ChangeValue].Amount == 0)
                    {
                        theChanging[ChangeValue].Amount += 0;
                    }
                }
                catch { }
            }
        }

        //Used for when_the_entity_is_being_eaten algorithm
        public void BeingEaten(List<Entity> goDown)
        {
            if (goDown[ChangeValue].Amount == 0)
            {
                goDown[ChangeValue].Amount += 0;
            }
            else
            {
                goDown[ChangeValue].Amount += -TheValueDifference;
            }
        }

        #region ExtraBackUpCode
        /*
            if(TheWorms[0].Amount > 0)
            {
                TheWorms[2].Amount += 20;
            }
            else if (TheWorms[0].Amount == 0)
            {
                try
                {
                    if (TheWorms[2].Amount == 0)
                    {
                        TheWorms[2].Amount += 0;
                    }
                    else
                    {
                        TheWorms[2].Amount += -20;
                    }
                }
                catch { }
            }
            */

        /*
           if (TheWorms[1].Amount > 0)
           {
               TheWorms[3].Amount += 10;
           }
           else if (TheWorms[1].Amount == 0)
           {
               try
               {
                   if (TheWorms[3].Amount == 0)
                   {
                       TheWorms[3].Amount += 0;
                   }
                   else 
                   {
                       TheWorms[3].Amount += -20;
                   }
               }
               catch { }
           }
           */

        /*

           if (TheBats[4].Amount > 0)
           {
               TheBats[4].Amount += 10;
           }
           else
           {
               try
               {
                   if (TheBats[4].Amount < 0)
                   {
                       TheBats[4].Amount += 1;
                   }
                   else if (TheBats[4].Amount == 0)
                   {
                       return TheBats[4].Amount.ToString();
                   }
               }
               catch { }
           }
           */

        /*
          if (TheHawk[5].Amount != 0 || TheHawk[5].Amount > 0)
          {
              TheHawk[5].Amount += 10;
          }
          else
          {
              try
              {
                  if (TheHawk[5].Amount < 0)
                  {
                      TheHawk[5].Amount += 1;
                  }
                  else if (TheHawk[5].Amount == 0)
                  {
                      return TheHawk[5].Amount.ToString();
                  }
              }
              catch { }
          }
          TheHawk[4].Amount += 2;
          */

        /*
          if (TheWorms[2].Amount >= 10)
            {
                TheWorms[2].Amount += - 10;
            }
         
        
            if (TheWorms[3].Amount >= 10)
            {
                TheWorms[3].Amount += - 10;
            }

        
            if (TheBat[4].Amount >= 5)
            {
                TheBat[4].Amount += -5;
            }

          if (TheHawk[5].Amount >= 5)
            {
                TheHawk[5].Amount += -1;
            }
         */
        #endregion


    }
}
