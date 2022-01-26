using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

namespace playerAndJump {
    public class SuicideAnim : MonoBehaviour
    {

        public SkeletonAnimation suicideAnim;
        public AnimationReferenceAsset run, explosion;
        private string currentAnimation;


        bool huntOrNo, triggEnt;
        private void Start()
        {
            triggEnt = false;
        }


        private void Update()
        {
            huntOrNo = GetComponent<EnemyBehavior>().isHunt;

            moveAnim();

           
            
        }


        public void setAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
        {
            if (animation.name.Equals(currentAnimation))
            {
                return;
            }

            suicideAnim.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
            currentAnimation = animation.name;
        }

        public void setCharacterState(string state)
        {


            if (state.Equals("run"))
            {
                setAnimation(run, true, 1f);
            }
            else if(state.Equals("explosion"))
            {
                setAnimation(explosion, false, 1f);
            }
           

        }

        public void moveAnim()
        {
            if (huntOrNo == true && triggEnt == false) 
            {
                setCharacterState("run");
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "KickPlayer" || collision.gameObject.tag == "strongAttack" || collision.gameObject.tag == "shadowOfPlayer")
            {
                triggEnt = true;

                GetComponent<BoxCollider2D>().enabled = false;

                setCharacterState("explosion");

                StartCoroutine(startDeath());
                
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
           
                if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "bulletPlayer")
                {
                    triggEnt = true;

                    GetComponent<BoxCollider2D>().enabled = false;

                    setCharacterState("explosion");

                    StartCoroutine(startDeath());

                }
            
        }


        IEnumerator startDeath()
        {
            yield return new WaitForSeconds(0.5f);

            Destroy(gameObject);
        }
    }

    

}