using GameStore.Client.Models;

namespace GameStore.Client
{
    public static class GameClient
    {
        private static readonly List<Game> games = new()
        {
            new Game()
            {
                Id = 1,
                Name = "Street Fighter II",
                Genre = "Fighting",
                Price = 19.99,
                ReleaseDate = new DateTime(1991, 2, 1)
            },
            new Game()
            {
                Id = 2,
                Name = "Final Fantasy XIV",
                Genre = "Roleplain",
                Price = 59.99,
                ReleaseDate = new DateTime(2010, 9, 30)
            },
            new Game()
            {
                Id = 3,
                Name = "FIFA 23",
                Genre = "Sports",
                Price = 99.99,
                ReleaseDate = new DateTime(2022, 9, 27)
            }
        };

        public static Game[] GetGames()
        {
            return games.ToArray();
        }

        public static void AddGame(Game game)
        {
            game.Id = games.Count + 1;
            games.Add(game);
        }


        public static Game GetGame(int id)
        {
            return games.Find(x => x.Id == id) ?? throw new Exception("Couldn't find game!");
        }

        public static void UpdateGame(Game game)
        {
            var oldGame = games.Find(x => x.Id == game.Id) ?? throw new Exception("Couldn't find game to update");
            oldGame.Name = game.Name;
            oldGame.Genre = game.Genre;
            oldGame.Price = game.Price;
            oldGame.ReleaseDate = game.ReleaseDate;
        }



    }
}
