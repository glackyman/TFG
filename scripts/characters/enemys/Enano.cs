using Godot;
using System;

public partial class Enano : Enemy
{
    public Enano()
    {
        Speed = 300.0f; // Enano es rápido
        Health = 50; // Enano tiene poca vida
        AttackDamage = 8; // Enano pega menos fuerte
    }

    public override void InitializeEnemy()
    {
        GD.Print($"{Name} el Enano corre hacia ti.");
        // Configurar animaciones específicas del enano si es necesario
    }

    protected override void Attack()
    {
        GD.Print($"{Name} el Enano ataca rápidamente con {AttackDamage} de daño.");
        // Implementar la lógica de ataque del enano
    }

    protected override void Die()
    {
        GD.Print($"{Name} el Enano ha sido derrotado.");
        QueueFree();
    }
}