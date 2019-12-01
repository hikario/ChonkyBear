// Patrol.cs
using UnityEngine;
using System.Collections;


public class SalmonBehavior : MonoBehaviour
{

  public Transform[] wayPoints;
  private int destPoint = 0;
  private UnityEngine.AI.NavMeshAgent agent;
  public bool flee = false;
  private bool losing = false;
  private Transform player;
  private Camera mc;
  private float MultiplyBy = 2.0f;

  void Start() {
    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    // Disabling auto-braking allows for continuous movement
    // between points (ie, the agent doesn't slow down as it
    // approaches a destination point).
    agent.autoBraking = false;

    GotoNextPoint();

    player = GameObject.FindWithTag("Player").transform;
    mc = Camera.main;

  }


  void GotoNextPoint() {
    // Returns if no points have been set up
    if (wayPoints.Length == 0) {
      return;
    }

    // Set the agent to go to the currently selected destination.
    agent.destination = wayPoints[destPoint].position;

    // Choose the next point in the array as the destination,
    // cycling to the start if necessary.
    destPoint = (destPoint + 1) % wayPoints.Length;
  }


  void Update() {
    // Choose the next destination point when the agent gets
    // close to the current one.

    if (agent.remainingDistance < 2.0f) {
      GotoNextPoint();
      print("Next Stop");
    }
    if (flee == true) {
      FleeFromUser();
      if (!losing) {
        StartCoroutine(LosePlayer());
        losing = true;
      }
    }
  }

  void FleeFromUser() {
    Transform startTransform = transform;

    //temporarily point the object to look away from the player
    transform.rotation = Quaternion.LookRotation(transform.position - player.position);

    //Then we'll get the position on that rotation that's multiplyBy down the path (you could set a Random.range
    // for this if you want variable results) and store it in a new Vector3 called runTo
    Vector3 runTo = transform.position + transform.forward * MultiplyBy;

    //So now we've got a Vector3 to run to and we can transfer that to a location on the NavMesh with samplePosition.

    UnityEngine.AI.NavMeshHit hit;    // stores the output in a variable called hit

    // 5 is the distance to check, assumes you use default for the NavMesh Layer name
    UnityEngine.AI.NavMesh.SamplePosition(runTo, out hit, 5, 1 << UnityEngine.AI.NavMesh.GetNavMeshLayerFromName("Walkable"));
    //Debug.Log("hit = " + hit + " hit.position = " + hit.position);

    // And get it to head towards the found NavMesh position
    agent.SetDestination(hit.position);

  }

  void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      mc.SendMessage("CausePanic");
    }
    if (other.tag == "WayPoint") {
      GotoNextPoint();
      print("Next Stop");
    }
  }

  void OnEnable() {
    EventManager.StartPanic += Flee;
  }

  void OnDisable() {
    EventManager.StartPanic -= Flee;
  }

  void Flee() {
    agent.speed = agent.speed * 1.5f;
    flee = true;
  }

  IEnumerator LosePlayer() {
    yield return new WaitForSeconds (5);
    print (Time.time);
    flee = false;
    losing = false;
    agent.speed = agent.speed / 1.5f;
    GotoNextPoint ();
  }


}
