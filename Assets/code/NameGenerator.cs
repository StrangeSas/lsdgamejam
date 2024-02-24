using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameGenerator : MonoBehaviour
{
    [SerializeField] GameObject IAm;
    // Start is called before the first frame update

    public Text texts;
    void Start()
    {
        texts = GetComponent<Text>();
    }

    // Update is called once per frame
    public void yeah()
    {
        string[] bullshit = {"Demitasse", "Derecho", "Diphthong", "Doldrums", "Doohickey", "Doppelgänger",
            "Dumfounded", "Earwig", "Elixir", "Ephemeral", "Ersatz", "Finagle", "Festooned", "Fez", "Flimflam",
            "Flummery", "Flyspeck", "Foofaraw", "Fracas", "Frangipani", "Fuddy-duddy", "Futz", "Gadzooks", "Gambit",
            "Gazebo", "Gizmo" };
        string writing = bullshit[Random.Range(0, bullshit.Length)] + bullshit[Random.Range(0, bullshit.Length)];
        texts.text = writing;
        Destroy(IAm, 0.5f);
    }
    public void OnTriggerEnter(Collider other)
    {
        yeah();
    }
}
