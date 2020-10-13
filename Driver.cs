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
	Vector2 sxy(Vector2 start){ //switch x and y
		return new Vector2(start.y, start.x);
	}
	//as viewed from the top right quarter (+, +)
	//refering to rtype and horizontal & vertical
	driver[] fver = {
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
	driver[] sver = {
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
		new driver(4, 10, 1)
	};
	driver[] aver = {
		new driver(1, 1, 10),
		new driver(2, 3, 8),
		new driver(2, 4, 7),
		new driver(3, 4, 7),
		new driver(3, 5, 6),
		new driver(4, 5, 6),
		new driver(3, 6, 5),
		new driver(4, 6, 5),
		new driver(5, 6, 5),
		new driver(4, 7, 4),
		new driver(5, 7, 4),
		new driver(4, 8, 3),
		new driver(5, 8, 3),
		new driver(6, 8, 3),
		new driver(5, 9, 2),
		new driver(6, 9, 2),
		new driver(7, 9, 2),
		new driver(5, 10, 1),
		new driver(6, 10, 1),
		new driver(7, 10, 1)
	};
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
	public void interpret(int angle){ //angle*15 degrees
		switch(angle){
			case 0:
				render(fver, true, true, false);
				break;
			case 1:
				render(sver, true, true, false);
				break;
			case 2:
				render(aver, true, true, false);
				break;
			case 3:
				render(c, true, true, false);
				break;
			case 4:
				render(aver, true, true, true);
				break;
			case 5:
				render(sver, true, true, true);
				break;

			case 6:
				render(fver, true, true, true);
				break;
			case 7:
				render(sver, true, false, false);
				break;
			case 8:
				render(aver, true, false, false);
				break;
			case 9:
				render(c, true, false, false);
				break;
			case 10:
				render(aver, true, false, true);
				break;
			case 11:
				render(sver, true, false, true);
				break;

			case 12:
				render(fver, true, false, false);
				break;
			case 13:
				render(sver, false, false, false);
				break;
			case 14:
				render(aver, false, false, false);
				break;
			case 15:
				render(c, false, false, false);
				break;
			case 16:
				render(aver, false, false, true);
				break;
			case 17:
				render(sver, false, false, true);
				break;

			case 18:
				render(fver, true, false, true);
				break;
			case 19:
				render(sver, false, true, false);
				break;
			case 20:
				render(aver, false, true, false);
				break;
			case 21:
				render(c, false, true, false);
				break;
			case 22:
				render(aver, false, true, true);
				break;
			case 23:
				render(sver, false, true, true);
				break;
				
			default:
				GD.PrintErr("rendered default "+ angle);
				break;
		}
	}
	public void render(driver[] drivers, bool Xplus, bool Yplus, bool sxy){
		
	}
}
