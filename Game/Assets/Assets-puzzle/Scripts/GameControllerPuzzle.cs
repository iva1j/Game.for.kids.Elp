using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerPuzzle : MonoBehaviour {

    public int level;
    public int row, col, countStep;
    public int rowBlank, colBlank; //position of blank image
    public int sizeRow, sizeCol;
    int countPoints = 0;
    int countImageKey = 0;
    int countComplete=0;

    public bool startControl = false;
    public bool checkComplete;
    public bool gameIsComplete;
    public GameObject FinishPanel;
    public GameObject FinishPanelDark;

    GameObject temp;

    public List<GameObject> imageKeyList; // run from 0 ---> list.count
    public List<GameObject> imageOfPictureList;
    public List<GameObject> checkPointList;

    GameObject[,] imageKeyMatrix;
    GameObject[,] imageOfPicturesMatrix;
    GameObject[,] checkPointMatrix;


    // Use this for initialization
    void Start()
    {

        FinishPanel.SetActive(false);
        FinishPanelDark.SetActive(false);
        imageKeyMatrix = new GameObject[sizeRow, sizeCol];
        imageOfPicturesMatrix = new GameObject[sizeRow, sizeCol];
        checkPointMatrix = new GameObject[sizeRow, sizeCol];
        if (level == 1)
        {
            ImageOfEasyLevel();
        }
        else if (level == 2)
        {
            ImageOfNormalLevel();
        }
        else if (level == 3)
        {
            ImageOfHardLevel();
        }
        

        //call functions
        CheckPointManager();
        ImageKeyManager();
        for (int r = 0; r < sizeRow; r++) //run row
        {
            for (int c = 0; c < sizeCol; c++) // run col
            {
                if (imageOfPicturesMatrix[r, c].name.CompareTo("blank") == 0)
                {
                    rowBlank = r;
                    colBlank = c;
                    break;
                }

            }

        }
    }

    void CheckPointManager()
    {
        for (int r = 0; r < sizeRow; r++) //run row
        {
            for (int c = 0; c < sizeCol; c++) // run col
            {
                checkPointMatrix[r, c] = checkPointList[countPoints];
                countPoints++;
            }
        }
    }
    

    void ImageKeyManager()
    {
        for (int r = 0; r < sizeRow; r++) //run row
        {
            for (int c = 0; c < sizeCol; c++) // run col
            {
                imageKeyMatrix[r, c] = imageKeyList[countImageKey];
                countImageKey++;
            }
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        if (startControl) // move for images of pictures
        {
            startControl = false;
            if (countStep == 1)
            {
                if (imageOfPicturesMatrix[row, col] != null && imageOfPicturesMatrix[row, col].name.CompareTo("blank") != 0) // check if position touched is image not image blank
                {
                    if (rowBlank != row && colBlank == col)
                    {
                        if (Mathf.Abs(row - rowBlank) == 1) //move one cell
                        {
                            //move
                            //call function ImageSort
                            SortImage();
                            countStep = 0; //reset countStep
                        }
                        else
                        {
                            countStep = 0; //reset countStep
                        }
                    }


                    else if (rowBlank == row && colBlank != col)
                    {
                        if (Mathf.Abs(col - colBlank) == 1)
                        {
                            //move
                            SortImage();
                            countStep = 0;
                        }
                        else
                        {
                            countStep = 0; //reset countStep
                        }
                    }
                    else if ((rowBlank == row && colBlank == col) || (rowBlank != row && colBlank != col))
                    {
                        countStep = 0; //does not move
                    }
                }
                else
                {
                    countStep = 0; //does not move
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (checkComplete)
        {
            checkComplete = false;
            for(int r = 0; r < sizeRow; r++) //run row
            {
                for(int c = 0; c < sizeCol; c++) //run col
                {
                    if (imageKeyMatrix[r, c].gameObject.name.CompareTo(imageOfPicturesMatrix[r, c].gameObject.name) == 0) {
                        countComplete++;
}
                    else
                    {
                        break; //out loop
                    }
                }
            }
            if (countComplete == checkPointList.Count) // if 9 imageOfPicture == 9 imageKey ( in 2 array) (check point list=9)
            {
                gameIsComplete = true;
                Debug.Log("Game Is Complete");
                FinishPanel.SetActive(true);
                FinishPanelDark.SetActive(true);
                
            }
            else
            {
                countComplete = 0;
            }
        }
    }

    void SortImage()
    { //sort
        temp = imageOfPicturesMatrix[rowBlank, colBlank];
        imageOfPicturesMatrix[rowBlank, colBlank] = null;

        imageOfPicturesMatrix[rowBlank, colBlank] = imageOfPicturesMatrix[row, col];
        imageOfPicturesMatrix[row, col] = temp;
        //set move for image
        imageOfPicturesMatrix[rowBlank, colBlank].GetComponent<ImageControllerPuzzle>().target = checkPointMatrix[rowBlank, colBlank];
        imageOfPicturesMatrix[row, col].GetComponent<ImageControllerPuzzle>().target = checkPointMatrix[row, col];

        imageOfPicturesMatrix[rowBlank, colBlank].GetComponent<ImageControllerPuzzle>().startMove = true;
        imageOfPicturesMatrix[row, col].GetComponent<ImageControllerPuzzle>().startMove = true;

        //set row and col for image blank

        rowBlank = row;
        colBlank = col;



    }

     void ImageOfEasyLevel()
    {
        imageOfPicturesMatrix[0, 0] = imageOfPictureList[0]; // we set one less than in ImageOfPicture ( images in folder by number)
        imageOfPicturesMatrix[0, 1] = imageOfPictureList[2];
        imageOfPicturesMatrix[0, 2] = imageOfPictureList[5];
        imageOfPicturesMatrix[1, 0] = imageOfPictureList[4];
        imageOfPicturesMatrix[1, 1] = imageOfPictureList[1];
        imageOfPicturesMatrix[1, 2] = imageOfPictureList[7];
        imageOfPicturesMatrix[2, 0] = imageOfPictureList[3];
        imageOfPicturesMatrix[2, 1] = imageOfPictureList[6];
        imageOfPicturesMatrix[2, 2] = imageOfPictureList[8]; // blank image


    }

    void ImageOfNormalLevel()
    {
        imageOfPicturesMatrix[0, 0] = imageOfPictureList[4];
        imageOfPicturesMatrix[0, 1] = imageOfPictureList[0];
        imageOfPicturesMatrix[0, 2] = imageOfPictureList[1];
        imageOfPicturesMatrix[0, 3] = imageOfPictureList[3]; // blank image
        imageOfPicturesMatrix[1, 0] = imageOfPictureList[8];
        imageOfPicturesMatrix[1, 1] = imageOfPictureList[6];
        imageOfPicturesMatrix[1, 2] = imageOfPictureList[7];
        imageOfPicturesMatrix[1, 3] = imageOfPictureList[11];
        imageOfPicturesMatrix[2, 0] = imageOfPictureList[12];
        imageOfPicturesMatrix[2, 1] = imageOfPictureList[5];
        imageOfPicturesMatrix[2, 2] = imageOfPictureList[14];
        imageOfPicturesMatrix[2, 3] = imageOfPictureList[10];
        imageOfPicturesMatrix[3, 0] = imageOfPictureList[13];
        imageOfPicturesMatrix[3, 1] = imageOfPictureList[9];
        imageOfPicturesMatrix[3, 2] = imageOfPictureList[15];
        imageOfPicturesMatrix[3, 3] = imageOfPictureList[2];


    }

    void ImageOfHardLevel()
    {
        imageOfPicturesMatrix[0, 0] = imageOfPictureList[5];
        imageOfPicturesMatrix[0, 1] = imageOfPictureList[2];
        imageOfPicturesMatrix[0, 2] = imageOfPictureList[3];
        imageOfPicturesMatrix[0, 3] = imageOfPictureList[4];
        imageOfPicturesMatrix[0, 4] = imageOfPictureList[9];
        imageOfPicturesMatrix[1, 0] = imageOfPictureList[10];
        imageOfPicturesMatrix[1, 1] = imageOfPictureList[1];
        imageOfPicturesMatrix[1, 2] = imageOfPictureList[12];
        imageOfPicturesMatrix[1, 3] = imageOfPictureList[7];
        imageOfPicturesMatrix[1, 4] = imageOfPictureList[8];
        imageOfPicturesMatrix[2, 0] = imageOfPictureList[15];
        imageOfPicturesMatrix[2, 1] = imageOfPictureList[6];
        imageOfPicturesMatrix[2, 2] = imageOfPictureList[13];
        imageOfPicturesMatrix[2, 3] = imageOfPictureList[14];
        imageOfPicturesMatrix[2, 4] = imageOfPictureList[19];
        imageOfPicturesMatrix[3, 0] = imageOfPictureList[20];
        imageOfPicturesMatrix[3, 1] = imageOfPictureList[11];
        imageOfPicturesMatrix[3, 2] = imageOfPictureList[22];
        imageOfPicturesMatrix[3, 3] = imageOfPictureList[17];
        imageOfPicturesMatrix[3, 4] = imageOfPictureList[18];
        imageOfPicturesMatrix[4, 0] = imageOfPictureList[21];
        imageOfPicturesMatrix[4, 1] = imageOfPictureList[16];
        imageOfPicturesMatrix[4, 2] = imageOfPictureList[23];
        imageOfPicturesMatrix[4, 3] = imageOfPictureList[24];
        imageOfPicturesMatrix[4, 4] = imageOfPictureList[0]; //blank
    }




}


