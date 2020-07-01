using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject goMenu;
    public GameObject bossMenu;

    public void EndGame() {
        if (gameHasEnded == false) {

            gameHasEnded = true;
            goMenu.SetActive(true);
        }
    }

    public void BossChoice() {
        Debug.Log("bosschoice function called");
        bossMenu.SetActive(true);
    }

}
