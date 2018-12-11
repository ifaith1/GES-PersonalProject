﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    private AudioSource audioSource;

    private bool isPlayerInTrigger;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger)
        {
            audioSource.Play();
            Debug.Log("Player activated door.");
            SceneManager.LoadScene(sceneToLoad);
            Gem_Collect.count = 0;
            Collect.count = 0;
        }
    }
}
