using Godot;
using System;
using System.Collections.Generic;
using System.Drawing;
//in this project, x comes beffore y
public class Player : Node2D{
	int WorldX = 0;
	int WorldY = 0;
	public static Vector2 Pos = new Vector2(0, 0); //player position
	public byte Life = 255;
	public byte Ammo = 255;
	public byte Weapon = 255;
	public static Lib.obj[,] map;
	Dictionary<Vector2, Lib.obj> entities = new Dictionary<Vector2, Lib.obj>();
	public override void _Ready(){
		String dirpath = System.Environment.GetEnvironmentVariable("LOCALAPPDATA")+@"\12P1DFPS\level.bmp";
		Bitmap image = new Bitmap(dirpath);
		WorldX = image.Width;
		WorldY = image.Height;
		map = new Lib.obj[WorldX, WorldY];
		for(int i = 0; i < WorldX; i++){
			for(int ii = 0; ii < WorldY; ii++){
				System.Drawing.Color t = image.GetPixel(i, ii);
				Godot.Color tc = Godot.Color.Color8(t.R, t.G, t.B, 0);
				if(Lib.c2obj.ContainsKey(tc)){
					Lib.obj temp;
					Lib.c2obj.TryGetValue(tc, out temp);
					if((byte)temp < 5){
						addObj(temp, i, ii);
					}
					else if(temp == Lib.obj.spawn){
						Pos = new Vector2(i, ii);
					}
					else if((byte)temp > 5){
						map[i, ii] = temp;
					}
				}
				else{
					map[i, ii] = Lib.obj.empty;
				}
			}
		}
		Graphics.reload();
	}
	public void addObj(Lib.obj thing, int x, int y){
		entities.Add(new Vector2(x, y), thing);
		map[x, y] = thing;
	}
	public override void _Process(float delta){
		Vector2 tempos = Pos;
		tempos.x += Input.IsActionPressed("ui_left") ? -1 : 0;
		tempos.x += Input.IsActionPressed("ui_right") ? 1 : 0;
		tempos.y += Input.IsActionPressed("ui_up") ? 1 : 0;
		tempos.y += Input.IsActionPressed("ui_down") ? -1 : 0;
		try{
			if((int)map[(int)tempos.x, (int)tempos.y] < 3 && !entities.ContainsKey(tempos)){
				Pos = tempos;
				Graphics.reload();
			}
		}catch(System.IndexOutOfRangeException){}
		GD.Print(Pos);
	}
}
