using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
MVP
Jest plansza
da sie poruszac
na planszy sa wrogowie ktorzy też się ruszają
2 pokoje połaczone korytarzem
postac ma 1 statysyke - zycie
da sie ja zabic
 * 
 */


namespace Rogue
{
	class Game
	{
		public static Player player = new Player();
		public static Map map;
		public static List<Enemy> Enemies = new List<Enemy>();

		public static bool GameOver { get; set; } = false;

		static void Main(string[] args)
		{
			OperateMenu();
		}

		private static void OperateMenu() 
		{
			Console.WriteLine("Welcome to the Rogue Game");
			Console.WriteLine("1 - Start New Game\n" +
							  "2 - View Game Information\n" +
							  "3 - Quit Game");

			if (Console.ReadKey(true).Key == ConsoleKey.D1)
			{
				Console.WriteLine("Booting new game");

				map = new Map();
				RunGameLoop();

			}
		}

		private static void RunGameLoop()
		{
			while (!GameOver)
			{
				player.HandlePlayerInput();

				foreach (Enemy enemy in Enemies)
				{
					enemy.AIBehaviour();
				}

				map.DrawMap(map.Room);
			}

			Console.WriteLine("You were defeated. Now the evil Necromancer will rule the world. GAME OVER!");
		}



	}
}
