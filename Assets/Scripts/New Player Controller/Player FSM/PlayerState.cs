using System;
using UnityEngine;

namespace New_Player_Controller.Player_FSM
{
    public abstract class PlayerState
    {
        public float horizontalSpeed;
        public float verticalSpeed;
        public Vector3 scale;
        
        public abstract void Start(PlayerMovement player);
        public abstract PlayerState Update(PlayerMovement player, bool onGround);
    }

    public class StandardState : PlayerState
    {
        public override void Start(PlayerMovement player)
        {
            Debug.Log("Standard State");

            horizontalSpeed = player.normalSpeed;
            verticalSpeed = 0f;
            scale = player.transform.localScale;
        }

        public override PlayerState Update(PlayerMovement player, bool onGround)
        {
            if (!onGround)
            {
                //return new FallingState();
            }
            
            if (Input.GetButtonDown("Jump"))
            {
                //return new JumpingState();
            }
            
            if (Input.GetButtonDown("Sprint"))
            {
                //return new SprintingState();
            }
            
            if (Input.GetButtonDown("Crouch"))
            {
                //return new CrouchingState();
            }
            
            return null;
        }
    }
    
    public class FallingState : PlayerState
    {
        public override void Start(PlayerMovement player)
        {
            Debug.Log("Falling State");
            
            horizontalSpeed = player.normalSpeed;
            verticalSpeed = 0f;
            scale = player.transform.localScale;
        }

        public override PlayerState Update(PlayerMovement player, bool onGround)
        {
            if (onGround)
            {
                new StandardState();
            }
            
            verticalSpeed -= player.gravity * Time.deltaTime;

            return null;
        }
    }
    
    public class JumpingState : PlayerState
    {
        public override void Start(PlayerMovement player)
        {
            Debug.Log("Jumping State");
            
            horizontalSpeed = player.normalSpeed;
            verticalSpeed = Mathf.Sqrt(player.jumpHeight * 2f * player.gravity);
            scale = player.transform.localScale;
        }

        public override PlayerState Update(PlayerMovement player, bool onGround)
        {
            if (onGround)
            {
                return new StandardState();
            }

            if (Input.GetButtonDown("Crouch"))
            {
                return new CrouchedJumpState();
            }
            
            verticalSpeed -= player.gravity * Time.deltaTime;
            
            return null;
        }
    }
    
    public class SprintingState : PlayerState
    {
        public override void Start(PlayerMovement player)
        {
            Debug.Log("Sprinting State");

            horizontalSpeed = player.normalSpeed * player.sprintSpeedMult;
            verticalSpeed = 0f;
            scale = player.transform.localScale;
        }

        public override PlayerState Update(PlayerMovement player, bool onGround)
        {
            if (Input.GetButtonUp("Sprint"))
            {
                return new StandardState();
            }

            if (Input.GetButtonDown("Jump"))
            {
                return new SprintJumpState();
            }
            
            return null;
        }
    }
    
    public class CrouchingState : PlayerState
    {
        public override void Start(PlayerMovement player)
        {
            Debug.Log("Crouching State");

            horizontalSpeed = player.normalSpeed * player.crouchSpeedMult;
            verticalSpeed = 0f;
            scale = player.transform.localScale * player.crouchFactor;
        }

        public override PlayerState Update(PlayerMovement player, bool onGround)
        {
            if (Input.GetButtonUp("Crouch"))
            {
                return new StandardState();
            }
            
            return null;
        }
    }
    
    public class SprintJumpState : PlayerState
    {
        public override void Start(PlayerMovement player)
        {
            Debug.Log("Sprint Jump State");

            horizontalSpeed = player.normalSpeed * player.sprintSpeedMult;
            verticalSpeed = Mathf.Sqrt(player.jumpHeight * 2f * player.gravity);
            scale = player.transform.localScale;
        }

        public override PlayerState Update(PlayerMovement player, bool onGround)
        {
            if (onGround)
            {
                return new SprintingState();
            }

            if (Input.GetButtonUp("Sprint"))
            {
                return new JumpingSprintSpeedState();
            }
            
            verticalSpeed -= player.gravity * Time.deltaTime;

            return null;
        }
    }
    
    public class CrouchedJumpState : PlayerState
    {
        public override void Start(PlayerMovement player)
        {
            Debug.Log("Crouched Jump State");
            
            horizontalSpeed = player.normalSpeed;
            verticalSpeed = player.vertSpeed;
            scale = player.transform.localScale * player.crouchFactor;
        }

        public override PlayerState Update(PlayerMovement player, bool onGround)
        {
            if (onGround)
            {
                return new CrouchingState();
            }

            if (Input.GetButtonUp("Crouch"))
            {
                return new JumpingState();
            }
            
            verticalSpeed -= player.gravity * Time.deltaTime;
            
            return null;
        }
    }
    
    public class JumpingSprintSpeedState : PlayerState
    {
        public override void Start(PlayerMovement player)
        {
            Debug.Log("Jump at-sprint-speed State");
            
            horizontalSpeed = player.normalSpeed * player.sprintSpeedMult;
            verticalSpeed = player.vertSpeed;
            scale = player.transform.localScale;
        }

        public override PlayerState Update(PlayerMovement player, bool onGround)
        {
            if (onGround)
            {
                return new StandardState();
            }

            if (Input.GetButtonDown("Crouch"))
            {
                return new CrouchedJumpSprintSpeedState();
            }
            
            verticalSpeed -= player.gravity * Time.deltaTime;
            
            return null;
        }
    }

    public class CrouchedJumpSprintSpeedState : PlayerState
    {
        public override void Start(PlayerMovement player)
        {
            Debug.Log("Crouched Jump at-sprint-speed State");
            
            horizontalSpeed = player.normalSpeed * player.sprintSpeedMult;
            verticalSpeed = player.vertSpeed;
            scale = player.transform.localScale * player.crouchFactor;
        }

        public override PlayerState Update(PlayerMovement player, bool onGround)
        {
            if (onGround)
            {
                return new StandardState();
            }
            
            if (Input.GetButtonUp("Crouch"))
            {
                return new JumpingSprintSpeedState();
            }
            
            verticalSpeed -= player.gravity * Time.deltaTime;

            return null;
        }
    }
}