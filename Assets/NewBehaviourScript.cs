using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{
    public TextAsset asset1;
    public GameObject tilefab;
    private string text;
    public List<GameObject> tiles;
    public GameObject nospace;
    void Start()
    {
        text = asset1.text;
        char[,] cArray = new char[8, 8];
        var lines = text.Split(new[] { '\n' });
        int row = 0;
        foreach (string line in lines)
        {
            int column = 0;
            foreach (char character in line)
            {
                if (column < 7 & row < 7)
                {
                    cArray[row, column] = character;
                }
                column++;
            }
            row++;
        }
        for(int x = 0; x < 7; x++)
        {
            for(int y = 0; y <7; y++)
            {
                if (cArray[x, y] == '-' || cArray[x, y] == '|')
                {
                    Vector2 pos = new Vector2(x,y);
                    GameObject currentFile = Instantiate(tilefab, pos, Quaternion.identity) as GameObject;
                    tiles.Add(currentFile);
                }
                else
                {
                    Vector2 pos1 = new Vector2(x, y);
                    GameObject currentFile= Instantiate(nospace, pos1, Quaternion.identity) as GameObject;
                    tiles.Add(currentFile);
                }
            }
        }

    }
}