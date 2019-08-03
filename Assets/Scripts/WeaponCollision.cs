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
                UIManager.instance.resultadoPlayer.text = "Player Score";
                PlayerActions.instance.hit = true;
            }

            if (other.tag == "Enemy" && EnemyBehaviour.instance.defense)
            {
                UIManager.instance.resultadoPlayer.text = "Enemy Defended";
            }
        }

        else if (!isPlayer)
        {
            if (other.tag == "Player" && !PlayerActions.instance.defense)
            {
                UIManager.instance.resultadoEnemy.text = "Enemy Score";
            }

            else if(other.tag == "Player" && PlayerActions.instance.defense)
            {
                UIManager.instance.resultadoEnemy.text = "Player Defended";
            }
        }
    }
}
