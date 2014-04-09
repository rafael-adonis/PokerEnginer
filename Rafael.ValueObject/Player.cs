using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rafael.ValueObject
{
    public class Player
    {
        private string name;
        private int points = 0;
        private List<Card> cards;
        private int rules = 0;

        public int Rules
        {
            get { return rules; }
            set { rules = value; }
        }

                
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        
        public List<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        }
    }
}
