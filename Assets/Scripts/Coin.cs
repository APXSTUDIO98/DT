using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.gameObject.tag == "Player")
        {

            GameManager.numberOfCoins++;
            AudioManager.instance.Play("coin");

            Destroy(gameObject);

        }
    }

   
}
