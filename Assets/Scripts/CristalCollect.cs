using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CristalCollect : MonoBehaviour
{

    public static int cristalCount;
    private Text cristalCounter;




    void Start()
    {
        cristalCounter = GetComponent<Text>();
        cristalCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        cristalCounter.text = "" + cristalCount;

    }
}
