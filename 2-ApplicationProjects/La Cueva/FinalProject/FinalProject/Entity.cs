using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinalProject
{
    public class Entity : INotifyPropertyChanged
    {
       
        private string name;
        private string species;
        private int amount;
        //Code from Janell Baxter
        public event PropertyChangedEventHandler PropertyChanged;
        string imagePath = "batcave";

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ImagePath { get => imagePath; set => imagePath = value; }
        public string Name { get => name; set => name = value; }
        public string Species { get => species; set => species = value; }
        
        public int Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged("amount");
            }
        }
        public Entity() { }
    }
}
