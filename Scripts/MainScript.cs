using Godot;
using System;





public partial class MainScript : Node2D
{
	private int p1score=0;
	private int p2score=0;
	
	[Export]
	public PackedScene BolaScene { get; set; }
	
	private Bola bola;
	private AudioStreamPlayer audioStreamPlayer;
	private ScoreAudioPlayer scoreAudioPlayer;
	private MainMenu mainMenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetTree().Paused = false;
		audioStreamPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		scoreAudioPlayer = GetNode<ScoreAudioPlayer>("ScoreAudioPlayer");
		crearBola();
		audioStreamPlayer.SetBola(bola);
		scoreAudioPlayer.SetBola(bola);
		UpdateScore("P1Score",p1score);
		UpdateScore("P2Score",p2score);
		
	}

	private void crearBola(){
		bola = BolaScene.Instantiate<Bola>();
		bola.P1Scored += OnP1Scored;
		bola.P2Scored += OnP2Scored;
		AddChild(bola);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	public void UpdateScore(string label,int score)
	{
		GetNode<Label>(label).Text = score.ToString();
	}
	
	private void OnP1Scored(){
		
		p1score++;
		UpdateScore("P1Score",p1score);
	}
	
	private void OnP2Scored(){
		
		p2score++;
		UpdateScore("P2Score",p2score);
	}
	
}
