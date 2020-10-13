using Godot;
using System;

public class Driver : Node
{
    public class driver {
		public Vector2 unit;
		public int dis; //distance
		public driver( int x, int y, int dis){
			unit = new Vector2(x, y);
			this.dis = dis;
		}
	}
	//as viewed from the top right quarter (+, +)
	//refering to rtype and horizontal & vertical
	driver[] fhor = {
		new driver(0, 1, 10),
		new driver(0, 2, 9),
		new driver(0, 3, 8),
		new driver(0, 4, 7),
		new driver(0, 5, 6),
		new driver(0, 6, 5),
		new driver(-1, 7, 4),
		new driver(0, 7, 4),
		new driver(1, 7, 4),
		new driver(-1, 8, 3),
		new driver(0, 8, 3),
		new driver(1, 8, 3),
		new driver(-1, 9, 2),
		new driver(0, 9, 2),
		new driver(1, 9, 2),
		new driver(-2, 10, 1),
		new driver(-1, 10, 1),
		new driver(0, 10, 1),
		new driver(1, 10, 1),
		new driver(2, 10, 1)
		};
	driver[] fver = {
		new driver(1, 0, 10),
		new driver(2, 0, 9),
		new driver(3, 0, 8),
		new driver(4, 0, 7),
		new driver(5, 0, 6),
		new driver(6, 0, 5),
		new driver(7, -1, 4),
		new driver(7, 0, 4),
		new driver(7, 1, 4),
		new driver(8, -1, 3),
		new driver(8, 0, 3),
		new driver(8, 1, 3),
		new driver(9, -1, 2),
		new driver(9, 0, 2),
		new driver(9, 1, 2),
		new driver(10, -2, 1),
		new driver(10, -1, 1),
		new driver(10, 0, 1),
		new driver(10, 1, 1),
		new driver(10, 2, 1)
	};
	driver[] shor = {
		new driver(0, 1, 10),
		new driver(1, 2, 9),
		new driver(1, 3, 8),
		new driver(1, 4, 7),
		new driver(1, 5, 6),
		new driver(2, 5, 6),
		new driver(1, 6, 5),
		new driver(2, 6, 5),
		new driver(2, 7, 4),
		new driver(3, 7, 4),
		new driver(2, 8, 3),
		new driver(3, 8, 3),
		new driver(2, 9, 2),
		new driver(3, 9, 2),
		new driver(4, 9, 2),
		new driver(3, 10, 1),
		new driver(4, 10, 1),
	};
	driver[] sver = {
		new driver(1, 0, 10),
		new driver(2, 1, 9),
		new driver(3, 1, 8),
		new driver(4, 1, 7),
		new driver(5, 1, 6),
		new driver(5, 2, 6),
		new driver(6, 1, 5),
		new driver(6, 2, 5),
		new driver(7, 2, 4),
		new driver(7, 3, 4),
		new driver(8, 2, 3),
		new driver(8, 3, 3),
		new driver(9, 2, 2),
		new driver(9, 3, 2),
		new driver(9, 4, 2),
		new driver(10, 3, 1),
		new driver(10, 4, 1),
	};
	driver[] ahor = {};
	driver[] aver = {};
	driver[] c = {
		new driver(1, 1, 10),
		new driver(2, 2, 9),
		new driver(3, 3, 8),
		new driver(4, 4, 7),
		new driver(5, 5, 6),
		new driver(6, 6, 5),
		new driver(6, 7, 4),
		new driver(7, 7, 4),
		new driver(7, 6, 4),
		new driver(7, 8, 3),
		new driver(8, 8, 3),
		new driver(8, 7, 3),
		new driver(8, 9, 2),
		new driver(9, 9, 2),
		new driver(9, 8, 2),
		new driver(8, 10, 1),
		new driver(9, 10, 1),
		new driver(10, 10, 1),
		new driver(10, 9, 1),
		new driver(10, 8, 1)
	};
}
