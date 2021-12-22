using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


namespace playerAndJump {
    public class AnimTruck : MonoBehaviour
    {
        public SkeletonAnimation suicideAnim;
        public AnimationReferenceAsset run, shoot, death, takeDamage;
        private string currentAnimation;


        int hp;
        bool isHit, isShot, isDeath;
        private void Start()
        {
            
        }


        private void Update()
        {
            isHit = gameObject.GetComponent<enemyBehaviotLong>().afterKickPlayer;

            isShot = gameObject.GetComponent<enemyBehaviotLong>().isShot;

            hp = gameObject.GetComponent<takeDamage>().hp;

            isDeath = gameObject.GetComponent<takeDamage>().isDeath;

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
            else if(state.Equals("takeDamage"))
            {
                setAnimation(takeDamage, false, 1f);
            }
            else if(state.Equals("shoot"))
            {
                setAnimation(shoot, false, 1f);
            }
            else if (state.Equals("death"))
            {
                setAnimation(death, false, 1f);
            }




        }

        public void moveAnim()
        {
            if (isHit == true && isShot == false && isDeath == false)
            {
                setCharacterState("run");
            }

            else if (isHit == true && isShot == true && isDeath == false)
            {
                setCharacterState("shoot");
            }

            if(isHit == false && isDeath == false)
            {
                setCharacterState("takeDamage");
            }
            else if(isDeath == true)
            {
                StartCoroutine(startDeath());
            }
        }

        IEnumerator startDeath()
        {
            
            setCharacterState("death");

            yield return new WaitForSeconds(0.5f);

            Destroy(gameObject);
        }

    }
}