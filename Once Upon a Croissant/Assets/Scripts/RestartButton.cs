using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{

	// restarts game 
    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
