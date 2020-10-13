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
	driver[] fhor = {};
	driver[] fver = {};
	driver[] shor = {};
	driver[] sver = {};
	driver[] ahor = {};
	driver[] aver = {};
	driver[] c = {};
}
