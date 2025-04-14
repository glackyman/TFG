using Godot;
using System;

public partial class Coin : PickUp
{
	private int value;
	Random random = new Random();

	public Coin()
	{
		Name = "Coin";
		value = GenerateRandomValue();
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AnimatedSprite2D animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		if (value == 10)
		{
			animatedSprite.Play("ten_coin");
			Id = 13;
		}

		if (value == 5)
		{
			animatedSprite.Play("five_coin");
			Id = 12;

		}

		if (value == 1) 
		{
			animatedSprite.Play("one_coin");
			Id = 11;

		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private int GenerateRandomValue()
	{
		Random random = new Random();
		int roll = random.Next(0, 100);

		if (roll < 70)
		{
			return 1;
		}
		else if (roll < 90)
		{
			return 5;
		}
		else
		{
			return 10;
		}
	}

	public void pickUpCoin(Node node)
	{
		if(node is CharacterBody2D player)
		{

			GD.Print($"{player.Name} cogio moneda {value}; {Id}");
		}
	}
}
