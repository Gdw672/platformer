using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


namespace playerAndJump
{



    public class Animation : MonoBehaviour
    {
        private playerCreatePatrons playerBulletAnim;
        private strongAttack strong;
        private wallAndPlayerReaction wall;
        public SkeletonAnimation skeletonAnimation;
        public AnimationReferenceAsset idleFromTime, idleDefoult, run, jump, falling, firstHit, secondHit, hitOnRun, hitonAir, jerk, takeDamage, slidingWall, strongAttack1, strongAttack2, rangeAttack, rangeAttackAir;
        private Rigidbody2D playerBody;
        public string currentState;
        private string currentAnimation;
        private bool groundCheck, isStartIdle, isStartIdleCor;
        internal byte sumOfGround;
        private void Start()
        {
            playerBulletAnim = GetComponent<playerCreatePatrons>();
            strong = transform.GetChild(0).GetComponent<strongAttack>();
            wall = gameObject.GetComponent<wallAndPlayerReaction>();
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
            else if (state.Equals("idleFromTime"))
            {
                setAnimation(idleFromTime, false, 1f);
            }

            else if (state.Equals("slidingWall"))
            {
                setAnimation(slidingWall, true, 1f);
            }
            else if (state.Equals("strongAttack1"))
            {
                setAnimation(strongAttack1, true, 1f);
            }
            else if (state.Equals("strongAttack2"))
            {
                setAnimation(strongAttack2, false, 1f);
            }
            else if (state.Equals("rangeAttack"))
            {
                setAnimation(rangeAttack, false, 1.25f);
            }
            else if (state.Equals("rangeAttackAir"))
            {
                setAnimation(rangeAttackAir, false, 1f);
            }

        }
        public void MoveAnim()
        {
            if (playerHp.isTakeDamage == false &&  strong.attackIsStart == false && playerBulletAnim.isReadyPatron == true)
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
                

                if (playerBody.velocity.y < -0.1f && attackScript.isHit == false && wall.onWall == false)
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
                if (moveLeft.Pressed == false && moveRight.Pressed == false && JumpScript.sumJump > 0 && attackScript.isHit == false && JerkScript.isJerk == false && sumOfGround > 0)
                {
                    if(isStartIdle == false)
                    {
                        setCharacterState("idleDefoult");
                   
                    }
                    if(isStartIdleCor == false)
                    {
                        StartCoroutine(waitForAnimationIdle());
                    }
                }


                if(wall.onWall == true)
                {
                    setCharacterState("slidingWall");
                }
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


            if (playerBulletAnim.isReadyPatron == false && sumOfGround > 0)
            {
                setCharacterState("rangeAttack");
            }

            if(playerBulletAnim.isReadyPatron == false && sumOfGround == 0)
            {
                setCharacterState("rangeAttackAir");
            }

            if(strong.attackIsStart == true && strong.isStrongAttack == false && attackScript.isHit == false) 
            {
                setCharacterState("strongAttack1");
            }
            if (strong.isStrongAttack == true && strong.attackIsStart)
            {
                setCharacterState("strongAttack2");
            }

            if (playerHp.isTakeDamage == true)
                setCharacterState("takeDamage");
            
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                print(sumOfGround);


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
            isStartIdleCor = true;
            yield return new WaitForSeconds(10f);

            if(moveLeft.Pressed == false && moveRight.Pressed == false && JumpScript.sumJump > 0 && attackScript.isHit == false && JerkScript.isJerk == false && sumOfGround > 0)
            {
                isStartIdle = true;

                setCharacterState("idleFromTime");

                yield return new WaitForSeconds(2f);
                isStartIdle = false;
            }

            isStartIdleCor = false;
           
        }

        IEnumerator checkGround()
        {
            yield return new WaitForSeconds(0.01f);

        }
    }
}
    

