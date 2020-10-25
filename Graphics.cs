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
	public static obj[] sight = new obj[24];
	static Vector2 pos;
	byte starton = 0;
	//searches through cordiantes to fine if theres objects in the way
	//as viewed from the top right quarter (+, +)
	//refering to rtype and horizontal & vertical
	static Vector2[] fver = {
		new Vector2(0, 1),
		new Vector2(0, 2),
		new Vector2(0, 3),
		new Vector2(0, 4),
		new Vector2(0, 5),
		new Vector2(0, 6),
		new Vector2(-1, 7),
		new Vector2(0, 7),
		new Vector2(1, 7),
		new Vector2(-1, 8),
		new Vector2(0, 8),
		new Vector2(1, 8),
		new Vector2(-1, 9),
		new Vector2(0, 9),
		new Vector2(1, 9),
		new Vector2(-2, 10),
		new Vector2(-1, 10),
		new Vector2(0, 10),
		new Vector2(1, 10),
		new Vector2(2, 10)
	};
	static Vector2[] sver = {
		new Vector2(0, 1),
		new Vector2(1, 2),
		new Vector2(1, 3),
		new Vector2(1, 4),
		new Vector2(1, 5),
		new Vector2(2, 5),
		new Vector2(1, 6),
		new Vector2(2, 6),
		new Vector2(2, 7),
		new Vector2(3, 7),
		new Vector2(2, 8),
		new Vector2(3, 8),
		new Vector2(2, 9),
		new Vector2(3, 9),
		new Vector2(4, 9),
		new Vector2(3, 10),
		new Vector2(4, 10)
	};
	static Vector2[] aver = {
		new Vector2(1, 1),
		new Vector2(1, 2),
		new Vector2(2, 3),
		new Vector2(2, 4),
		new Vector2(3, 4),
		new Vector2(3, 5),
		new Vector2(4, 5),
		new Vector2(3, 6),
		new Vector2(4, 6),
		new Vector2(5, 6),
		new Vector2(4, 7),
		new Vector2(5, 7),
		new Vector2(4, 8),
		new Vector2(5, 8),
		new Vector2(6, 8),
		new Vector2(5, 9),
		new Vector2(6, 9),
		new Vector2(7, 9),
		new Vector2(5, 10),
		new Vector2(6, 10),
		new Vector2(7, 10)
	};
	static Vector2[] c = {
		new Vector2(1, 1),
		new Vector2(2, 2),
		new Vector2(3, 3),
		new Vector2(4, 4),
		new Vector2(5, 5),
		new Vector2(6, 6),
		new Vector2(6, 7),
		new Vector2(7, 7),
		new Vector2(7, 6),
		new Vector2(7, 8),
		new Vector2(8, 8),
		new Vector2(8, 7),
		new Vector2(8, 9),
		new Vector2(9, 9),
		new Vector2(9, 8),
		new Vector2(8, 10),
		new Vector2(9, 10),
		new Vector2(10, 10),
		new Vector2(10, 9),
		new Vector2(10, 8)
	};
	public static void interpret(byte angle){ //angle*15 degrees
		bool xplus = false;
		bool yplus = false;
		switch(angle/6){
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
		switch(angle%6){
			case 0:
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
				break;
			case 1:
				search(angle, sver, xplus, yplus, true);
				return;
			case 2:
				search(angle, aver, xplus, yplus, true);
				return;
			case 3:
				search(angle, c, xplus, yplus, true);
				return;
			case 4:
				search(angle, aver, xplus, yplus, false);
				return;
			case 5:
				search(angle, sver, xplus, yplus, false);
				return;
		}
	}
	static void search(byte angle, Vector2[] Drivers, bool Xplus, bool Yplus, bool sxy){
		foreach(Driver e in Drivers){
			Vector2 t = e+pos;
			t.x = Xplus ? t.x : 0-t.x;
			t.y = Yplus ? t.y : 0-t.y;
			t = sxy ? new Vector2(t.y, t.x) : t;
			try{
				if(Player.map[(int)t.x, (int)t.y] != Player.Object.empty){
					sight[angle] = new obj(Player.map[(int)t.x, (int)t.y], Convert.ToByte(25.5*(11-Math.Max(t.x, t.y)))); //lum = 11-mathmax
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
			GD.Print(Graphics.sight[4].type+" "+Graphics.sight[3].bright);
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
				case Player.Object.empty:
					pixel.Color = Color.Color8(0, 0, 0, 0);
					break;
			}
		}catch(NullReferenceException){}
	}
}
