using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
namespace WesternFolkG
{
    public class CharacterMovement : MonoBehaviour
    {
        public NavMeshAgent Agent;
        public Animator animator;
        public List<Transform> TargetPos;
        public float Distance;
        public bool stop = false;
        public bool startAttack = false;
        public Transform PlayerPos;
        public float DelayMovement = 4f;
        void Start()
        {
            Agent = this.GetComponent<NavMeshAgent>();

            PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
            Invoke("StartRun", DelayMovement);
        }
        public void StartRun()
        {
            animator.Play("Run_N");
            Agent.destination = TargetPos[0].position;

        }
        public void StartAttack()
        {
            animator.Play("IdleShoot");
            startAttack = true;
        }

        void FixedUpdate()
        {
            Distance = Vector3.Distance(TargetPos[0].position, this.transform.position);
            if ((int)Distance == 0 && !stop)
            {
                stop = true;
                Agent.enabled = false;
                StartAttack();
            }
            if (!this.GetComponent<CharacterEnemyHealth>().isdDeath)
            {
                Vector3 aimDirection = (PlayerPos.position - transform.position).normalized;
                this.transform.rotation = Quaternion.LookRotation(aimDirection, Vector3.up);
            }


        }
    }
}