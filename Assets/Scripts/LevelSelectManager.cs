using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    private GlobalVariableManager globalVariableManager;
    public int levelIndex;
    public GameObject lockedIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        globalVariableManager = GameObject.FindGameObjectsWithTag("GVM")[0].GetComponent<GlobalVariableManager>();
        if (globalVariableManager.levelProgress[levelIndex - 1])
        {
            lockedIcon.SetActive(false);
        }
        else
        {
            lockedIcon.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterLevel()
    {
        if (globalVariableManager.levelProgress[levelIndex - 1])
        {
            SceneManager.LoadScene(1 + levelIndex);
        }
        else
        {
            Debug.Log("level locked!");
        }
    }
}
