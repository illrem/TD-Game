using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{    public void reset()
    {
        //Loading the game
        Cash.cashNumber = 200;
        SceneManager.LoadScene(1);
    }
}
