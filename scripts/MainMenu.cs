using Godot;
using System;

public partial class MainMenu : CanvasLayer
{
    public override void _Ready()
    {
        var playButton = GetNode<Button>("VBoxContainer/Jugar");
        var exitButton = GetNode<Button>("VBoxContainer/Salir");

        playButton.Pressed += OnPlayPressed;
        exitButton.Pressed += OnExitPressed;
    }

    private void OnPlayPressed()
    {
        // Cambia "GameScene.tscn" por el nombre de tu escena principal de juego
        GetTree().ChangeSceneToFile("res://scenes/entorn/map_example.tscn");
    }

    private void OnExitPressed()
    {
        GetTree().Quit();
    }
}