using Godot;
using System;

public partial class Tree : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.

	bool isTouched = false;


	public bool IsTouched {
		set { isTouched = value; }
		get { return isTouched; } 
	}

	public override void _Ready()
	{

		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (isTouched) { 
			//Recuerda poner a false isTouched en "Player"
			QueueFree();
		}

	}
}
