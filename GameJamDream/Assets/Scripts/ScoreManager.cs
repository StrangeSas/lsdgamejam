using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int memoryCount;
    public Text memoryText;
    private void Update()
    {
        memoryText.text = memoryCount.ToString();
        if(memoryCount == 1)
        {
         
        }
        if (memoryCount == 2)
        {

        }
        if (memoryCount == 3) 
        {

        }
    }
}
