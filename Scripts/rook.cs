using Godot;
using System;

public class rook : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    // Les valeurs sont dans l'ordre : 1ere valeur = X et Y du rook blanc gauche (a1) / 2eme = X et Y du rook blanc droit (h1)
    // 3eme = X et Y du rook noir gauche (a8) / 4eme = X et Y du rook noir droit (h8)
    public float[] rookX = new float[4];   
    public float[] rookY = new float[4];

    public Vector2 testVec = new Vector2();

    //public float test;

    public override void _Ready()
    {
    //     Position2D.GlobalPosition = new Vector2();

        // var test = Get("Node2D/position");
        // GD.Print(test);

        testVec = rook.GlobalPosition;
    }

    // public override void _PhysicsProcess(float delta)
    // {
    //     GetGlobalPosition 
    // }





    // public void _on_Area2D_input_event() {

    // }

    // public void _OnArea2DInputEvent(Viewport viewport, InputEvent @event, int shape_idx)
    // {

    //     // GD.Print("Clicked");

    //     // if (@event is InputEventMouseButton click && click.ButtonIndex == (int)ButtonList.Left && @event.IsPressed()) {
    //     //     GD.Print("Clicked");
    //     // }


    //     if (@event is InputEventMouseButton) {

    //         GD.Print("Clicked");

    //         if (@event.IsActionPressed("click")) {
    //                 GD.Print("Clicked");
    //         }
    //     }

    // }


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
    





    // public void _on_Area2D_input_event() {

    // }

    // public void _OnArea2DInputEvent(Viewport viewport, InputEvent @event, int shape_idx)
    // {

    //     // GD.Print("Clicked");

    //     // if (@event is InputEventMouseButton click && click.ButtonIndex == (int)ButtonList.Left && @event.IsPressed()) {
    //     //     GD.Print("Clicked");
    //     // }


    //     if (@event is InputEventMouseButton) {
            
    //         GD.Print("Clicked");
            
    //         if (@event.IsActionPressed("click")) {
    //                 GD.Print("Clicked");
    //         }
    //     }
       
    // }


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
