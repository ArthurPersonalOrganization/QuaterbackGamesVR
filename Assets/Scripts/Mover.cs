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
    int pathLenght = 0;
    


    private void Start()
    {
        pathLenght = path.Length;
        pointSource = 0;
        pointDestiny = 1;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveThroughPath();
        }
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

        Debug.Log("At position moving to ");
         
         
    }

    void MoveThroughPath()
    {
        //we have n number of points in path
        Debug.Log("number of points in the path " + pathLenght);
        int i = 0;
        while (i <= pathLenght)
        {
            Debug.Log(path[i]+" "+path[i+1]);
            i++;
        }
        i = pathLenght;
        while (i >= 0)
        {
            Debug.Log(path[i] + " " + path[i-1]);
            i--;
        }
    }

}