using System;
using UnityEngine;

public class ViewBobing : MonoBehaviour
{
    [SerializeField] float cum = 1f;
    [Range(0.001f, 5.0f)]
    public float Amount = 0.002f;
    [Range(1f, 30f)]
    public float Frequency = 10f;
    [Range(10f, 100f)]
    public float Smooth = 10.0f;
    // Update is called once per frame


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckForHeadBobTrigger();
    }

    private void CheckForHeadBobTrigger()
    {
        float inputMagnitude = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;

        if(inputMagnitude > 0 ) 
        {
            StartHeadBob();
        }
        else
        {
            StartHeadBobSamll();
        }
    }

    private Vector3 StartHeadBob()
    {
        Vector3 rot = Vector3.zero;
        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Lerp(pos.x, (float)Math.Sin(Time.time * Frequency) * Amount * 1f, Smooth * Time.deltaTime);
        pos.y = Mathf.Lerp(pos.y, (float)Math.Sin(Time.time * Frequency) * Amount * 1.4f, Smooth * Time.deltaTime);
        pos.z = Mathf.Lerp(pos.z, (float)Math.Sin(Time.time * Frequency) * Amount * 1.4f, Smooth * Time.deltaTime);
        transform.localPosition += pos;


        return pos;
    }
    private Vector3 StartHeadBobSamll()
    {
        Vector3 rot = Vector3.zero;
        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Lerp(pos.x, (float)Math.Sin(Time.time * Frequency * 0.4f) * Amount * 0.3f, Smooth * Time.deltaTime);
        pos.y = Mathf.Lerp(pos.y, (float)Math.Sin(Time.time * Frequency * 0.4f) * Amount * 0.5f, Smooth * Time.deltaTime);
        pos.z = Mathf.Lerp(pos.z, (float)Math.Sin(Time.time * Frequency * 0.4f) * Amount * 0.5f, Smooth * Time.deltaTime);
        transform.localPosition += pos;


        return pos;
    }
}
