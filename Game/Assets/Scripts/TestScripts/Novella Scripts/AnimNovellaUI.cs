using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimNovellaUI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject cityBack, roomBack;
   public void activateAnim()
    {
        animator.SetBool("isDark", true);
    }

    public void activateRoomBack()
    {
        cityBack.SetActive(false);
        roomBack.SetActive(true);
    }
}
