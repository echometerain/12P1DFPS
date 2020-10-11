using Godot;
using System;

public class Scene : Node2D{
    public sbyte WorldY = 20;
    public sbyte WorldX = 20;
    public override void _Ready(){
        sbyte[][] map = new sbyte[WorldY][WorldX];
    }
    public override void _Process(float delta){

    }
}
