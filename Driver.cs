using Godot;
using System;

public class Driver : Node{
	public string tilename;
	Vector2 unit;
	int dis; //distance
	public Driver( int x, int y, int dis){
		unit = new Vector2(x, y);
		this.dis = dis;
	}
	Vector2 sxy(Vector2 start){ //switch x and y
		return new Vector2(start.y, start.x);
	}
	//as viewed from the top right quarter (+, +)
	//refering to rtype and horizontal & vertical
	Driver[] fver = {
		new Driver(0, 1, 10),
		new Driver(0, 2, 9),
		new Driver(0, 3, 8),
		new Driver(0, 4, 7),
		new Driver(0, 5, 6),
		new Driver(0, 6, 5),
		new Driver(-1, 7, 4),
		new Driver(0, 7, 4),
		new Driver(1, 7, 4),
		new Driver(-1, 8, 3),
		new Driver(0, 8, 3),
		new Driver(1, 8, 3),
		new Driver(-1, 9, 2),
		new Driver(0, 9, 2),
		new Driver(1, 9, 2),
		new Driver(-2, 10, 1),
		new Driver(-1, 10, 1),
		new Driver(0, 10, 1),
		new Driver(1, 10, 1),
		new Driver(2, 10, 1)
	};
	Driver[] sver = {
		new Driver(0, 1, 10),
		new Driver(1, 2, 9),
		new Driver(1, 3, 8),
		new Driver(1, 4, 7),
		new Driver(1, 5, 6),
		new Driver(2, 5, 6),
		new Driver(1, 6, 5),
		new Driver(2, 6, 5),
		new Driver(2, 7, 4),
		new Driver(3, 7, 4),
		new Driver(2, 8, 3),
		new Driver(3, 8, 3),
		new Driver(2, 9, 2),
		new Driver(3, 9, 2),
		new Driver(4, 9, 2),
		new Driver(3, 10, 1),
		new Driver(4, 10, 1)
	};
	Driver[] aver = {
		new Driver(1, 1, 10),
		new Driver(2, 3, 8),
		new Driver(2, 4, 7),
		new Driver(3, 4, 7),
		new Driver(3, 5, 6),
		new Driver(4, 5, 6),
		new Driver(3, 6, 5),
		new Driver(4, 6, 5),
		new Driver(5, 6, 5),
		new Driver(4, 7, 4),
		new Driver(5, 7, 4),
		new Driver(4, 8, 3),
		new Driver(5, 8, 3),
		new Driver(6, 8, 3),
		new Driver(5, 9, 2),
		new Driver(6, 9, 2),
		new Driver(7, 9, 2),
		new Driver(5, 10, 1),
		new Driver(6, 10, 1),
		new Driver(7, 10, 1)
	};
	Driver[] c = {
		new Driver(1, 1, 10),
		new Driver(2, 2, 9),
		new Driver(3, 3, 8),
		new Driver(4, 4, 7),
		new Driver(5, 5, 6),
		new Driver(6, 6, 5),
		new Driver(6, 7, 4),
		new Driver(7, 7, 4),
		new Driver(7, 6, 4),
		new Driver(7, 8, 3),
		new Driver(8, 8, 3),
		new Driver(8, 7, 3),
		new Driver(8, 9, 2),
		new Driver(9, 9, 2),
		new Driver(9, 8, 2),
		new Driver(8, 10, 1),
		new Driver(9, 10, 1),
		new Driver(10, 10, 1),
		new Driver(10, 9, 1),
		new Driver(10, 8, 1)
	};
	public void interpret(int angle){ //angle*15 degrees
		switch(angle){
			case 0:
				render(fver, true, true, false);
				return;
			case 6:
				render(fver, true, true, false);
				return;
			case 12:
				render(fver, true, true, false);
				return;
			case 18:
				render(fver, true, true, false);
				return;
		}
		bool xplus = false;
		bool yplus = false;
		switch(angle/4){
			case 0:
				xplus = true; yplus = true;
				break;
			case 1:
				xplus = true; yplus = false;
				break;
			case 2:
				xplus = false; yplus = false;
				break;
			case 3:
				xplus = false; yplus = true;
				break;
		}
		switch(angle/6){
			case 1:
				render(sver, xplus, yplus, true);
				break;
			case 2:
				render(aver, xplus, yplus, true);
				break;
			case 3:
				render(c, xplus, yplus, true);
				break;
			case 4:
				render(aver, xplus, yplus, false);
				break;
			case 5:
				render(sver, xplus, yplus, false);
				break;
		}
	}
	public void render(Driver[] Drivers, bool Xplus, bool Yplus, bool sxy){
		foreach(Driver e in Drivers){
			Vector2 t = e.unit;
			t.x = Xplus ? t.x : 0-t.x;
			t.y = Yplus ? t.y : 0-t.y;
			if(sxy){
				int temp = t.x;
				t.x = t.y
			}
			if(Player.map[])
		}
	}
}
