using UnityEngine;
using System; 
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;  

public class BoardManager : MonoBehaviour{

    public GameObject[] floorTiles; 
    public GameObject[] cornerFloorTiles; 

    private List <Vector3> gridPositions = new List<Vector3>(); 
    private int boardlength = 80; 
    private Transform boardHolder; 

    void InitialiseList()
    {
        gridPositions.Clear();
        for (int x = 0; x < boardlength+1; x++)
        {
           gridPositions.Add(new Vector3(x, 0, 0f)); 
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform; 
        for(int x = 0; x < boardlength+1; x++)
        {
            GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)]; 
            if (x == 0)
                toInstantiate = cornerFloorTiles[0]; 
            if (x == boardlength)
                toInstantiate = cornerFloorTiles[1]; 
            GameObject instance = Instantiate(toInstantiate, new Vector3 (x,0,0f), Quaternion.identity) as GameObject; 
            instance.transform.SetParent(boardHolder); 
        }
    }
    public void SetupScene()
    {
        BoardSetup(); 
        InitialiseList(); 
    }
}
