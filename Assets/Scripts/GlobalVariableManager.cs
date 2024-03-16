using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableManager : MonoBehaviour
{
    // Static reference to the instance of this class
    private static GlobalVariableManager _instance;

    public bool[] levelProgress;

    private void Awake()
    {
        // If an instance doesn't exist, assign this instance as the persistent object
        if (_instance == null)
        {
            _instance = this;
            // Mark this object not to be destroyed when loading new scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this duplicate
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
