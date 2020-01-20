using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    


    public GameObject scoreTextObject;
    public GameObject Transport;
    
    int score;
    Text scoreText;
    
    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        

        scoreText = scoreTextObject.GetComponent<Text>();
        scoreText.text = "   : " + score.ToString() + " / 7";


        
        Transport.SetActive(false);
    }

    public void Collect( int passedValue, GameObject passedObject)
    {
        
        passedObject.GetComponent<Collider>().enabled = false;
        Destroy (passedObject, 0.3f);
        score = score + passedValue;
        scoreText.text = "   : " + score.ToString() + " / 7";

        

    }


    public void Update()
    {
        if(score >= 7)
        {
            Transport.SetActive(true);
            

            
        }
    }

}
