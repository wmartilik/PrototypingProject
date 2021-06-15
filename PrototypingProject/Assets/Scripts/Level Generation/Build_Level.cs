using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Build_Level : MonoBehaviour
{
    public enum MapSize
    {
        Small = 3,
        Medium = 5,
        Large = 8
    }    

    [SerializeField]
    private MapSize Level_Size;

    [SerializeField]
    private List<GameObject> Areas = new List<GameObject>();

    private List<GameObject> Chosen_Areas = new List<GameObject>();    

    private int MapSize_Count = 0;

    private List<Vector3> Positions = new List<Vector3>();
    private Vector3 Origin = new Vector3(0, 0, 0);
    private Vector3 Pos_1 = new Vector3(0,0,25);
    private Vector3 Pos_2 = new Vector3(25,0,25);
    private Vector3 Pos_3 = new Vector3(25,0,0);
    private Vector3 Pos_4 = new Vector3(25,0,-25);
    private Vector3 Pos_5 = new Vector3(0,0,-25);
    private Vector3 Pos_6 = new Vector3(-25,0,-25);
    private Vector3 Pos_7 = new Vector3(-25,0,0);
    private Vector3 Pos_8 = new Vector3(-25,0,25);

    private List<Vector3> Upper_Positions = new List<Vector3>();
    private Vector3 UOrigin = new Vector3(0, 12, 0);
    private Vector3 UPos_1 = new Vector3(0, 12, 25);
    private Vector3 UPos_2 = new Vector3(25, 12, 25);
    private Vector3 UPos_3 = new Vector3(25, 12, 0);
    private Vector3 UPos_4 = new Vector3(25, 12, -25);
    private Vector3 UPos_5 = new Vector3(0, 12, -25);
    private Vector3 UPos_6 = new Vector3(-25, 12, -25);
    private Vector3 UPos_7 = new Vector3(-25, 12, 0);
    private Vector3 UPos_8 = new Vector3(-25, 12, 25);

    // Start is called before the first frame update
    void Start()
    {
        FillPositionsVectors();
        
        GetAreaPiece(Areas);
        
        LoadAreas();
        
        
        
    }       

    void FillPositionsVectors()
    {
        Positions.Add(Origin);
        Positions.Add(Pos_1);
        Positions.Add(Pos_2);
        Positions.Add(Pos_3);
        Positions.Add(Pos_4);
        Positions.Add(Pos_5);
        Positions.Add(Pos_6);
        Positions.Add(Pos_7);
        Positions.Add(Pos_8);
    } 

    void GetAreaPiece(List<GameObject> _areas) //This needs to change from completely filling the level to just getting bottom floor pieces
    {
        int temp_random = Random.Range(0, _areas.Count);   //Gets a random number to choose a piece from the area array 
        List<GameObject> temp_areas = new List<GameObject>();
        for (int i = 0; i < _areas.Count; i++)
        {
            if (i != temp_random)
            {
                temp_areas.Add(_areas[i]);
            }
        }       
        Chosen_Areas.Add(_areas[temp_random]);
        MapSize_Count++;
        if(MapSize_Count <= (int)Level_Size)
        {
            GetAreaPiece(temp_areas);
        }
    }   
    
    void LoadAreas()
    {
        for (int i = 0; i < Chosen_Areas.Count; i++)
        {
            Instantiate(Chosen_Areas[i], Positions[i], Quaternion.identity);
        }
        
    }

    void CreateRoomPositionArray(MapSize _size)
    {

    }

    void GetAreaPieceUpperFloor() //This gets an area piece from an upper floor and sets its position
    {

    }

    void SetUpBarricadesLowerFloor()
    {

    }

    void SetUpBarricadesUpperFloor()
    {

    }
}
