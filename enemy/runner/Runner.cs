using System;
using Godot;

public partial class Runner : Enemy
{
    public const float Speed = 200.0f;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = Position.DirectionTo(_player.Position) * Speed / Slowdown;

        if (Position.DistanceTo(_player.Position) > 10)
        {
            MoveAndSlide();
        }
    }
}
