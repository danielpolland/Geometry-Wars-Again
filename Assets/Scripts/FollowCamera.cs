using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform objecttofollow;
    Vector3 targetposition;

     void LateUpdate()
    {
        targetposition.x = objecttofollow.position.x;
        targetposition.y = objecttofollow.position.y;
        targetposition.z = transform.position.z;

        transform.position = targetposition;
    }
}
