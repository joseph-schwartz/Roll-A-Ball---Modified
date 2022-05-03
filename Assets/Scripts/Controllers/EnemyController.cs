using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    //Aggro Range
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the enemy's target to the player
        target = PlayerManager.instance.player.transform;
        //Setes a local variable for the agent so you don't have to call get each time
        agent = GetComponent<NavMeshAgent>();
    }
  

    // Update is called once per frame
    void Update()
    {   
        //Distance between target and the enemy
        float distance = Vector3.Distance(target.position, transform.position);
        //If within aggro range
        if (distance <= lookRadius)
        {
            //The Angle between the enemy's vision and the player's position
            float angleOfVision = Vector3.Angle(transform.forward, target.position);
            //If in vision, charge
            if (angleOfVision < 45)
            {
                agent.SetDestination(target.position);
            }
            //If not in vision, turn to face player
            else
            {
                FaceTarget();
            }
            //Face if stopped, Useful for future Ideas

        }

    }
    //Rotates the enemy to face the player, uses Quaternion.Slerp to make a smoother rotation
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * .5f);
    }

    //Used to visualize the aggro range - Something in my settings is not letting me see it though
    void onDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
