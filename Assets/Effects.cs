/*
 * called from "BarrelExplosion.anim"
 * in the animation at the end is an event trigger
 * to set off the "spijkerbom"
 * 
 * - attached to the Exploding Barrel object in hierarchy
 */

using UnityEngine;
using System.Collections;

public class Effects : MonoBehaviour 
{

    [SerializeField]
    private GameObject SpijkerBom;
    [SerializeField]
    private Animator Gravity;

    public void EnableSpijkerBom()
    {
        SpijkerBom.SetActive(true);
    }

    public void DisableAnimator()
    {
        Gravity.enabled = false;
    }
}
