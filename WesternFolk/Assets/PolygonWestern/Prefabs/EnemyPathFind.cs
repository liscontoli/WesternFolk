using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace WesternFolkG
{
    public class EnemyPathFind : MonoBehaviour
    {
        public NavMeshAgent Agent;
        public Transform PlayerPos;
        public float Distance;
        public bool stop = false;
        void Start()
        {
            PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
            Agent = this.GetComponent<NavMeshAgent>();
        }
        void FixedUpdate()
        {
            Distance = Vector3.Distance(PlayerPos.position, this.transform.position);
            if (Distance >= 3f)
            {
                Agent.enabled = true;
                Agent.destination = PlayerPos.position;
                this.GetComponent<EnemyAttack>().AutoShot = false;
            }
            else
            {
                this.GetComponent<EnemyAttack>().AutoShot = true;
                Agent.enabled = false;
                stop = true;
            }
        }
    }
}