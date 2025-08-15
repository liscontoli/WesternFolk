using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
//using System;
namespace WesternFolkG
{
    public class CharacterEnemyHealth : MonoBehaviour
    {
        public int Health;
        public int MinHealth;
        public int MaxHealth;
        int TempHealth;
        public bool isdDeath = false;
        //    public GameObject Explodeeffect;
        public Image HealthBar;
        //      public Transform Instantiatetransform;

        void Start()
        {
            Health = Random.Range(MinHealth, MaxHealth);
            TempHealth = Health;
            HealthBar.fillAmount = 1f;



        }

        public void TakeDamage(int damage)
        {
            if (!isdDeath)
            {
                Health -= damage;
                HealthBar.fillAmount = (float)Health / (float)TempHealth;
                if (Health <= 0)
                {
                    isdDeath = true;
                    this.GetComponent<Animator>().Play("Death");


                    //  this.transform.position = new Vector3(this.transform.position.x, -1.04f, this.transform.position.z);
                    this.GetComponent<CharacterMovement>().startAttack = false;

                    SpawnCharacters.SpawnCharactersInstance.NCharactersC();
                    //Death

                    Destroy(gameObject, 6f);

                    /*int r = Random.Range(0, 5);
                    if (r == 1)
                    {
                        Instantiate(Explodeeffect, Instantiatetransform.position, Quaternion.identity);
                    }*/
                }
            }

        }
    }
}