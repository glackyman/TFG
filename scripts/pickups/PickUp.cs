using Godot;
using System;

public partial class PickUp : Area2D
{

	private int id;
	private string name;

	public int Id
	{
		set { id = value; }
		get { return id; }
	}

	public string Name {
		set { name = value; }
		get { return name; }
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

}
