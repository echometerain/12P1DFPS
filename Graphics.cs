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
	byte starton = 20;
	//searches through cordiantes to find if theres objects in the way
	//as viewed from the top right quarter (+, +)
	//refering to 0:front, 1:side, 2:annoying, and 3:corner.
	static Vector2[][] Drivers = new Vector2[4][]{
		new Vector2[]{
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
		},
		new Vector2[]{
			new Vector2(0, 1),
			new Vector2(1, 2),
			new Vector2(1, 3),
			new Vector2(1, 4),
			new Vector2(1, 5),
			new Vector2(2, 5),
			new Vector2(1, 6),
			new Vector2(2, 6),
			new Vector2(3, 6),
			new Vector2(2, 7),
			new Vector2(3, 7),
			new Vector2(2, 8),
			new Vector2(3, 8),
			new Vector2(4, 8),
			new Vector2(2, 9),
			new Vector2(3, 9),
			new Vector2(4, 9),
			new Vector2(3, 10),
			new Vector2(4, 10)
		},
		new Vector2[]{
			new Vector2(1, 1),
			new Vector2(1, 2),
			new Vector2(2, 3),
			new Vector2(2, 4),
			new Vector2(3, 4),
			new Vector2(3, 5),
			new Vector2(4, 5),
			new Vector2(4, 6),
			new Vector2(5, 6),
			new Vector2(4, 7),
			new Vector2(5, 7),
			new Vector2(5, 8),
			new Vector2(6, 8),
			new Vector2(5, 9),
			new Vector2(6, 9),
			new Vector2(7, 9),
			new Vector2(5, 10),
			new Vector2(6, 10),
			new Vector2(7, 10)
		},
		new Vector2[]{
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
		}
	};
	public static void interpret(byte angle){ //angle*15 degrees
		bool xplus = false;
		bool yplus = false;
		switch(angle/6){
			case 0:
				xplus = true; yplus = true;
				if(angle%6 == 0)yplus = false;
				break;
			case 1:
				xplus = true; yplus = false;
				if(angle%6 == 0)yplus = true;
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
				search(angle, Drivers[0], true, xplus, yplus);
				break;
			case 4:
				search(angle, Drivers[2], xplus, yplus, false);
				break;
			case 5:
				search(angle, Drivers[1], xplus, yplus, false);
				break;
			default:
				search(angle, Drivers[angle%6], xplus, yplus, true);
				break;
		}
	}
	static void search(byte angle, Vector2[] Vangle, bool Xplus, bool Yplus, bool sxy){
		foreach(Vector2 e in Vangle){
			Vector2 t = e;
			if(!Xplus){t.x = 0-e.x;}
			if(!Yplus){t.y = 0-e.y;}
			t += pos;
			if(sxy){
				Vector2 tem = new Vector2(t.y, t.x);
				t = tem;
			}
			try{
				if(Player.map[(int)t.x, (int)t.y] != Player.Object.empty){
					sight[angle] = new obj(Player.map[(int)t.x, (int)t.y], Convert.ToByte(25.5*(11-Math.Max(e.x, e.y)))); //lum = 11-mathmax
					return;
				}
			}catch(System.IndexOutOfRangeException){
				byte temp = e.x > e.y ? Convert.ToByte(25.5*(11-e.x)) : Convert.ToByte(25.5*(11-e.y));
				sight[angle] = new obj(Player.Object.wall, temp);
				GD.Print(angle + " " + t.x +" "+ t.y);
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
			GD.Print(Graphics.sight[8].type+" "+Graphics.sight[8].bright);
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
