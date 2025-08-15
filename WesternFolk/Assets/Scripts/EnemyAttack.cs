using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WesternFolkG
{
    public class EnemyAttack : MonoBehaviour
    {
        public GameObject Shot;
        public Transform firePoint;
        public Transform hitPoint;
        public float shotDelay = 0.4f;
        float shotTimer;
        public bool AutoShot = false;

        public Transform PlayerPos;

        public LayerMask aimColliderLayerMask = new LayerMask();
        [SerializeField] private GameObject ShotFx;
        void Start()
        {
            PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        }
        private void FixedUpdate()
        {
            if (AutoShot)
            {
                shotTimer -= Time.deltaTime;
                if (shotTimer <= 0f)
                {
                    GameObject g = Instantiate(Shot, firePoint.position, firePoint.rotation);
                    //  g.GetComponent<AudioSource>().Play();
                    //  AudioManager.AudioManagerInstance.PlayGunshotAction();
                    PlayGunshotAction();
                    shotTimer = shotDelay;
                }
            }

            Vector3 aimDirection = (PlayerPos.position - transform.position).normalized;
            RaycastHit hit;
            if (Physics.Raycast(hitPoint.position, aimDirection, out hit, 20f, aimColliderLayerMask))
            {
                //         Debug.DrawRay(hitPoint.position, aimDirection * 20f, Color.yellow);
                if (this.gameObject.tag == "EnemiesT2")
                {
                    if (hit.transform.CompareTag("Player") && this.GetComponent<CharacterMovement>().startAttack)
                    {
                        AutoShot = true;
                    }
                    else
                    {
                        AutoShot = false;
                    }
                }

            }
        }
        public void PlayGunshotAction()
        {
            GameObject g = Instantiate(ShotFx, this.transform.position, Quaternion.identity);
            Destroy(g, 2f);
        }
    }
}