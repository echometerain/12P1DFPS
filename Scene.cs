using Godot;
using System;
using System.Collections.Generic;

public class Scene : Node2D{
	public const int WorldY = 21;
	public const int WorldX = 21;
	public Vector2 Pos = new Vector2(WorldX, WorldY);
	public byte Life = 255;
	public byte Ammo = 255;
	public byte Weapon = 255;
	public enum mapO{
		empty, wall, supply, heal, spawner
	}
	public enum entity{
		player, enemy
	}
	public enum Rtype{
		front, side, corner, annoy
	}
	public mapO[,] map = new mapO[WorldY, WorldX];
	Dictionary<Vector2, entity> entities = new Dictionary<Vector2, entity>();
	public override void _Ready(){
		for(int i = 0; i < WorldY-1; i++) {
			for(int ii = 0; ii < WorldX-1; ii++) {
				map[i, ii] = mapO.empty;
			}
		}
		entities.Add(Pos, entity.player);
		entities.Add(new Vector2(10, 10), entity.enemy);
	}
	public void hud(){
		
	}
	public void raster(ColorRect pixel, bool Ypositive, bool Xpositive){
		
	}
	public override void _Process(float delta){
		
	}
}
