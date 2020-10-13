using Godot;
using System;
using System.Collections.Generic;
//in this project, x comes beffore y
public class Player : Node2D{
	public const int WorldX = 21;
	public const int WorldY = 21;
	public Vector2 Pos = new Vector2(WorldX/2, WorldY/2); //player position
	public byte Life = 255;
	public byte Ammo = 255;
	public byte Weapon = 255;
	enum Object{
		empty, wall, supply, heal, spawner, player, enemy
	}
	public enum Rtype{
		front, side, corner, annoying
	}
	Object[,] map = new Object[WorldX, WorldY];
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
		if(Input.IsKeyPressed((int)KeyList.W)){
			tempos.y += 1;
		}
		else if(Input.IsKeyPressed((int)KeyList.S)){
			tempos.y -= 1;
		}
		if(Input.IsKeyPressed((int)KeyList.A)){
			tempos.x -= 1;
		}
		else if(Input.IsKeyPressed((int)KeyList.D)){
			tempos.x += 1;
		}
		try{
			if(map[(int)tempos.x, (int)tempos.y] == Object.empty && !entities.ContainsKey(tempos)){
				Pos = tempos;
			}
		}catch(System.IndexOutOfRangeException){}
		GD.Print(Pos);
	}
}
