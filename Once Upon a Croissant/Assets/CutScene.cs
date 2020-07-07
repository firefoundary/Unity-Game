using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;



public class CutScene : MonoBehaviour
{
    public PlayableAsset cutscene;

    // Start is called before the first frame update
    void Start()
    {
        float duration = (float) cutscene.duration;
		Invoke("LoadNextLevel", duration);
    }


    public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
