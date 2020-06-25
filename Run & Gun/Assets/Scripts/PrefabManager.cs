using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{

    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEasy() {
        Prefab.GetComponent<Player>().numOfHearts = 10;
        Prefab.GetComponent<Player>().health = 10;
    }
    
    public void SetNormal() {
        Prefab.GetComponent<Player>().numOfHearts = 6;
        Prefab.GetComponent<Player>().health = 6;
    }

    public void SetHard() {
        Prefab.GetComponent<Player>().numOfHearts = 3;
        Prefab.GetComponent<Player>().health = 3;
    }
}
