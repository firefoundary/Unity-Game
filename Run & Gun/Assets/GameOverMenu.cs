using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject gameOverMenu;

    public void respawn() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
