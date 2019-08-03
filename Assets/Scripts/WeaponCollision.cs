using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    public bool isPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer)
        {
            if (other.tag == "Enemy")
            {
                Debug.Log("Player Score");
                PlayerActions.instance.hit = true;
            }
        }

        else if (!isPlayer)
        {
            if (other.tag == "Player")
            {
                Debug.Log("Enemy Score");
            }
        }
    }
}
