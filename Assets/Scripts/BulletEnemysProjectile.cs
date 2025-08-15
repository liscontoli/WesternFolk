using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WesternFolkG
{
    public class BulletEnemysProjectile : MonoBehaviour
    {

        [SerializeField] private Transform vfxHitGreen;
        [SerializeField] private Transform vfxHitRed;

        private Rigidbody bulletRigidbody;

        private void Awake()
        {
            bulletRigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            float speed = 50f;
            bulletRigidbody.velocity = transform.forward * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BulletEnemy>() != null)
            {
                // Hit target
                Instantiate(vfxHitGreen, transform.position, Quaternion.identity);

                other.GetComponent<PlayerHealth>().TakeDamage(1);
            }
            else
            {
                // Hit something else
                Instantiate(vfxHitRed, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}