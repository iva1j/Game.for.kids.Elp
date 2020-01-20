using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour {

    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;


    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.5279464f, 0.5279464f, 0.5279464f);
    }

    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.49f, 0.49f, 0.49f);
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}
