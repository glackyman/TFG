using Godot;
using System;

public partial class Trol : Enemy
{
    // Constructor (opcional, pero puede ser útil)
    public Trol()
    {
        Speed = 80.0f; // Trol es lento
        Health = 200; // Trol tiene mucha vida
        AttackDamage = 20; // Trol pega fuerte
    }

    public override void InitializeEnemy()
    {
        // Aquí podrías añadir lógica específica del Trol al inicio,
        // como configurar animaciones específicas del trol si son diferentes.
        GD.Print($"{Name} el Trol ha aparecido.");
    }

    protected override void Attack()
    {
        GD.Print($"{Name} el Trol golpea fuerte con {AttackDamage} de daño.");
        // Aquí implementarías la lógica real para dañar al jugador
    }

    protected override void Die()
    {
        GD.Print($"{Name} el Trol cae.");
        QueueFree();
        // Aquí podrías añadir lógica para soltar objetos al morir, etc.
    }
}