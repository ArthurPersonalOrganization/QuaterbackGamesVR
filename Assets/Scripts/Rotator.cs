using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    [Range(-1.5f,1.5f)]
    private float speed;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0,0,speed, Space.Self);
    }
}
