using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
using UnityEngine.EventSystems;
using WesternFolkG;
using Unity.Mathematics;
public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private Rig aimrig;
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private List<Transform> spawnBulletPosition;
    [SerializeField] private List<GameObject> Guns;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    [SerializeField] private GameObject Cross;
    [SerializeField] private GameObject ShotFx;
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    private float aimrigweight = 0f;
    int GunsIndex = 0;


    private void Awake()
    {

        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        GunsIndex = PlayerPrefs.GetInt("Gun_selected");
        Guns[GunsIndex].SetActive(true);
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 13f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
            aimrigweight = 1f;
            Cross.SetActive(true);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
            aimrigweight = 0f;
            Cross.SetActive(false);
        }


        if (starterAssetsInputs.shoot && starterAssetsInputs.aim && GamePlayManager.GamePlayManagerInstance.HaveBullets)
        {

            /*if (hitTransform != null)
            {
                // Hit something
                if (hitTransform.GetComponent<BulletTarget>() != null)
                {
                    // Hit target
                    Instantiate(vfxHitGreen, mouseWorldPosition, Quaternion.identity);
                }
                else
                {
                    // Hit something else
                    Instantiate(vfxHitRed, mouseWorldPosition, Quaternion.identity);
                }
            }*/

            GamePlayManager.GamePlayManagerInstance.updateshotCount();
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition[GunsIndex].position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletPosition[GunsIndex].position, Quaternion.LookRotation(aimDir, Vector3.up));
            //  AudioManager.AudioManagerInstance.PlayGunshotAction();
            PlayGunshotAction();
            //*/
            starterAssetsInputs.shoot = false;
        }
        aimrig.weight = Mathf.Lerp(aimrig.weight, aimrigweight, Time.deltaTime * 13f);

    }
    public void PlayGunshotAction()
    {
        GameObject g = Instantiate(ShotFx, this.transform.position, Quaternion.identity);
        Destroy(g, 2f);
    }

}