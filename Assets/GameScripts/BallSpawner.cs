using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject BallPrefab;
    [SerializeField]
    private bool ballHere = false;

    [SerializeField]
    private Transform ballSpawnerOffset;
    //  private GameObject[] ballArray;
     
    public void SpawnBall()
    {
        GameObject ball = Instantiate(BallPrefab);
        ball.transform.localPosition = ballSpawnerOffset.localPosition;
        ball.transform.localRotation = Quaternion.identity;
        ball.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        ball.gameObject.name = "ball";
    }

    public void DestroyBall()
    {
        
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Ball"))
        {
            ballHere = false;
             
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (!ballHere)
            {
                SpawnBall();
            }         
        }
        if (other.tag.Equals("Ball"))
        {
            ballHere = true;
            Debug.Log("Ball here");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Other "+other.name);
      
    }
}