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
            if (other.tag == "Enemy" && !EnemyBehaviour.instance.defense)
            {
                EnemyBehaviour.instance.die();
            }

            if (other.tag == "Enemy" && EnemyBehaviour.instance.defense)
            {
            }
        }

        else if (!isPlayer)
        {
            if (other.tag == "Player" && !PlayerActions.instance.defense)
            {
                PlayerActions.instance.die();
            }

            else if(other.tag == "Player" && PlayerActions.instance.defense)
            {
            }
        }
    }
}
