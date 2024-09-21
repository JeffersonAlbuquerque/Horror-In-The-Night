using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lifePlayer : MonoBehaviour
{
    [Header("Life Player Settings")]
    public float life;
    public float lifeMaximum;
    [Header("Life Player HUD")]
    public Image lifeBar;
    public GameObject menuGameOver;
    public Animator MenuAnimation;
    [Header("Audio Effects")]
    public AudioSource gameOverSound;


    void Start()
    {
        life = lifeMaximum;
    }

    // Update is called once per frame
    void Update()
    {
        lifeBar.fillAmount = life / lifeMaximum;
        if (life <= 0)
        {
            audioEffect();
            life = 0;
            menuGameOver.SetActive(true);
            MenuAnimation.SetBool("MenuAnimationn", true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            reloadScene();
        }
    }

    public void reloadScene()
    {
        SceneManager.LoadScene("game");
    }
    public void audioEffect()
    {
        gameOverSound.Play();
    }

}
