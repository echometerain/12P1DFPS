using Godot;
using System;

public class Viewport : Node{
    public void scan(byte viewer, byte angle, Vector2 pos) => search(interpret(angle));
    void search(Driver[] Drivers, bool Xplus, bool Yplus, bool sxy){
		foreach(Driver e in Drivers){
			Vector2 t = e.unit+pos;
			t.x = Xplus ? t.x : 0-t.x;
			t.y = Yplus ? t.y : 0-t.y;
			t = new Vector2(t.y, t.x);
			try{
				if(Player.map[(int)t.x, (int)t.y] != Player.Object.empty){
					render(1, Player.map[(int)t.x, (int)t.y], e.lum);
					return;
				}
			}catch(System.IndexOutOfRangeException){
				render(1, Player.map[(int)t.x, (int)t.y], e.lum);
				return;
			}
		}
		GetChild<ColorRect>(1).Color = Color.Color8(255, 255, 255, 255);
	}
	void render(int viewer, Player.Object type, byte lum){
		lum = Convert.ToByte(25.5*lum);
		ColorRect pixel = GetChild<ColorRect>(viewer);
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
}