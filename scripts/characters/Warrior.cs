using Godot;
using System;

	public partial class Warrior : Player
	{
		private Random random = new Random();
		private double criticDamage;
		private double criticChance;
		
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
		
		public Warrior(){
			
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
