using Godot;
using System;

// Este script define la clase Player, que hereda de CharacterBody2D.
// La clase Player representa al jugador en el juego y maneja su estado, salud, nivel, experiencia, ataque y defensa.
// También maneja la animación y el movimiento del jugador en el juego.
// La clase utiliza el sistema de animación de Godot para cambiar entre diferentes estados de animación (idle, run, attack).
// La clase también maneja la entrada del jugador para mover al personaje y realizar ataques.
// También tiene métodos para atacar, defenderse y recibir daño.

public partial class Player : CharacterBody2D
{
	private AnimationPlayer animationPlayer;
	private Vector2 lastDirection = Vector2.Zero;
	private Sprite2D sprite;
	private AnimationTree animationTree;
	private AnimationNodeStateMachinePlayback stateMachine;

	private enum State
	{
		idle,
		run,
		attack
	}
	State currentState = State.idle;

	private bool isAttacking;
	private string name;
	private double hp, def, lvl, xp, ap, ad;
	private bool isDead = false;
	public const float Speed = 300.0f;

	[Export]
	public string NameP
	{
		set { name = value; }
		get { return name; }
	}
	[Export]
	public double Health
	{
		set
		{
			hp = Math.Max(value, 0);
			if (value <= 0)
			{
				IsDead = true;
			}
			else
			{
				IsDead = false;
			}
		}
		get { return hp; }
	}
	[Export]
	public double Level
	{
		set { lvl = value; }
		get { return lvl; }
	}
	[Export]
	public double XP
	{
		set
		{
			xp = value;
			while (xp >= 100)
			{
				Level++;
				xp -= 100;
			}
		}
		get { return xp; }
	}
	[Export]
	public double Def
	{
		set { def = value; }
		get { return def; }
	}
	[Export]
	public double Ap
	{
		set { ap = value; }
		get { return ap; }
	}
	[Export]
	public double Ad
	{
		set { ad = value; }
		get { return ad; }
	}
	[Export]
	public bool IsDead
	{
		set { isDead = value; }
		get { return isDead; }
	}

	public Player(string name, double hp, double def, double ap, double ad)
	{
		this.NameP = name;
		this.Health = hp;
		this.Def = def;
		this.Level = 1;
		this.Ap = ap;
		this.Ad = ad;
	}
	public Player()
	{

	}

	public string LevelUp()
	{
		Level++;
		return $"{NameP} sube de nivel";
	}

	public virtual string Attack()
	{
		return $"{NameP} ataco!!";
	}

	public string Deffend()
	{

		return $"{NameP} se defendio";
	}

	public string TakesDamage(double enemyDamage)
	{
		Health -= enemyDamage;

		return $"{NameP} fue atacado";
	}

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animationTree = GetNode<AnimationTree>("AnimationTree");
		sprite = GetNode<Sprite2D>("Sprite2D");
		stateMachine = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");

		// Inicializar los parámetros de mezcla (asegúrate de que los paths sean correctos)
		animationTree.Set("parameters/idle/blend_position", 0.0f);
		animationTree.Set("parameters/run/blend_position", 0.0f);
		animationTree.Set("parameters/attack/blend_position", 0.0f); // Correcto si tienes un BlendSpace llamado "attack_blend"


	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity;
		Vector2 direction = Input.GetVector("left", "right", "up", "down").Normalized();

		if (Input.IsActionJustPressed("attack"))
		{
			isAttacking = true;
			ChangeState(State.attack, lastDirection);
			return;
		}

		if (direction != Vector2.Zero)
		{
			velocity = direction * Speed;
			lastDirection = direction;

			if (Math.Abs(direction.X) > Math.Abs(direction.Y))
			{
				sprite.FlipH = direction.X > 0;
			}

			ChangeState(State.run, direction);
		}
		else
		{
			velocity = Vector2.Zero;
			ChangeState(State.idle, lastDirection);
		}

		Velocity = velocity;
		MoveAndSlide();

		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var collision = GetSlideCollision(i);
			if (((Node)collision.GetCollider()) is Tree tree)
			{
				tree.IsTouched = true;
			}
		}
		
	}

	private void ChangeState(State newState, Vector2 direction)
	{
		if (currentState == newState) return;

		currentState = newState;

		switch (newState)
		{
			case State.idle:
				stateMachine.Travel("idle");
				SetBlendAmount("idle/blend_position", GetBlendValue(direction));
				break;
			case State.run:
				stateMachine.Travel("run");
				SetBlendAmount("run/blend_position", GetBlendValue(direction));
				break;
			case State.attack:
				stateMachine.Travel("attack");
				SetBlendAmount("attack/blend_position", GetBlendValue(direction));
				break;
		}
	}

	private void SetBlendAmount(string parameterPath, float blendValue)
	{
		if (animationTree != null)
		{
			animationTree.Set($"parameters/{parameterPath}", blendValue);
		}
	}

	private float GetBlendValue(Vector2 direction)
	{
		if (Math.Abs(direction.Y) > Math.Abs(direction.X))
		{

			if (direction.Y < -0.5f) return -0.1f; // Arriba
			if (direction.Y > 0.5f) return 0.1f;  // Abajo
		}
		else if (Math.Abs(direction.X) > 0.5f)
		{
			return 0.0f; // Lado
		}
		return 0.0f; // Valor por defecto (lado)
	}
}
