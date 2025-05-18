    using Godot;
    using System;

    public partial class Enemy : CharacterBody2D
    {
        //Propiedades
        [Export]
        public float Speed = 200.0f;

        [Export]
        public int Health { get; set; } = 100; 

        [Export]
        public int AttackDamage { get; set; } = 10; 
    
        [Export]
        public NodePath PlayerPath;
    
        protected CharacterBody2D player; 

        protected Sprite2D sprite; 
        protected AnimationTree animationTree; 
        protected AnimationNodeStateMachinePlayback stateMachine; 

        //Constructor vacio para godot, TODO incluir uno con propiedades inicializadas?
        public Enemy()
        {

        }

        protected enum State
        {
            Idle,
            Chase,
            Attack
        }
        protected State currentState = State.Idle; 

        public override void _Ready()
        {        
            player = GetNode<CharacterBody2D>(PlayerPath);
            sprite = GetNode<Sprite2D>("Sprite2D");
     
            animationTree = GetNode<AnimationTree>("AnimationTree");
            stateMachine = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");

            InitializeEnemy();
        }

        //Logica futura
        public virtual void InitializeEnemy()
        {
            
        }

        public override void _PhysicsProcess(double delta)
        {
            if (player == null || player.IsQueuedForDeletion())
                return;

            Vector2 toPlayer = (player.GlobalPosition - GlobalPosition);
            float distance = toPlayer.Length();

            
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
                
                Attack(); 
            }
            
            MoveAndSlide();
        }

        protected virtual void Attack()
        {
            //GD.Print($"{Name} está atacando con {AttackDamage} de daño.");
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
                    
                    if (sprite != null && direction.X != 0)
                        sprite.FlipH = direction.X > 0;
                    break;
                case State.Attack:
                    if (stateMachine != null) stateMachine.Travel("attack");
                    break;
            }
        }

        
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
            QueueFree(); 
        }
    }