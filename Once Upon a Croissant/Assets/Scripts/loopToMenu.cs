using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loopToMenu : MonoBehaviour
{
    public GameObject text, text1, text2;
    public GameObject fadeOut, endCredits, blackBackground;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loopMenu());
    }

    IEnumerator loopMenu() {
        //dialogue
        yield return new WaitForSeconds(2f);
        text.SetActive(true);
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
        text1.SetActive(true);
        yield return new WaitForSeconds(3f);
        text1.SetActive(false);
        text2.SetActive(true);
        yield return new WaitForSeconds(3f);
        text2.SetActive(false);
        yield return new WaitForSeconds(2f);

        //transition to end credits
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        blackBackground.SetActive(true);
        endCredits.SetActive(true);
        yield return new WaitForSeconds(20f);

        //back to menu
        SceneManager.LoadScene(0);
    }
}
