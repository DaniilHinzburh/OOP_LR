using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OOP_LR1
{
    class GameAccount
    {
        public string UserName;
        public int CurrentRating;
        public int GamesCount;
        public List<Game> gamelist = new List<Game>();



        public void WinGame(string opponentName)
        {
            Console.WriteLine("Перемога гравця:" + UserName + " проти: "+ opponentName+ ". Рейтинг гри "+ CurrentRating);
            CurrentRating++;
            Console.WriteLine("Новий рейтинг " + UserName + " : " + CurrentRating);
        }
        public void LoseGame(string opponentName)
        {
            Console.WriteLine("Перемога гравця:" + opponentName + " проти: " + UserName + ". Рейтинг гри " + CurrentRating);
            CurrentRating--;
            Console.WriteLine("Новий рейтинг " + UserName + " : " + CurrentRating);
        }
        public void GetStats(GameAccount GameAccount)
        {
            for (int i = 0; i < GameAccount.gamelist.Count; i++)
            {
                if (GameAccount.gamelist[i].Winner==GameAccount.UserName)
                {
                    Console.WriteLine("Гда виграна проти: "+ GameAccount.gamelist[i].Loser+". Індекс гри: "+ GameAccount.gamelist[i].index);
                    GameAccount.WinGame(GameAccount.gamelist[i].Loser);
                }
                if (GameAccount.gamelist[i].Loser == GameAccount.UserName)
                {
                    Console.WriteLine("Гда програна проти: " + GameAccount.gamelist[i].Winner + ". Індекс гри: " + GameAccount.gamelist[i].index);
                    GameAccount.LoseGame(GameAccount.gamelist[i].Winner);
                }
            }
        }
    }
    class Game
    {
        public string Winner;
        public string Loser;
        public int index;
    }
    class Program
    {
        public static void Main(string[] args)
        {
            
            int indexgame = 1;
            GameAccount Account1 = new GameAccount();
            Account1.UserName = "Dan";
            Account1.CurrentRating = 10;
            Account1.GamesCount = 0;
            GameAccount Account2 = new GameAccount();
            Account2.UserName = "Ilon";
            Account2.CurrentRating = 10;
            Account2.GamesCount = 0;

            Game game1 = new Game();
            game1.Winner = Account1.UserName;
            game1.Loser= Account2.UserName;
            game1.index = indexgame++;
            Account1.gamelist.Add(game1);
            Account2.gamelist.Add(game1);

            Game game2 = new Game();
            game2.Winner = Account2.UserName;
            game2.Loser = Account1.UserName;
            game2.index = indexgame++;
            Account1.gamelist.Add(game2);
            Account2.gamelist.Add(game1);

            Account1.GetStats(Account1);
        }
        
    }
}