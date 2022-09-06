using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            SmackTalkingPlayer player1 = new SmackTalkingPlayer();
            player1.Name = "Bob";
            player1.Taunt = "You suck!";

            OneHigherPlayer player2 = new OneHigherPlayer();
            player2.Name = "Sue";

            player2.Play(player1);

            Console.WriteLine("-------------------");

            Player player3 = new Player();
            player3.Name = "Wilma";

            player3.Play(player2);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            player1.Play(large);

            Console.WriteLine("-------------------");

            HumanPlayer player5 = new HumanPlayer();
            player5.Name = "The One";

            player2.Play(player5);

            Console.WriteLine("-------------------");

            CreativeSmackTalkingPlayer player6 = new CreativeSmackTalkingPlayer();
            player6.Name = "Sean";
            player6.SmackTalk.Add("You're going down.");
            player6.SmackTalk.Add("I'm the gambler");
            player6.SmackTalk.Add("Booyah");
            player1.Play(player6);

            Console.WriteLine("-------------------");

            SoreLoserPlayer player7 = new SoreLoserPlayer();
            player7.Name = "Bucky";

            player7.Play(player2);

            Console.WriteLine("-------------------");

            UpperHalfPlayer player8 = new UpperHalfPlayer();
            player8.Name = "Hazel";

            player8.Play(player1);

            Console.WriteLine("-------------------");
            SoreLoserUpperHalfPlayer player9 = new SoreLoserUpperHalfPlayer();
            player9.Name = "Boone";

            player9.Play(player3);

            List<Player> players = new List<Player>() {
                player1, player2, player3, large, player5, player6, player7, player8, player9
            };


            PlayMany(players);
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play noe another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                player1.Play(player2);
            }
        }
    }
}