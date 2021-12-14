using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


namespace playerAndJump
{

    

    public class Animation : MonoBehaviour
    {
        public SkeletonAnimation skeletonAnimation;
        public AnimationReferenceAsset idle, run, jump, falling, fallFin , runStart, firstHit, secondHit;
        private Rigidbody2D playerBody;
        public GameObject Ground;
        public string currentState;
        private string currentAnimation;
        private bool groundCheck, checkForStartRunning;
        private float distance;

        private void Start()
        {
            checkForStartRunning = true;
            playerBody = GetComponent<Rigidbody2D>();
            currentState = "Idle";
            setCharacterState(currentState);
        }
        
        private void Update()
        {
            MoveAnim();
        }

        
        public void setAnimation(AnimationReferenceAsset animation , bool loop, float timeScale)
        {
            if(animation.name.Equals(currentAnimation))
            {

                return;
            }

            skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
            currentAnimation = animation.name;
        }

        public void setCharacterState(string state)
        {

            if (state.Equals("run"))
            {
                setAnimation(run, true, 1f);
            }
            else if(state.Equals("jump"))
            {
                setAnimation(jump, false, 1f);
            }
            else if(state.Equals("fallFin"))
            {
                setAnimation(fallFin, false, 1.5f);
            }
            else if(state.Equals("falling"))
            {
                print("you are fall");

                setAnimation(falling, true, 1f);
            }
            else if(state.Equals("firstHit"))
            {
                setAnimation(firstHit, false, 1f);
            }
            else if (state.Equals("secondHit"))
            {
                setAnimation(secondHit, false, 1f);
            }

            else if (state.Equals("Idle"))
            {
                setAnimation(idle, true, 1f);
            }
        }

        public void MoveAnim()
        {
            
            if ((MoveLeft.Pressed == true) || (MoveRight.Pressed == true ))
            {
                if(JerkScript.testRotation == 0)   
                    transform.localScale = new Vector2(-0.25f, 0.25f);

                if (JerkScript.testRotation == 1)
                    transform.localScale = new Vector2(0.25f, 0.25f);
                setCharacterState("run");
                
               
            }
            if(JumpScript.sumJump == 0 && groundCheck == false)
            {
                setCharacterState("jump");
            }

            if(playerBody.velocity.y < -0.1f)
            {
                setCharacterState("falling");
            }


           if(groundCheck == true)
            {
                setCharacterState("fallFin");
            }

           if(attackScript.isHit == true)
            {
                if(attackScript.testHitOf % 2 == 0 )
                {
                    setCharacterState("firstHit");

                }
                if(attackScript.testHitOf % 2 != 0)
                {
                    setCharacterState("secondHit");
                }
            }

            if (MoveLeft.Pressed == false && MoveRight.Pressed == false && JumpScript.sumJump != 0 && groundCheck == false && attackScript.isHit == false)
            {
                setCharacterState("Idle");
            }
            
            

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                if(MoveRight.Pressed == false && MoveLeft.Pressed == false)

                groundCheck = true;

                StartCoroutine("landingTime");
            }
        }

        IEnumerator landingTime()
        {
            yield return new WaitForSeconds(0.3f);

            groundCheck = false;

        }

      

    }

    

}