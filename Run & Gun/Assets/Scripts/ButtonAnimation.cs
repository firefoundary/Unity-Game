using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator animator;

    public void OnPointerEnter(PointerEventData eventData) {
        animator.SetBool("Selected", true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        animator.SetBool("Selected", false);
    }
}
