using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject prefabManager;
    public GameObject fade;
    private PrefabManager difficulty;

    void Start() {
        difficulty = prefabManager.GetComponent<PrefabManager>();
    }

    public void startGame() {
        StartCoroutine(startGameHelper());
        fade.SetActive(true);
    }

    public void loadGame() {
        StartCoroutine(loadGameHelper());
        fade.SetActive(true);
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

    IEnumerator startGameHelper() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

     IEnumerator loadGameHelper() {
        ProgressData data = SaveSystem.LoadProgress();

        Debug.Log("loading game with sceneIndex " + data.progress);

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(data.progress);
    }

    
}
