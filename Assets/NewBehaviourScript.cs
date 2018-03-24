using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{
    public TextAsset asset1;                                                                //Declaration of the text file
    public GameObject tilefab;                                                              //Will be used to indicate hallways in the game tab
    private string text;                                                                    
    public List<GameObject> tiles;                                                          //List of Gameobjects, which will be tiles when they are spawned
    public GameObject nospace;                                                              //tile indicates all the other spaces except for hallways

    void Start()
    {
        text = asset1.text;                                                                 //get all the text as one string
        char[,] cArray = new char[8, 8];                                                    //makes a new 2d 8 x 8 array of characters
        var lines = text.Split(new[] { '\n' });                                             //separates string by line
        int row = 0;
        foreach (string line in lines)
        {
            int column = 0;
            foreach (char character in line)
            {
                if (column < 7 & row < 7)
                {
                    cArray[row, column] = character;                                        //saves character at position x and y in the 2d array
                }
                column++;
            }
            row++;
        }
        for(int x = 0; x < 7; x++)
        {
            for(int y = 0; y <7; y++)
            {
                if (cArray[x, y] == '-' || cArray[x, y] == '|')                             // '-' and '|' are indicators of hallways
                {
                    Vector2 pos = new Vector2(x,y);
                    GameObject currentFile = Instantiate(tilefab, pos, Quaternion.identity) as GameObject;
                    tiles.Add(currentFile);
                }
                else
                {
                    Vector2 pos1 = new Vector2(x, y);
                    GameObject currentFile= Instantiate(nospace, pos1, Quaternion.identity) as GameObject;
                    tiles.Add(currentFile);                                                 // adds new gameobject to list of gameobjects
                }
            }
        }

    }
}                                                                                           //parts of code obtained from https://www.youtube.com/watch?v=66eyeyPMbHc