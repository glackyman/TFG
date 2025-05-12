using Godot;
using System;

public partial class Trol : Enemy
{
    
    public Trol()
    {
        Speed = 80.0f; 
        Health = 200; 
        AttackDamage = 20; 
    }

    public override void InitializeEnemy()
    {
        
        
        GD.Print($"{Name} el Trol ha aparecido.");
    }

    protected override void Attack()
    {
        GD.Print($"{Name} el Trol golpea fuerte con {AttackDamage} de daño.");
        
    }

    protected override void Die()
    {
        GD.Print($"{Name} el Trol cae.");
        QueueFree();
        
    }
}