using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rafael.ValueObject
{
    public static class CardMatriz
    {
        private static Dictionary<string, int> values = null;
        private static Dictionary<string, int> sequence = null;

        public static Dictionary<string, int> Sequence
        {
            get
            {
                if (sequence == null)
                {
                    sequence = new Dictionary<string, int>();
                    sequence.Add("A", 1);
                    sequence.Add("2", 2);
                    sequence.Add("3", 3);
                    sequence.Add("4", 4);
                    sequence.Add("5", 5);
                    sequence.Add("6", 6);
                    sequence.Add("7", 7);
                    sequence.Add("8", 8);
                    sequence.Add("9", 9);
                    sequence.Add("10", 10);
                    sequence.Add("J", 11);
                    sequence.Add("Q", 12);
                    sequence.Add("K", 13);

                }
                return CardMatriz.sequence;
            }

        }


        public static Dictionary<string, int> Values
        {
            get
            {
                if (values == null)
                {
                    values = new Dictionary<string, int>();
                    values.Add("2", 2);
                    values.Add("3", 3);
                    values.Add("4", 4);
                    values.Add("5", 5);
                    values.Add("6", 6);
                    values.Add("7", 7);
                    values.Add("8", 8);
                    values.Add("9", 9);
                    values.Add("10", 10);
                    values.Add("J", 11);
                    values.Add("Q", 12);
                    values.Add("K", 13);
                    values.Add("A", 14);
                }
                return CardMatriz.values;
            }

        }
    }
}
