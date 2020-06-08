using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public Animator transition;
	public float transitionTime = 1f;
	private bool portalReady = false;

	// Update is called once per frame
    void Update()
    {
	    if (portalReady && Input.GetKeyDown(KeyCode.E))
		    LoadNextLevel();
    }

	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
			portalReady = true;
	}

	void OnTriggerExit2D (Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
			portalReady = false;
	}

	public void LoadNextLevel()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
	}

	IEnumerator LoadLevel(int levelIndex)
	{
		//Play animation
		transition.SetTrigger("Start");

		//Wait
		yield return new WaitForSeconds(transitionTime);

		//Load scene
		SceneManager.LoadScene(levelIndex);
	}
}
