using Godot;
using System;

public class head : Node
{
    public class driver {
		public Vector2 unit;
		public int lum;
		public void put(int y, int x, int lum){
			unit = new Vector2(y, x);
			this.lum = lum;
		}
	}
	const int WorldY = 21;
	const int WorldX = 21;
	Vector2 Pos = new Vector2(WorldX/2, WorldY/2); //player position
	byte Life = 255;
	byte Ammo = 255;
	byte Weapon = 255;
	//as viewed from the top right quarter (+, +)
	//refering to rtype and horizontal & vertical
	driver[] fhor = {};
	driver[] fver = {};
	driver[] shor = {};
	driver[] sver = {};
	driver[] ahor = {};
	driver[] aver = {};
	driver[] c = {};
}
