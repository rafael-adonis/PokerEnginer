using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rafael.ValueObject.Enum;

namespace Rafael.ValueObject
{
    public class Card
    {
        private int value = 0;
        private EnumNipe nipe;

        public EnumNipe Nipe
        {
            get { return nipe; }
            set { nipe = value; }
        }
        private int sequence = 0;

        public int Sequence
        {
            get { return sequence; }
            set { sequence = value; }
        }


        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

    }
}
