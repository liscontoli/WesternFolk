using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WesternFolkG;
public class MissionData : MonoBehaviour
{
    public static MissionData CloningEnemyInstance;
    public List<GameObject> AdderList;
    public List<GameObject> ScorpionList;
    public List<Transform> AdderTransform;
    public List<Transform> ScorpionTransform;
    public float waittimeAdder;
    public float waittimeScorpion;
    public bool stop = false;
    public bool onlyAdder = false;
    public bool onlyScorpion = false;

    public int TEnenmys;
    public int NCharacters;
    void Start()
    {
        NCharacters = TEnenmys;
        CloningEnemyInstance = this;
        if (onlyAdder)
        {
            GenerateAdder();
        }
        if (onlyScorpion)
        {
            GenerateScorpion();
        }
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
        while (!stop && TEnenmys != 0)
        {
            TEnenmys -= 1;
            int r = Random.Range(0, ScorpionList.Count);
            int _x = Random.Range(0, ScorpionTransform.Count);
            index++;
            GameObject Scorpion = Instantiate(ScorpionList[r], ScorpionTransform[_x].position, transform.localRotation, this.transform);
            Scorpion.SetActive(true);
            await Awaitable.WaitForSecondsAsync(waittimeScorpion);
        }
        /*    if (TEnenmys == 0)
            {
                GamePlayManager.GamePlayManagerInstance.ShowHide_MissionWIN();

            }*/
    }
    public async void GenerateAdder()
    {
        int index = 0;
        while (!stop && TEnenmys != 0)
        {
            TEnenmys -= 1;
            int r = Random.Range(0, AdderList.Count);
            int _x = Random.Range(0, AdderTransform.Count);
            index++;
            GameObject Adder = Instantiate(AdderList[r], AdderTransform[_x].position, transform.localRotation, this.transform);
            Adder.SetActive(true);
            await Awaitable.WaitForSecondsAsync(waittimeAdder);
        }
    }
}
