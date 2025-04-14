using Godot;
using System;

public partial class Tree : StaticBody2D
{
	[Signal]
	public delegate void TreeHitEventHandler(Vector2 position);

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
			EmitSignal(SignalName.TreeHit, this.GlobalPosition); // Emitir señal con posición
			GD.Print("Tree hit! Signal emitted.");
			isTouched = false;
		}

	}

	
}
