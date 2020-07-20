using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class LevelLoader : MonoBehaviour
{
	public Animator transition;
	public TextMeshProUGUI levelText;
	public float transitionTime = 1f;
	private bool portalReady = false;

	public bool bossSpared;


	// Update is called once per frame
    void Update()
    {
		if (portalReady && Input.GetKeyDown(KeyCode.E) && bossSpared) {
			LoadSparedScene();
			return;
		}

	    if (portalReady && Input.GetKeyDown(KeyCode.E))
		    LoadNextLevel();
    }

	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			portalReady = true;
			levelText.gameObject.SetActive(true);
		}
	}

	void OnTriggerExit2D (Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			portalReady = false;
			levelText.gameObject.SetActive(false);
		}
	}

	public void LoadNextLevel()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
		SaveSystem.SaveProgress();
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

	public void LoadSparedScene() {
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
	}

	public void SetSparedTrue() {
		bossSpared = true;
	}

}
