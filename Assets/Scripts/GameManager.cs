using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool menu = false;
    public Animator animator;
    public static bool isGameOver = false;
    public static bool isGamefinish = false;

    public TextMeshProUGUI coinsUI;

    public GameObject Player;
    public Transform PlayerSpawner;
    public CinemachineVirtualCamera VCam;
    public static int numberOfCoins;

    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public GameObject VictoryPanel;
    private void Awake()
    {
        Time.timeScale = 1;
        numberOfCoins = 0;
        isGameOver = false;
        isGamefinish = false;
        if (menu == false)
        {
            VCam.m_Follow = Player.transform;
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        if (menu == true)
        {
            AudioManager.instance.Play("menu");
        }
        else
        {
            AudioManager.instance.Play("Theme");
        }
    }
    // Update is called once per frame
    void Update()
    {
        

        if (menu == false)
        {
            coinsUI.text = (numberOfCoins) +"/10";
            if (isGameOver == true)
            {
                PlayerDeath();
            }
            if(isGamefinish==true)
            {
                victory();
            }
        }

    }
    public void Pause()
    {
        AudioManager.instance.Play("click");
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Retry()
    {
        AudioManager.instance.Play("click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Resume()
    {
        AudioManager.instance.Play("click");
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void PlayerDeath()
    {
        animator.SetTrigger("dead");
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);

        Debug.Log("ded");
        //  PolygonCollider2D c = Player.GetComponent<PolygonCollider2D>();
        // c.enabled = false;
    }
        public void play()
        {
        AudioManager.instance.Play("click");
        SceneManager.LoadScene(1);
       }
    public void menuscene()
    {
        AudioManager.instance.Play("click");
        SceneManager.LoadScene(0);
    }
    public void victory()
    {
        Debug.Log("2");
       
        Time.timeScale = 0;
        VictoryPanel.SetActive(true);
    }

    public void Level1()
    {
        AudioManager.instance.Play("click");
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        AudioManager.instance.Play("click");
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        AudioManager.instance.Play("click");
        SceneManager.LoadScene(3);
    }
}
