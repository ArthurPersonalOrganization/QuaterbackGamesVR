using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LoginManager : MonoBehaviour
{
    public GameObject ConnectOptionsPanelGameObject;
    public GameObject ConnectWithNamePanelGameObject;

    public GameObject Player;
    public GameObject UILoginGameObject;
    public Vector3 UIPanelDistanceFromRig = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        ConnectOptionsPanelGameObject.SetActive(true);
        ConnectWithNamePanelGameObject.SetActive(false);
    }

    private void Update() 
    {
        
    }
    
    public void SetDistanceLoginFromRig()
    {
        UILoginGameObject.transform.position = UIPanelDistanceFromRig; 
    }

}
