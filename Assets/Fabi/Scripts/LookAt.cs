using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private float fov;
    [SerializeField] private Transform target;
    [SerializeField] private Material lookMat, notLookMat;
    [SerializeField] private bool front;
    private bool sight = false;

    void Update()
    {
        if (sight) return;
        if (target) 
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = (target.position - transform.position);
            toOther.Normalize();
            float dot = Vector3.Dot(forward, toOther);
            bool condition = front ? dot > fov : dot < fov;
            Renderer r = target.gameObject.GetComponent<Renderer>();
            r.material = condition ? lookMat : notLookMat;
            if (condition) sight = true;
        }
    }
}
