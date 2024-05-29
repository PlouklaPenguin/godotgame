using System;
using Godot;

public partial class Enemy : CharacterBody2D
{
    public float Slowdown;

    private Signals _signals;

    public Player _player;

    public void Initialize(Vector2I startPosition)
    {
        Position = startPosition;
        //LookAt(playerPosition);
    }

    public override void _Ready()
    {
        _signals = GetNode<Signals>("/root/Signals");
        _player = GetNode<Player>("/root/Main/Player");
        _signals.EnemySlowdown += OnEnemySlowdown;
        Slowdown = 1f;
        base._Ready();
    }

    public void OnEnemySlowdown(float SlowdownBy)
    {
        Slowdown = SlowdownBy;
    }
}
