using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rafael.Engine;
using Rafael.ValueObject;
using Rafael.ValueObject.Enum;


namespace Rafael.BusinessObjects
{
    public class CardBO
    {
        //According to points, defines the winning player
        private List<Player> GetWinPlayer(Player PlayerOne, Player PlayerTwo, EnumRules rules)
        {
            List<Player> listFinal = new List<Player>();
            if (PlayerOne.Points > 0 || PlayerTwo.Points > 0)
            {
                if (PlayerOne.Points == PlayerTwo.Points)
                {
                    listFinal.Add(PlayerOne);
                    listFinal.Add(PlayerTwo);
                }
                else
                {
                    if (PlayerOne.Points > PlayerTwo.Points)
                    {
                        listFinal.Add(PlayerOne);
                        PlayerOne.Rules = Convert.ToInt32(rules);
                    }
                    else
                    {
                        listFinal.Add(PlayerTwo);
                        PlayerTwo.Rules = Convert.ToInt32(rules);
                    }
                }
            }
            return listFinal;
        }

        //Checks the type at which point fits the cards of each player
        public List<Player> GetTotalPoints(Player PlayerOne, Player PlayerTwo)
        {
            try
            {
                List<Player> PlayersList = new List<Player>();

                PlayerOne.Points = Engine.Engine.StraightFlushPoints(PlayerOne.Cards);
                PlayerTwo.Points = Engine.Engine.StraightFlushPoints(PlayerTwo.Cards);
                PlayersList = GetWinPlayer(PlayerOne, PlayerTwo, EnumRules.STRAIGHT_FLUSH);
                if (PlayersList.Count > 0)
                    return PlayersList;

                PlayerOne.Points = Engine.Engine.SquarePoints(PlayerOne.Cards);
                PlayerTwo.Points = Engine.Engine.SquarePoints(PlayerTwo.Cards);
                PlayersList = GetWinPlayer(PlayerOne, PlayerTwo, EnumRules.FOUR_OF_A_KIND);
                if (PlayersList.Count > 0)
                    return PlayersList;

                PlayerOne.Points = Engine.Engine.FullHousePoints(PlayerOne.Cards);
                PlayerTwo.Points = Engine.Engine.FullHousePoints(PlayerTwo.Cards);
                PlayersList = GetWinPlayer(PlayerOne, PlayerTwo, EnumRules.FULL_HOUSE);
                if (PlayersList.Count > 0)
                    return PlayersList;

                PlayerOne.Points = Engine.Engine.FlushPoints(PlayerOne.Cards);
                PlayerTwo.Points = Engine.Engine.FlushPoints(PlayerTwo.Cards);
                PlayersList = GetWinPlayer(PlayerOne, PlayerTwo, EnumRules.FLUSH);
                if (PlayersList.Count > 0)
                    return PlayersList;

                PlayerOne.Points = Engine.Engine.StraightPoints(PlayerOne.Cards);
                PlayerTwo.Points = Engine.Engine.StraightPoints(PlayerTwo.Cards);
                PlayersList = GetWinPlayer(PlayerOne, PlayerTwo, EnumRules.STRAIGHT_FLUSH);
                if (PlayersList.Count > 0)
                    return PlayersList;

                PlayerOne.Points = Engine.Engine.ThreePoints(PlayerOne.Cards);
                PlayerTwo.Points = Engine.Engine.ThreePoints(PlayerTwo.Cards);
                PlayersList = GetWinPlayer(PlayerOne, PlayerTwo, EnumRules.THREE_OF_A_KIND);
                if (PlayersList.Count > 0)
                    return PlayersList;

                PlayerOne.Points = Engine.Engine.DoublePairPoints(PlayerOne.Cards);
                PlayerTwo.Points = Engine.Engine.DoublePairPoints(PlayerTwo.Cards);
                PlayersList = GetWinPlayer(PlayerOne, PlayerTwo, EnumRules.DOUBLE_PAIR);
                if (PlayersList.Count > 0)
                    return PlayersList;

                PlayerOne.Points = Engine.Engine.PairPoints(PlayerOne.Cards);
                PlayerTwo.Points = Engine.Engine.PairPoints(PlayerTwo.Cards);
                PlayersList = GetWinPlayer(PlayerOne, PlayerTwo, EnumRules.PAIR);
                if (PlayersList.Count > 0)
                    return PlayersList;

                PlayerOne.Points = Engine.Engine.HighCardPoint(PlayerOne.Cards);
                PlayerTwo.Points = Engine.Engine.HighCardPoint(PlayerTwo.Cards);
                PlayersList = GetWinPlayer(PlayerOne, PlayerTwo, EnumRules.HIGH_CARD);
                if (PlayersList.Count > 0)
                    return PlayersList;

                return PlayersList;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
