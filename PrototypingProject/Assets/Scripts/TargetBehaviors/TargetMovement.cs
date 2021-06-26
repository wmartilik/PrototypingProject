using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 1;
    Vector3 currDest;
    Vector3 nextDest;
    public TargetSpline spline;
    [SerializeField] int currentPoint = 0;

    void Start()
    {
        //Spawn cube at point 0
        transform.position = spline.obj_points[0];

        //set current destination to point 1
        currDest = spline.obj_points[currentPoint += 1];
        Debug.Log(currDest);

        //set next destination to point 2
        nextDest = spline.obj_points[currentPoint += 1];
        Debug.Log(nextDest);
    }

    void FixedUpdate()
    {
        GoToPoint();

        //Rotates Target
        transform.Rotate(Vector3.up * (speed * 15) * Time.deltaTime);

        if (currentPoint == spline.obj_points.Count - 1)
        {
            currentPoint = 0;
        }

        //if target is less than 1 unit from current destination, go to next destination
        if (Vector3.Distance(transform.position, currDest) < 1f)
        {
            currDest = nextDest;
            nextDest = spline.obj_points[currentPoint += 1];
        }
    }
    void GoToPoint()
    {
        Debug.Log("Moving");
        transform.position = Vector3.MoveTowards(transform.position, currDest, .02f * speed);
    }
}
