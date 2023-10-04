using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour {

    public Transform target;
    NavMeshAgent nav;

    // Start is called before the first frame update

    void Start() {
        nav = GetComponent<NavMeshAgent>();
    }

    void update() {
        nav.SetDestination(target.position);
    }
}