using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void loseGame(){
        Debug.Log("You Lost!");
        Invoke("stopTime", 2f);
    }

    public void winGame(){
        Debug.Log("You Win!");
        Invoke("stopTime", 2f);
    }

    void stopTime(){
        Time.timeScale = 0;
        Debug.Log("Game End");
    }
}
