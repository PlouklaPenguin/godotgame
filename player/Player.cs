using System;
using System.Collections;
using System.Collections.Generic;
using Godot;

public partial class Player : CharacterBody2D
{
    public const float Speed = 400.0f;
    public const float JumpVelocity = -400.0f;
    private Signals _signals;

    private static float SlowdownBy = 10f;

    [Export]
    public const float MaxHealth = 100f;

    [Export]
    public float Health { get; set; }

    [Signal]
    public delegate void PlayerHealthUpdateEventHandler(float CurrentHealth);

    [Signal]
    public delegate void SlowDownEventHandler(float SlowdownBy);

    public override void _Ready()
    {
        _signals = GetNode<Signals>("/root/Signals");
        _signals.EmitSignal(nameof(Signals.PlayerHealthUpdate), MaxHealth);
        Health = MaxHealth;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("spell"))
        {
            _signals.EmitSignal(nameof(Signals.EnemySlowdown), SlowdownBy);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        if (direction != Vector2.Zero)
        {
            velocity = direction * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, 10 * Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, 10 * Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
