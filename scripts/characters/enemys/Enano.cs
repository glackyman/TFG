using Godot;
using System;

public partial class Enano : Enemy
{
    public Enano()
    {
        Speed = 300.0f; 
        Health = 50; 
        AttackDamage = 8; 
    }

    public override void InitializeEnemy()
    {
        GD.Print($"{Name} el Enano corre hacia ti.");
        
    }

    protected override void Attack()
    {
        GD.Print($"{Name} el Enano ataca rápidamente con {AttackDamage} de daño.");
        
    }

    protected override void Die()
    {
        GD.Print($"{Name} el Enano ha sido derrotado.");
        QueueFree();
    }
}