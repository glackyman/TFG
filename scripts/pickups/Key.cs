using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Key : PickUp
{
	public Key()
	{
		Id = 2;
		Name = "Key";
	}

	public void pickUpKey(Node node)
	{
		if (node is Player player)
		{
			GD.Print($"{player.Name} cogio una llave; {Id}");
			player.AddCoins(1);
			QueueFree();
		}
	}
}
