using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControllerPuzzle : MonoBehaviour {

    public int row, col;
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

    }

    private void OnMouseDown()
    {
        Debug.Log("Row is:" + row + "Col is:" + col); // test touch
        gameMN.countStep += 1;
        gameMN.row = row;
        gameMN.col = col;
        gameMN.startControl = true;
    }
}
