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

        public void WinGame(Game game, GameAccount opponentName)
        {
            game.Winner = UserName;
            game.Loser = opponentName.UserName;
            gamelist.Add(game);
            opponentName.gamelist.Add(game);
            game.Rating = (CurrentRating + opponentName.CurrentRating) / 2;
            Console.WriteLine("Перемога гравця:" + UserName + " проти: " + opponentName + ". Рейтинг гри " + (int)game.Rating);
            CurrentRating++;
            opponentName.CurrentRating--;
            Console.WriteLine("Новий рейтинг " + UserName + " : " + CurrentRating+ " Новий рейтинг " + opponentName.UserName + " : " + opponentName.CurrentRating);

        }
        public void LoseGame(Game game, GameAccount opponentName)
        {
            game.Winner = opponentName.UserName;
            game.Loser = UserName;
            game.Rating = (CurrentRating + opponentName.CurrentRating) / 2;
            Console.WriteLine("Перемога гравця:" + opponentName + " проти: " + UserName + ". Рейтинг гри " + (int)game.Rating);
            CurrentRating--;
            opponentName.CurrentRating++;
            CurrentRating = examination(CurrentRating);
            Console.WriteLine("Новий рейтинг " + UserName + " : " + CurrentRating + " Новий рейтинг " + opponentName.UserName + " : " + opponentName.CurrentRating);

        }
        private int examination(int CurrentRating)
        {
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
            return CurrentRating;
        }
        public void GetStats(GameAccount GameAccount)
        {
            for (int i = 0; i < GameAccount.gamelist.Count; i++)
            {
                
                    Console.WriteLine("Переможець: " + GameAccount.gamelist[i].Winner+ " Програвший: "+ GameAccount.gamelist[i].Loser + " Індекс гри: " + GameAccount.gamelist[i].index + " Рейтинг гри: " + GameAccount.gamelist[i].Rating);

                
                
            }
        }
    }
    class Game
    {
        public string Winner;
        public string Loser;
        public int index ;
        public double Rating;


        class Program
        {
            public static void Main(string[] args)
            {
                int indexgame = 1;
                GameAccount account1=new GameAccount();
                account1.UserName = "Dan";
                account1.CurrentRating = 10;
                account1.GamesCount = 0;

                GameAccount account2 = new GameAccount();
                account2.UserName = "Ilon";
                account2.CurrentRating = 9;
                account2.GamesCount = 0;

                Game game1 = new Game();
                game1.index = indexgame++; 

                account1.WinGame(game1, account2);

                Game game2 = new Game();
                game2.index = indexgame++;
                account2.WinGame(game2, account1);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(account1+" stats");

                account1.GetStats(account1);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(account2 + " stats");

                account1.GetStats(account2);
            }
         
           
        }
    }
}