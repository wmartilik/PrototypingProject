using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    float speed = 50;
    Vector3 currDest;
    Vector3 nextDest;
    public TargetSpline spline;
    int currentPoint = 0;

    void Start()
    {
        transform.position = spline.obj_points[currentPoint];
        currDest = spline.obj_points[currentPoint + 1];
        Debug.Log(currDest);
        nextDest = spline.obj_points[currentPoint + 2];
        Debug.Log(nextDest);
        currentPoint += 1;
    }

    void Update()
    {
        GoToPoint();

        //Rotates Target
        transform.Rotate(Vector3.up * speed * Time.deltaTime);

        //if target is less than 1 unit from current destination, go to next destination
        if (Vector3.Distance(transform.position, currDest) < 1f)
        {
            currDest = nextDest;
            nextDest = spline.obj_points[currentPoint + 2];
            currentPoint += 1;
        }

        if(currentPoint == spline.obj_points.Count)
        {
            currentPoint = 0;
        }
    }
    void GoToPoint()
    {
        Debug.Log("Moving");
        transform.position = Vector3.MoveTowards(transform.position, currDest, .02f);
    }
}
