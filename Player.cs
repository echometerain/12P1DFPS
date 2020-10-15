using Godot;
using System;
using System.Collections.Generic;
using System.Collections;
//in this project, x comes beffore y
public class Player : Node2D{
	public ArrayList viewport = new ArrayList{0, 1, 2, 3, 4, 5, 6, 7, 8};
	const int WorldX = 21;
	const int WorldY = 21;
	public Vector2 Pos = new Vector2(WorldX/2, WorldY/2); //player position
	public byte Life = 255;
	public byte Ammo = 255;
	public byte Weapon = 255;
	public enum Object{
		empty, ammos, heal, wall, spawner, player, enemy, euser
	}
	public enum Rtype{
		front, side, corner, annoying
	}
	public Object[,] map = new Object[WorldX, WorldY];
	Dictionary<Vector2, Object> entities = new Dictionary<Vector2, Object>();
	public override void _Ready(){
		for(int i = 0; i < WorldX-1; i++) {
			for(int ii = 0; ii < WorldY-1; ii++) {
				map[i, ii] = Object.empty;
			}
		}
		entities.Add(new Vector2(12, 12), Object.enemy);
	}
	public void hud(){
		
	}
	public override void _Process(float delta){
		Vector2 tempos = Pos;
		tempos.x += Input.IsActionPressed("ui_left") ? -1 : 0;
		tempos.x += Input.IsActionPressed("ui_right") ? 1 : 0;
		tempos.y += Input.IsActionPressed("ui_up") ? 1 : 0;
		tempos.y += Input.IsActionPressed("ui_down") ? -1 : 0;
		try{
			if(map[(int)tempos.x, (int)tempos.y] < 3 && !entities.ContainsKey(tempos)){
				Pos = tempos;
			}
		}catch(System.IndexOutOfRangeException){}
		GD.Print(Pos);
	}
}
