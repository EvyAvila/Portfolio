using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Media.Imaging;

namespace FinalProject
{
    public class EcosystemWorld
    {
        //List code from class example
        public static List<Entity> LoadEntities(string fileName)
        {
            List<Entity> entities = new List<Entity>();
            if (File.Exists(fileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlNode root = doc.DocumentElement;
                XmlNodeList entityList = root.SelectNodes("/environment/entity");
                foreach (XmlElement entity in entityList)
                {
                    Entity temp;
                    int amt = 0;

                    if(int.TryParse(entity.GetAttribute("amount"), out int a))
                    { amt = a; }

                    if (entity.GetAttribute("type") == "Producer")
                    {
                        temp = new Producer();
                    }
                    else if (entity.GetAttribute("type") == "Consumer")
                    {
                        temp = new Consumer();
                    }
                    else if (entity.GetAttribute("type") == "Decomposer")
                    {
                        temp = new Decomposer();
                    }
                    else
                    {
                        temp = new Entity();
                    }
                    temp.Name = entity.GetAttribute("name");
                    temp.Species = entity.GetAttribute("species");
                    temp.Amount = amt;
                    temp.ImagePath = entity.GetAttribute("theImage");               
                    entities.Add(temp);
                }
            }
            return entities;
        }

        public List<Entity> TheEntities = LoadEntities("../data/updated_final_data.xml");

        public int currentDay = 1;

        #region DisplayingMethod
        public string DisplayEachName()
        {
            string output = "";
            for (int i = 0; i < 4; i++)
            {
                output += $"       {TheEntities[i].Name}        ";
            }
            return output;
        }

        public string DisplayEachNamePartTwo()
        {
            string output = "";
            for (int i = 4; i < 8; i++)
            {
                output += $"  {TheEntities[i].Name}   ";
            }
            return output;
        }

        public string DisplayEachNumberPartOne()
        {
            string output = "";
            for (int i = 0; i < 4; i++)
            {
                output += $"  {TheEntities[i].Amount}\t\t";
            }

            return output;
        }

        public string DisplayEachNumberPartTwo()
        {
            string output = "";
            for (int i = 4; i < 8; i++)
            {
                output += $"  {TheEntities[i].Amount}\t\t      ";
            }

            return output;
        }
        #endregion
    }
}
