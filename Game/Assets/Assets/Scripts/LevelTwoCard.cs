using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoCard : MonoBehaviour {

    [SerializeField] private GameObject backCard;

    public void OnMouseDown()
    {
        if (backCard.activeSelf && twoController.canReveal)
        {
            backCard.SetActive(false);
            twoController.CardRevealed(this);
        }
    }

    public void Unreveal()
    {
        backCard.SetActive(true);
    }


    [SerializeField] private LevelTwoController twoController;


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
