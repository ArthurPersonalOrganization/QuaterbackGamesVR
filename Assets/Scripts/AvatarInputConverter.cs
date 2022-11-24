using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarInputConverter : MonoBehaviour
{
  //Avatar Transforms
        public Transform MainAvatarTransform;
        public Transform AvatarHead;
        public Transform AvatarBody;
        public Transform AvatarHand_left;
        public Transform AvatarHand_right;

        public Transform XRHead;
        public Transform XRHand_Left;
        public Transform XRHand_Right;
        public Vector3 headPositionOffset;
        public Vector3 handRotationOffset;


    private void Start() 
    {
        this.gameObject.transform.position = Vector3.zero;
        AvatarHand_left.transform.position = AvatarHand_right.transform.position = Vector3.zero;    
    }
    // Update is called once per frame
    void Update()
    {
        MainAvatarTransform.position = Vector3.Lerp(MainAvatarTransform.position, XRHead.position + headPositionOffset, 0.5f);
        AvatarHead.rotation = Quaternion.Lerp(AvatarHead.rotation, XRHead.rotation, 0.5f);
        AvatarBody.rotation = Quaternion.Lerp(AvatarBody.rotation, Quaternion.Euler(new Vector3(0, AvatarHead.rotation.eulerAngles.y,0)),0.05f);

        AvatarHand_right.position = Vector3.Lerp(AvatarHand_right.position, XRHand_Right.position, 0.5f);
        AvatarHand_right.rotation = Quaternion.Lerp(AvatarHand_right.rotation, XRHand_Right.rotation,0.5f) * Quaternion.Euler(handRotationOffset);
        
        AvatarHand_left.position = Vector3.Lerp(AvatarHand_left.position, XRHand_Left.position, 0.5f);
        AvatarHand_left.rotation = Quaternion.Lerp(AvatarHand_left.rotation, XRHand_Left.rotation,0.5f) * Quaternion.Euler(handRotationOffset);

       // Debug.Log("XR hand rotation =" + XRHand_Left.rotation);
       
    }
}
