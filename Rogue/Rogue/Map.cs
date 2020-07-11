using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{

	class Map
	{
		public Tile[,] Room;
		
		

		public Map()
		{
			Room = GenerateRoomTiles();
			DrawMap(Room);
		}


		private static Tile[,] GenerateRoomTiles()
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
						currentRoom[i, j] = new Wall(i, j);
					}
					else
					{
						currentRoom[i, j] = new Floor(i, j);
					}
				}
			}

			currentRoom[Game.player.PositionY, Game.player.PositionX] = Game.player;
			currentRoom[5, 5] = new Enemy(5, 5);
			currentRoom[10, 10] = new Enemy(10, 10);

			return currentRoom;

		}
	
		public void DrawMap(Tile[,] Room)
		{
			Console.Clear();

			for (int i = 0; i < Room.GetLength(0); i++)
			{
				for (int j = 0; j < Room.GetLength(1); j++)
				{
					Console.Write(Room[i, j].Character);
				}
				Console.WriteLine();
			}
		}





	}
}
