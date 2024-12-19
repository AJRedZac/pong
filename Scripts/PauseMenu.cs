using Godot;
using System;

public partial class PauseMenu : MainMenu
{
	private Button continueButton;
	private Button exitButton;
	private Button newGameButton;
	private bool whaaaat=false;
	//making changes for the sake of it
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		continueButton = GetNode<Button>("VBoxContainer/ContinueButton");
		continueButton.Connect("pressed", new Callable(this, nameof(OnContinueButtonPressed)));
		exitButton = GetNode<Button>("VBoxContainer/QuitButton");
		exitButton.Connect("pressed", new Callable(this, nameof(OnExitButtonPressed)));
		newGameButton = GetNode<Button>("VBoxContainer/NewGameButton");
		newGameButton.Connect("pressed", new Callable(this, nameof(OnNewGameButtonPressed)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnContinueButtonPressed(){
		GD.Print("Continue");
		Hide();
		GetTree().Paused = false;
	}
	
	private void OnNewGameButtonPressed(){
		var mainScene = ResourceLoader.Load<PackedScene>("res://Main.tscn");
		GetTree().ChangeSceneToPacked(mainScene);
	}
	
	private void OnExitButtonPressed(){
		GetTree().Quit();
	}
	
	
}
