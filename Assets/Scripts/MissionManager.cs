using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace WesternFolkG
{
    public class MissionManager : MonoBehaviour
    {
        public Text CoinsTXT;
        private int CoinsVal;
        public GameObject MissionsMenuscreen;
        public int index_character;
        public List<GameObject> Mission_character;
        public int index_guns;
        public List<GameObject> Mission_guns;

        public List<GameObject> Mission_btns_txt;
        public List<int> Guns_Price;
        void Start()
        {
            UpdateMissionData();
        }
        public void SelectCharacter(int index)
        {
            index_character = index;
            if (index_character == 0)
            {
                Mission_character[1].transform.GetChild(0).gameObject.SetActive(false);
                Mission_character[0].transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (index_character == 1)
            {
                Mission_character[0].transform.GetChild(0).gameObject.SetActive(false);
                Mission_character[1].transform.GetChild(0).gameObject.SetActive(true);
            }
            PlayerPrefs.SetInt("Char_G", index_character);
            PlayerPrefs.Save();
        }


        public void SelectGuns(int index)
        {
            index_guns = PlayerPrefs.GetInt("Gun_selected");

            if (PlayerPrefs.GetInt("Gun_" + index) == 1 && index_guns != index)
            {
                Mission_guns[index].transform.GetChild(0).gameObject.SetActive(true);
                Mission_guns[index].transform.GetChild(1).gameObject.SetActive(false);
                Mission_guns[index_guns].transform.GetChild(0).gameObject.SetActive(false);
                index_guns = index;
                PlayerPrefs.SetInt("Gun_selected", index_guns);
                PlayerPrefs.Save();
            }
        }
        public void BuyGun(int index)
        {
            if (CoinsVal >= Guns_Price[index])
            {
                PlayerPrefs.SetInt("CoinsVal", CoinsVal - Guns_Price[index]);
                PlayerPrefs.SetInt("Gun_" + index, 1);
                SelectGuns(index);
                PlayerPrefs.Save();
                CoinsVal = PlayerPrefs.GetInt("CoinsVal");
                CoinsTXT.text = CoinsVal.ToString();

            }
        }
        public void DisplayGuns()
        {
            index_guns = PlayerPrefs.GetInt("Gun_selected");
            for (int i = 0; i < Mission_guns.Count; i++)
            {
                if (index_guns == i)
                {
                    Mission_guns[i].transform.GetChild(0).gameObject.SetActive(true);
                    Mission_guns[i].transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    Mission_guns[i].transform.GetChild(0).gameObject.SetActive(false);
                    if (PlayerPrefs.GetInt("Gun_" + i) == 1)
                    {
                        Mission_guns[i].transform.GetChild(1).gameObject.SetActive(false);
                    }
                    else
                    {
                        Mission_guns[i].transform.GetChild(1).gameObject.SetActive(true);
                        Mission_guns[i].transform.GetChild(1)
                        .transform.GetChild(1).gameObject.GetComponent<Text>().text = Guns_Price[i].ToString();
                    }
                }
            }
        }

        public void DisplayMissionBtns()
        {
            for (int i = 0; i < Mission_btns_txt.Count; i++)
            {
                if (PlayerPrefs.GetInt("Mission_" + (i)) == 1)
                {
                    Mission_btns_txt[i].transform.GetChild(1).GetComponent<Text>().text = "Available";
                }
                else
                {
                    Mission_btns_txt[i].transform.GetChild(1).GetComponent<Text>().text = "Unavailable";
                }
            }


        }
        public void DisplayCoinsVal()
        {
            CoinsVal = PlayerPrefs.GetInt("CoinsVal");
            CoinsTXT.text = CoinsVal.ToString();
        }
        public void DisplayCharacter()
        {
            index_character = PlayerPrefs.GetInt("Char_G");
            for (int i = 0; i < Mission_character.Count; i++)
            {
                if (index_character == i)
                {
                    Mission_character[i].transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    Mission_character[i].transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        public void ShowHide_MissionsMenuscreen()
        {
            if (MissionsMenuscreen.activeSelf)
            {
                MissionsMenuscreen.SetActive(false);
            }
            else
            {
                MissionsMenuscreen.SetActive(true);
            }
        }



        public void UpdateMissionData()
        {
            if (!PlayerPrefs.HasKey("MDataGame"))
            {
                PlayerPrefs.SetInt("MDataGame", 1);
                PlayerPrefs.SetInt("Char_G", 0);
                PlayerPrefs.SetInt("Gun_0", 1);
                PlayerPrefs.SetInt("Gun_1", 0);
                PlayerPrefs.SetInt("Gun_2", 0);
                PlayerPrefs.SetInt("Gun_3", 0);
                PlayerPrefs.SetInt("Gun_selected", 0);

                PlayerPrefs.SetInt("Mission_S", 0);

                PlayerPrefs.SetInt("Mission_0", 1);
                PlayerPrefs.SetInt("Mission_1", 0);
                PlayerPrefs.SetInt("Mission_2", 0);
                PlayerPrefs.SetInt("Mission_3", 0);
                PlayerPrefs.SetInt("CoinsVal", 6000);

                PlayerPrefs.SetInt("CGun_0", 21);
                PlayerPrefs.SetInt("CGun_1", 21);
                PlayerPrefs.SetInt("CGun_2", 21);
                PlayerPrefs.SetInt("CGun_3", 21);
                PlayerPrefs.Save();
            }
            DisplayCoinsVal();
            DisplayCharacter();
            DisplayGuns();
            DisplayMissionBtns();


        }

        public void MissionssScene(int Missionindex)
        {
            Time.timeScale = 1f;
            if (PlayerPrefs.GetInt("Mission_" + (Missionindex)) == 1)
            {
                PlayerPrefs.SetInt("Mission_S", Missionindex);
                SceneManager.LoadScene("GamePlay " + Missionindex);
            }

        }




    }
}






/* public void SetMissionSelect(int indexMission)
 {
     PlayerPrefs.SetInt("MissionSelect", indexMission);
     PlayerPrefs.Save();
 }*/


/* public void SelectMission(int indexMission)
 {
     if (CheckMission(indexMission))
     {
         SetMissionSelect(indexMission);
         ShowHide_MissionsMenuscreen();
     }
 }*/

/*----------------------------------------------------------------------------*/


/* public bool CheckMission(int indexMission)
 {
     if (PlayerPrefs.GetInt("lev_" + indexMission) == 1)
     {
         return true;
     }
     return false;
 }*/

/*for (int i = 0; i < Mission_list.Count; i++)
{
if (CheckMission(i + 1))
{
Mission_list[i].GetComponent<Image>().sprite = Mission_open;
Mission_list[i].transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
}
else
{
Mission_list[i].GetComponent<Image>().sprite = Mission_locked;
Mission_list[i].transform.GetChild(0).GetComponent<Text>().text = "";
}

}*/