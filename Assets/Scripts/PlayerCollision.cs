using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public void Update()
    {
      
    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Enemy")
    //    {
    //        Debug.Log("a");
    //        HealthManager.health = HealthManager.health --;
    //        if (HealthManager.health <= 0)
    //        {
    //            Debug.Log("a");
    //            GameManager.isGameOver = true;
    //            AudioManager.instance.Play("gameover");
    //            //   gameObject.SetActive(false);
    //        }
    //        else
    //        {

    //            AudioManager.instance.Play("oof");
    //            StartCoroutine(GetHurt());
    //        }
    //    }
    //    if (collision.transform.tag == "Spike")
    //    {
    //        HealthManager.health = HealthManager.health - 3;
    //        if (HealthManager.health <= 0)
    //        {
    //            GameManager.isGameOver = true;
    //            AudioManager.instance.Play("gameover");
    //            //   gameObject.SetActive(false);
    //        }
    //        else
    //        {
    //            AudioManager.instance.Play("oof");
    //            StartCoroutine(GetHurt());
    //        }
    //    }
    //    if (collision.transform.tag == "door")
    //    {
    //        Debug.Log("work");
    //        AudioManager.instance.Play("levelcomplete");
    //        GameManager.isGamefinish = true;
    //    }
    //}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            HealthManager.health = HealthManager.health -1;
            if (HealthManager.health <= 0)
            {
                Debug.Log("a");
                GameManager.isGameOver = true;
               AudioManager.instance.Play("gameover");
                gameObject.SetActive(false);
            }
            else
{

    AudioManager.instance.Play("oof");
    StartCoroutine(GetHurt());
}
        }
        if (collision.transform.tag == "Spike")
{
    HealthManager.health = HealthManager.health - 3;
    if (HealthManager.health <= 0)
    {
        GameManager.isGameOver = true;
        AudioManager.instance.Play("gameover");
        gameObject.SetActive(false);
    }
    else
    {
        AudioManager.instance.Play("oof");
        StartCoroutine(GetHurt());
    }
}
if (collision.transform.tag == "door")
{
    Debug.Log("work");
    AudioManager.instance.Play("levelcomplete");
    GameManager.isGamefinish = true;
}
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(7, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(7, 8, false);

    }
}
