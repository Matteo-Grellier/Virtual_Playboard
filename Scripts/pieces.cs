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


    //position de la souris
    public override void _Input(InputEvent @event)
    {
        board Board = new board();
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
        velocity = Position.DirectionTo(toMovement) * speed;

        if (Position.DistanceTo(toMovement) > 5)
        {
            velocity = MoveAndSlide(velocity);
        }
    }

}
