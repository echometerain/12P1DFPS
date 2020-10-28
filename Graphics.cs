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
				search(angle, 0, true, xplus, yplus);
				break;
			case 4:
				search(angle, 2, xplus, yplus, true);
				break;
			case 5:
				search(angle, 1, xplus, yplus, true);
				break;
			default:
				search(angle, Convert.ToByte(angle%6), xplus, yplus, false);
				break;
		}
	}
	static void search(byte angle, byte arrId, bool Xplus, bool Yplus, bool sxy){
		foreach(Vector2 e in Drivers.arr[arrId]){
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
					sight[angle] = new obj(Player.map[(int)t.x, (int)t.y], Convert.ToByte(10*(16-Math.Max(e.x, e.y)))); //lum = 11-mathmax
					return;
				}
			}catch(System.IndexOutOfRangeException){
				byte temp = e.x > e.y ? Convert.ToByte(25.5*(11-e.x)) : Convert.ToByte(10*(16-e.y));
				sight[angle] = new obj(Player.Object.wall, temp);
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
		for(int i = starton; i < starton+10; i++){
			render(GetChild<ColorRect>(temp), (i % 24));
			temp++;
		}
	}
	static void render(ColorRect pixel, int rnum){ //rnum = the index in sight (render number)
		if(sight[rnum].bright == 16){sight[rnum].bright = 15;}
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
