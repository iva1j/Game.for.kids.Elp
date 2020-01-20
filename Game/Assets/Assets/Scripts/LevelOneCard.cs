using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneCard : MonoBehaviour {

    [SerializeField] private GameObject bCard;

    public void OnMouseDown()
    {
        if (bCard.activeSelf && oneController.canReveal)
        {
            bCard.SetActive(false);
            oneController.CardRevealed(this);
        }
    }

    public void Unreveal()
    {
        bCard.SetActive(true);
    }


    [SerializeField] private LevelOneController oneController;


    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }


}
