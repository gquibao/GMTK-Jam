using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public static EnemyBehaviour instance;

    public Animator anim;

    public Image feedback;

    public Sprite attackFeedback;
    public Sprite defenseFeedback;

    private int offensive = 5;
    private int defensive = 5;
    private float responseTime = 0.5f;
    [SerializeField]
    private float fatigue = 0;

    public bool defense = false;
    public bool isResting = false;
    public bool isIncomingBlow = false;
    public bool isPlayerBlocking = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(enemyAction(1));
    }

    private void Update()
    {
        if (isIncomingBlow && !isResting)
        {
            StopAllCoroutines();
            StartCoroutine(defend(0f));
            isIncomingBlow = false;
        }
    }

    IEnumerator enemyAction(float time)
    {
        feedback.enabled = false;
        yield return new WaitForSeconds(time);

        if (random() > 5 && fatigue < 5)
        {
            if (!isPlayerBlocking)
            {
                if (random() < 70)
                {
                    StopAllCoroutines();
                    StartCoroutine(attack());
                }
            }

            else
            {
                if (offensive > defensive)
                {
                    if (random() > 100 - (offensive * 10))
                        StartCoroutine(attack());

                    else
                        StartCoroutine(defend(0.5f));
                }

                else if (offensive < defensive)
                {
                    if (random() > 100 - (defensive * 10))
                        StartCoroutine(defend(0.5f));

                    else
                        StartCoroutine(attack());
                }

                else
                {
                    if (random() > 50)
                    {
                        StartCoroutine(attack());
                    }

                    else
                    {
                        StartCoroutine(defend(0.5f));
                    }
                }
            }
        }

        else
        {
            fatigue -= 5;
            if (fatigue < 0)
                fatigue = 0;

            if (fatigue > 10)
                StartCoroutine(enemyAction(responseTime + 1));

            else
                StartCoroutine(enemyAction(responseTime));
        }
    }

    IEnumerator defend(float feedbackTime)
    {
        feedback.enabled = true;
        feedback.sprite= defenseFeedback;
        yield return new WaitForSeconds(feedbackTime);
        feedback.enabled = false;
        defense = true;
        anim.SetBool("Defend", defense);
        yield return new WaitForSeconds(2);
        defense = false;
        anim.SetBool("Defend", defense);
        offensive++;
        defensive--;
        isResting = true;
        StartCoroutine(enemyAction(responseTime));
        yield return new WaitForSeconds(0.5f);
        isResting = false;
    }

    IEnumerator attack()
    {
        feedback.enabled = true;
        feedback.sprite = attackFeedback;
        yield return new WaitForSeconds(0.2f);
        feedback.enabled = false;
        anim.SetTrigger("Melee Right Attack 01");
        offensive--;
        defensive++;
        fatigue++;
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
        feedback.enabled = false;
        anim.SetTrigger("Die");
        enabled = false;
        StartCoroutine(endGame());
    }


IEnumerator endGame()
{
    yield return new WaitForSeconds(2);
    UIManager.instance.gameOver.gameObject.SetActive(true);
    UIManager.instance.gameOver.sprite = UIManager.instance.victory;
}
}
