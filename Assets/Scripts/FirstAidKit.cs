using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private int addHealt = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (player.life == 5)
                addHealt = 0;

            player.life += addHealt;

            Destroy(gameObject);
        }

   
}
}
