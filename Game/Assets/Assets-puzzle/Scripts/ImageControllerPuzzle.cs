using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageControllerPuzzle : MonoBehaviour {

    public GameObject target;
    public bool startMove = false;
    GameControllerPuzzle gameMN;

    // Use this for initialization
    void Start()
    {
        GameObject gamemanager = GameObject.Find("GameControllerPuzzle");
        gameMN = gamemanager.GetComponent<GameControllerPuzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startMove)
        {
            startMove = false;
            this.transform.position = target.transform.position; // move to new position
            gameMN.checkComplete = true;
        }
    }
}
