using System;
using System.Collections.Generic;
using System.Diagnostics;

 class GameAccount
{
    public string UserName;
    public double CurrentRating;
    public int GamesCount;
    public List<Game> gamelist = new();

    public virtual void WinGame(Game game, GameAccount opponentName, GameAccount me)
    {
        game.WinnerA = me;
        game.LoserA = opponentName;
        game.Winner = UserName;
        game.Loser = opponentName.UserName;
        gamelist.Add(game);
        opponentName.gamelist.Add(game);

        Console.Write("Перемога гравця:" + game.WinnerA.UserName + " проти: " + game.LoserA.UserName + ". Рейтинг гри: ");
        double RaitingGame = game.CounRatingGame();
        if (RaitingGame == -1)
        {
            Console.WriteLine(" ця гра була без рейтинга");
        }
        else
        {
            Console.WriteLine(RaitingGame);
        }
        game.PlaerRaiting();
        CurrentRating = Examination(CurrentRating);
        Console.WriteLine("Новий рейтинг " + game.WinnerA.UserName + " : " + game.WinnerA.CurrentRating + " Новий рейтинг: " + game.LoserA.UserName + " : " + game.LoserA.CurrentRating);

    }
    public virtual void LoseGame(Game game, GameAccount opponentName, GameAccount me)
    {
        game.WinnerA = opponentName;
        game.LoserA = me;
        game.Winner = opponentName.UserName;
        game.Loser = UserName;
        gamelist.Add(game);
        opponentName.gamelist.Add(game);

        Console.Write("Перемога гравця:" + game.WinnerA.UserName + " проти: " + game.LoserA.UserName + ". Рейтинг гри: " );
        double RaitingGame = game.CounRatingGame();
        if (RaitingGame == -1)
        {
            Console.WriteLine(" ця гра була без рейтинга");
        }
        else
        {
            Console.WriteLine(RaitingGame);
        }
        game.PlaerRaiting();
        CurrentRating = Examination(CurrentRating);
        Console.WriteLine("Новий рейтинг " + game.WinnerA.UserName + " : " + game.WinnerA.CurrentRating + " Новий рейтинг: " + game.LoserA.UserName + " : " + game.LoserA.CurrentRating);

    }
    private static double Examination(double CurrentRating)
    {
        if (CurrentRating < 1)
        {
            CurrentRating = 1;
        }
        return CurrentRating;
    }
    public virtual void GetStats(GameAccount GameAccount)
    {
        if (GameAccount.gamelist.Count==0)
        {
            Console.WriteLine(GameAccount.UserName+ " ще не зіграв жодної гри.");
        }
        else
        {
            for (int i = 0; i < GameAccount.gamelist.Count; i++)
            {
                Console.Write("Переможець: " + GameAccount.gamelist[i].Winner + " Програвший: " + GameAccount.gamelist[i].Loser + " Індекс гри: " + GameAccount.gamelist[i].index + " Рейтинг гри: " );
                double RaitingGame = GameAccount.gamelist[i].CounRatingGame();
                if (RaitingGame == -1)
                {
                    Console.WriteLine(" ця гра була без рейтинга");
                }
                else
                {
                    Console.WriteLine(RaitingGame);
                }
            }
        }
        
    }
}
class GameAccountNew : GameAccount //зменшує рейтинг на 0.5
{
    public override void LoseGame(Game game, GameAccount opponentName, GameAccount me)
    {
        CurrentRating += 0.5;
        base.LoseGame(game, opponentName,  me);
        
    }
}
class GameAccountPro : GameAccount //якщо йде серія перемог(2 та більше гри виграно підряд) рейтинг за виграш додається в х2 розмірі
{
    private int WinStreak=0;
    public override void WinGame(Game game, GameAccount opponentName, GameAccount me)
    {
        WinStreak++;
        if (WinStreak>=2)
        {
            CurrentRating++;
        }
        base.WinGame(game, opponentName , me);
    }
    public override void LoseGame(Game game, GameAccount opponentName, GameAccount me)
    {
        WinStreak = 0;
        base.LoseGame(game, opponentName,me);
    }
}
abstract class Game
{
    public GameAccount WinnerA;
    public GameAccount LoserA;
    public string Winner;
    public string Loser;
    public int index;
    public double Rating;



    public virtual double CounRatingGame()
    {
        Rating = (int)((WinnerA.CurrentRating + LoserA.CurrentRating)/2);
        return Rating;
        
    }
    public virtual void PlaerRaiting()
    {
        WinnerA.CurrentRating++;
        LoserA.CurrentRating--;
    }

}
class GameStandart : Game
{

}
class GameNoRating : Game // гра без рейтингу
{
    public GameNoRating()
    {
        Rating = -1;
    }
    public override double CounRatingGame()
    {   
        return -1;
        
    }
}
class GameSolo : Game // гра де програвший не втрачає рейтинг, а переможець підвищує рейтинг
{
    public override void PlaerRaiting()
    {
        base.PlaerRaiting();
        LoserA.CurrentRating++;
    }
}



    class Program
    {
        public static void Main()
        {
            int indexgame = 1;
            GameAccount account1 = new()
            {
                UserName = "Dan",
                CurrentRating = 10,
                GamesCount = 0
            };

            GameAccount account2 = new()
            {
                UserName = "Ilon",
                CurrentRating = 9,
                GamesCount = 0
            };

            GameStandart game1 = new()
            {  
                index = indexgame++
            };
            account1.WinGame(game1, account2, account1);
            
            GameSolo game2 = new()
            {
                index = indexgame++
            };
            account1.WinGame(game2, account2, account1);

            GameNoRating game3 = new()
            {
                index = indexgame++
            };
            account2.WinGame(game3, account1, account2);

            account1.GetStats(account1);
                

    }


    }

    



