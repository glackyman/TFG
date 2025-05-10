using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
    // Velocidad de movimiento base
    [Export]
    public float Speed = 200.0f;

    // Vida del enemigo
    [Export]
    public int Health { get; set; } = 100; // Valor predeterminado de 100

    // Poder de ataque del enemigo
    [Export]
    public int AttackDamage { get; set; } = 10; // Valor predeterminado de 10

    // Path al nodo Player en la escena
    [Export]
    public NodePath PlayerPath;

    // Referencia al nodo Player
    protected CharacterBody2D player; // Cambiado a protected para que las clases hijas puedan acceder

    protected Sprite2D sprite; // Cambiado a protected
    protected AnimationTree animationTree; // Cambiado a protected
    protected AnimationNodeStateMachinePlayback stateMachine; // Cambiado a protected

    public Enemy()
    {

    }

    protected enum State
    {
        Idle,
        Chase,
        Attack
    }
    protected State currentState = State.Idle; // Cambiado a protected

    public override void _Ready()
    {
        // Obtener al jugador
        player = GetNode<CharacterBody2D>(PlayerPath);
        sprite = GetNode<Sprite2D>("Sprite2D");

        // Si usas animaciones:
        animationTree = GetNode<AnimationTree>("AnimationTree");
        stateMachine = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");

        // Llamada a un método virtual para inicialización específica de cada enemigo
        InitializeEnemy();
    }

    // Método virtual para que las clases hijas puedan personalizar la inicialización
    public virtual void InitializeEnemy()
    {
        // Aquí se pueden añadir comportamientos específicos de cada tipo de enemigo en su _Ready
    }

    public override void _PhysicsProcess(double delta)
    {
        if (player == null || player.IsQueuedForDeletion())
            return;

        Vector2 toPlayer = (player.GlobalPosition - GlobalPosition);
        float distance = toPlayer.Length();

        // Estado de patrulla (idle) si muy lejos, persecución si cerca, ataque si muy cerca
        if (distance > 400)
        {
            ChangeState(State.Idle, Vector2.Zero);
            Velocity = Vector2.Zero;
        }
        else if (distance > 50)
        {
            ChangeState(State.Chase, toPlayer.Normalized());
            Velocity = toPlayer.Normalized() * Speed;
        }
        else
        {
            ChangeState(State.Attack, Vector2.Zero);
            Velocity = Vector2.Zero;
            // Aquí podrías llamar a un método Attack()
            Attack(); // Llamamos al método de ataque
        }

        MoveAndSlide();
    }

    protected virtual void Attack()
    {
        // Lógica de ataque base. Las clases hijas pueden sobreescribir esto.
        GD.Print($"{Name} está atacando con {AttackDamage} de daño.");
        // Aquí deberías implementar la lógica real para dañar al jugador
    }

    protected void ChangeState(State newState, Vector2 direction)
    {
        if (newState == currentState) return;
        currentState = newState;

        switch (newState)
        {
            case State.Idle:
                if (stateMachine != null) stateMachine.Travel("idle");
                break;
            case State.Chase:
                if (stateMachine != null) stateMachine.Travel("run");
                // Opcional: voltear sprite según dirección
                if (sprite != null && direction.X != 0)
                    sprite.FlipH = direction.X > 0;
                break;
            case State.Attack:
                if (stateMachine != null) stateMachine.Travel("attack");
                break;
        }
    }

    // Método para recibir daño
    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        GD.Print($"{Name} recibió {damage} de daño. Vida restante: {Health}");
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        GD.Print($"{Name} ha muerto.");
        QueueFree(); // Eliminar el nodo de la escena
    }
}