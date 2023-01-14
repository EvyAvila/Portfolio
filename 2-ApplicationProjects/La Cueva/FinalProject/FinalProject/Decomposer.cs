using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Decomposer : Entity
    {
        //Bettle 1 = 6
        //Bettle 2 = 7

        public int ChangeValue;
        public int TheValueDifference;

        #region BeetleOne
        public string BeetleOneGoUp(List<Entity> TheBeetle)
        {
            string output = "";
            ChangeValue = 6;
            TheValueDifference = 2;
            ChangingValue(TheBeetle);
            return output;
        }
        public string PickBeetleOne(List<Entity> Pick)
        {
            string output = "";
            ChangeValue = 6;
            TheValueDifference = 1;
            BeingChoosenToSell(Pick);
            return output;
        }
        #endregion

        #region BeetleTwo
        public string BeetleTwoGoUp(List<Entity> TheBeetle)
        {
            string output = "";
            ChangeValue = 7;
            TheValueDifference = 2;
            ChangingValue(TheBeetle);
            return output;
        }
        public string PickBeetleTwo(List<Entity> Pick)
        {
            string output = "";
            ChangeValue = 7;
            TheValueDifference = 1;
            BeingChoosenToSell(Pick);
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

        public void BeingChoosenToSell(List<Entity> goDown)
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
         if (TheBeetle[5].Amount >= 5)
            {
                TheBeetle[6].Amount += 2;
            }
         */

        /*
         TheBeetle[7].Amount += 2;
         */

        #endregion
    }
}
