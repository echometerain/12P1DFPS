using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public class Graphics : Node2D{
	public class obj{
		public Player.Object type;
		public byte bright; //luminosity
		public obj(Player.Object type, byte bright){
			this.type = type;
			this.bright = bright;
		}
	}
	public class Driver{//gets the light distance from pos(lum) and vector distance(unit)
		public Vector2 unit;
		public byte lum; //distance
		public Driver(int x, int y, byte lum){
			unit = new Vector2(x, y);
			this.lum = lum;
		}
	}
	public static obj[] sight = new obj[24];
	static Vector2 pos;
	byte starton = 12;
	//searches through cordiantes to fine if theres objects in the way
	//as viewed from the top right quarter (+, +)
	//refering to rtype and horizontal & vertical
	static Driver[] fver = {
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
	static Driver[] sver = {
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
	static Driver[] aver = {
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
	static Driver[] c = {
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
	public static void interpret(byte angle){ //angle*15 degrees
		switch(angle){
			case 0:
				search(angle, fver, true, true, false);
				return;
			case 6:
				search(angle, fver, true, true, true);
				return;
			case 12:
				search(angle, fver, true, false, false);
				return;
			case 18:
				search(angle, fver, true, false, true);
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
				search(angle, sver, xplus, yplus, true);
				break;
			case 2:
				search(angle, aver, xplus, yplus, true);
				break;
			case 3:
				search(angle, c, xplus, yplus, true);
				break;
			case 4:
				search(angle, aver, xplus, yplus, false);
				break;
			case 5:
				search(angle, sver, xplus, yplus, false);
				break;
		}
	}
	static void search(byte angle, Driver[] Drivers, bool Xplus, bool Yplus, bool sxy){
		foreach(Driver e in Drivers){
			Vector2 t = e.unit+pos;
			t.x = Xplus ? t.x : 0-t.x;
			t.y = Yplus ? t.y : 0-t.y;
			t = new Vector2(t.y, t.x);
			try{
				if(Player.map[(int)t.x, (int)t.y] != Player.Object.empty){
					sight[angle] = new obj(Player.map[(int)t.x, (int)t.y], Convert.ToByte(25.5*e.lum));
					return;
				}
			}catch(System.IndexOutOfRangeException){
				sight[angle] = new obj(Player.Object.wall, Convert.ToByte(25.5*e.lum));
				return;
			}
		}
		sight[angle] = new obj(Player.Object.empty, 0);
	}
	public static void moved(){
		pos = Player.Pos;
		for(byte i = 0; i <= 23; i++) {
			interpret(i);
		}
	}
	public override void _Process(float delta){
		byte temp = 0;
		for(int i = starton; i < starton+9; i++){
			render(GetChild<ColorRect>(temp), (i % 24));
			temp++;
		}
		try{
			GD.Print(Graphics.sight[0].type+" "+Graphics.sight[0].bright);
		}catch(NullReferenceException){GD.Print("nullreference");}
	}
	static void render(ColorRect pixel, int rnum){ //rnum = the index in sight (render number)
		try{
			switch(sight[rnum].type){
            case Player.Object.ammos:
                pixel.Color = Color.Color8(255, 255, 0, sight[rnum].bright);
                break;
            case Player.Object.heal:
                pixel.Color = Color.Color8(255, 128, 0, sight[rnum].bright);
                break;
            case Player.Object.wall:
                pixel.Color = Color.Color8(0, 0, 255, sight[rnum].bright);
                break;
            case Player.Object.spawner:
                pixel.Color = Color.Color8(255, 255, 255, sight[rnum].bright);
                break;
            case Player.Object.enemy:
                pixel.Color = Color.Color8(0, 255, 0, sight[rnum].bright);
                break;
            case Player.Object.euser:
                pixel.Color = Color.Color8(0, 255, 0, sight[rnum].bright);
                break;
			}
		}catch(NullReferenceException){}
	}
}
