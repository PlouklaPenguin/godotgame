using System;
using System.Collections.Generic;
using Godot;

[GlobalClass]
public partial class Globals : Node
{
    public static Dictionary<String, PackedScene> Weapons = new Dictionary<String, PackedScene>
    {
        { "Sword", GD.Load<PackedScene>("res://player/weapons/sword/Sword.tscn") }
    };

    public override void _Ready() { }
}
