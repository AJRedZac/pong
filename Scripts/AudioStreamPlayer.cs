using Godot;
using System;

public partial class AudioStreamPlayer : Godot.AudioStreamPlayer
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
		GD.Print("SetBola");
		bola = b;
		bola.ObjectHit += OnObjectHit;
		bola.P1Scored += OnP1Scored;
		bola.P2Scored += OnP2Scored;
	}
	
	private void OnObjectHit(){
		
		GD.Print("OnObjectHit");
		Play();
		
	}
	
	private void OnP1Scored(){
		
		
	}
	
	private void OnP2Scored(){
		
		 
	}
	
	
	
	
}
