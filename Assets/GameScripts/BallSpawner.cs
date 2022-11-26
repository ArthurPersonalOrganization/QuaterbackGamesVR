using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

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

    [Header("Ball Settings values")]
    public TMP_Text smoothDuration;
    public TMP_Text velScale;
    public TMP_Text angVel;
    public TMP_Text toitRot;
    

    public bool trackRot { get; set; }
    public float throwSmoothingDuration { get; set; }
    public float throwVelocityScale { get; set; }
    public float angularVelocity { get; set; }
    
    public float angularDamp { get; set; }

    public float tightenRot { get; set; }



    public void SpawnBall()
    {
        GameObject ball = Instantiate(BallPrefab);
        XRGrabInteractable interactable;
        interactable = ball.GetComponent<XRGrabInteractable>();
        interactable.throwSmoothingDuration = throwSmoothingDuration;
        interactable.throwVelocityScale = throwVelocityScale;
        interactable.throwAngularVelocityScale = angularVelocity;
        interactable.angularVelocityDamping = angularDamp;
        interactable.trackRotation = trackRot;
        interactable.tightenRotation = tightenRot;
        ball.transform.localPosition = ballSpawnerOffset.localPosition;
        ball.transform.localRotation = Quaternion.identity;
        ball.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        ball.gameObject.name = "ball";
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
        Debug.Log("Spawn entered  " + other.tag);
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

    public void DisplayValues()
    {
        smoothDuration.text = ""+ throwSmoothingDuration;
        velScale.text = ""+ throwVelocityScale;
        angVel.text = "" + angularVelocity;
        toitRot.text = "" + tightenRot;
    }

}