using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTwoController : MonoBehaviour
{

    public const int gridRows = 2;
    public const int gridCols = 6;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    [SerializeField] private LevelTwoCard twooriginalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh scoreLabel;
    public GameObject EndPanel;


    private float startTime;
    public Text timerText;
    private float levelDuration;
    
    


    private void Start()
    {
        Vector3 startPos = twooriginalCard.transform.position;

        EndPanel.SetActive(false);

        startTime = Time.time;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5};
        numbers = ShuffleArray(numbers);


        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                LevelTwoCard card;
                if (i == 0 && j == 0)
                {
                    card = twooriginalCard;
                }
                else
                {
                    card = Instantiate(twooriginalCard) as LevelTwoCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);



                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }


        }
    }

    private int[] ShuffleArray(int[] numbers)
    {

        int[] newArray = numbers.Clone() as int[];

        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;


        }
        return newArray;


    }

    private LevelTwoCard _firstRevealed;
    private LevelTwoCard _secondRevealed;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }


    private int _score = 0;

    public void CardRevealed(LevelTwoCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;

        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }

    }

    public void Restart()
    {
        Application.LoadLevel("scene2");
    }


    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            scoreLabel.text = "SCORE: " + _score;
            if (_score >= 6)
            {
                yield return new WaitForSeconds(.1f);
                EndPanel.SetActive(true);           
                

            }


        }
        else
        {
            yield return new WaitForSeconds(.4f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;
    }

  

    public void Update()
    {
        if (_score >= 6)
            return;

        levelDuration = Time.time - startTime;

        string minutes = ((int) levelDuration / 60).ToString("00");
        string seconds = ( levelDuration % 60).ToString("00.00");

        timerText.text = minutes + ":" + seconds;


        

        
    }
    
}


