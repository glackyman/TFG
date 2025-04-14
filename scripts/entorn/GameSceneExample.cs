using Godot;
using System;

public partial class GameSceneExample : Node
{
	private PackedScene _treeScene;
	private PackedScene _coinScene;
	
	public override void _Ready()
	{
		// Cargar las escenas
		_treeScene = GD.Load<PackedScene>("res://scenes/entorn/arbol.tscn");
		_coinScene = GD.Load<PackedScene>("res://scenes/pickups/Coin.tscn");

		// Instanciar arbol
		SpawnTree(new Vector2(4, 5));

		var treeInstance = _treeScene.Instantiate();
		AddChild(treeInstance);

	   
		//Monedas
		//for (int i = 0; i < 100; i++)
		//{
		//	SpawnCoin(new Vector2(i*55, 55));
		//}
	}

	private void SpawnTree(Vector2 position)
	{
		// Crear una instancia de la escena del árbol
		if (_treeScene != null)
		{
			var treeInstance = _treeScene.Instantiate();
			AddChild(treeInstance);

			// Posicionar el árbol
			if (treeInstance is Node2D treeNode)
			{
				treeNode.Position = position;
			}

			// Verificar el nodo de colisión
			if (treeInstance is Node tree)
			{
				var collisionShape = tree.GetNode<CollisionShape2D>("CollisionShape2D");
				collisionShape.Disabled = false;
				if (collisionShape == null)
				{
					GD.PrintErr("CollisionShape2D not found in tree instance.");
				}
				else
				{
					//GD.Print("CollisionShape2D found and ready.");
				}
			}
		}
		else
		{
			GD.PrintErr("Failed to load the tree scene.");
		}
	}

	private void SpawnCoin(Vector2 position)
	{
		if (_coinScene != null)
		{
			var coinInstance = _coinScene.Instantiate();
			AddChild(coinInstance);

			if(coinInstance is Area2D coinNode)
			{
				coinNode.Position = position;
			}

			if(coinInstance is Node coin)
			{
				var collisionShape = coin.GetNode<CollisionShape2D>("CollisionShape2D");
				collisionShape.Disabled = false;
				if (collisionShape == null)
				{
					GD.PrintErr("CollisionShape2D not found in tree instance.");
				}else{
					GD.Print("CollisionShape2D get ready.");
				}
				

			}
		}
	}
}
