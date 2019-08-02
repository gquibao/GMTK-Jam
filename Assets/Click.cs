using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    bool attack = false;
    bool defense = false;

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
            Debug.Log("Defendendo: " + defense);
        }
        else if(!defense && !attack)
        {
            attack = true;
            Debug.Log("Atacando: " + attack);
        }
        attack = false;
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.2f);
        defense = true;
        Debug.Log("Defendendo: " + defense);
    }

}
