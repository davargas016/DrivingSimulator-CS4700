using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void setUp(){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Prototype 1");
    }

    public void terminate(){
        Debug.Log("Game Ended");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
