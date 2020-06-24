using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject goMenu;

    public void EndGame() {
        if (gameHasEnded == false) {

            gameHasEnded = true;
            goMenu.SetActive(true);
        }
    }

}
