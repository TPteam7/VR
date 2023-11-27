using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private Animator animator;
    public GameObject Player;
    public float AllowedDistance;
    public GameObject Penguin;
    public float FollowSpeed;
    public RaycastHit Shot;
    public float MaxRaycastDistance = 20;
    public float StopDistance = 2.0f;

    private void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
        animator.SetTrigger("idle");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * MaxRaycastDistance, Color.red);

        transform.LookAt(Player.transform);
        transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot, MaxRaycastDistance))
        {
            // Get the current position of the object
            Vector3 currentPosition = transform.position;

            // Set the target position only in the x and y directions
            Vector3 targetPosition = new Vector3(Player.transform.position.x, currentPosition.y, Player.transform.position.z);

            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, FollowSpeed);

            float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

            if (distanceToPlayer <= StopDistance)
            {
                FollowSpeed = 0f;
            }
            else
            {
                FollowSpeed = 0.02f;
                animator.SetTrigger("walk");
            }
        }
    }
}