using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public static EnemyBehaviour instance;

    public Animator anim;

    public Image feedback;
    
    private int offensive = 5;
    private int defensive = 5;
    private int responseTime = 1;

    public bool defense = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //StartCoroutine(defend());
        StartCoroutine(enemyAction(0));
    }

    IEnumerator enemyAction(int time)
    {
        feedback.color = Color.white;
        yield return new WaitForSeconds(time);

        if(random() > 5)
        {
            if(offensive > defensive)
            {
                if (random() > 100-(offensive*10))
                    StartCoroutine(attack());

                else
                    StartCoroutine(defend());
            }

            else if(offensive < defensive)
            {
                if (random() > 100 - (defensive * 10))
                    StartCoroutine(defend());

                else
                    StartCoroutine(attack());
            }

            else
            {
                if(random() > 50)
                {
                    StartCoroutine(attack());
                }

                else
                {
                    StartCoroutine(defend());
                }
            }
        }

        else
        {
            StartCoroutine(enemyAction(responseTime));
        }
    }

    IEnumerator defend()
    {
        feedback.color = Color.blue;
        yield return new WaitForSeconds(0.5f);
         defense = true;
        anim.SetBool("Defend", defense);
        yield return new WaitForSeconds(2);
        defense = false;
        anim.SetBool("Defend", defense);
        offensive++;
        defensive--;
        StartCoroutine(enemyAction(responseTime));
    }

    IEnumerator attack()
    {
        feedback.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("Melee Right Attack 01");
        offensive--;
        defensive++;
        StartCoroutine(enemyAction(responseTime));
    }

    int random()
    {
        return Random.Range(0, 101);
    }

    public void die()
    {
        foreach (Collider collider in GetComponentsInChildren<Collider>())
        {
            collider.enabled = false;
        }
        anim.SetTrigger("Die");
    }
}
