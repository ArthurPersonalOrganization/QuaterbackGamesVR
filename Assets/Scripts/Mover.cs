using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Transform[] path;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int pointSource = 0;

    [SerializeField]
    private int pointDestiny = 0;

    [SerializeField]
    private int pathLenght = 0;

    [Header("Index values")]
    public int prev = 0;
    public int index = 0;
    public int next = 0;

    private void Start()
    {
        pathLenght = path.Length;
        pointSource = 0;
        pointDestiny = 1;
        MoveThroughPath();

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveThroughPath();
        }
    }

    private void MoveThroughPath()
    {
        StartCoroutine(SequenceRoutine());
    }

    private IEnumerator SequenceRoutine()
    {
        //we have n number of points in path
       // Debug.Log("number of points in the path " + pathLenght);
        while (index < pathLenght)
        {
            prev = index - 1;
            next = index + 1;

            if (next >= pathLenght)
            {
                //Debug.Log("reached  top number");
                next = 0;
                // Debug.Log("From " + index + " to " + next);
                yield return StartCoroutine(MoveRoutine(path[index].localPosition, path[next].localPosition, speed));

                index = 0;
                next = index + 1;
                prev = index - 1;
            }

            //Debug.Log("From " + index + " to " + next);
            yield return StartCoroutine(MoveRoutine(path[index].localPosition, path[next].localPosition, speed));

            //yield return new WaitForSeconds(1f);
            index++;
        }
        yield return new WaitForEndOfFrame();
    }

    private void Move()
    {
        if (pathLenght >= 2)
        {
            StartCoroutine(MoveRoutine(path[pointSource].localPosition, path[pointDestiny].localPosition, speed));
        }
        else
        {
            Debug.Log("Not enough points to move");
        }
    }

    private IEnumerator MoveRoutine(Vector3 a, Vector3 b, float speed)
    {
        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step;
            this.transform.localPosition = Vector3.Lerp(a, b, t);
            yield return new WaitForFixedUpdate();
        }
        this.transform.localPosition = b;

      //  Debug.Log("At position moving to ");
    }
}