using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI TreasureCountertxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TreasureCountertxt.text = "Treasure Counter: " + PlayerMovement.TreasureCounter.ToString();
    }
}
