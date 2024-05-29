using System;
using Godot;

public partial class HealthBar : ProgressBar
{
    // Called when the node enters the scene tree for the first time.
    private Signals _signals;

    public override void _Ready()
    {
        _signals = GetNode<Signals>("/root/Signals");
        _signals.PlayerHealthUpdate += OnPlayerHealthUpdate;
        Value = 100;
        //GD.Print(GetTree().GetNodesInGroup("Player")[0]);
    }

    public void OnPlayerHealthUpdate(float CurrentHealth)
    {
        //GD.Print(CurrentHealth.ToString("0.0000"));
        Value = CurrentHealth * 100 / Player.MaxHealth;
    }
}
