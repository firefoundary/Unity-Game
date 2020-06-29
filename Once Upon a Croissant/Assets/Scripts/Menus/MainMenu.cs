using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject prefabManager;
    private PrefabManager difficulty;

    void Start() {
        difficulty = prefabManager.GetComponent<PrefabManager>();
    }

    public void startGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void setEasy() {
        difficulty.SetEasy();
    }

    public void setNormal() {
        difficulty.SetNormal();
    }

    public void setHard() {
        difficulty.SetHard();
        
    }
    
}
