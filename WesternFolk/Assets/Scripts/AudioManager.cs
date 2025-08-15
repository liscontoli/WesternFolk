using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Android;
using Unity.VisualScripting;

namespace WesternFolkG
{
    public class AudioManager : MonoBehaviour
    {
        // Start is called before the first frame update
        public static AudioManager AudioManagerInstance;
        public Sprite Btn_ON, Btn_OFF;
        public Image Btn_Music, Btn_Sounds;
        public bool AudioSounds = false;
        public bool AudioMusic = false;
        public AudioSource MBG, Button, GameOver, LevelUpMusic, Tap, Crack, gunshot;

        public bool gameplayscene = false;
        void Start()
        {
            AudioManagerInstance = this;
            SetupAudio();
        }

        public void SetupAudio()
        {

            if (!PlayerPrefs.HasKey("Music"))
            {
                PlayerPrefs.SetInt("Music", 1);
                PlayerPrefs.SetInt("Sounds", 1);
                PlayerPrefs.Save();
            }
            PlayMusic();
            PlaySounds();



        }


        public void MusicBtnClick()
        {
            PlayBtnClick();
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                Btn_Music.sprite = Btn_ON;
                PlayerPrefs.SetInt("Music", 1);
                AudioMusic = true;
            }
            else if (PlayerPrefs.GetInt("Music") == 1)
            {
                Btn_Music.sprite = Btn_OFF;
                PlayerPrefs.SetInt("Music", 0);

                AudioMusic = false;
            }
            PlayerPrefs.Save();
            PlayBackgroundMusic();
        }

        public void SoundsBtnClick()
        {
            PlayBtnClick();
            if (PlayerPrefs.GetInt("Sounds") == 0)
            {
                Btn_Sounds.sprite = Btn_ON;
                PlayerPrefs.SetInt("Sounds", 1);
                AudioSounds = true;

            }
            else if (PlayerPrefs.GetInt("Sounds") == 1)
            {
                Btn_Sounds.sprite = Btn_OFF;
                PlayerPrefs.SetInt("Sounds", 0);
                AudioSounds = false;

            }
            PlayerPrefs.Save();
        }

        public void PlayMusic()
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                if (!gameplayscene)
                {
                    Btn_Music.sprite = Btn_OFF;
                }

                AudioMusic = false;
            }
            else if (PlayerPrefs.GetInt("Music") == 1)
            {
                if (!gameplayscene)
                {
                    Btn_Music.sprite = Btn_ON;
                }

                AudioMusic = true;
            }
            PlayBackgroundMusic();
        }
        public void PlaySounds()
        {
            if (PlayerPrefs.GetInt("Sounds") == 0)
            {
                if (!gameplayscene)
                {
                    Btn_Sounds.sprite = Btn_OFF;
                }

                AudioSounds = false;

            }
            else if (PlayerPrefs.GetInt("Sounds") == 1)
            {
                if (!gameplayscene)
                {
                    Btn_Sounds.sprite = Btn_ON;
                }

                AudioSounds = true;

            }
        }

        public void PlayBtnClick()
        {
            if (AudioSounds)
            {
                Button.Play();
            }

        }

        public void PlayTapAction()
        {
            if (AudioSounds)
            {
                Tap.Play();
            }

        }
        public void PlayCrackAction()
        {
            if (AudioSounds)
            {
                Crack.Play();
            }

        }


        public void PlayGunshotAction()
        {
            if (AudioSounds)
            {
                gunshot.Play();
            }

        }



        public void PlayBackgroundMusic()
        {
            if (AudioMusic)
            {
                MBG.Play();
            }
            else
            {
                MBG.Stop();
            }
        }
        public void PlayGameOverMusic()
        {
            if (AudioMusic)
            {
                GameOver.Play();
            }
        }
        public void PlayLevelUpMusic()
        {
            if (AudioMusic)
            {
                LevelUpMusic.Play();
            }
        }
        void Update()
        {

        }
    }
}