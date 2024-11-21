using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play()
    {
        Application.LoadLevel("Game Play"); 
    }
    public void Restart()
    {
        Application.LoadLevel("Game Play");
    }
    public void Proceed()
    {
        Application.LoadLevel("Game Play");
    }
}
