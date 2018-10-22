using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour {

    public RuntimeAnimatorController anim;
    public float length;

    public void Awake()
    {
        GetComponent<Animator>().runtimeAnimatorController = anim;
        Destroy(gameObject,length);
    }

}
