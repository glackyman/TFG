using Godot;
using System;

public partial class Player : CharacterBody2D
{

	private string name;
	private double hp, def, lvl, xp, ap, ad;
	private bool isDead = false;

	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	private AnimationPlayer animationPlayer;
	private Vector2 lastDirection = Vector2.Zero;

	private Sprite2D sprite;
	private bool isAttacking;

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
		sprite = GetNode<Sprite2D>("Sprite2D"); // <-- Aquí
	}


	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Obtener la dirección de entrada del jugador.
		Vector2 direction = Input.GetVector("left", "right", "up", "down");

		if (direction != Vector2.Zero)
		{
			// Mover al personaje según la dirección de entrada.
			velocity = direction * Speed;

			lastDirection = direction;
			//
			//// Cambiar la animación según la dirección.
			if (direction.Y < 0) // Movimiento hacia arriba
			{
				animationPlayer.Play("run_top");
			}
			else if (direction.Y > 0) // Movimiento hacia abajo
			{
				animationPlayer.Play("run_down");
			}
			else if (direction.X < 0) // Movimiento hacia la izquierda
			{
				animationPlayer.Play("run_side");
				sprite.FlipH = false;
			}
			else if (direction.X > 0) // Movimiento hacia la derecha
			{
				animationPlayer.Play("run_side");
				sprite.FlipH = true;
			}
		}
		else
		{
			// Detener suavemente el movimiento cuando no hay entrada.
			velocity.X = 0;
			velocity.Y = 0;

			if (lastDirection.Y < 0)
			{
				animationPlayer.Play("idle_top");
			}
			else if (lastDirection.Y > 0)
			{
				animationPlayer.Play("idle_down");
			}
			else
			{
				animationPlayer.Play("idle_side");
			}
		}

		if (Input.IsActionJustPressed("attack"))
		{
			if (lastDirection.Y < 0)
			{
				animationPlayer.Play("attack_top3");
			}
			else if (lastDirection.Y > 0)
			{
				animationPlayer.Play("attack_down");
			}
			else
			{
				animationPlayer.Play("attack_side");
			}

			lastDirection = Vector2.Zero; // Prueba esto
			return;
		}

		// Aplicar el movimiento.
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
		isAttacking = false;
	}
}
