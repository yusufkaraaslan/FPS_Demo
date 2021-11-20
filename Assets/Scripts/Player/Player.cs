using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore;

public class Player : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] float runSpeed;
    [SerializeField] float mouseSensetivity;

    CameraSystem cam;
    [SerializeField] FPSCamLayout camData; 

    public void Init()
    {
        gun.Init();
        camData.FPSCamInit(mouseSensetivity);
        cam = CameraSystem.GetInstance();
        gameObject.SetActive(false);
    }

    public void StartPlayer(Transform startPose)
    {
        gameObject.SetActive(true);

        transform.position = startPose.position;
        transform.rotation = startPose.rotation;

        cam.SetCam("Main", new BasicFollowCam(), camData);

        gun.ActivateGun();
    }

    public void ClosePlayer()
    {
        gun.DeactivateGun();
        gameObject.SetActive(false);
    }

    void PlayerMove()
    {
        float verticalMove = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;
        float horizontalMove = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;

        transform.Translate(new Vector3(horizontalMove, 0, verticalMove), camData.transform);

    }

    void PlayerLook()
    {
        camData.ControlCamera();
    }

    void PlayerShoot()
    {

    }

    void PlayerChangeGun()
    {

    }

    private void Update()
    {
        if (GameManeger.State == GameState.Ingame)
        {
            PlayerMove();
            PlayerLook();
            PlayerChangeGun();
            PlayerShoot();
        }
    }

}
