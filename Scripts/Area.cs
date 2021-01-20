using Godot;
using System;

public class Area : Area2D
{
    private void _on_Area2D_input_event(Viewport viewport, InputEvent @event, int shape_idx)
    {
        if (@event is InputEventMouseButton btn && btn.ButtonIndex == (int)ButtonList.Left && @event.IsPressed()) {
            GD.Print("Clicked");
        }
    }

}