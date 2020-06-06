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
		public Tile stoodOnTile = new Floor();
		

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
						currentRoom[i, j] = new Wall();
					}
					else
					{
						currentRoom[i, j] = new Floor();
					}
				}
			}

			currentRoom[Game.player.Position[0], Game.player.Position[1]] = Game.player;

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
