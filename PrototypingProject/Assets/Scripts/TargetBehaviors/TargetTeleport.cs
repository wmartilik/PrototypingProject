using UnityEngine;
using System.Collections;

public class TargetTeleport : MonoBehaviour
{
    float speed = 50;

    public TargetSpline spline;
    bool hasTeleported;

    void Start()
    {
        //Spawn cube at point 0
        transform.position = spline.obj_points[0];
    }

    void FixedUpdate()
    {
        //Rotates Target
        transform.Rotate(Vector3.up * speed * Time.deltaTime);

        if(hasTeleported == false) StartCoroutine(GoToPoint());

    }
    public IEnumerator GoToPoint()
    {
        hasTeleported = true;

        yield return new WaitForSeconds(15f);

        int newPos = Random.Range(0, spline.obj_points.Count);

        Debug.Log("Teleporting!");

        transform.position = spline.obj_points[newPos];

        hasTeleported = false;
    }
}
