using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagDollOnOff : MonoBehaviour
{
    public BoxCollider mainCollider;
    public GameObject CharacterRig;
    public Animator CharacterAnimator;

    public Transform pos1, pos2;
    public Vector3 target;

    public Rigidbody rb;

   

    //public NavMeshAgent agent;
    /*public float range; //radius of sphere

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area*/




    // Start is called before the first frame update
    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();

        target = GetRandomPosition();

        rb = GetComponent<Rigidbody>();

        //agent = GetComponent<NavMeshAgent>();


    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(pos1.position.x, pos2.position.x);
        float z = Random.Range(pos1.position.z, pos2.position.z);
        float y = 0.589f;

        return new Vector3(x, y , z);
    }

 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Ball"))
        {
            RagdollModeOn();

            //agent.enabled = false;

            Character1Drop.instance.InstantiateCharacter();
            Object.Destroy(gameObject, 5.0f);

        }
    }

    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidbodies;
    void GetRagdollBits()
    {
        ragDollColliders = CharacterRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = CharacterRig.GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }*/

        // Destroy();

       

        Vector3 dir = target - transform.position;
        dir.Normalize();
        dir *= 0.8f;

        rb.AddForce(dir, ForceMode.Impulse);

        //transform.Translate(dir);
            
       if (Vector3.Distance(transform.position, target) < 0.5)
       {
        target = GetRandomPosition();
       }
        


    }

    /*bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 2.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }*/

    void RagdollModeOn()
    {
        CharacterAnimator.enabled = false;
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }

        
        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    void RagdollModeOff()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = false;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }

        CharacterAnimator.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
