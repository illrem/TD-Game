﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{
    public void Nextlevel()
    {
        //reset the wave
        WaveSpawner.Currentwave = "0";
        //Loading the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
