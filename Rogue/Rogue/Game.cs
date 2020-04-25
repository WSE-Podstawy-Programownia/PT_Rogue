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
		public static Tile[,] Room;

		static void Main(string[] args)
		{
			OperateMenu();

		}

		private static void OperateMenu() 
		{
			Console.WriteLine("Welcome to the Rogue Game");
			Console.WriteLine("1 - Start New Game\n" +
							  "2 - View Game Information\n" +
							  "3 - Quit Game);");

			if (Console.ReadKey(true).Key == ConsoleKey.D1)
			{
				Console.WriteLine("Booting new game");

				Room = GenerateRoomTiles();

				DrawMap(Room);
			}


		}

		private static Tile[ , ] GenerateRoomTiles()
		{
			Tile[,] currentRoom = new Tile[15, 15];

			for (int i = 0; i < currentRoom.GetLength(0); i++)
			{
				for (int j = 0; j < currentRoom.GetLength(1); j++)
				{
					if (
					   i == 0 
					|| i == currentRoom.GetLength(0) - 1
					|| j == 0
					|| j == currentRoom.GetLength(1) - 1
					   )
					{
						currentRoom[i, j] = new Wall(); 
					} 
					else
					{
						currentRoom[i, j] = new Floor();
					}
				}
			}

			return currentRoom;

		}

		private static void DrawMap(Tile[,] Room)
		{
			for (int i = 0; i < Room.GetLength(0); i++)
			{ 
				for (int j = 0; j < Room.GetLength(0); j++)
				{
					Console.Write(Room[i, j].Character);
				}
				Console.WriteLine();
			}
		}
		

	}
}
