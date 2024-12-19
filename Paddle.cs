using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
	// Velocidad de movimiento de la paleta
	[Export]
	public float Speed = 800.0f;
	Vector2 input_velocity = Vector2.Zero;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	

		// Entrada del jugador 1 (W y S)
		if (Input.IsActionPressed("up")){
		   input_velocity.Y = -Speed;
		}
		else if (Input.IsActionPressed("down")){
			input_velocity.Y = Speed;
		}
		else if(Input.IsActionJustReleased("up")){
			input_velocity.Y  = 0;
		}else if(Input.IsActionJustReleased("down")){
			input_velocity.Y  = 0;
		}
		   
		
		

		// Actualizar posición
		//Position += velocity * (float)delta;

		// Limitar posición dentro de la pantalla
		//Position = new Vector2(Position.x, Mathf.Clamp(Position.y, _screenTop + 50, _screenBottom - 50));
	
	}
	
	public override void _PhysicsProcess(double delta){
		var collisionInfo = MoveAndCollide(input_velocity * (float)delta);
		if (collisionInfo != null)
		{
			var collisionPoint = collisionInfo.GetPosition();
		}
	}
}
