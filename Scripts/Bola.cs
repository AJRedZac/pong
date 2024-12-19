using Godot;
using System;

public partial class Bola : RigidBody2D
{
	
	[Signal]
	public delegate void P1ScoredEventHandler();
	
	[Signal]
	public delegate void P2ScoredEventHandler();
	
	[Signal]
	public delegate void ObjectHitEventHandler();
	
	[Export]
	public float InitialSpeed = 600.0f; // Velocidad inicial de la bola
	private Vector2 Velocity = Vector2.Zero; // Velocidad manual
	private Vector2 StartPosition; // Posición inicial de la bola
	
	public override void _Ready()
	{
		StartPosition = Position; // Guardamos la posición inicial
		// Iniciar la bola en una dirección aleatoria
		//GD.Print(StartPosition);
		StartBallMovement();
	}

	private void StartBallMovement()
	{
		
		// Seleccionar una dirección inicial aleatoria
		Vector2 initialDirection = new Vector2(GD.Randf() > 0.5f ? 1 : -1, GD.Randf() * 2 - 1).Normalized();
		Velocity = initialDirection * InitialSpeed;
		
	}

	public override void _PhysicsProcess(double delta)
	{
		
		var collision = MoveAndCollide(Velocity * (float)delta);
		if (collision != null)
		{
			EmitSignal(SignalName.ObjectHit);
			Velocity = Velocity.Bounce(collision.GetNormal());
		}
		 

		// Detectar si la bola sale del área del juego
		if (Position.X > 1920) // Sale por el lado derecho
		{
			EmitSignal(SignalName.P1Scored);
			ResetBall();
		}
		else if (Position.X < 0) // Sale por el lado izquierdo
		{
			EmitSignal(SignalName.P2Scored);
			ResetBall();
		}
	
	}
	
	public override void _Process(double delta){
		
		
	}
	
	private void ResetBall()
	{
		
		// Regresar la bola a su posición inicial y detenerla
		Position = StartPosition;
		Velocity = Vector2.Zero;
		
		// Iniciar la bola después de un pequeño retraso
		GetTree().CreateTimer(1.0f).Timeout += StartBallMovement;
	}
}
