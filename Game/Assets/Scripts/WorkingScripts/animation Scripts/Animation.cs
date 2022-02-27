using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


namespace playerAndJump
{



    public class Animation : MonoBehaviour
    {
        public SkeletonAnimation skeletonAnimation;
        public AnimationReferenceAsset idleFromTime, idleDefoult, run, jump, falling, fallFin, runStart, firstHit, secondHit, hitOnRun, hitonAir, jerk, takeDamage;
        private Rigidbody2D playerBody;
        public string currentState;
        private string currentAnimation;
        private bool groundCheck;
        protected internal bool inAir;
        internal byte sumOfGround;
        private void Start()
        {
            playerBody = GetComponent<Rigidbody2D>();
            currentState = "Idle";
            setCharacterState(currentState);
            sumOfGround = 0;

            MoveAnim();
        }

        private void Update()
        {
            MoveAnim();
         
            if (JerkScript.testRotation == 0)
                transform.localScale = new Vector2(-1f, 1f);

            if (JerkScript.testRotation == 1)
                transform.localScale = new Vector2(1f , 1f);
        }


        public void setAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
        {
            if (animation.name.Equals(currentAnimation))
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
            else if (state.Equals("jump"))
            {
                setAnimation(jump, false, 1f);
            }
            else if (state.Equals("fallFin"))
            {
                setAnimation(fallFin, false, 1.5f);
            }
            else if (state.Equals("falling"))
            {
                setAnimation(falling, true, 1f);
            }
            else if (state.Equals("firstHit"))
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

            else if (state.Equals("idleDefoult"))
            {
                setAnimation(idleDefoult, true, 1f);
            }

            else if (state.Equals("hitonAir"))
            {
                setAnimation(hitonAir, false, 1f);
            }

            else if (state.Equals("hitOnRun"))
            {
                setAnimation(hitOnRun, false, 1f);
            }
            else if(state.Equals("takeDamage"))
            {
                setAnimation(takeDamage, false, 1f);
            }

            else if (state.Equals("runStart"))
            {
                setAnimation(runStart, false, 1f);
            }

            else if (state.Equals("idleFromTime"))
            {
                setAnimation(idleFromTime, false, 1f);
            }
        }
        public void MoveAnim()
        {
            if (playerHp.isTakeDamage == false)
            {

                if ((moveLeft.Pressed == true || moveRight.Pressed == true) && attackScript.isHit == false && JerkScript.isJerk == false && sumOfGround > 0)
                {
                    setCharacterState("run");
                }

                if (JumpScript.sumJump < 2 && JerkScript.isJerk == false && playerBody.velocity.y > 0 && attackScript.isHit == false)
                {
                    setCharacterState("jump");
                }

                if (JerkScript.isJerk == true)
                {
                    setCharacterState("jerk");
                }
                

                if (playerBody.velocity.y < -0.1f && attackScript.isHit == false)
                {
                    setCharacterState("falling");
                }

                if (groundCheck == true && JerkScript.isJerk == false)
                {
                    setCharacterState("fallFin");
                }

                if ((moveLeft.Pressed == true && attackScript.isHit == true && sumOfGround > 0 && JerkScript.isJerk == false)
                    || (moveRight.Pressed == true && attackScript.isHit == true && sumOfGround > 0 && JerkScript.isJerk == false))
                {
                    setCharacterState("hitOnRun");
                }

                if (attackScript.isHit == true && JerkScript.isJerk == false && sumOfGround == 0)
                {
                    setCharacterState("hitonAir");
                }

                if (attackScript.isHit == true && JerkScript.isJerk == false && sumOfGround > 0 && moveRight.Pressed == false && moveLeft.Pressed == false)
                {
                    if (attackScript.testHitOf % 2 == 0)
                    {
                        setCharacterState("firstHit");
                    }
                    if (attackScript.testHitOf % 2 != 0)
                    {
                        setCharacterState("secondHit");
                    }
                }

                if (moveLeft.Pressed == false && moveRight.Pressed == false && JumpScript.sumJump > 0 && attackScript.isHit == false && JerkScript.isJerk == false && sumOfGround > 0)
                {
                    setCharacterState("idleDefoult");
                }
            }

            if (playerHp.isTakeDamage == true)
                setCharacterState("takeDamage");
            
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                sumOfGround += 1;

            }
        }

        void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.tag == "Ground")
            {
                sumOfGround -= 1;
            }
        }
        IEnumerator landingTime()
        {
            yield return new WaitForSeconds(0.3f);

            groundCheck = false;

        }

        IEnumerator waitForAnimationIdle()
        {
            yield return new WaitForSeconds(3f);

            setCharacterState("idleFromTime");
        }

        IEnumerator checkGround()
        {
            yield return new WaitForSeconds(0.01f);

        }
    }
}
    

