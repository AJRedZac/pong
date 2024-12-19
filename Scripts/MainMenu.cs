using Godot;
using System;

public partial class MainMenu : Node2D
{
	// Called when the node enters the scene tree for the first time.
	
	private Button exitButton;
	private Button newGameButton;
	
	public override void _Ready()
	{
		exitButton = GetNode<Button>("VBoxContainer/QuitButton");
		exitButton.Connect("pressed", new Callable(this, nameof(OnExitButtonPressed)));
		newGameButton = GetNode<Button>("VBoxContainer/NewGameButton");
		newGameButton.Connect("pressed", new Callable(this, nameof(OnNewGameButtonPressed)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	private void OnNewGameButtonPressed(){
		var mainScene = ResourceLoader.Load<PackedScene>("res://Main.tscn");
		GetTree().ChangeSceneToPacked(mainScene);
	}
	
	private void OnExitButtonPressed(){
		GetTree().Quit();
	}
}
