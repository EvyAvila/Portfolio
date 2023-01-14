using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Producer : Entity
    {
        //Help from Janell Baxter
        //corn = 0
        //cotton = 1
        public int ChangeValue;
        public int TheValueDifference;

        #region Corns
        public string CornBeingEaten(List<Entity> RemovingCorn)
        {
            string output = "";
            ChangeValue = 0;
            TheValueDifference = 20;
            BeingEaten(RemovingCorn);
            return output;
        }
        public string RegenerateCorn(List<Entity> GoUp)
        {
            string output = "";
            ChangeValue = 0;
            TheValueDifference = 40;
            ChangingValue(GoUp);
            return output;
        }
        #endregion

        #region Cottons
        public string CottonBeingEaten(List<Entity> RemovingCotton)
        {
            string output = "";
            ChangeValue = 1;
            TheValueDifference = 20;
            BeingEaten(RemovingCotton);
            return output;
        }
        public string RegenerateCotton(List<Entity> GoUp)
        {
            string output = "";
            ChangeValue = 1;
            TheValueDifference = 40;
            ChangingValue(GoUp);
            return output;
        }
        #endregion

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
        if(GoUp[0].Amount > 0)
        {
            GoUp[0].Amount += 10;
        }
        else if(GoUp[0].Amount == 0)
        {
            try
            {
                if (GoUp[0].Amount == 0)
                {
                    GoUp[0].Amount += 0;
                }
            }
            catch { }
        }
        */

        /*
          if (GoUp[1].Amount > 0)
          {
              GoUp[1].Amount += 10;
          }
          else if (GoUp[1].Amount == 0)
          {
              try
              {
                  if(GoUp[1].Amount == 0)
                  {
                      GoUp[1].Amount += 0;
                  }
              }
              catch { }
          }
          */

        ////////////////////////////////////////

        /*
           if(RemovingCorn[0].Amount == 0)
           {
               RemovingCorn[0].Amount += 0;
           }
           else
           {
               RemovingCorn[0].Amount += -20;
           }
           */

        //RemovingCotton[1].Amount += -20;

        #endregion
    }
}
