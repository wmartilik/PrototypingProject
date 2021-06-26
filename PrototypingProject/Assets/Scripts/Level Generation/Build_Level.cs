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
    public MapSize Level_Size;

    [SerializeField]
    private List<GameObject> Lower_Areas = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Upper_Areas = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Double_Areas = new List<GameObject>();

    [SerializeField]
    private GameObject Barricade;

    [SerializeField]
    private GameObject Deathnet;

    [SerializeField]
    private bool MultiFloor;

    private List<GameObject> Chosen_Lower_Areas = new List<GameObject>();

    private List<GameObject> Chosen_Upper_Areas = new List<GameObject>();

    public List<Vector3> Room_Centers = new List<Vector3>();

    private int DoubleDecker_Count = 0;

    private List<int> Skip_Indices = new List<int>();

    private List<Vector3> Positions = new List<Vector3>();
    private Vector3 Origin = new Vector3(0, 0, 0);
    private Vector3 Pos_1 = new Vector3(0, 0, 25);
    private Vector3 Pos_2 = new Vector3(25, 0, 25);
    private Vector3 Pos_3 = new Vector3(25, 0, 0);
    private Vector3 Pos_4 = new Vector3(25, 0, -25);
    private Vector3 Pos_5 = new Vector3(0, 0, -25);
    private Vector3 Pos_6 = new Vector3(-25, 0, -25);
    private Vector3 Pos_7 = new Vector3(-25, 0, 0);
    private Vector3 Pos_8 = new Vector3(-25, 0, 25);

    private List<Vector3> Upper_Positions = new List<Vector3>();
    private Vector3 U_Origin = new Vector3(0, 11, 0);
    private Vector3 U_Pos_1 = new Vector3(0, 11, 25);
    private Vector3 U_Pos_2 = new Vector3(25, 11, 25);
    private Vector3 U_Pos_3 = new Vector3(25, 11, 0);
    private Vector3 U_Pos_4 = new Vector3(25, 11, -25);
    private Vector3 U_Pos_5 = new Vector3(0, 11, -25);
    private Vector3 U_Pos_6 = new Vector3(-25, 11, -25);
    private Vector3 U_Pos_7 = new Vector3(-25, 11, 0);
    private Vector3 U_Pos_8 = new Vector3(-25, 11, 25);

    private List<Vector3> Barricade_Positions_Small = new List<Vector3>();
    private Vector3 Barr_Pos_1 = new Vector3(-12f, 2.5f, 25f);
    private Vector3 Barr_Pos_2 = new Vector3(0, 2.5f, 37f);
    private Vector3 Barr_Pos_3 = new Vector3(25, 2.5f, 37f);
    private Vector3 Barr_Pos_4 = new Vector3(37f, 2.5f, 25f);
    private Vector3 Barr_Pos_5 = new Vector3(37f, 2.5f, 0f);
    private Vector3 Barr_Pos_6 = new Vector3(25, 2.5f, -12f);
    private Vector3 Barr_Pos_7 = new Vector3(0, 2.5f, -12f);
    private Vector3 Barr_Pos_8 = new Vector3(-12f, 2.5f, 0f);

    private List<Vector3> Barricade_Positions_Medium = new List<Vector3>();
    private Vector3 Med_Barr_Pos_1 = new Vector3(-12f, 2.5f, 25f);
    private Vector3 Med_Barr_Pos_2 = new Vector3(0, 2.5f, 37f);
    private Vector3 Med_Barr_Pos_3 = new Vector3(25f, 2.5f, 37f);
    private Vector3 Med_Barr_Pos_4 = new Vector3(37f, 2.5f, 25f);
    private Vector3 Med_Barr_Pos_5 = new Vector3(37f, 2.5f, 0f);
    private Vector3 Med_Barr_Pos_6 = new Vector3(37f, 2.5f, -25f);
    private Vector3 Med_Barr_Pos_7 = new Vector3(25f, 2.5f, -37f);
    private Vector3 Med_Barr_Pos_8 = new Vector3(0, 2.5f, -37f);
    private Vector3 Med_Barr_Pos_9 = new Vector3(-12f, 2.5f, -25f);
    private Vector3 Med_Barr_Pos_10 = new Vector3(-12f, 2.5f, 0f);

    private List<Vector3> Barricade_Positions_Large = new List<Vector3>();
    private Vector3 Large_Barr_Pos_1 = new Vector3(-25f, 2.5f, 37f);
    private Vector3 Large_Barr_Pos_2 = new Vector3(0, 2.5f, 37f);
    private Vector3 Large_Barr_Pos_3 = new Vector3(25f, 2.5f, 37f);
    private Vector3 Large_Barr_Pos_4 = new Vector3(37f, 2.5f, 25f);
    private Vector3 Large_Barr_Pos_5 = new Vector3(37f, 2.5f, 0f);
    private Vector3 Large_Barr_Pos_6 = new Vector3(37f, 2.5f, -25f);
    private Vector3 Large_Barr_Pos_7 = new Vector3(25f, 2.5f, -37f);
    private Vector3 Large_Barr_Pos_8 = new Vector3(0, 2.5f, -37f);
    private Vector3 Large_Barr_Pos_9 = new Vector3(-25f, 2.5f, -37f);
    private Vector3 Large_Barr_Pos_10 = new Vector3(-37f, 2.5f, -25f);
    private Vector3 Large_Barr_Pos_11 = new Vector3(-37f, 2.5f, 0f);
    private Vector3 Large_Barr_Pos_12 = new Vector3(-37f, 2.5f, 25f);

    private List<Vector3> UBarricade_Positions_Small = new List<Vector3>();
    private Vector3 UBarr_Pos_1 = new Vector3(-12f, 13.5f, 25f);
    private Vector3 UBarr_Pos_2 = new Vector3(0, 13.5f, 37f);
    private Vector3 UBarr_Pos_3 = new Vector3(25, 13.5f, 37f);
    private Vector3 UBarr_Pos_4 = new Vector3(37f, 13.5f, 25f);
    private Vector3 UBarr_Pos_5 = new Vector3(37f, 13.5f, 0f);
    private Vector3 UBarr_Pos_6 = new Vector3(25, 13.5f, -12f);
    private Vector3 UBarr_Pos_7 = new Vector3(0, 13.5f, -12f);
    private Vector3 UBarr_Pos_8 = new Vector3(-12f, 13.5f, 0f);

    private List<Vector3> UBarricade_Positions_Medium = new List<Vector3>();
    private Vector3 UMed_Barr_Pos_1 = new Vector3(-12f, 13.5f, 25f);
    private Vector3 UMed_Barr_Pos_2 = new Vector3(0, 13.5f, 37f);
    private Vector3 UMed_Barr_Pos_3 = new Vector3(25f, 13.5f, 37f);
    private Vector3 UMed_Barr_Pos_4 = new Vector3(37f, 13.5f, 25f);
    private Vector3 UMed_Barr_Pos_5 = new Vector3(37f, 13.5f, 0f);
    private Vector3 UMed_Barr_Pos_6 = new Vector3(37f, 13.5f, -25f);
    private Vector3 UMed_Barr_Pos_7 = new Vector3(25f, 13.5f, -37f);
    private Vector3 UMed_Barr_Pos_8 = new Vector3(0, 13.5f, -37f);
    private Vector3 UMed_Barr_Pos_9 = new Vector3(-12f, 13.5f, -25f);
    private Vector3 UMed_Barr_Pos_10 = new Vector3(-12f, 13.5f, 0f);

    private List<Vector3> UBarricade_Positions_Large = new List<Vector3>();
    private Vector3 ULarge_Barr_Pos_1 = new Vector3(-25f, 13.5f, 37f);
    private Vector3 ULarge_Barr_Pos_2 = new Vector3(0, 13.5f, 37f);
    private Vector3 ULarge_Barr_Pos_3 = new Vector3(25f, 13.5f, 37f);
    private Vector3 ULarge_Barr_Pos_4 = new Vector3(37f, 13.5f, 25f);
    private Vector3 ULarge_Barr_Pos_5 = new Vector3(37f, 13.5f, 0f);
    private Vector3 ULarge_Barr_Pos_6 = new Vector3(37f, 13.5f, -25f);
    private Vector3 ULarge_Barr_Pos_7 = new Vector3(25f, 13.5f, -37f);
    private Vector3 ULarge_Barr_Pos_8 = new Vector3(0, 13.5f, -37f);
    private Vector3 ULarge_Barr_Pos_9 = new Vector3(-25f, 13.5f, -37f);
    private Vector3 ULarge_Barr_Pos_10 = new Vector3(-37f, 13.5f, -25f);
    private Vector3 ULarge_Barr_Pos_11 = new Vector3(-37f, 13.5f, 0f);
    private Vector3 ULarge_Barr_Pos_12 = new Vector3(-37f, 13.5f, 25f);


    // Start is called before the first frame update
    void Awake()
    {


        FillPositionsVectors();

        SelectAllPieces();

        LoadAreas();

        SetUpBarricadesLowerFloor(Level_Size);

        if (MultiFloor)
            SetUpBarricadesUpperFloor(Level_Size);
        Vector3 temp_vec = new Vector3(0.0f, -20.0f, 0.0f);
        //Instantiate(Deathnet, temp_vec, Quaternion.identity);

        Debug.Log(Room_Centers.Count);
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

        Upper_Positions.Add(U_Origin);
        Upper_Positions.Add(U_Pos_1);
        Upper_Positions.Add(U_Pos_2);
        Upper_Positions.Add(U_Pos_3);
        Upper_Positions.Add(U_Pos_4);
        Upper_Positions.Add(U_Pos_5);
        Upper_Positions.Add(U_Pos_6);
        Upper_Positions.Add(U_Pos_7);
        Upper_Positions.Add(U_Pos_8);

        Barricade_Positions_Small.Add(Barr_Pos_1);
        Barricade_Positions_Small.Add(Barr_Pos_2);
        Barricade_Positions_Small.Add(Barr_Pos_3);
        Barricade_Positions_Small.Add(Barr_Pos_4);
        Barricade_Positions_Small.Add(Barr_Pos_5);
        Barricade_Positions_Small.Add(Barr_Pos_6);
        Barricade_Positions_Small.Add(Barr_Pos_7);
        Barricade_Positions_Small.Add(Barr_Pos_8);

        Barricade_Positions_Medium.Add(Med_Barr_Pos_1);
        Barricade_Positions_Medium.Add(Med_Barr_Pos_2);
        Barricade_Positions_Medium.Add(Med_Barr_Pos_3);
        Barricade_Positions_Medium.Add(Med_Barr_Pos_4);
        Barricade_Positions_Medium.Add(Med_Barr_Pos_5);
        Barricade_Positions_Medium.Add(Med_Barr_Pos_6);
        Barricade_Positions_Medium.Add(Med_Barr_Pos_7);
        Barricade_Positions_Medium.Add(Med_Barr_Pos_8);
        Barricade_Positions_Medium.Add(Med_Barr_Pos_9);
        Barricade_Positions_Medium.Add(Med_Barr_Pos_10);

        Barricade_Positions_Large.Add(Large_Barr_Pos_1);
        Barricade_Positions_Large.Add(Large_Barr_Pos_2);
        Barricade_Positions_Large.Add(Large_Barr_Pos_3);
        Barricade_Positions_Large.Add(Large_Barr_Pos_4);
        Barricade_Positions_Large.Add(Large_Barr_Pos_5);
        Barricade_Positions_Large.Add(Large_Barr_Pos_6);
        Barricade_Positions_Large.Add(Large_Barr_Pos_7);
        Barricade_Positions_Large.Add(Large_Barr_Pos_8);
        Barricade_Positions_Large.Add(Large_Barr_Pos_9);
        Barricade_Positions_Large.Add(Large_Barr_Pos_10);
        Barricade_Positions_Large.Add(Large_Barr_Pos_11);
        Barricade_Positions_Large.Add(Large_Barr_Pos_12);

        UBarricade_Positions_Small.Add(UBarr_Pos_1);
        UBarricade_Positions_Small.Add(UBarr_Pos_2);
        UBarricade_Positions_Small.Add(UBarr_Pos_3);
        UBarricade_Positions_Small.Add(UBarr_Pos_4);
        UBarricade_Positions_Small.Add(UBarr_Pos_5);
        UBarricade_Positions_Small.Add(UBarr_Pos_6);
        UBarricade_Positions_Small.Add(UBarr_Pos_7);
        UBarricade_Positions_Small.Add(UBarr_Pos_8);

        UBarricade_Positions_Medium.Add(UMed_Barr_Pos_1);
        UBarricade_Positions_Medium.Add(UMed_Barr_Pos_2);
        UBarricade_Positions_Medium.Add(UMed_Barr_Pos_3);
        UBarricade_Positions_Medium.Add(UMed_Barr_Pos_4);
        UBarricade_Positions_Medium.Add(UMed_Barr_Pos_5);
        UBarricade_Positions_Medium.Add(UMed_Barr_Pos_6);
        UBarricade_Positions_Medium.Add(UMed_Barr_Pos_7);
        UBarricade_Positions_Medium.Add(UMed_Barr_Pos_8);
        UBarricade_Positions_Medium.Add(UMed_Barr_Pos_9);
        UBarricade_Positions_Medium.Add(UMed_Barr_Pos_10);

        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_1);
        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_2);
        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_3);
        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_4);
        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_5);
        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_6);
        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_7);
        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_8);
        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_9);
        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_10);
        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_11);
        UBarricade_Positions_Large.Add(ULarge_Barr_Pos_12);
    }

    bool GetLowerAreaPiece(List<GameObject> _areas, List<GameObject> _chosen_areas) //This needs to change from completely filling the level to just getting bottom floor pieces
    {
        int temp_random = Random.Range(0, _areas.Count);   //Gets a random number to choose a piece from the area array 
        List<GameObject> temp_areas = new List<GameObject>();
        bool return_value = true;
        //for (int i = 0; i < _chosen_areas.Count; i++)
        //{
        //    if (_chosen_areas[i] == _areas[temp_random])
        //    {
        //        return_value = false;
        //        break;
        //    }
        //}
        //if (return_value)
        Chosen_Lower_Areas.Add(_areas[temp_random]);

        return return_value;
    }

    void LoadAreas()
    {
        bool skip = false;

        for (int i = 0; i < Chosen_Lower_Areas.Count; i++)
        {
            Instantiate(Chosen_Lower_Areas[i], Positions[i], Quaternion.identity);
            Vector3 something = new Vector3(Positions[i].x, Positions[i].y, Positions[i].z);
            Vector3 otherTemp_vec = new Vector3(0.0f, 5.0f, 0.0f);

            Room_Centers.Add(something + otherTemp_vec);

            if (MultiFloor)
            {
                Vector3 temp_vec = new Vector3(0.0f, 15.0f, 0.0f);

                Room_Centers.Add(something + temp_vec);
            }
                
        }

        if (MultiFloor)
        {
            for (int i = 0; i < Chosen_Upper_Areas.Count; i++)
            {
                skip = false;
                foreach (int index in Skip_Indices)
                {
                    if (index == i)
                    {
                        skip = true;
                        break;
                    }
                }
                if (skip == false)
                {
                    Instantiate(Chosen_Upper_Areas[i], Upper_Positions[i], Quaternion.identity);
                    
                }
            }
        }
    }

    void SelectAllPieces()
    {
        DoubleDecker_Count = (int)Level_Size / 2 + 1;

        for (int i = 0; i <= (int)Level_Size; ++i)
        {
            if (MultiFloor)
            {
                int temp_random = Random.Range(0, 100);

                if (temp_random % 2 != 0 && DoubleDecker_Count > 0)
                {
                    while (!GetDoubleAreaPiece(Double_Areas, Chosen_Lower_Areas))
                    { }
                    --DoubleDecker_Count;
                }
                else
                {
                    while (!GetLowerAreaPiece(Lower_Areas, Chosen_Lower_Areas))
                    { }
                    while (!GetUpperAreaPiece(Upper_Areas, Chosen_Upper_Areas))
                    { }
                }
            }
            else
                while (!GetLowerAreaPiece(Lower_Areas, Chosen_Lower_Areas))
                { }

        }
    }

    bool GetUpperAreaPiece(List<GameObject> _areas, List<GameObject> _chosen_areas) //This gets an area piece from an upper floor
    {
        int temp_random = Random.Range(0, _areas.Count);   //Gets a random number to choose a piece from the area array 
        List<GameObject> temp_areas = new List<GameObject>();
        bool return_value = true;
        //for (int i = 0; i < _chosen_areas.Count; i++)
        //{
        //    if (_chosen_areas[i] == _areas[temp_random])
        //    {
        //        return_value = false;
        //        break;
        //    }
        //}
        //if (return_value)
        Chosen_Upper_Areas.Add(_areas[temp_random]);

        return return_value;
    }

    bool GetDoubleAreaPiece(List<GameObject> _areas, List<GameObject> _chosen_areas) //This gets an area piece from a double floor
    {
        int temp_random = Random.Range(0, _areas.Count);   //Gets a random number to choose a piece from the area array 
        List<GameObject> temp_areas = new List<GameObject>();
        bool return_value = true;
        //for (int i = 0; i < _chosen_areas.Count; i++)
        //{
        //    if (_chosen_areas[i] == _areas[temp_random])
        //    {
        //        return_value = false;
        //        break;
        //    }
        //}
        //if (return_value)
        //{
        Chosen_Upper_Areas.Add(_areas[temp_random]);
        Chosen_Lower_Areas.Add(_areas[temp_random]);
        Skip_Indices.Add(Chosen_Lower_Areas.Count - 1);
        // }


        return return_value;
    }

    void SetUpBarricadesLowerFloor(MapSize _size)
    {
        if (_size == MapSize.Small)
        {
            for (int i = 0; i < Barricade_Positions_Small.Count; i++)
            {
                if (i == 1 || i == 2 || i == 5 || i == 6)
                {
                    Instantiate(Barricade, Barricade_Positions_Small[i], Quaternion.Euler(0f, 90f, 0f));
                }
                else
                    Instantiate(Barricade, Barricade_Positions_Small[i], Quaternion.identity);
            }
        }
        if (_size == MapSize.Medium)
        {
            for (int i = 0; i < Barricade_Positions_Medium.Count; i++)
            {
                if (i == 1 || i == 2 || i == 7 || i == 6)
                {
                    Instantiate(Barricade, Barricade_Positions_Medium[i], Quaternion.Euler(0f, 90f, 0f));
                }
                else
                    Instantiate(Barricade, Barricade_Positions_Medium[i], Quaternion.identity);
            }
        }
        if (_size == MapSize.Large)
        {
            for (int i = 0; i < Barricade_Positions_Large.Count; i++)
            {
                if (i == 1 || i == 2 || i == 7 || i == 6 || i == 8 || i == 0)
                {
                    Instantiate(Barricade, Barricade_Positions_Large[i], Quaternion.Euler(0f, 90f, 0f));
                }
                else
                    Instantiate(Barricade, Barricade_Positions_Large[i], Quaternion.identity);
            }
        }

    }

    void SetUpBarricadesUpperFloor(MapSize _size)
    {
        if (_size == MapSize.Small)
        {
            for (int i = 0; i < UBarricade_Positions_Small.Count; i++)
            {
                if (i == 1 || i == 2 || i == 5 || i == 6)
                {
                    Instantiate(Barricade, UBarricade_Positions_Small[i], Quaternion.Euler(0f, 90f, 0f));
                }
                else
                    Instantiate(Barricade, UBarricade_Positions_Small[i], Quaternion.identity);
            }
        }
        if (_size == MapSize.Medium)
        {
            for (int i = 0; i < UBarricade_Positions_Medium.Count; i++)
            {
                if (i == 1 || i == 2 || i == 7 || i == 6)
                {
                    Instantiate(Barricade, UBarricade_Positions_Medium[i], Quaternion.Euler(0f, 90f, 0f));
                }
                else
                    Instantiate(Barricade, UBarricade_Positions_Medium[i], Quaternion.identity);
            }
        }
        if (_size == MapSize.Large)
        {
            for (int i = 0; i < UBarricade_Positions_Large.Count; i++)
            {
                if (i == 1 || i == 2 || i == 7 || i == 6 || i == 8 || i == 0)
                {
                    Instantiate(Barricade, UBarricade_Positions_Large[i], Quaternion.Euler(0f, 90f, 0f));
                }
                else
                    Instantiate(Barricade, UBarricade_Positions_Large[i], Quaternion.identity);
            }
        }
    }
}
