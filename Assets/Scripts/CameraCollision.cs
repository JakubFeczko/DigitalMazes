using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject targetObject;
    public Vector3 direction;
    public bool moveObject = false;
    [Header("Capsule Collider")]
    public CapsuleCollider capsuleCollider;

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(mainCamera.transform.position, 0.1f);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider == capsuleCollider)
            {
                targetObject.SetActive(true);
                moveObject = true;
            }
        }
        if(moveObject)
        {
            targetObject.transform.position += direction * Time.deltaTime;
        }
    }

    //private void Update()
    //{
    //    if (moveObject)
    //    {
    //        targetObject.transform.position += direction * Time.deltaTime;
    //    }
    //}
}
