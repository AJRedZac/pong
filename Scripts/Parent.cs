using Godot;
using System;

public partial class Parent : Node
{
	// Called when the node enters the scene tree for the first time.
	private PauseMenu pauseMenu;
	public override void _Ready()
	{
		pauseMenu = GetNode<PauseMenu>("Menu2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("pause")){
			GD.Print("Paused");
			pauseMenu.Show();
			GetTree().Paused = true;
		}
	}
	
	
}
