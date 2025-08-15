using System.Collections;
using System.Collections.Generic;
using WesternFolkG;
using UnityEngine;
namespace WesternFolkG
{
    public class PlayerHealth : MonoBehaviour
    {
        public int Health;

        public bool isdestroy = false;


        void Start()
        {

        }
        public void TakeDamage(int damage)
        {
            if (!isdestroy)
            {
                Health -= damage;
                GamePlayManager.GamePlayManagerInstance.updatePlayerHealth(Health);
                if (Health <= 0)
                {
                    GamePlayManager.GamePlayManagerInstance.ShowHide_MissionEND();
                    isdestroy = true;
                    //  Destroy(gameObject, 0.2f);
                    //Instantiate(Explodeeffect, Instantiatetransform.position, Quaternion.identity);
                }
            }
        }
    }
}