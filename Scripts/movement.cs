using Godot;
using System;

public class movement : KinematicBody2D
{
    [Export] public int speed = 200;

    public Vector2 target = new Vector2();
    public Vector2 velocity = new Vector2();

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("click"))
        {
            target = GetGlobalMousePosition();
        }
    }

    public override void _PhysicsProcess(float delta)
    {
        velocity = Position.DirectionTo(target) * speed;
        // LookAt(target);
        if (Position.DistanceTo(target) > 5)
        {
            velocity = MoveAndSlide(velocity);
        }
    }
}
