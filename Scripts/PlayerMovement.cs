using Godot;
using System;

public class PlayerMovement : KinematicBody2D
{

    private float gravity = 800;
    private int walkspeed = 300;
    private int JumpCount = 2;
    private int JumpForce = -500;


    Vector2 velocity;

    public override void _PhysicsProcess(float delta)
    {
        velocity.y += delta * gravity;

        //jump
        if(Input.IsActionJustPressed("jump") && JumpCount > 0)
        {
            velocity.y = JumpForce;
            JumpCount -= 1;
          
        }
        
         if(IsOnFloor())
         {
               JumpCount = 2;
         }
        

        //move left and right 
        if(Input.IsActionPressed("move_left"))
        {
            velocity.x = -walkspeed;
        }
        
        else if(Input.IsActionPressed("move_right"))
        {
            velocity.x = walkspeed;
        }
        else
        {
            velocity.x = 0;
        }

       
       MoveAndSlide(velocity, new Vector2(0, -1));
       
    
       
    }

}
