﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //MapSize
    public int colums = 8;
    public int rows = 8;

    private List<Vector2> gridPositions = new List<Vector2>();

    public GameObject[] floorTiles;
    public GameObject[] foodTiles;      //Sodaも含む
    public GameObject[] WallTiles;
    public GameObject[] outWallTiles;
    public GameObject[] enemyTiles;
    public GameObject Close_tresureBox;
    public GameObject Open_tresureBox;
    public GameObject exit;

    public int wallMin = 5;             //何個障害を作るか
    public int wallMax = 10;
    public int foodMin = 1;             //何個foodを生成するか
    public int foodMax = 5;

    public int x, y;

    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x < colums - 1; x++)
            for (int y = 1; y < rows - 1; y++)
                gridPositions.Add(new Vector2(x, y));

    }

    void BoardSetUp()
    {
        for (int x = -1; x < colums + 1; x++)
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate;

                if (x == -1 || x == colums || y == -1 || y == rows)
                    toInstantiate = outWallTiles[Random.Range(0, outWallTiles.Length)]; //Lengthは配列用

                else
                    toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

                Instantiate(toInstantiate, new Vector2(x - 2, y), Quaternion.identity);
            }
    }

    Vector2 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);                         //CountはList用

        Vector2 randomPosition = gridPositions[randomIndex];

        gridPositions.RemoveAt(randomIndex);                                            //アイテムを置くためにタイルを消す

        return randomPosition;
    }

    void LayoutRandomObject(GameObject[] tileArray, int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector2 randomPosition = RandomPosition();
            GameObject tileChoise = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(tileChoise, new Vector2(randomPosition.x - 2, randomPosition.y), Quaternion.identity);
        }
    }

    public void SetUpScene()
    {
        BoardSetUp();
        InitialiseList();
        LayoutRandomObject(WallTiles, wallMin, wallMax);
        LayoutRandomObject(foodTiles, foodMin, foodMax);

        //int enemyCount = (int)Mathf.Log(level, 2f);
        //Debug.Log(enemyCount);
        LayoutRandomObject(enemyTiles, 1, 5);
        Instantiate(exit, new Vector2(colums - 3, rows - 1), Quaternion.identity);

        x = Random.Range(1, colums - 1);
        y = Random.Range(1, rows - 1);
        if ((x != 1 && y != 1) || (x != 7 && y != 7))
            Instantiate(Close_tresureBox, new Vector2(x - 2, y), Quaternion.identity);


    }

    public void TresureOpen(Vector2 pos)
    {
        Instantiate(Open_tresureBox, pos, Quaternion.identity);
    }
}