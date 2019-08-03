using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public static PlayerActions instance;

    public bool attacking = false;
    public bool defense = false;
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
            EnemyBehaviour.instance.isPlayerBlocking = false;
        }
        else if(!defense && !attacking)
        {
            attacking = true;
            anim.SetTrigger("Melee Right Attack 01");
            EnemyBehaviour.instance.isIncomingBlow = true;
        }
        attacking = false;
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.2f);
        defense = true;
        EnemyBehaviour.instance.isPlayerBlocking = true;
        anim.SetBool("Defend", defense);
    }

    public void die()
    {
        foreach(Collider collider in GetComponentsInChildren<Collider>())
        {
            collider.enabled = false;
        }
        anim.SetTrigger("Die");
    }
}
