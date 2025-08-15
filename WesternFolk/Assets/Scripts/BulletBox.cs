using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WesternFolkG
{
    public class BulletBox : MonoBehaviour
    {
        // Start is called before the first frame update
        public int Val;
        public bool isBullet;
        public bool isCoins;

        void Start()
        {

        }

        void FixedUpdate()
        {
            this.transform.Rotate(0f, 2f, 0f, Space.Self);

        }


        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("--------------------------------");
            if (other.gameObject.tag == "Player")
            {
                if (isBullet)
                {
                    GamePlayManager.GamePlayManagerInstance.updateGunscollect(Val);
                }
                if (isCoins)
                {
                    GamePlayManager.GamePlayManagerInstance.updatecoinscollect(Val);
                }

                Destroy(gameObject);
            }
        }


    }
}
