using Godot;
using System;

public class test : KinematicBody2D
{
    // speed du perso
    [Export] public int speed = 200;

    public Vector2 velocity = new Vector2();

    private string str = "Hello World";

    public void GetInput()
    {
        velocity = new Vector2();
        //Les différentes directions
        if (Input.IsActionPressed("right"))
            velocity.x += 1;

        if (Input.IsActionPressed("left"))
            velocity.x -= 1;

        if (Input.IsActionPressed("down"))
            velocity.y += 1;

        if (Input.IsActionPressed("up"))
            velocity.y -= 1;
        //donner une valeur de vitesse
        velocity = velocity.Normalized() * speed;

        GD.Print(str);
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        velocity = MoveAndSlide(velocity);
    }
}
