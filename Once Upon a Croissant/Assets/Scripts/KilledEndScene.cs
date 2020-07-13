using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledEndScene : MonoBehaviour
{
    public GameObject portal;

    private LevelLoader level;

    // Start is called before the first frame update
    void Start()
    {
        level = portal.GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadKilledScene() {
        portal.SetActive(true);
        level.LoadNextLevel();
    }
}
