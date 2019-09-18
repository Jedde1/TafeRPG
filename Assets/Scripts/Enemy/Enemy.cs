using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum AIState
    {
        Patrol,
        Seek,
        Attack,
        Die
    }
    [Space(5),Header("Base Stats")]
    public AIState state;
    public float curHealth, mxHealth, moveSpeed, attackRange, attackSpeed, sightRange;
    public int curWaypoint;

    [Space(5), Header("Base References")]
    public GameObject self;
    public Transform player;
    public Transform waypointParent;
    protected Transform[] waypoints;
    public NavMeshAgent agent;
    public GameObject healthCanvas;
    public Image healthbar;
    public Animator anim;

    private void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        agent = self.GetComponent<NavMeshAgent>();
        curWaypoint = 1;
        agent.speed = moveSpeed;
        anim = self.GetComponent<Animator>();
        Patrol();

    }

    private void Update()
    {
        Patrol();
        Seek();
        Attack();
        Die();
    }
    public void Patrol()
    {
        state = AIState.Patrol;
        //DO NOT CONTINUE IF NO WAYPOINTS
        if (waypoints.Length == 0 || Vector3.Distance(player.position,self.transform.position) <= sightRange)
        {
            return;
        }
        //Follow waypoints
        //Set agent to target
        agent.destination = waypoints[curWaypoint].position;
        //Are we at the waypoint
        if (self.transform.position.x.Equals(agent.destination.x))
        {
            if(curWaypoint < waypoints.Length - 1)
            {
                //If so go to next waypoin
                curWaypoint++;
            }
            else
            {
                //If at end of patrol go to start
                curWaypoint = 1;
            }
        }
        //If so go to next waypoint
    }
    public void Seek()
    {
        if(Vector3.Distance(player.position, self.transform.position) > sightRange || Vector3.Distance(player.position, self.transform.position) < attackRange)
        {
            return;
        }
        state = AIState.Seek;
        //If player in SightRange and not attack then chase
        agent.destination = player.position;
    }
    public virtual void Attack()
    {
       if (Vector3.Distance(player.position, self.transform.position) > attackRange || curHealth > 0)
        {
            return;
        }
        state = AIState.Attack;
        //If player in attack range attack
        Debug.Log("Attack");
    }
    public void Die()
    {
        //If we are Alive
        if(curHealth > 0)
        {
            //Don't run this
            return;
        }
        //Else we are dead so run ths
        state = AIState.Die;
        //Drop EPIC LOOTZ
    }
}
