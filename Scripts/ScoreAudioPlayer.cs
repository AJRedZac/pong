using Godot;
using System;

public partial class ScoreAudioPlayer : Godot.AudioStreamPlayer
{
	private Bola bola;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void SetBola(Bola b){
		bola = b;
		bola.P1Scored += OnP1Scored;
		bola.P2Scored += OnP2Scored;
	}
	
	
	private void OnP1Scored(){
		GD.Print("OnP1Score");
		Play();	
		
	}
	
	private void OnP2Scored(){
		GD.Print("OnP2Scored");
		Play();	
		 
	}
}
