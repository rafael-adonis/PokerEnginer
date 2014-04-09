using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rafael.ValueObject;
using Rafael.ValueObject.Enum;
using Rafael.Util;

namespace Rafael.Engine
{
    public class Engine
    {
        //Method for get max value
        private static int MaxPoints(List<Card> cards)
        {
            return cards.OrderByDescending(c => c.Value).First().Value;
        }

        //Returns the highest card
        public static int HighCardPoint(List<Card> cards)
        {
            return MaxPoints(cards);
        }

        //Verification Method Flush
        public static int FlushPoints(List<Card> cards)
        {
            try
            {
                bool hasSameNipe = HasAllSameNipe(cards);
                if (!hasSameNipe)
                    return 0;
                return MaxPoints(cards);

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Verification Method Straight
        public static int StraightPoints(List<Card> cards)
        {
            try
            {
                if (HasSequenceValues(cards))
                {
                    int valor = 0;
                    cards.ForEach(c => valor += c.Value);
                    return valor;
                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Verifier method par with higher value
        public static int DoublePairPointsHighValue(List<Card> cards)
        {
            return DoublePairPoints(cards, true);
        }

        //Method checker two pairs
        public static int DoublePairPoints(List<Card> cards)
        {
            return DoublePairPoints(cards, false);
        }

        //Generic method for treating two pairs and odd card
        private static int DoublePairPoints(List<Card> cards, bool bySingleCard)
        {
            try
            {
                var groups = cards.GroupBy(c => c.Value).Where(g => g.ToList().Count == (bySingleCard ? 1 : 2));
                int valor = 0;
                List<Card> listaFinal = new List<Card>();
                foreach (var group in groups)
                {
                    listaFinal.AddRange(cards.FindAll(c => c.Value == group.Key).ToList());
                }
                if (listaFinal.Count > 0)
                {
                    listaFinal.ForEach(c => valor += c.Value);
                }

                return valor;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Method to verify generic set of cards
        public static int QuantityPoint(List<Card> cards, int qtdCards)
        {
            try
            {
                bool hasSquarePoints = false;
                int SquarePointsValue = 0;
                foreach (int v in CardMatriz.Values.Values)
                {
                    if (cards.FindAll(c => c.Value == v).Count == qtdCards)
                    {
                        hasSquarePoints = true;
                        SquarePointsValue = v;
                    }
                }
                if (!hasSquarePoints)
                    return 0;
                return SquarePointsValue * qtdCards;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Verifier method Full House
        public static int FullHousePoints(List<Card> cards)
        {
            try
            {
                int ThreePoint = ThreePoints(cards);
                int PairPoint = PairPoints(cards);
                if (ThreePoint > 0 && PairPoint > 0)
                    return ThreePoint + PairPoint;
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Method Checker simple pair
        public static int PairPoints(List<Card> cards)
        {
            return QuantityPoint(cards, 2);
        }

        //Tester Method Three of a Kind
        public static int ThreePoints(List<Card> cards)
        {
            return QuantityPoint(cards, 3);
        }

        //Verifier method Four of a kind
        public static int SquarePoints(List<Card> cards)
        {
            return QuantityPoint(cards, 4);
        }

        //Verifier method of letters containing the same nipe
        private static bool HasAllSameNipe(List<Card> cards)
        {
            try
            {
                bool hasSameNipe = false;
                EnumUtil.GetValues<EnumNipe>().ToList<EnumNipe>().ForEach(delegate(EnumNipe nipe)
                {
                    if (cards.FindAll(c => c.Nipe == nipe).Count == 5)
                        hasSameNipe = true;

                });
                return hasSameNipe;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Verifier method sequence of letters
        private static bool HasSequenceValues(List<Card> cards)
        {
            try
            {
                cards.OrderBy(c => c.Sequence);
                bool hasSequenceValue = false;
                int beforeValue = 0;
                cards.ForEach(delegate(Card c)
                {
                    if (beforeValue != 0)
                    {
                        if (beforeValue != c.Sequence - 1)
                        {
                            if (hasSequenceValue)
                                hasSequenceValue = true;
                        }
                        beforeValue = c.Value;
                    }
                });
                return hasSequenceValue;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Verifier method of Straight Flush Points
        public static int StraightFlushPoints(List<Card> cards)
        {
            try
            {
                bool hasSameNipe = HasAllSameNipe(cards);
                if (!hasSameNipe)
                    return 0;

                bool hasSequenceValue = false;
                hasSequenceValue = HasSequenceValues(cards);
                if (!hasSequenceValue)
                    return 0;
                int valor = 0;
                cards.ForEach(c => valor += c.Value);
                return valor;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
