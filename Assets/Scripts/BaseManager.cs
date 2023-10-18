using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BaseState
{
    Opened,
    Closed
}
public class BaseManager : MonoBehaviour
{
    public string baseName = "Mine"; 
    public BaseState currentState;

    [SerializeField]
    private Mine mine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
