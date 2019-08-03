using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public static EnemyBehaviour instance;

    public Animator anim;

    [Header("Atributos")]
    public int offensive = 0;
    public int defensive = 0;
    public int responseTime = 0;

    public bool defense = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(defend());
        StartCoroutine(enemyAction(0));
    }

    

    IEnumerator enemyAction(int repeatTime)
    {
        yield return new WaitForSeconds(repeatTime);
        int chance = random();
        if(chance < 20)
        {
            anim.SetTrigger("Melee Right Attack 01");
            if(chance < 5)
            {
                repeatTime = 0;
            }

            else
            {
                repeatTime = 1;
            }
        }

        else if(chance >= 20 && chance < 55)
        {
            StartCoroutine(defend());
            repeatTime = 1;
        }

        StartCoroutine(enemyAction(repeatTime));
    }

    IEnumerator defend()
    {
        defense = true;
        anim.SetBool("Defend", defense);
        yield return new WaitForSeconds(2);
        defense = false;
        anim.SetBool("Defend", defense);
    }

    int random()
    {
        return Random.Range(0, 101);
    }
}
