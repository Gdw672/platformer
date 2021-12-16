using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


namespace playerAndJump
{

    

    public class Animation : MonoBehaviour
    {
        public SkeletonAnimation skeletonAnimation;
        public AnimationReferenceAsset idle, run, jump, falling, fallFin , runStart, firstHit, secondHit , jerk;
        private Rigidbody2D playerBody;
        public GameObject Ground;
        public string currentState;
        private string currentAnimation;
        private bool groundCheck, checkForStartRunning, isNormalRun, inAir;
        private float distance;

        private void Start()
        {
            checkForStartRunning = true;
            playerBody = GetComponent<Rigidbody2D>();
            currentState = "Idle";
            setCharacterState(currentState);
            isNormalRun = false;

            MoveAnim();
        }
        
        private void Update()
        {
            MoveAnim();

            if (MoveLeft.Pressed == true || MoveRight.Pressed == true || JumpScript.sumJump == 0 || groundCheck == true  || attackScript.isHit == true)
            {
                StopCoroutine("waitForIdle");
            }

            if (MoveLeft.Pressed == false && MoveRight.Pressed == false)
            {
                isNormalRun = false;

                StopCoroutine("waitForNormalRun");
            }
            print(currentAnimation);
           
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
            else if (state.Equals("jerk"))
            {
                setAnimation(jerk, true, 1f);
            }
            

            else if (state.Equals("runStart"))
                {
                    setAnimation(runStart, false, 1f);
                }

            else if (state.Equals("Idle"))
              {
                    setAnimation(idle, false, 1f);
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

              
                StartCoroutine("waitForNormalRun");


            }
            if(JumpScript.sumJump == 0 && JerkScript.isJerk == false && playerBody.velocity.y > 0)
            {
                setCharacterState("jump");
            }



            if (playerBody.velocity.y < -0.1f)
            {
                setCharacterState("falling");
            }
            if (JerkScript.isJerk == true)
            {
                setCharacterState("jerk");
            }

            if (groundCheck == true && JerkScript.isJerk == false)
            {
                setCharacterState("fallFin");
            }

           if(attackScript.isHit == true && JerkScript.isJerk == false)
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

          



            if (MoveLeft.Pressed == false && MoveRight.Pressed == false && JumpScript.sumJump != 0 && groundCheck == false && attackScript.isHit == false && JerkScript.isJerk == false)
            {
                setCharacterState("Idle");
            }

          //  if (MoveLeft.Pressed == false && MoveRight.Pressed == false && JumpScript.sumJump != 0 && groundCheck == false && attackScript.isHit == false)
          //  {
          //     StartCoroutine("waitForIdle");
          // }



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

        IEnumerator waitForIdle()
        {
            yield return new WaitForSeconds(6f);

            setCharacterState("Idle");
        }

        IEnumerator waitForNormalRun()
        {
            
            if(isNormalRun == false)
            setCharacterState("runStart");

            yield return new WaitForSeconds(0.2f);

            setCharacterState("run");
            isNormalRun = true;


        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Ground")
            {
                inAir = true;
            }
        }
    }
}
    

