using Godot;
using System;

public class Driver : Node
{
    public class driver {
		public Vector2 unit;
		public int lum;
		public driver(int x, int y, int lum){
			unit = new Vector2(x, y);
			this.lum = lum;
		}
	}
<<<<<<< HEAD
	driver[] fhor = {};
=======
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
		
		};
>>>>>>> a462313bf5eb7a3504df5e30d3c18199659735d4
	driver[] fver = {};
	driver[] shor = {};
	driver[] sver = {};
	driver[] ahor = {};
	driver[] aver = {};
	driver[] c = {};
}
