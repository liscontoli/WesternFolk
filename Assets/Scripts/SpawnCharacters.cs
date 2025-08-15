using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WesternFolkG
{
    public class SpawnCharacters : MonoBehaviour
    {
        public static SpawnCharacters SpawnCharactersInstance;
        public List<GameObject> CharactersList;
        public List<Transform> CharactersTransform;
        public float waittime;
        public bool stop = false;
        public int NCharacters;


        void Start()
        {
            SpawnCharactersInstance = this;
            //  GenerateScorpion();

        }

        public async void NCharactersC()
        {
            NCharacters -= 1;
            if (NCharacters == 0)
            {
                GamePlayManager.GamePlayManagerInstance.ShowHide_MissionWIN();

            }
        }

        public async void GenerateScorpion()
        {
            int index = 0;
            while (!stop && NCharacters != 0)
            {
                NCharacters -= 1;
                int r = Random.Range(0, CharactersList.Count);
                int _x = Random.Range(0, CharactersTransform.Count);
                index++;
                GameObject Scorpion = Instantiate(CharactersList[r], CharactersTransform[_x].position, transform.localRotation, this.transform);
                Scorpion.SetActive(true);
                await Awaitable.WaitForSecondsAsync(waittime);
            }
        }


    }
}
