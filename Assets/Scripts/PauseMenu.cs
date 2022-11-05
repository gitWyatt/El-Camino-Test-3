using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Cinemachine;

public class PauseMenu : MonoBehaviour
{
    public InputMaster controls;

    CarController carController;

    CarEffects carEffects;

    CarBodySelection carBodySelection;

    [SerializeField] CinemachineVirtualCamera CMCameraLockWorldUp;
    [SerializeField] CinemachineVirtualCamera CMCameraSimpleWorldUp;
    CinemachineTransposer cameraTransposerLockWorldUp;
    CinemachineTransposer cameraTransposerSimpleWorldUp;

    [SerializeField] CinemachineVirtualCamera CMCameraActionCam;

    public GameObject pauseMenuUI;

    public GameObject carBodySelectionWindow;
    public GameObject carBodyFirstButton;

    public GameObject pauseFirstButton;

    public TMPro.TMP_Dropdown BodyDropDown;
    public TMPro.TMP_Dropdown CameraDropDown;

    public TMPro.TMP_Dropdown QualityDropDown;
    public TMPro.TMP_Dropdown FPSDropDown;

    public TMPro.TMP_Dropdown AxleDropDown;
    public TMPro.TMP_Dropdown MotorDropDown;
    public TMPro.TMP_Dropdown TransmissionDropDown;
    public TMPro.TMP_Dropdown TireDropDown;
    public TMPro.TMP_Dropdown SteeringPowerDropDown;
    public TMPro.TMP_Dropdown SteeringAngleDropDown;
    public TMPro.TMP_Dropdown SuspensionDropDown;
    public TMPro.TMP_Dropdown HandbrakeDropDown;

    public TMPro.TMP_Dropdown PassiveDropDown;
    public TMPro.TMP_Dropdown UseButtonDropDown;
    public TMPro.TMP_Dropdown BoostButtonDropDown;

    public int fpsCheck = 60;

    public int cameraPick;
    public int quality;
    public int axle;
    public int fps;
    public int motor;
    public int transmission;
    public int tire;
    public int steeringPower;
    public int steeringAngle;
    public int suspension;
    public int handbrake;
    public int passive;
    public int useButton;
    public int boostButton;

    private void Awake()
    {
        carController = GameObject.Find("Camino").GetComponent<CarController>();
        carEffects = GameObject.Find("Camino").GetComponent<CarEffects>();
        controls = new InputMaster();
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);

        //hacky fix for closest follow camera reset bug
        int camera = PlayerPrefs.GetInt("cameraIndex", 1);
        CameraDropDown.value = camera;
        SetCamera(camera);

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

    }

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        //int body = PlayerPrefs.GetInt("bodyIndex", 0);
        //BodyDropDown.value = body;

        cameraPick = PlayerPrefs.GetInt("cameraIndex", 1);
        CameraDropDown.value = cameraPick;

        quality = PlayerPrefs.GetInt("qualityIndex", 0);
        QualityDropDown.value = quality;

        axle = PlayerPrefs.GetInt("axleIndex", 1);
        AxleDropDown.value = axle;

        fps = PlayerPrefs.GetInt("fpsIndex", 1);
        switch (fps)
        {
            case 0:
                QualitySettings.vSyncCount = 0;
                fpsCheck = 30;
                Application.targetFrameRate = fpsCheck;
                break;
            case 1:
                QualitySettings.vSyncCount = 0;
                fpsCheck = 60;
                Application.targetFrameRate = fpsCheck;
                break;
            case 2:
                QualitySettings.vSyncCount = 0;
                fpsCheck = 72;
                Application.targetFrameRate = fpsCheck;
                break;
            case 3:
                QualitySettings.vSyncCount = 0;
                fpsCheck = 120;
                Application.targetFrameRate = fpsCheck;
                break;
            case 4:
                QualitySettings.vSyncCount = 0;
                fpsCheck = 144;
                Application.targetFrameRate = fpsCheck;
                break;
        }
        FPSDropDown.value = fps;

        motor = PlayerPrefs.GetInt("motorIndex", 1);
        MotorDropDown.value = motor;

        transmission = PlayerPrefs.GetInt("transmissionIndex", 1);
        TransmissionDropDown.value = transmission;

        tire = PlayerPrefs.GetInt("tireIndex", 0);
        TireDropDown.value = tire;

        steeringPower = PlayerPrefs.GetInt("steeringPowerIndex", 1);
        SteeringPowerDropDown.value = steeringPower;

        steeringAngle = PlayerPrefs.GetInt("steeringAngleIndex", 0);
        SteeringAngleDropDown.value = steeringAngle;

        suspension = PlayerPrefs.GetInt("suspensionIndex", 3);
        SuspensionDropDown.value = suspension;

        handbrake = PlayerPrefs.GetInt("handbrakeIndex", 1);
        HandbrakeDropDown.value = handbrake;

        passive = PlayerPrefs.GetInt("passiveIndex", 0);
        PassiveDropDown.value = passive;

        useButton = PlayerPrefs.GetInt("useButtonIndex", 0);
        UseButtonDropDown.value = useButton;

        boostButton = PlayerPrefs.GetInt("boostButtonIndex", 0);
        BoostButtonDropDown.value = boostButton;

        CheckPlayerChoices();
        //Debug.Log(fps);
    }

    private void FixedUpdate()
    {
        //if(Application.targetFrameRate != fpsCheck)
        //{
        //    Application.targetFrameRate = fpsCheck;
        //}

        //Debug.Log(FPSDropDown.value);
        //Debug.Log(PlayerPrefs.GetInt("fpsIndex"));

        //if (CMCameraLockWorldUp.gameObject.activeInHierarchy == true)
        //{
        //    Debug.Log("CMCameraLockWorldUp = true");
        //}
        //if (CMCameraSimpleWorldUp.gameObject.activeInHierarchy == true)
        //{
        //    Debug.Log("CMCameraSimpleWorldUp = true");
        //}
        //if (CMCameraActionCam.gameObject.activeInHierarchy == true)
        //{
        //    Debug.Log("CMCameraActionCam = true");
        //}


    }
    public void CheckPlayerChoices()
    {
        SetCamera(cameraPick);
        SetQuality(quality);
        SetFPS(fps);
        SetMotor(motor);
        SetTransmission(transmission);
        SetTire(tire);
        SetSteeringPower(steeringPower);
        SetSteeringAngle(steeringAngle);
        SetSuspension(suspension);
        SetHandbrake(handbrake);
        SetPassive(passive);
        SetUseButton(useButton);
    }

    public void OnPause()
    {
        if (Time.timeScale < 0.1f)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        //Debug.Log("step 2");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        //Debug.Log("step 3");
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);

        //Debug.Log("step 3");
    }

    public void OpenCarBodySelect()
    {
        carBodySelectionWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(carBodyFirstButton);
        pauseMenuUI.SetActive(false);
    }


    public void LoadDirtTrack()
    {
        Time.timeScale = 1f;
        //pauseMenuUI.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void LoadSkatePark()
    {
        Time.timeScale = 1f;
        //pauseMenuUI.SetActive(false);
        SceneManager.LoadScene(2);
    }
    public void LoadHills()
    {
        Time.timeScale = 1f;
        //pauseMenuUI.SetActive(false);
        SceneManager.LoadScene(3);
    }
    public void LoadRoadTest1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }
    public void LoadRoadTest2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(5);
    }

    //public void SetBody(int bodyIndex)
    //{
    //    switch (bodyIndex)
    //    {
    //        case 0:
    //            carController.bodySelection = 0;
    //            carEffects.bodySelection = 0;
    //            //carEffects.SetBodyElCamino();
    //            break;
    //        case 1:
    //            carController.bodySelection = 1;
    //            carEffects.bodySelection = 1;
    //            //carEffects.SetBodyFumigator();
    //            break;
    //        case 2:
    //            carController.bodySelection = 2;
    //            carEffects.bodySelection = 2;
    //            //carEffects.SetBodyAE86();
    //            break;
    //    }
    //    PlayerPrefs.SetInt("bodyIndex", bodyIndex);
    //}

    public void SetCamera(int cameraIndex)
    {
        cameraTransposerLockWorldUp = CMCameraLockWorldUp.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>();
        cameraTransposerSimpleWorldUp = CMCameraSimpleWorldUp.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>();

        switch (cameraIndex)
        {
            case 0:
                CMCameraLockWorldUp.gameObject.SetActive(true);
                cameraTransposerLockWorldUp.m_FollowOffset.y = 7f;
                cameraTransposerLockWorldUp.m_FollowOffset.z = -20f;
                cameraTransposerLockWorldUp.m_YawDamping = 1f;

                CMCameraSimpleWorldUp.gameObject.SetActive(false);
                cameraTransposerSimpleWorldUp.m_FollowOffset.y = 7f;
                cameraTransposerSimpleWorldUp.m_FollowOffset.z = -20f;
                cameraTransposerSimpleWorldUp.m_YawDamping = 1f;

                CMCameraActionCam.gameObject.SetActive(false);

                break;
            case 1:
                CMCameraLockWorldUp.gameObject.SetActive(true);
                cameraTransposerLockWorldUp.m_FollowOffset.y = 13f;
                cameraTransposerLockWorldUp.m_FollowOffset.z = -25f;
                cameraTransposerLockWorldUp.m_YawDamping = 1f;

                CMCameraSimpleWorldUp.gameObject.SetActive(false);
                cameraTransposerSimpleWorldUp.m_FollowOffset.y = 13f;
                cameraTransposerSimpleWorldUp.m_FollowOffset.z = -25f;
                cameraTransposerSimpleWorldUp.m_YawDamping = 1f;

                CMCameraActionCam.gameObject.SetActive(false);

                break;
            case 2:
                CMCameraLockWorldUp.gameObject.SetActive(true);
                cameraTransposerLockWorldUp.m_FollowOffset.y = 16f;
                cameraTransposerLockWorldUp.m_FollowOffset.z = -30f;
                cameraTransposerLockWorldUp.m_YawDamping = 1f;

                CMCameraSimpleWorldUp.gameObject.SetActive(false);
                cameraTransposerSimpleWorldUp.m_FollowOffset.y = 16f;
                cameraTransposerSimpleWorldUp.m_FollowOffset.z = -30f;
                cameraTransposerSimpleWorldUp.m_YawDamping = 1f;

                CMCameraActionCam.gameObject.SetActive(false);

                break;
            case 3:
                CMCameraLockWorldUp.gameObject.SetActive(false);
                cameraTransposerLockWorldUp.m_FollowOffset.y = 7f;
                cameraTransposerLockWorldUp.m_FollowOffset.z = -20f;
                cameraTransposerLockWorldUp.m_YawDamping = 0f;

                CMCameraSimpleWorldUp.gameObject.SetActive(true);
                cameraTransposerSimpleWorldUp.m_FollowOffset.y = 7f;
                cameraTransposerSimpleWorldUp.m_FollowOffset.z = -20f;
                cameraTransposerSimpleWorldUp.m_YawDamping = 0f;

                CMCameraActionCam.gameObject.SetActive(false);

                break;
            case 4:
                CMCameraLockWorldUp.gameObject.SetActive(false);
                cameraTransposerLockWorldUp.m_FollowOffset.y = 13f;
                cameraTransposerLockWorldUp.m_FollowOffset.z = -25f;
                cameraTransposerLockWorldUp.m_YawDamping = 0f;

                CMCameraSimpleWorldUp.gameObject.SetActive(true);
                cameraTransposerSimpleWorldUp.m_FollowOffset.y = 13f;
                cameraTransposerSimpleWorldUp.m_FollowOffset.z = -25f;
                cameraTransposerSimpleWorldUp.m_YawDamping = 0f;

                CMCameraActionCam.gameObject.SetActive(false);

                break;
            case 5:
                CMCameraLockWorldUp.gameObject.SetActive(false);
                cameraTransposerLockWorldUp.m_FollowOffset.y = 16f;
                cameraTransposerLockWorldUp.m_FollowOffset.z = -30f;
                cameraTransposerLockWorldUp.m_YawDamping = 0f;

                CMCameraSimpleWorldUp.gameObject.SetActive(true);
                cameraTransposerSimpleWorldUp.m_FollowOffset.y = 16f;
                cameraTransposerSimpleWorldUp.m_FollowOffset.z = -30f;
                cameraTransposerSimpleWorldUp.m_YawDamping = 0f;

                CMCameraActionCam.gameObject.SetActive(false);

                break;
        }

        PlayerPrefs.SetInt("cameraIndex", cameraIndex);
    }
    public void CameraFlop(bool inAir) //fixes camera when in air
    {
        if (inAir || carController.slidingFlag)
        {
            CMCameraLockWorldUp.gameObject.SetActive(false);
            CMCameraSimpleWorldUp.gameObject.SetActive(true);
            //if (CMCameraSimpleWorldUp.gameObject.activeInHierarchy == true)
            //{
            //    CMCameraLockWorldUp.gameObject.SetActive(false);
            //    CMCameraSimpleWorldUp.gameObject.SetActive(true);
            //}
        }

        if (!inAir && !carController.slidingFlag)
        {
            if (PlayerPrefs.GetInt("cameraIndex") == 0 || PlayerPrefs.GetInt("cameraIndex") == 1 || PlayerPrefs.GetInt("cameraIndex") == 2)
            {
                CMCameraLockWorldUp.gameObject.SetActive(true);
                CMCameraSimpleWorldUp.gameObject.SetActive(false);
            }

            if (PlayerPrefs.GetInt("cameraIndex") == 3 || PlayerPrefs.GetInt("cameraIndex") == 4 || PlayerPrefs.GetInt("cameraIndex") == 5)
            {
                CMCameraLockWorldUp.gameObject.SetActive(false);
                CMCameraSimpleWorldUp.gameObject.SetActive(true);
            }
        }
    }
    public void CameraActionSwitch()
    {
        if (CMCameraActionCam.gameObject.activeInHierarchy == true)
        {
            if (PlayerPrefs.GetInt("cameraIndex") == 0 || PlayerPrefs.GetInt("cameraIndex") == 1 || PlayerPrefs.GetInt("cameraIndex") == 2)
            {
                CMCameraLockWorldUp.gameObject.SetActive(true);
                CMCameraSimpleWorldUp.gameObject.SetActive(false);
            }

            if (PlayerPrefs.GetInt("cameraIndex") == 3 || PlayerPrefs.GetInt("cameraIndex") == 4 || PlayerPrefs.GetInt("cameraIndex") == 5)
            {
                CMCameraLockWorldUp.gameObject.SetActive(false);
                CMCameraSimpleWorldUp.gameObject.SetActive(true);
            }

            CMCameraActionCam.gameObject.SetActive(false);
        }

        else if (CMCameraActionCam.gameObject.activeInHierarchy == false)
        {
            CMCameraActionCam.gameObject.SetActive(true);
            CMCameraLockWorldUp.gameObject.SetActive(false);
            CMCameraSimpleWorldUp.gameObject.SetActive(false);
        }
    }

    public void SetPoweredAxle(int axleIndex)
    {
        if (axleIndex == 0)
        {
            carController.frontWheelDrive = true;
            carController.rearWheelDrive = false;
        }
        if (axleIndex == 1)
        {
            carController.frontWheelDrive = false;
            carController.rearWheelDrive = true;
        }
        if (axleIndex == 2)
        {
            carController.frontWheelDrive = true;
            carController.rearWheelDrive = true;
        }

        PlayerPrefs.SetInt("axleIndex", axleIndex);
    }
    public void SetMotor(int motorIndex)
    {
        switch(motorIndex)
        {
            case 0:
                carController.motorSelection = 0;
                break;
            case 1:
                carController.motorSelection = 1;
                break;
            case 2:
                carController.motorSelection = 2;
                break;
        }

        PlayerPrefs.SetInt("motorIndex", motorIndex);
    }
    public void SetTransmission(int transmissionIndex)
    {
        switch(transmissionIndex)
        {
            case 0:
                carController.transmissionSelection = 0;
                break;
            case 1:
                carController.transmissionSelection = 1;
                break;
            case 2:
                carController.transmissionSelection = 2;
                break;
            case 3:
                carController.transmissionSelection = 3;
                break;
        }

        PlayerPrefs.SetInt("transmissionIndex", transmissionIndex);
    }
    public void SetTire(int tireIndex)
    {
        switch(tireIndex)
        {
            case 0:
                carController.tireSelection = 0;
                carEffects.SetStandardTire();
                break;
            case 1:
                carController.tireSelection = 1;
                carEffects.SetOffRoadTire();
                break;
            case 2:
                carController.tireSelection = 2;
                carEffects.SetDriftTire();
                break;
        }

        PlayerPrefs.SetInt("tireIndex", tireIndex);
    }
    public void SetSteeringPower(int steeringPowerIndex)
    {
        switch(steeringPowerIndex)
        {
            case 0:
                carController.steeringPowerSelection = 0;
                break;
            case 1:
                carController.steeringPowerSelection = 1;
                break;
        }

        PlayerPrefs.SetInt("steeringPowerIndex", steeringPowerIndex);
    }
    public void SetSteeringAngle(int steeringAngleIndex)
    {
        switch(steeringAngleIndex)
        {
            case 0:
                carController.steeringAngleSelection = 0;
                break;
            case 1:
                carController.steeringAngleSelection = 1;
                break;
        }

        PlayerPrefs.SetInt("steeringAngleIndex", steeringAngleIndex);
    }
    public void SetSuspension(int suspensionIndex)
    {
        switch(suspensionIndex)
        {
            case 0:
                carController.suspensionSelection = 0;
                break;
            case 1:
                carController.suspensionSelection = 1;
                break;
            case 2:
                carController.suspensionSelection = 2;
                break;
            case 3:
                carController.suspensionSelection = 3;
                break;
        }

        PlayerPrefs.SetInt("suspensionIndex", suspensionIndex);
    }
    public void SetHandbrake(int handbrakeIndex)
    {
        switch(handbrakeIndex)
        {
            case 0:
                carController.handbrakeSelection = 0;
                break;
            case 1:
                carController.handbrakeSelection = 1;
                break;
            case 2:
                carController.handbrakeSelection = 2;
                break;
        }

        PlayerPrefs.SetInt("handbrakeIndex", handbrakeIndex);
    }
    public void SetPassive(int passiveIndex)
    {
        switch(passiveIndex)
        {
            case 0:
                carController.passiveSelection = 0;
                break;
            case 1:
                carController.passiveSelection = 1;
                break;
        }

        PlayerPrefs.SetInt("passiveIndex", passiveIndex);
    }
    public void SetUseButton(int useButtonIndex)
    {
        switch(useButtonIndex)
        {
            case 0:
                carController.useButtonSelection = 0;
                break;
            case 1:
                carController.useButtonSelection = 1;
                break;
            case 2:
                carController.useButtonSelection = 2;
                break;
        }

        PlayerPrefs.SetInt("useButtonIndex", useButtonIndex);
    }
    public void SetBoostButton(int boostButtonIndex)
    {
        switch (boostButtonIndex)
        {
            case 0:
                carController.boostButtonSelection = 0;
                break;
            case 1:
                carController.boostButtonSelection = 1;
                break;
            case 2:
                carController.boostButtonSelection = 2;
                break;
            case 3:
                carController.boostButtonSelection = 3;
                break;
        }

        PlayerPrefs.SetInt("boostButtonIndex", boostButtonIndex);
    }
    public void SetQuality(int qualityIndex)
    {        
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityIndex", qualityIndex);

        //QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityIndex"));
        
        //QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFPS(int fpsIndex)
    {
        QualitySettings.vSyncCount = 0;
        switch (fpsIndex)
        {
            case 0:
                Application.targetFrameRate = 30;
                break;
            case 1:
                Application.targetFrameRate = 60;
                break;
            case 2:
                Application.targetFrameRate = 72;
                break;
            case 3:
                Application.targetFrameRate = 120;
                break;
            case 4:
                Application.targetFrameRate = 144;
                break;
        }
        //Application.SetTargetFrameRate(fpsIndex);
        //Application.targetFrameRate = fpsIndex;
        PlayerPrefs.SetInt("fpsIndex", fpsIndex);
    }
    public void ResetPlayerPrefs()
    {
        int tempBody = PlayerPrefs.GetInt("bodyIndex");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("bodyIndex", tempBody);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}