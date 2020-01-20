using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeCard : MonoBehaviour {

    [SerializeField] private GameObject bCard;

    public void OnMouseDown()
    {
        if (bCard.activeSelf && threeController.canReveal)
        {
            bCard.SetActive(false);
            threeController.CardRevealed(this);
        }
    }

    public void Unreveal()
    {
        bCard.SetActive(true);
    }


    [SerializeField] private LevelThreeController threeController;


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
