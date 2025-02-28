using System;
using Godot;

public partial class StartButton : Button
{
    private SceneTree RootTree;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        RootTree = GetTree();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    public override void _Pressed()
    {
        RootTree.ChangeSceneToFile("res://game.tscn");
    }
}
