using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomRandomList
{
    public class RandomList:List<string>
    {
        public List<string> randomList { get; set; }
        public RandomList()
        {
            randomList = new List<string>();
        }

        public string RandomString()
        {
            Random random = new Random();
            int element = random.Next(0, randomList.Count);
            randomList.Remove(randomList[element]);
            return randomList[element].ToString();
           
        }
    }
}
