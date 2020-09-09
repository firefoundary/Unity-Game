using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject fade;
    public GameObject bossButton;

    void Awake() {
        ProgressData data = SaveSystem.LoadProgress();
        if (data.beatBoss)
            bossButton.SetActive(true);
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

    public void loadBossBattle() {
        StartCoroutine(loadBossHelper());
        fade.SetActive(true);
    }

    IEnumerator loadBossHelper() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Boss Battle");
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
