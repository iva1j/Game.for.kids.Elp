using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicksound : MonoBehaviour {

    AudioSource ac;

    private void Start()
    {
        ac = GetComponent<AudioSource>();


    }

    private void OnMouseDown()
    {
        ac.PlayOneShot(ac.clip);
    }
}
