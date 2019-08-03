using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public static PlayerActions instance;

    bool attack = false;
    bool defense = false;
    public bool hit = false;
    public Animator anim;

    private void Awake()
    {
        instance = this;
    }

    public void OnClickEnter()
    {
        StartCoroutine(timer());
    }

    public void OnClickExit()
    {
        StopAllCoroutines();
        if(defense)
        {
            defense = false;
            anim.SetBool("Defend", defense);
        }
        else if(!defense && !attack)
        {
            attack = true;
            anim.SetTrigger("Melee Right Attack 01");
        }
        attack = false;
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.2f);
        defense = true;
        anim.SetBool("Defend", defense);
    }

}
