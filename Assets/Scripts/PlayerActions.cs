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
    public Collider sword;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        sword.enabled = false;
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
            attack();
        }
        attacking = false;
    }

    public void attack()
    {
        attacking = true;
        anim.SetTrigger("Attack");
        EnemyBehaviour.instance.isIncomingBlow = true;
    }

    public void attackSFX()
    {
        sword.enabled = true;
        AudioManager.instance.pMove.Play();
    }

    public void onSwordExit()
    {
        sword.enabled = false;
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
        EnemyBehaviour.instance.gameObject.GetComponent<Collider>().enabled = false;
        foreach (Collider collider in GetComponentsInChildren<Collider>())
        {
            collider.enabled = false;
        }
        anim.SetTrigger("Die");
        StartCoroutine(endGame());
    }

    public void diedAnim()
    {
        StartCoroutine(endGame());
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(1);
        UIManager.instance.gameOver.gameObject.SetActive(true);
        UIManager.instance.gameOver.sprite = UIManager.instance.defeat;
        UIManager.instance.returnToMenu();
    }
}
