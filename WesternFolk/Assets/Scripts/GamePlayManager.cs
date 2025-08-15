using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Android;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;
using Cinemachine;

namespace WesternFolkG
{
    public class GamePlayManager : MonoBehaviour
    {
        public static GamePlayManager GamePlayManagerInstance;
        public Text GunsCounter;
        public Text CoinsCounter;
        public Text PlayerHealth;
        public GameObject Gameoverscreen;
        public GameObject VICTORYscreen;
        public GameObject ExitMenu;
        public Text Coinsvictory, Scorevictory;
        public Text Coinsgameover, Scoregameover;
        private int CoinsVal;
        private int GunsVal;
        public bool HaveBullets = true;

        public List<GameObject> playerMeshes;
        public List<Transform> playerMeshesRoot;
        public List<CinemachineVirtualCamera> cinemachineVirtualCameras;
        int index_char;
        void Start()
        {
            GamePlayManagerInstance = this;
            UpdateMissionData();
            index_char = PlayerPrefs.GetInt("Char_G");
            if (index_char == 0)
            {
                playerMeshes[1].SetActive(false);
                playerMeshes[0].SetActive(true);
                cinemachineVirtualCameras[0].Follow = playerMeshesRoot[0];
                cinemachineVirtualCameras[1].Follow = playerMeshesRoot[0];
            }
            else if (index_char == 1)
            {
                playerMeshes[0].SetActive(false);
                playerMeshes[1].SetActive(true);
                cinemachineVirtualCameras[0].Follow = playerMeshesRoot[1];
                cinemachineVirtualCameras[1].Follow = playerMeshesRoot[1];
            }


            // updateGunscollect(21);

        }
        public void UpdateMissionData()
        {
            DisplayCoinsVal();
            DisplayGunsVal();
        }


        public void updatePlayerHealth(int health)
        {
            PlayerHealth.text = health.ToString() + " %";
        }

        public void updatecoinscollect(int coinval)
        {
            CoinsVal += coinval;
            PlayerPrefs.SetInt("CoinsVal", CoinsVal);
            PlayerPrefs.Save();
            CoinsCounter.text = CoinsVal.ToString();
        }
        public void updateGunscollect(int gunsVal)
        {
            GunsVal += gunsVal;
            PlayerPrefs.SetInt("CGun_" + PlayerPrefs.GetInt("Gun_selected"), GunsVal);
            PlayerPrefs.Save();
            GunsCounter.text = GunsVal.ToString();
            HaveBullets = true;
        }

        public void updateshotCount()
        {
            if (GunsVal != 0)
            {
                GunsVal -= 1;
                PlayerPrefs.SetInt("CGun_" + PlayerPrefs.GetInt("Gun_selected"), GunsVal);
                PlayerPrefs.Save();
                GunsCounter.text = GunsVal.ToString();
                HaveBullets = true;
            }
            if (GunsVal == 0)
            {
                HaveBullets = false;
            }

        }








        public void DisplayCoinsVal()
        {
            CoinsVal = PlayerPrefs.GetInt("CoinsVal");
            CoinsCounter.text = CoinsVal.ToString();

        }
        public void DisplayGunsVal()
        {
            GunsVal = PlayerPrefs.GetInt("CGun_" + PlayerPrefs.GetInt("Gun_selected"));
            GunsCounter.text = GunsVal.ToString();
            if (GunsVal == 0)
            {
                HaveBullets = false;
            }
            else
            {
                HaveBullets = true;
            }
        }


        public void ShowHide_MissionWIN()
        {
            if (VICTORYscreen.activeSelf)
            {
                VICTORYscreen.SetActive(false);
            }
            else
            {
                int nextMissionIndex = PlayerPrefs.GetInt("Mission_S") + 1;
                if (PlayerPrefs.GetInt("Mission_" + nextMissionIndex) != 1)
                {
                    PlayerPrefs.SetInt("Mission_" + nextMissionIndex, 1);
                }
                PlayerPrefs.SetInt("Mission_S", nextMissionIndex);
                PlayerPrefs.Save();
                Time.timeScale = 0f;
                VICTORYscreen.SetActive(true);
            }
        }
        public void ShowHide_MissionEND()
        {
            if (Gameoverscreen.activeSelf)
            {
                Gameoverscreen.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                Gameoverscreen.SetActive(true);
            }
        }
        public void ShowHide_ExitMenu()
        {
            if (ExitMenu.activeSelf)
            {
                Time.timeScale = 1f;
                ExitMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                ExitMenu.SetActive(true);
            }
        }
        public void MainMenuScene()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Main");
        }
        public void GamePlayScene()
        {
            Time.timeScale = 1f;
            string s = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(s);
        }

        public void GamePlayNextMissionScene()
        {
            Time.timeScale = 1f;
            string s = PlayerPrefs.GetInt("Mission_S").ToString();
            SceneManager.LoadScene("GamePlay " + s);
        }

    }
}