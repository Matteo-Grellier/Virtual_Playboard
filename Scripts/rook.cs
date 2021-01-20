using Godot;
using System;

public class rook : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    public float bFirstRookX = 32;

    public override void _Ready()
    {
        
    }

    // public void _on_Area2D_input_event() {

    // }

    public void _OnArea2DInputEvent(Viewport viewport, InputEvent @event, int shape_idx)
    {

        // GD.Print("Clicked");

        // if (@event is InputEventMouseButton click && click.ButtonIndex == (int)ButtonList.Left && @event.IsPressed()) {
        //     GD.Print("Clicked");
        // }


        if (@event is InputEventMouseButton) {
            
            GD.Print("Clicked");
            
            if (@event.IsActionPressed("click")) {
                    GD.Print("Clicked");
            }
        }
       
    }


    // public void _OnArea2DInputEvent(Node n, InputEvent @event, int idx) { 

    //     //if (@event is InputEventMouseButton) {
            
    //         if (@event.IsActionPressed("click")) {
    //                 GD.Print("Clicked");
    //         }
    //     //}

    // }


     // public void _on_Area2D_input_event() {

    // }

    // private void _OnSpriteInputEvent(Viewport viewport, InputEvent @event, int shape_idx)
    // {

    //     // GD.Print("Clicked");

    //     // if (@event is InputEventMouseButton click && click.ButtonIndex == (int)ButtonList.Left && @event.IsPressed()) {
    //     //     GD.Print("Clicked");
    //     // }


    //     if (@event is InputEventMouseButton) {
            
    //         if (@event.IsActionPressed("click")) {
    //                 GD.Print("Clicked");
    //         }
    //     }
       
    // }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
