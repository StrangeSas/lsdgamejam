using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] Camera camera1;
    [SerializeField] Camera camera3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraSwitch();
    }

    public void cameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            camera1.enabled = true;
            camera3.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            camera1.enabled = false;
            camera3.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            camera1.enabled = false;
            camera3.enabled = false;
        }

    }

    public Camera getCamera1() 
    {
        return camera1;
    }
    public Camera getCamera3() 
    {
        return camera3;
    }
}
