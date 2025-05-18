using Godot;
using System;

public partial class Warrior : Player
{
	private Random random = new Random();
	private double criticDamage;
	private double criticChance;
	private Area2D attackArea;

	[Export]
	public double Critic
	{
		set { criticDamage = value; }
		get { return criticDamage; }
	}

	[Export]
	public double CriticChance
	{
		set { criticChance = value; }
		get { return criticChance; }
	}

	public Warrior(string name, double criticDamege, double criticChance) : base(name, 120, 33.33, 10, 0)
	{
		Critic = criticDamege;
		CriticChance = criticChance;
	}

	public Warrior()
	{

	}

	public override void _Ready()
	{
		base._Ready();
		attackArea = GetNode<Area2D>("AttackArea2D");
		attackArea.BodyEntered += OnAttackAreaBodyEntered;
		attackArea.Monitoring = true;
	}

	private void OnAttackAreaBodyEntered(Node2D body)
	{
		if (body is Enemy enemy)
		{
			enemy.TakeDamage((int)Ad);
			GD.Print("ATACA");
		}
	}


	public override string Attack()
	{
		if (isACritic())
		{
			double adCritic = Ad * criticDamage;

			return base.Attack() + "CON UN CRITICO";

		}

		return base.Attack();
	}

	public bool isACritic()
	{
		return random.NextDouble() >= CriticChance;
	}


}
