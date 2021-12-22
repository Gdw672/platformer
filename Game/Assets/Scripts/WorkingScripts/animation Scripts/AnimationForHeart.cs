using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

namespace playerAndJump
{
    public class AnimationForHeart : MonoBehaviour
    {
        public SkeletonGraphic uiHeart;
        public AnimationReferenceAsset basqe, lifeMinus, lifePlus, move;
        public string currentState;
        float hpForAnim;

        private void Start()
        {
            hpForAnim = playerHp.hp;
            uiHeart.AnimationState.SetAnimation(0, lifeMinus, false);
        }

        private void Update()
        {
            if(hpForAnim != playerHp.hp)
            {
                uiHeart.AnimationState.SetAnimation(0, move, false);
                StartCoroutine(defoultPosition());
                hpForAnim = playerHp.hp;
            }
        }

        private IEnumerator defoultPosition()
        {
            yield return new WaitForSeconds(0.4f);

            uiHeart.AnimationState.SetAnimation(0, lifeMinus, false);
             
        }

    }

    
}


