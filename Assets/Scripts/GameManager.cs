using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Android;
using Unity.VisualScripting;
namespace WesternFolkG
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager GameManagerInstance;
        public GameObject MainMenu;
        public GameObject SettingsMenu;
        public GameObject ExitMenu;
        public GameObject MissionSelectMenu;

        public bool test = false;

        private void Awake()
        {
            GameManagerInstance = this;
        }
        void Start()
        {
            if (test)
            {
                PlayerPrefs.DeleteAll();
            }
            //             PlayerPrefs.DeleteAll();

        }
        public void ShowHide_MissionSelectMenu()
        {
            if (MissionSelectMenu.activeSelf)
            {
                MissionSelectMenu.SetActive(false);
            }
            else
            {
                MissionSelectMenu.SetActive(true);
            }
        }
        public void ShowHide_SettingsMenu()
        {
            if (SettingsMenu.activeSelf)
            {
                SettingsMenu.SetActive(false);
            }
            else
            {
                SettingsMenu.SetActive(true);
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

        public void ExitGame()
        {

            Application.Quit();


        }




    }
}