using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
//using System;
namespace WesternFolkG
{
    public class BoxHealth : MonoBehaviour
    {
        public int Health;
        int TempHealth;
        public int MinHealth;
        public int MaxHealth;
        public GameObject Explodeeffect;

        public bool isdestroy = false;

        public Transform Instantiatetransform;

        public Image HealthBar;

        public bool haveBar = false;



        void Start()
        {
            Health = Random.Range(MinHealth, MaxHealth);
            TempHealth = Health;
            if (haveBar)
            {
                HealthBar.fillAmount = 1f;
            }


        }
        public void TakeDamage(int damage)
        {
            if (!isdestroy)
            {
                Health -= damage;
                if (haveBar)
                {
                    HealthBar.fillAmount = (float)Health / (float)TempHealth;
                }

                if (Health <= 0)
                {
                    isdestroy = true;
                    Destroy(gameObject, 0.2f);

                    int r = Random.Range(0, 5);
                    if (r == 1)
                    {
                        Instantiate(Explodeeffect, Instantiatetransform.position, Quaternion.identity);
                    }

                    MissionData.CloningEnemyInstance.NCharactersC();

                    // await Awaitable.WaitForSecondsAsync(1f);

                }
            }
        }






    }

}
