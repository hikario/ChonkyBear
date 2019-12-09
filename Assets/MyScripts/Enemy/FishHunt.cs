// Patrol.cs
using UnityEngine;
using System.Collections;
 

public class FishHunt : MonoBehaviour
{

    public Transform[] wayPoints;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
	public bool aggro = false;
	private Transform fish;


    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();

		fish = GameObject.FindWithTag ("Fish").transform;
    }


   void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (wayPoints.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = wayPoints[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % wayPoints.Length;
    }
	

    void Update()
    {
        // Choose the next destination point when the agent gets        
		if (aggro == true) 
		{
			agent.destination = fish.position;
		}
    }

	void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Fish")
        {
			aggro = true;
            ChaseTime();
		}

        if (other.tag == "WayPoint")
        {
            GotoNextPoint();
            print("Next Stop");
        }
	}

    void ChaseTime()
    {
        //agent.destination = player.position;
        Debug.Log("AGGROOOOOO");
    }

	void OnTriggerExit(Collider other)
    {
		if (other.tag == "Fish")
        {
			//aggro = false;
			StartCoroutine(LosePlayer());
		}
	}

	IEnumerator LosePlayer()
	{
		yield return new WaitForSeconds (5);
		print (Time.time);
		aggro = false;
		GotoNextPoint ();

	}

   
}