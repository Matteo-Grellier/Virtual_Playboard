extends KinematicBody2D

const GRAVITY = 1000
const ACCEL = 10
const UP = Vector2(0, -1)

var vel = Vector2()
var max_speed = 200   #'export (int)' pour modifier dans la scene

func _ready():
	pass 


func _process(delta): # execute l'action a chaque frame.
	pass

func _physics_process(delta): #execute 60 ticks par seconde
	movement_loop()
	vel.y += GRAVITY * delta
	vel = move_and_slide(vel, UP) #UP indique le plafond

func movement_loop():
	var right =  Input.is_action_pressed("ui_right")
	var left  =  Input.is_action_pressed("ui_left")
	var jump = Input.is_action_just_pressed("ui_accept")
	
	var dirx = int(right) - int(left)
	
	if dirx == -1:
		vel.x = max(vel.x -ACCEL, -max_speed)
		$Sprite.flip_h = true
		animation_loop("walk")
	elif dirx == 1:
		vel.x = min(vel.x + 5, max_speed)
		$Sprite.flip_h = false
		animation_loop("walk")
	else:
		vel.x = lerp(vel.x, 0, 0.1)
		animation_loop("idle")
	
	
	if jump == true and is_on_floor():
		vel.y = -700
	if vel.y < 0:
		animation_loop("jump_down")
	if vel.y > 0:
		animation_loop("jump_up")
	
func animation_loop(animation):
	if $anim.current_animation != animation:
		$anim.play(animation)
	
	
	
	
	
	
	
	
	
	
	
	
