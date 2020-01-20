using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public int value;
    public float rotateSpeed;

    private void Update()
    {
        gameObject.transform.Rotate (Vector3.up * Time.deltaTime * rotateSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {

        GameManager.instance.Collect(value, gameObject);
        

        AudioSource source = GetComponent<AudioSource>();
        source.Play();
    }
}
