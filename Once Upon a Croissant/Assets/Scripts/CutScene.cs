using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;



public class CutScene : MonoBehaviour
{
    public PlayableAsset cutscene;
    public bool restartGame;

    // Start is called before the first frame update
    void Start()
    {
        float duration = (float) cutscene.duration;

        if (restartGame) {
            Invoke("loopGame", duration);
            return;
        } 
        else
		    Invoke("LoadNextLevel", duration);
    }


    public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void loopGame()
	{
		SceneManager.LoadScene(0);
	}

}
