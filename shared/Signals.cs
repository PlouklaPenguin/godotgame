using System;
using Godot;

public partial class Signals : Node
{
    [Signal]
    public delegate void PlayerHealthUpdateEventHandler(float CurrentHealth);

    [Signal]
    public delegate void EnemySlowdownEventHandler(float SlowdownBy);
}
