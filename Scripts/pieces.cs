using Godot;
using System;

public class pieces : KinematicBody2D
{

    public float[] rightCoor = new float[2];

    //pour _Input()
    public Vector2 mouseClick = new Vector2();
    public float mouseX;
    public float mouseY;

    //pour Movement() 
    public int speed = 400;
    public Vector2 toMovement = new Vector2();
    public Vector2 velocity = new Vector2();
    float t;

    //position de la souris
    public override void _Input(InputEvent @event)
    {
        board Board = new board(); //référence au code board.cs (je crois)
        // rightCoor = test.RightCoor(mouseClick.x, mouseClick.y);

        //Mouse in viewport coordinates.
        if (@event.IsActionPressed("click"))
        {
            GD.Print("Mouse Click/Unclick at: ", GetGlobalMousePosition());
            mouseClick = GetGlobalMousePosition();

            //Debug
            GD.Print(mouseClick.x);
            GD.Print(mouseClick.y);

            rightCoor = Board.RightCoor(mouseClick.x, mouseClick.y);

            //Debug
            GD.Print(rightCoor[0]);
        }  

        toMovement.x = rightCoor[0];
        toMovement.y = rightCoor[1];
        //Movement();
        
    }
    

    public override void _PhysicsProcess(float delta)
    {
        //Node child = GetChild(0);

        //Node child = GetNode("KinematicBody2D");

        //Node2D obj = GetNode("KinematicBody2D").Object; // Property access.

        //t += delta * 0.4f;

        velocity = Position.DirectionTo(toMovement) * speed;

        if (Position.DistanceTo(toMovement) > 5)
        {
        velocity = MoveAndSlide(velocity);
        }
        else
        {
            //SetGlobalPosition(toMovement);
            //GlobalPosition = new Vector2(toMovement.x, toMovement.y);
            GlobalPosition = toMovement;
        }

        //obj.Position = mouseClick.LinearInterpolate(toMovement, t);
    }

}
 