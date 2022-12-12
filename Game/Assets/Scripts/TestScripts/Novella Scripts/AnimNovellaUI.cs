using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimNovellaUI : MonoBehaviour
{
    [SerializeField] private Animator animator;

   public void activateAnim()
    {
        animator.SetBool("isDark", true);
    }
}
