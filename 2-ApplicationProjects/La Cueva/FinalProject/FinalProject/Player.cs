using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace FinalProject
{
    public class Player : Entity, INotifyPropertyChanged
    {
        #region PlayerStatus
        public int HungerLevel = 15;
        public int SleepLevel = 10;
        private int HealthLevel = 20;

        public event PropertyChangedEventHandler ThePropertyChanged;

        protected virtual void OnThePropertyChanged(string propertyName)
        {
            ThePropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Health
        {
            get => HealthLevel;
            set
            {
                HealthLevel = value;
                OnThePropertyChanged("HealthLevel");
            }
        }
        public int Sleep { get => SleepLevel; set => SleepLevel = value; }
        public int Hunger { get => HungerLevel; set => HungerLevel = value; }
        #endregion

        #region ItemAmounts
        public int FertilizerAmount = 2;
        public int MothAmount = 2;
        public int RabbitAmount = 2;
        #endregion
       
        public string Notebook;
        public Player() { }

        #region PlayerStatusMethods
        public int PlayerEnergy = 3;

        public string DisplayPlayer()
        {
            string output = "";

            output += $"Hunger\tSleep\tHealth\n{Hunger}  \t{Sleep}     \t{Health}";

            return output;
        }
        public void ChangeIndicator()
        {
            Health = HealthLevel - 3;
            Sleep = SleepLevel - 1;
            Hunger = HungerLevel - 2;
        }

        public void AddHealth()
        {
            Health = HealthLevel + 2;
        }

        public void AddSleep()
        {
            Sleep = SleepLevel + 2;
        }

        public void AddHunger()
        {
            Hunger = HungerLevel + 2;
        }

        public string ShowPlayerHealthPoints()
        {
            string output = "";

            output += $"Available Points: {PlayerEnergy}";

            return output;
        }

        public void LowerEnergy()
        {
            PlayerEnergy = PlayerEnergy - 1;
        }

        public void RengereateEnergy()
        {
            PlayerEnergy = PlayerEnergy + 2;
        }

        #endregion
       
        public string ShowNotebook()
        {
            string output = "";

            //EcosystemWorld ex = new EcosystemWorld();

            Notebook = $"You are in charge of keeping the ecosystem in balance while also managing your health. " +
                $"\nYou may harvest both crops and beetles that can be used to sell to the vendor, which is located in the store. " +
                $"\nYou can also purchase items to use in your ecosystem." +
                $"\nA game over will appear if you let all of your animals die or let one of your health levels reach 0." +
                $"\nGood luck!";

            //Here is a list of each biotic organism you will be watching over:\n\n
            /*for (int i = 0; i < ex.TheEntities.Count; i++)
            {
                Notebook += $"{ex.TheEntities[i].Name} is a {ex.TheEntities[i].Species}" + Environment.NewLine;
            }*/

            output += Notebook;

            return output;
        }

        public string ShowPlayerInventory()
        {
            string output = "";
            
            output += $"Fertilizer amount: {FertilizerAmount} \nMoth amount: {MothAmount} \nRabbit amount: {RabbitAmount}";
            return output;
        }

        #region UseItem
        public void RemoveFertilizer()
        {
            FertilizerAmount += -1;
        }

        public void RemoveMoth()
        {
            MothAmount += -1;
        }

        public void RemoveRabbit()
        {
            RabbitAmount += -1;
        }

        #endregion
    }
}
