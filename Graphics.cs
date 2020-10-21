using Godot;
using System;
using System.Collections.Generic;

public class Graphics : Node2D{
	public List<Byte> viewport = new List<Byte>{0, 1, 2, 3, 4, 5, 6, 7, 8};
	static Vector2 pos;
	static byte viewid;
	
	public class inis{
		public Vector2 unit;
		public byte lum; //distance
		public inis(int x, int y, byte lum){
			unit = new Vector2(x, y);
			this.lum = lum;
		}
	}
	//as viewed from the top right quarter (+, +)
	//refering to rtype and horizontal & vertical
	static inis[] fver = {
		new inis(0, 1, 10),
		new inis(0, 2, 9),
		new inis(0, 3, 8),
		new inis(0, 4, 7),
		new inis(0, 5, 6),
		new inis(0, 6, 5),
		new inis(-1, 7, 4),
		new inis(0, 7, 4),
		new inis(1, 7, 4),
		new inis(-1, 8, 3),
		new inis(0, 8, 3),
		new inis(1, 8, 3),
		new inis(-1, 9, 2),
		new inis(0, 9, 2),
		new inis(1, 9, 2),
		new inis(-2, 10, 1),
		new inis(-1, 10, 1),
		new inis(0, 10, 1),
		new inis(1, 10, 1),
		new inis(2, 10, 1)
	};
	static inis[] sver = {
		new inis(0, 1, 10),
		new inis(1, 2, 9),
		new inis(1, 3, 8),
		new inis(1, 4, 7),
		new inis(1, 5, 6),
		new inis(2, 5, 6),
		new inis(1, 6, 5),
		new inis(2, 6, 5),
		new inis(2, 7, 4),
		new inis(3, 7, 4),
		new inis(2, 8, 3),
		new inis(3, 8, 3),
		new inis(2, 9, 2),
		new inis(3, 9, 2),
		new inis(4, 9, 2),
		new inis(3, 10, 1),
		new inis(4, 10, 1)
	};
	static inis[] aver = {
		new inis(1, 1, 10),
		new inis(2, 3, 8),
		new inis(2, 4, 7),
		new inis(3, 4, 7),
		new inis(3, 5, 6),
		new inis(4, 5, 6),
		new inis(3, 6, 5),
		new inis(4, 6, 5),
		new inis(5, 6, 5),
		new inis(4, 7, 4),
		new inis(5, 7, 4),
		new inis(4, 8, 3),
		new inis(5, 8, 3),
		new inis(6, 8, 3),
		new inis(5, 9, 2),
		new inis(6, 9, 2),
		new inis(7, 9, 2),
		new inis(5, 10, 1),
		new inis(6, 10, 1),
		new inis(7, 10, 1)
	};
	static inis[] c = {
		new inis(1, 1, 10),
		new inis(2, 2, 9),
		new inis(3, 3, 8),
		new inis(4, 4, 7),
		new inis(5, 5, 6),
		new inis(6, 6, 5),
		new inis(6, 7, 4),
		new inis(7, 7, 4),
		new inis(7, 6, 4),
		new inis(7, 8, 3),
		new inis(8, 8, 3),
		new inis(8, 7, 3),
		new inis(8, 9, 2),
		new inis(9, 9, 2),
		new inis(9, 8, 2),
		new inis(8, 10, 1),
		new inis(9, 10, 1),
		new inis(10, 10, 1),
		new inis(10, 9, 1),
		new inis(10, 8, 1)
	};
	public static void interpret(int angle, byte viewidt, Vector2 posi){ //angle*15 degrees
		viewid = viewidt;
		pos = posi;
		switch(angle){
			case 0:
				search(fver, true, true, false);
				return;
			case 6:
				search(fver, true, true, true);
				return;
			case 12:
				search(fver, true, false, false);
				return;
			case 18:
				search(fver, true, false, true);
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
				search(sver, xplus, yplus, true);
				break;
			case 2:
				search(aver, xplus, yplus, true);
				break;
			case 3:
				search(c, xplus, yplus, true);
				break;
			case 4:
				search(aver, xplus, yplus, false);
				break;
			case 5:
				search(sver, xplus, yplus, false);
				break;
		}
	}
	static void search(inis[] iniss, bool Xplus, bool Yplus, bool sxy){
		foreach(inis e in iniss){
			Vector2 t = e.unit+pos;
			t.x = Xplus ? t.x : 0-t.x;
			t.y = Yplus ? t.y : 0-t.y;
			t = new Vector2(t.y, t.x);
			try{
				if(Player.map[(int)t.x, (int)t.y] != Player.Object.empty){
					render(Player.map[(int)t.x, (int)t.y], e.lum);
					return;
				}
			}catch(System.IndexOutOfRangeException){
				render(Player.map[(int)t.x, (int)t.y], e.lum);
				return;
			}
		}
		GetChild<ColorRect>(viewid).Color = Color.Color8(255, 255, 255, 255);
	}
	static void render(Player.Object type, byte lum){
		lum = Convert.ToByte(25.5*lum);
		ColorRect pixel = GetChild<ColorRect>(viewid);
		switch(type){
			case Player.Object.ammos:
				pixel.Color = Color.Color8(255, 255, 0, lum);
				break;
			case Player.Object.heal:
				pixel.Color = Color.Color8(255, 128, 0, lum);
				break;
			case Player.Object.wall:
				pixel.Color = Color.Color8(0, 0, 255, lum);
				break;
			case Player.Object.spawner:
				pixel.Color = Color.Color8(255, 255, 255, lum);
				break;
			case Player.Object.enemy:
				pixel.Color = Color.Color8(0, 255, 0, lum);
				break;
			case Player.Object.euser:
				pixel.Color = Color.Color8(0, 255, 0, lum);
				break;
		}
	}
	public override void _Process(float delta){
        for(int i = 0; i < viewport.Count-1; i++) {
			interpret(i, viewport[i], );
		}
	}
}
