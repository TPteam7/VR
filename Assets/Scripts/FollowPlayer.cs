using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public float TargetDistance;
    public float AllowedDistance = 10;
    public GameObject Penguin;
    public float FollowSpeed;
    public RaycastHit Shot;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance >= AllowedDistance) 
            {
                FollowSpeed = .02f;
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, FollowSpeed);
            }
            else
            {
                FollowSpeed = 0;
            }
        }
    }
}