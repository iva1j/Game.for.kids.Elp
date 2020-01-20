using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPickUp : MonoBehaviour {

    [SerializeField] private Image customImage;

    public float rotateSpeed;
    
    

    

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }

    

        private void OnTriggerEnter(Collider other)
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();

        if (other.CompareTag("Player"))
        {
            customImage.enabled = true;
            Destroy(gameObject);
            
        }

       
    }

    



    }
