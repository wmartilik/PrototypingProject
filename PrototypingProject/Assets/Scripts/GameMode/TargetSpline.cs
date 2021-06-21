using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpline : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Build_Level level_info;

    private List<Vector3> obj_points = new List<Vector3>();

    private void Start()
    {
        switch ((int)level_info.Level_Size)
        {
            case 8:
                {
                    FillObjectPoints(20);
                }
                break;
            case 5:
                {
                    FillObjectPoints(15);
                }
                break;
            case 3:
                {
                    FillObjectPoints(10);
                }
                break;
        }
    }

    void FillObjectPoints(int _count)
    {
        for (int i = 0; i < _count; ++i)
        {
            int temp_random = Random.Range(0, level_info.Room_Centers.Count);
            obj_points.Add(level_info.Room_Centers[temp_random]);
        }
    }

    
}
