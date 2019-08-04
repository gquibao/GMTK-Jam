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
                EnemyBehaviour.instance.sword.enabled = false;
                AudioManager.instance.hit.Play();
                EnemyBehaviour.instance.die();
            }

            if (other.tag == "Enemy" && EnemyBehaviour.instance.defense)
            {
                AudioManager.instance.pClash.Play();
            }
        }

        else if (!isPlayer)
        {
            if (other.tag == "Player" && !PlayerActions.instance.defense)
            {
                AudioManager.instance.hit.Play();
                PlayerActions.instance.die();
            }

            else if(other.tag == "Player" && PlayerActions.instance.defense)
            {
                AudioManager.instance.eClash.Play();
            }
        }
    }
}
