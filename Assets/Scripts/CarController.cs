using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Cinemachine;

public class CarController : MonoBehaviour
{
    [SerializeField] public bool camFlopFlag;

    CarEffects carEffects;

    CarBodySelection carBodySelection;

    [SerializeField] WheelCoverCode flCoverCode;
    [SerializeField] WheelCoverCode frCoverCode;
    [SerializeField] WheelCoverCode blCoverCode;
    [SerializeField] WheelCoverCode brCoverCode;

    public InputMaster controls;

    public Transform centerOfMassCenterAir;
    public Transform centerOfMassCenterGround;
    public Transform centerOfMassFrontAir;
    public Transform centerOfMassFrontGround;
    public Transform centerOfMassRearAir;
    public Transform centerOfMassRearGround;
    public Transform centerOfMassCurrent;

    private Rigidbody carRigidBody;

    public PauseMenu pauseMenu;

    private float transmissionForce;

    private float horizontalInput;
    private float verticalInput;
    private float gas;
    private float cameraVerticalInput;
    private float cameraHorizontalInput;
    private float currentSteerAngle;
    private float currentBrakeForce;
    private float brakeCheck;
    private float resetCheck;
    private float flipCheck;
    private float engageCheck;
    private float stallCheck;

    public bool isCamming;
    public bool isBraking;
    public bool isReversing;
    private bool isResetting;
    private bool isFlipping;
    private bool isEngaging;
    private bool isStalling;


    public bool touchingGround;
    public bool flTouchingGround;
    public bool frTouchingGround;
    public bool blTouchingGround;
    public bool brTouchingGround;
    public bool slidingFlag;
    public bool flSlidingFlag;
    public bool frSlidingFlag;
    public bool blSlidingFlag;
    public bool brSlidingFlag;

    [SerializeField] private bool dragExists;
    [SerializeField] private float dragMultiple;
    double mph;
    private float engineRPM;
    [SerializeField] private float minRPM;
    [SerializeField] private float maxRPM;
    private float currentGear = 1f;
    private float gearNumber = 6f;
    private float[] gearRatio = new float[] { 2.66f, 1.78f, 1.3f, 1f, .7f, .1f };  //unneeded as of now.  top gear used to be .5f instead of .1f
    private float steerAngle;

    [SerializeField] public Text rpmOutput;
    [SerializeField] public Text velocityOutput;
    [SerializeField] public Text speedOutput;
    [SerializeField] public Text gearBox;
    [SerializeField] public Image boostMeter;
    [SerializeField] public CanvasGroup boostCanvasGroup;

    [SerializeField] private float flightGravity;
    [SerializeField] private float flightUpwardsForce;
    [SerializeField] float upwardsForce;
    [SerializeField] float upwardsPull;

    [SerializeField] public int passiveSelection;
    [SerializeField] public int useButtonSelection;
    [SerializeField] private float jumpForce;
    [SerializeField] private float thrusterForce;
    [SerializeField] private float groundBoostForce;
    [SerializeField] public bool airBoosting = false;
    [SerializeField] public bool groundBoosting = false;

    public float stallCounter = 40f;
    public float playerAirThrusterFuel = 100f;
    public bool airThrusterFlag = false;
    [SerializeField] private float maxAirThrusterFuel = 100f;
    [SerializeField] private float airThrusterDrain = 0.5f;
    [SerializeField] private float airThrusterRegen = 0.5f;
    [SerializeField] private float airThrusterCutoff = 25f;
    public float playerGroundBoostFuel = 100f;
    public bool groundBoostFlag = false;
    [SerializeField] private float maxGroundBoostFuel = 100f;
    [SerializeField] private float groundBoostDrain = 0.5f;
    [SerializeField] private float groundBoostRegen = 0.5f;
    [SerializeField] private float groundBoostCutoff = 25f;

    [SerializeField] public bool frontWheelDrive;
    [SerializeField] public bool rearWheelDrive;
    [SerializeField] private float singleAxleMFAdjustment;
    [SerializeField] private bool frontHandBrake;
    [SerializeField] private bool rearHandBrake;

    [Space]
    [Header("motor values")]
    [SerializeField] private float motorForce;
    [SerializeField] public int motorSelection;
    [SerializeField] private float streetMotorForce;
    [SerializeField] private float racingMotorForce;
    [Space]
    [Header("transmission values")]
    [SerializeField] public int transmissionSelection;
    [Space]
    [SerializeField] public float fourSpeedFirstGear;
    [SerializeField] public float fourSpeedSecondGear;
    [SerializeField] public float fourSpeedThirdGear;
    [SerializeField] public float fourSpeedFourthGear;
    [Space]
    [SerializeField] public float sixSpeedFirstGear;
    [SerializeField] public float sixSpeedSecondGear;
    [SerializeField] public float sixSpeedThirdGear;
    [SerializeField] public float sixSpeedFourthGear;
    [SerializeField] public float sixSpeedFifthGear;
    [SerializeField] public float sixSpeedSixthGear;
    [Space]
    [SerializeField] public float sixSpeedSportFirstGear;
    [SerializeField] public float sixSpeedSportSecondGear;
    [SerializeField] public float sixSpeedSportThirdGear;
    [SerializeField] public float sixSpeedSportFourthGear;
    [SerializeField] public float sixSpeedSportFifthGear;
    [SerializeField] public float sixSpeedSportSixthGear;
    [Space]
    [SerializeField] public float sixSpeedDriftFirstGear;
    [SerializeField] public float sixSpeedDriftSecondGear;
    [SerializeField] public float sixSpeedDriftThirdGear;
    [SerializeField] public float sixSpeedDriftFourthGear;
    [SerializeField] public float sixSpeedDriftFifthGear;
    [SerializeField] public float sixSpeedDriftSixthGear;
    [Header("end transmission values")]
    [Space]

    [SerializeField] private float brakeForce;
    [SerializeField] private float driftBrakesLerpValue;
    [SerializeField] public int handbrakeSelection;
    [SerializeField] private float moreDriftBrakeForce;
    [SerializeField] private float lessDriftBrakeForce;
    [SerializeField] private float driftForwardStiffnessConstant;
    [SerializeField] private float basicBrakesDriftFrontSidewaysStiffness;
    [SerializeField] private float basicBrakesDriftRearSidewaysStiffness;
    [SerializeField] private float offRoadBrakesDriftFrontSidewaysStiffness;
    [SerializeField] private float offRoadBrakesDriftRearSidewaysStiffness;
    [SerializeField] private float driftBrakesDriftFrontSidewaysStiffness;
    [SerializeField] private float driftBrakesDriftRearSidewaysStiffness;

    [SerializeField] public int tireSelection;
    [SerializeField] private float basicBrakesStandardSidewaysStiffness;
    [SerializeField] private float offRoadBrakesStandardSidewaysStiffness;
    [SerializeField] private float driftBrakesStandardSidewaysStiffness;

    [SerializeField] private float standardSidewaysStiffness;
    [SerializeField] private float driftFrontSidewaysStiffness;
    [SerializeField] private float driftRearSidewaysStiffness;

    [SerializeField] private float maxSteerAngle;
    [SerializeField] public int steeringAngleSelection;
    [SerializeField] private float streetSteerAngle;
    [SerializeField] private float driftSteerAngle;
    [SerializeField] public int steeringPowerSelection;
    [SerializeField] private float steeringLerpValue;
    [SerializeField] private float unpoweredSteeringLerpValue;
    [SerializeField] private float poweredSteeringLerpValue;

    [SerializeField] private float suspensionPower;
    [SerializeField] public int suspensionSelection;
    [SerializeField] private float bouncySuspensionValue;
    [SerializeField] private float middleSuspensionValue;
    [SerializeField] private float sturdySuspensionValue;
    [SerializeField] private float rockSuspensionValue;

    [SerializeField] private float controlPitchFactor;
    [SerializeField] private float controlYawFactor;
    [SerializeField] private float controlRollFactor;

    [SerializeField] public GameObject wheelColliderGroup;
    [SerializeField] public WheelCollider frontLeftWheelCollider;
    [SerializeField] public WheelCollider frontRightWheelCollider;
    [SerializeField] public WheelCollider backLeftWheelCollider;
    [SerializeField] public WheelCollider backRightWheelCollider;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    [SerializeField] public GameObject regularWheelGroup;
    [SerializeField] public WheelCollider frontLeftRegularWheelCollider;
    [SerializeField] public WheelCollider frontRightRegularWheelCollider;
    [SerializeField] public WheelCollider backLeftRegularWheelCollider;
    [SerializeField] public WheelCollider backRightRegularWheelCollider;
    [SerializeField] private Transform frontLeftRegularWheelTransform;
    [SerializeField] private Transform frontRightRegularWheelTransform;
    [SerializeField] private Transform backLeftRegularWheelTransform;
    [SerializeField] private Transform backRightRegularWheelTransform;

    [SerializeField] public GameObject bigWheelGroup;
    [SerializeField] public WheelCollider frontLeftBigWheelCollider;
    [SerializeField] public WheelCollider frontRightBigWheelCollider;
    [SerializeField] public WheelCollider backLeftBigWheelCollider;
    [SerializeField] public WheelCollider backRightBigWheelCollider;
    [SerializeField] private Transform frontLeftBigWheelTransform;
    [SerializeField] private Transform frontRightBigWheelTransform;
    [SerializeField] private Transform backLeftBigWheelTransform;
    [SerializeField] private Transform backRightBigWheelTransform;

    [SerializeField] private Collider frWheelCover;
    [SerializeField] private Collider flWheelCover;
    [SerializeField] private Collider brWheelCover;
    [SerializeField] private Collider blWheelCover;

    [SerializeField] private GameObject frWheelRigid;
    [SerializeField] private GameObject flWheelRigid;
    [SerializeField] private GameObject brWheelRigid;
    [SerializeField] private GameObject blWheelRigid;

    float frontLeftWheelSidewaysFrictionTemp = 99;
    float frontLeftWheelForwardFrictionTemp = 99;
    float frontRightWheelSidewaysFrictionTemp = 99;
    float frontRightWheelForwardFrictionTemp = 99;
    float backLeftWheelSidewaysFrictionTemp = 99;
    float backLeftWheelForwardFrictionTemp = 99;
    float backRightWheelSidewaysFrictionTemp = 99;
    float backRightWheelForwardFrictionTemp = 99;

    float flSpringTemp;
    float frSpringTemp;
    float blSpringTemp;
    float brSpringTemp;

    [SerializeField] CinemachineVirtualCamera CMCamera;
    CinemachineTransposer cameraOrbitalTransposer;

    Color thatPurpleyColor;

    PhysicMaterial slippery;


    private void Awake()
    {
        if (controls == null)
        {
            controls = new InputMaster();
        }
        Time.timeScale = 1f;
        carEffects = GameObject.Find("Camino").GetComponent<CarEffects>();
        thatPurpleyColor = boostMeter.color;

        
    }

    private void Start()
    {
        //sets center of mass to transform
        carRigidBody = GetComponent<Rigidbody>();
        //carRigidBody.centerOfMass = centerOfMassGround.localPosition;
        carRigidBody.centerOfMass = centerOfMassCurrent.localPosition;

        carBodySelection.BodyCheck();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void FixedUpdate()
    {
        GetInput();
        CheckGround();
        HandleThruster();   //sloppy, but its because of the new input system
        HandleSuspension();
        HandleHandbrake();
        HandleMotor();
        HandleSteering();
        HandleRotation();
        HandlePassive();
        HandleSpeedometer();
        HandleCamera();
        UpdateWheels();
        ResetCheck();
        //CheckGround();
        DebugToConsole();
    }

    private void GetInput()
    {
        //new input player

        horizontalInput = controls.Player.Steering.ReadValue<float>();
        verticalInput = controls.Player.UpDown.ReadValue<float>();
        gas = controls.Player.ForwardReverse.ReadValue<float>();

        //cameraVerticalInput = controls.Player.CameraUpDown.ReadValue<float>();
        //cameraHorizontalInput = controls.Player.CameraLeftRight.ReadValue<float>();

        brakeCheck = controls.Player.Handbrake.ReadValue<float>();
        resetCheck = controls.Player.Reset.ReadValue<float>();
        flipCheck = controls.Player.Flip.ReadValue<float>();
        controls.Player.Engage.performed += EngageHandler;
        engageCheck = controls.Player.Engage.ReadValue<float>();
        controls.Player.Passiveitemswap.performed += HandleSwitching;
        controls.Player.Useitemswap.performed += HandleSwitching;
        controls.Player.Pause.performed += PauseHandler;
        stallCheck = controls.Player.Stall.ReadValue<float>();
        stallCheck = controls.Player.Stall.ReadValue<float>();
        //controls.Player.CameraLock.performed += CameraLocker;

        if (brakeCheck > .5)
        { isBraking = true; }
        else { isBraking = false; }

        if (gas < 0)
        { isReversing = true; }
        else { isReversing = false; }

        if (resetCheck > .5)
        { isResetting = true; }
        else { isResetting = false; }

        if (flipCheck > .5)
        { isFlipping = true; }
        else { isFlipping = false; }

        if (engageCheck > .5)
        { isEngaging = true; }
        else { isEngaging = false; }

        if (Mathf.Abs(cameraVerticalInput) > .1f && Mathf.Abs(cameraHorizontalInput) > .1f)
        { isCamming = true; }
        else { isCamming = false; }

        if (stallCheck > .5)
        { isStalling = true; }
        else { isStalling = false; }
    }


    void CheckGround()
    {
        WheelFrictionCurve frontLeftWheelSidewaysFriction = frontLeftWheelCollider.sidewaysFriction;
        WheelFrictionCurve frontLeftWheelForwardFriction = frontLeftWheelCollider.forwardFriction;
        WheelFrictionCurve frontRightWheelSidewaysFriction = frontRightWheelCollider.sidewaysFriction;
        WheelFrictionCurve frontRightWheelForwardFriction = frontRightWheelCollider.forwardFriction;
        WheelFrictionCurve backLeftWheelSidewaysFriction = backLeftWheelCollider.sidewaysFriction;
        WheelFrictionCurve backLeftWheelForwardFriction = backLeftWheelCollider.forwardFriction;
        WheelFrictionCurve backRightWheelSidewaysFriction = backRightWheelCollider.sidewaysFriction;
        WheelFrictionCurve backRightWheelForwardFriction = backRightWheelCollider.forwardFriction;

        //flTouchingGround = false;
        //frTouchingGround = false;
        //blTouchingGround = false;
        //brTouchingGround = false;

        //flWheelCover.gameObject.SetActive(false);
        //frWheelCover.gameObject.SetActive(false);
        //blWheelCover.gameObject.SetActive(false);
        //brWheelCover.gameObject.SetActive(false);

        if (frontLeftWheelCollider.GetGroundHit(out WheelHit hitFrontLeft) == true)
        {
            flTouchingGround = true;

            if (frontLeftWheelSidewaysFriction.stiffness != 0)
            {
                frontLeftWheelSidewaysFrictionTemp = frontLeftWheelSidewaysFriction.stiffness;
            }
            if (frontLeftWheelForwardFriction.stiffness != 0)
            {
                frontLeftWheelForwardFrictionTemp = frontLeftWheelForwardFriction.stiffness;
            }

            if (hitFrontLeft.collider.tag == "lowFriction")
            {
                flSlidingFlag = true;
                frontLeftWheelSidewaysFriction.stiffness = 0;
                frontLeftWheelForwardFriction.stiffness = 0;
                frontLeftWheelCollider.sidewaysFriction = frontLeftWheelSidewaysFriction;
                frontLeftWheelCollider.forwardFriction = frontLeftWheelForwardFriction;
            }
            else
            {
                flSlidingFlag = false;
                frontLeftWheelSidewaysFriction.stiffness = frontLeftWheelSidewaysFrictionTemp;
                frontLeftWheelForwardFriction.stiffness = frontLeftWheelForwardFrictionTemp;
                frontLeftWheelCollider.sidewaysFriction = frontLeftWheelSidewaysFriction;
                frontLeftWheelCollider.forwardFriction = frontLeftWheelForwardFriction;
            }
        }
        else
        {
            flTouchingGround = false;
        }

        if (frontRightWheelCollider.GetGroundHit(out WheelHit hitFrontRight) == true)
        {
            frTouchingGround = true;

            if (frontRightWheelSidewaysFriction.stiffness != 0)
            {
                frontRightWheelSidewaysFrictionTemp = frontRightWheelSidewaysFriction.stiffness;
            }
            if (frontRightWheelForwardFriction.stiffness != 0)
            {
                frontRightWheelForwardFrictionTemp = frontRightWheelForwardFriction.stiffness;
            }

            if (hitFrontRight.collider.tag == "lowFriction")
            {
                frSlidingFlag = true;
                frontRightWheelSidewaysFriction.stiffness = 0;
                frontRightWheelForwardFriction.stiffness = 0;
                frontRightWheelCollider.sidewaysFriction = frontRightWheelSidewaysFriction;
                frontRightWheelCollider.forwardFriction = frontRightWheelForwardFriction;
            }
            else
            {
                frSlidingFlag = false;
                frontRightWheelSidewaysFriction.stiffness = frontRightWheelSidewaysFrictionTemp;
                frontRightWheelForwardFriction.stiffness = frontRightWheelForwardFrictionTemp;
                frontRightWheelCollider.sidewaysFriction = frontRightWheelSidewaysFriction;
                frontRightWheelCollider.forwardFriction = frontRightWheelForwardFriction;
            }
        }
        else
        {
            frTouchingGround = false;
        }

        if (backLeftWheelCollider.GetGroundHit(out WheelHit hitBackLeft) == true)
        {
            blTouchingGround = true;

            if (backLeftWheelSidewaysFriction.stiffness != 0)
            {
                backLeftWheelSidewaysFrictionTemp = backLeftWheelSidewaysFriction.stiffness;
            }
            if (backLeftWheelForwardFriction.stiffness != 0)
            {
                backLeftWheelForwardFrictionTemp = backLeftWheelForwardFriction.stiffness;
            }

            if (hitBackLeft.collider.tag == "lowFriction")
            {
                blSlidingFlag = true;
                backLeftWheelSidewaysFriction.stiffness = 0;
                backLeftWheelForwardFriction.stiffness = 0;
                backLeftWheelCollider.sidewaysFriction = backLeftWheelSidewaysFriction;
                backLeftWheelCollider.forwardFriction = backLeftWheelForwardFriction;
            }
            else
            {
                blSlidingFlag = false;
                backLeftWheelSidewaysFriction.stiffness = backLeftWheelSidewaysFrictionTemp;
                backLeftWheelForwardFriction.stiffness = backLeftWheelForwardFrictionTemp;
                backLeftWheelCollider.sidewaysFriction = backLeftWheelSidewaysFriction;
                backLeftWheelCollider.forwardFriction = backLeftWheelForwardFriction;
            }
        }
        else
        {
            blTouchingGround = false;
        }

        if (backRightWheelCollider.GetGroundHit(out WheelHit hitBackRight) == true)
        {
            brTouchingGround = true;

            if (backRightWheelSidewaysFriction.stiffness != 0)
            {
                backRightWheelSidewaysFrictionTemp = backRightWheelSidewaysFriction.stiffness;
            }
            if (backRightWheelForwardFriction.stiffness != 0)
            {
                backRightWheelForwardFrictionTemp = backRightWheelForwardFriction.stiffness;
            }

            if (hitBackRight.collider.tag == "lowFriction")
            {
                brSlidingFlag = true;
                backRightWheelSidewaysFriction.stiffness = 0;
                backRightWheelForwardFriction.stiffness = 0;
                backRightWheelCollider.sidewaysFriction = backRightWheelSidewaysFriction;
                backRightWheelCollider.forwardFriction = backRightWheelForwardFriction;
            }
            else
            {
                brSlidingFlag = false;
                backRightWheelSidewaysFriction.stiffness = backRightWheelSidewaysFrictionTemp;
                backRightWheelForwardFriction.stiffness = backRightWheelForwardFrictionTemp;
                backRightWheelCollider.sidewaysFriction = backRightWheelSidewaysFriction;
                backRightWheelCollider.forwardFriction = backRightWheelForwardFriction;
            }
        }
        else
        {
            brTouchingGround = false;
        }

        if (flTouchingGround && frTouchingGround && blTouchingGround && brTouchingGround)
        {
            touchingGround = true;
        }
        else
        {
            touchingGround = false;
        }

        if (flSlidingFlag || frSlidingFlag || blSlidingFlag || brSlidingFlag)
        {
            slidingFlag = true;
        }
        else
        {
            slidingFlag = false;
        }


        //if (flCoverCode.coverTouchingGround == false && frCoverCode.coverTouchingGround == false && blCoverCode.coverTouchingGround == false && brCoverCode.coverTouchingGround == false)
        //{
        //    flWheelRigid.gameObject.SetActive(true);
        //    frWheelRigid.gameObject.SetActive(true);
        //    blWheelRigid.gameObject.SetActive(true);
        //    brWheelRigid.gameObject.SetActive(true);
        //}
        
        //if (flCoverCode.coverTouchingGround == true || frCoverCode.coverTouchingGround == true || blCoverCode.coverTouchingGround == true || brCoverCode.coverTouchingGround == true)
        //{
        //    flWheelRigid.gameObject.SetActive(false);
        //    frWheelRigid.gameObject.SetActive(false);
        //    blWheelRigid.gameObject.SetActive(false);
        //    brWheelRigid.gameObject.SetActive(false);
        //}

        if (flCoverCode.coverTouchingGround == false)
        {
            flWheelRigid.gameObject.SetActive(true);
        }
        else
        {
            flWheelRigid.gameObject.SetActive(false);
        }

        if (frCoverCode.coverTouchingGround == false)
        {
            frWheelRigid.gameObject.SetActive(true);
        }
        else
        {
            frWheelRigid.gameObject.SetActive(false);
        }

        if (blCoverCode.coverTouchingGround == false)
        {
            blWheelRigid.gameObject.SetActive(true);
        }
        else
        {
            blWheelRigid.gameObject.SetActive(false);
        }

        if (brCoverCode.coverTouchingGround == false)
        {
            brWheelRigid.gameObject.SetActive(true);
        }
        else
        {
            brWheelRigid.gameObject.SetActive(false);
        }


        Debug.Log(flCoverCode.coverTouchingGround);

        //Debug.Log("slidingflag: " + slidingFlag);

        //old code
        { 
        //if (frontLeftWheelCollider.GetGroundHit(out WheelHit hitFrontLeft) == true && frontRightWheelCollider.GetGroundHit(out WheelHit hitFrontRight) == true && backLeftWheelCollider.GetGroundHit(out WheelHit hitBackLeft) && backRightWheelCollider.GetGroundHit(out WheelHit hitBackRight))
        //{
        //    touchingGround = true;


        //    if (frontLeftWheelSidewaysFriction.stiffness != 0)
        //    {
        //        frontLeftWheelSidewaysFrictionTemp = frontLeftWheelSidewaysFriction.stiffness;
        //    }
        //    if (frontLeftWheelForwardFriction.stiffness != 0)
        //    {
        //        frontLeftWheelForwardFrictionTemp = frontLeftWheelForwardFriction.stiffness;
        //    }
        //    if (frontRightWheelSidewaysFriction.stiffness != 0)
        //    {
        //        frontRightWheelSidewaysFrictionTemp = frontRightWheelSidewaysFriction.stiffness;
        //    }
        //    if (frontRightWheelForwardFriction.stiffness != 0)
        //    {
        //        frontRightWheelForwardFrictionTemp = frontRightWheelForwardFriction.stiffness;
        //    }
        //    if (backLeftWheelSidewaysFriction.stiffness != 0)
        //    {
        //        backLeftWheelSidewaysFrictionTemp = backLeftWheelSidewaysFriction.stiffness;
        //    }
        //    if (backLeftWheelForwardFriction.stiffness != 0)
        //    {
        //        backLeftWheelForwardFrictionTemp = backLeftWheelForwardFriction.stiffness;
        //    }
        //    if (backRightWheelSidewaysFriction.stiffness != 0)
        //    {
        //        backRightWheelSidewaysFrictionTemp = backRightWheelSidewaysFriction.stiffness;
        //    }
        //    if (backRightWheelForwardFriction.stiffness != 0)
        //    {
        //        backRightWheelForwardFrictionTemp = backRightWheelForwardFriction.stiffness;
        //    }

        //    if (hitFrontLeft.collider.tag == "lowFriction" || hitFrontRight.collider.tag == "lowFriction" || hitBackLeft.collider.tag == "lowFriction" || hitBackRight.collider.tag == "lowFriction" /*|| !touchingGround*/)
        //    {
        //        slidingFlag = true;
        //        frontLeftWheelSidewaysFriction.stiffness = 0;
        //        frontLeftWheelForwardFriction.stiffness = 0;
        //        frontLeftWheelCollider.sidewaysFriction = frontLeftWheelSidewaysFriction;
        //        frontLeftWheelCollider.forwardFriction = frontLeftWheelForwardFriction;
        //        frontRightWheelSidewaysFriction.stiffness = 0;
        //        frontRightWheelForwardFriction.stiffness = 0;
        //        frontRightWheelCollider.sidewaysFriction = frontRightWheelSidewaysFriction;
        //        frontRightWheelCollider.forwardFriction = frontRightWheelForwardFriction;
        //        backLeftWheelSidewaysFriction.stiffness = 0;
        //        backLeftWheelForwardFriction.stiffness = 0;
        //        backLeftWheelCollider.sidewaysFriction = backLeftWheelSidewaysFriction;
        //        backLeftWheelCollider.forwardFriction = backLeftWheelForwardFriction;
        //        backRightWheelSidewaysFriction.stiffness = 0;
        //        backRightWheelForwardFriction.stiffness = 0;
        //        backRightWheelCollider.sidewaysFriction = backRightWheelSidewaysFriction;
        //        backRightWheelCollider.forwardFriction = backRightWheelForwardFriction;
        //    }
        //    else
        //    {
        //        slidingFlag = false;
        //        frontLeftWheelSidewaysFriction.stiffness = frontLeftWheelSidewaysFrictionTemp;
        //        frontLeftWheelForwardFriction.stiffness = frontLeftWheelForwardFrictionTemp;
        //        frontLeftWheelCollider.sidewaysFriction = frontLeftWheelSidewaysFriction;
        //        frontLeftWheelCollider.forwardFriction = frontLeftWheelForwardFriction;
        //        frontRightWheelSidewaysFriction.stiffness = frontRightWheelSidewaysFrictionTemp;
        //        frontRightWheelForwardFriction.stiffness = frontRightWheelForwardFrictionTemp;
        //        frontRightWheelCollider.sidewaysFriction = frontRightWheelSidewaysFriction;
        //        frontRightWheelCollider.forwardFriction = frontRightWheelForwardFriction;
        //        backLeftWheelSidewaysFriction.stiffness = backLeftWheelSidewaysFrictionTemp;
        //        backLeftWheelForwardFriction.stiffness = backLeftWheelForwardFrictionTemp;
        //        backLeftWheelCollider.sidewaysFriction = backLeftWheelSidewaysFriction;
        //        backLeftWheelCollider.forwardFriction = backLeftWheelForwardFriction;
        //        backRightWheelSidewaysFriction.stiffness = backRightWheelSidewaysFrictionTemp;
        //        backRightWheelForwardFriction.stiffness = backRightWheelForwardFrictionTemp;
        //        backRightWheelCollider.sidewaysFriction = backRightWheelSidewaysFriction;
        //        backRightWheelCollider.forwardFriction = backRightWheelForwardFriction;
        //    }

        //        //Debug.Log("frontLeftWheelForwardFrictionTemp: " + frontLeftWheelForwardFrictionTemp);
        //        //Debug.Log("wheelhit output: " + hitFrontLeft.collider.tag);
        //}
        //else
        //{
        //    slidingFlag = false;
        //    touchingGround = false;
        //}

        //freeze rotation when sliding

        //if (slidingFlag)
        //{
        //    carRigidBody.freezeRotation = true;
        //}
        //else
        //{
        //    carRigidBody.freezeRotation = false;
        //}
        }
    }


    private void HandleSuspension()
    {
        var flSpring = frontLeftWheelCollider.suspensionSpring;
        var frSpring = frontRightWheelCollider.suspensionSpring;
        var blSpring = backLeftWheelCollider.suspensionSpring;
        var brSpring = backRightWheelCollider.suspensionSpring;

        switch (suspensionSelection)
        {
            case 0:
                flSpring.damper = bouncySuspensionValue;
                frSpring.damper = bouncySuspensionValue;
                blSpring.damper = bouncySuspensionValue;
                brSpring.damper = bouncySuspensionValue;
                break;
            case 1:
                flSpring.damper = middleSuspensionValue;
                frSpring.damper = middleSuspensionValue;
                blSpring.damper = middleSuspensionValue;
                brSpring.damper = middleSuspensionValue;
                break;
            case 2:
                flSpring.damper = sturdySuspensionValue;
                frSpring.damper = sturdySuspensionValue;
                blSpring.damper = sturdySuspensionValue;
                brSpring.damper = sturdySuspensionValue;
                break;
            case 3:
                flSpring.damper = rockSuspensionValue;
                frSpring.damper = rockSuspensionValue;
                blSpring.damper = rockSuspensionValue;
                brSpring.damper = rockSuspensionValue;
                break;
        }

        
        //this needs attention
        if (flSpring.spring != 0)
        {
            flSpringTemp = flSpring.spring;
        }
        if (frSpring.spring != 0)
        {
            frSpringTemp = frSpring.spring;
        }
        if (blSpring.spring != 0)
        {
            blSpringTemp = blSpring.spring;
        }
        if (brSpring.spring != 0)
        {
            blSpringTemp = brSpring.spring;
        }

        //if (slidingFlag)
        //{
        //    flSpring.spring = 0;
        //    flSpring.targetPosition = 0;
        //    frSpring.spring = 0;
        //    frSpring.targetPosition = 0;
        //    blSpring.spring = 0;
        //    blSpring.targetPosition = 0;
        //    brSpring.spring = 0;
        //    brSpring.targetPosition = 0;

        //    flSpring.damper = 20000;
        //    frSpring.damper = 20000;
        //    blSpring.damper = 20000;
        //    brSpring.damper = 20000;

        //    //frontLeftWheelCollider.forceAppPointDistance = 100;
        //    //frontRightWheelCollider.forceAppPointDistance = 100;
        //    //backLeftWheelCollider.forceAppPointDistance = 100;
        //    //backRightWheelCollider.forceAppPointDistance = 100;
        //}

        //if (!slidingFlag)
        //{
        //    flSpring.spring = flSpringTemp;
        //    flSpring.targetPosition = 0.5f;
        //    frSpring.spring = frSpringTemp;
        //    frSpring.targetPosition = 0.5f;
        //    blSpring.spring = blSpringTemp;
        //    blSpring.targetPosition = 0.5f;
        //    brSpring.spring = brSpringTemp;
        //    brSpring.targetPosition = 0.5f;

        //    //frontLeftWheelCollider.forceAppPointDistance = 0;
        //    //frontRightWheelCollider.forceAppPointDistance = 0;
        //    //backLeftWheelCollider.forceAppPointDistance = 0;
        //    //backRightWheelCollider.forceAppPointDistance = 0;
        //}

        if (!touchingGround)
        {
            frontLeftWheelCollider.ResetSprungMasses();
            frontRightWheelCollider.ResetSprungMasses();
            backLeftWheelCollider.ResetSprungMasses();
            backRightWheelCollider.ResetSprungMasses();

            flSpring.spring = 0;
            flSpring.targetPosition = 0;
            frSpring.spring = 0;
            frSpring.targetPosition = 0;
            blSpring.spring = 0;
            blSpring.targetPosition = 0;
            brSpring.spring = 0;
            brSpring.targetPosition = 0;

            flSpring.damper = 0;
            frSpring.damper = 0;
            blSpring.damper = 0;
            brSpring.damper = 0;

            frontLeftWheelCollider.suspensionDistance = 0.2f;
            frontRightWheelCollider.suspensionDistance = 0.2f;
            backLeftWheelCollider.suspensionDistance = 0.2f;
            backRightWheelCollider.suspensionDistance = 0.2f;
        }

        if (slidingFlag)
        {
            frontLeftWheelCollider.sprungMass = 0;
            frontRightWheelCollider.sprungMass = 0;
            backLeftWheelCollider.sprungMass = 0;
            backRightWheelCollider.sprungMass = 0;

            flSpring.spring = 0;
            flSpring.targetPosition = 0;
            frSpring.spring = 0;
            frSpring.targetPosition = 0;
            blSpring.spring = 0;
            blSpring.targetPosition = 0;
            brSpring.spring = 0;
            brSpring.targetPosition = 0;

            flSpring.damper = 0;
            frSpring.damper = 0;
            blSpring.damper = 0;
            brSpring.damper = 0;

            frontLeftWheelCollider.suspensionDistance = 0;
            frontRightWheelCollider.suspensionDistance = 0;
            backLeftWheelCollider.suspensionDistance = 0;
            backRightWheelCollider.suspensionDistance = 0;
        }

        if (!slidingFlag && touchingGround)
        {
            frontLeftWheelCollider.ResetSprungMasses();
            frontRightWheelCollider.ResetSprungMasses();
            backLeftWheelCollider.ResetSprungMasses();
            backRightWheelCollider.ResetSprungMasses();

            flSpring.spring = flSpringTemp;
            flSpring.targetPosition = 0.5f;
            frSpring.spring = frSpringTemp;
            frSpring.targetPosition = 0.5f;
            blSpring.spring = blSpringTemp;
            blSpring.targetPosition = 0.5f;
            brSpring.spring = brSpringTemp;
            brSpring.targetPosition = 0.5f;

            frontLeftWheelCollider.suspensionDistance = 0.3f;
            frontRightWheelCollider.suspensionDistance = 0.3f;
            backLeftWheelCollider.suspensionDistance = 0.3f;
            backRightWheelCollider.suspensionDistance = 0.3f;
        }

        frontLeftWheelCollider.suspensionSpring = flSpring;
        frontRightWheelCollider.suspensionSpring = frSpring;
        backLeftWheelCollider.suspensionSpring = blSpring;
        backRightWheelCollider.suspensionSpring = frSpring;

        
    }

    private void HandleHandbrake()
    {
        switch (handbrakeSelection)
        {
            case 0:
                frontHandBrake = false;
                brakeForce = moreDriftBrakeForce;
                driftFrontSidewaysStiffness = driftBrakesDriftFrontSidewaysStiffness;
                driftRearSidewaysStiffness = driftBrakesDriftRearSidewaysStiffness;
                break;
            case 1:
                frontHandBrake = false;
                brakeForce = lessDriftBrakeForce;
                driftFrontSidewaysStiffness = basicBrakesDriftFrontSidewaysStiffness;
                driftRearSidewaysStiffness = basicBrakesDriftRearSidewaysStiffness;
                break;
            case 2:
                frontHandBrake = true;
                if (frontWheelDrive && rearWheelDrive)
                {
                    brakeForce = motorForce * singleAxleMFAdjustment;
                }
                else if (!frontWheelDrive || !rearWheelDrive)
                {
                    brakeForce = motorForce;
                }
                driftFrontSidewaysStiffness = offRoadBrakesDriftFrontSidewaysStiffness;
                driftRearSidewaysStiffness = offRoadBrakesDriftRearSidewaysStiffness;
                break;
        }
        //Debug.Log(brakeForce);
    }

    private void HandleMotor()
    {
        if (dragExists)
        {
            carRigidBody.drag = carRigidBody.velocity.magnitude / dragMultiple;
        }
        else
        {
            carRigidBody.drag = 0f;
        }
        switch (motorSelection)
        {
            case 0:
                motorForce = streetMotorForce;
                break;
            case 1:
                motorForce = racingMotorForce;
                break;
            case 2:
                motorForce = 500f;
                break;
        }
        

        if (frontWheelDrive && rearWheelDrive)
        {
            Transmission();
            frontLeftWheelCollider.motorTorque = gas * motorForce * transmissionForce;
            frontRightWheelCollider.motorTorque = gas * motorForce * transmissionForce;
            backLeftWheelCollider.motorTorque = gas * motorForce * transmissionForce;
            backRightWheelCollider.motorTorque = gas * motorForce * transmissionForce;
        }
        else if (frontWheelDrive && !rearWheelDrive)
        {
            Transmission();
            frontLeftWheelCollider.motorTorque = gas * (motorForce * singleAxleMFAdjustment) * transmissionForce;
            frontRightWheelCollider.motorTorque = gas * (motorForce * singleAxleMFAdjustment) * transmissionForce;
            backLeftWheelCollider.motorTorque = 0f;
            backRightWheelCollider.motorTorque = 0f;
        }
        else if (rearWheelDrive && !frontWheelDrive)
        {
            Transmission();
            frontLeftWheelCollider.motorTorque = 0f;
            frontRightWheelCollider.motorTorque = 0f;
            backLeftWheelCollider.motorTorque = gas * (motorForce * singleAxleMFAdjustment) * transmissionForce;
            backRightWheelCollider.motorTorque = gas * (motorForce * singleAxleMFAdjustment) * transmissionForce;
        }

        currentBrakeForce = isBraking ? brakeForce : 0f;


        //lock wheels when stalling
        if (isStalling)
        {
            frontLeftWheelCollider.motorTorque = 0;
            frontRightWheelCollider.motorTorque = 0;
            backLeftWheelCollider.motorTorque = 0;
            backRightWheelCollider.motorTorque = 0;
        }

        ApplyBraking();
    }

    private void Transmission()
    {
        if (frontWheelDrive)
        {
            engineRPM = (frontLeftWheelCollider.rpm + frontRightWheelCollider.rpm) / 2f * transmissionForce;
        }
        else
        {
            engineRPM = (backLeftWheelCollider.rpm + backRightWheelCollider.rpm) / 2f * transmissionForce;
        }

        //4 SPEED TRANSMISSION
        if (transmissionSelection == 0)
        {
            if (engineRPM >= maxRPM)
            {
                if (currentGear < gearNumber)
                {
                    currentGear++;

                    switch (currentGear)
                    {
                        case 2:
                            transmissionForce = fourSpeedSecondGear;
                            break;
                        case 3:
                            transmissionForce = fourSpeedThirdGear;
                            break;
                        case 4:
                            transmissionForce = fourSpeedFourthGear;
                            break;
                    }
                }
                else
                {
                    currentGear = 4;
                    transmissionForce = fourSpeedFourthGear;
                }
            }
            if (engineRPM <= minRPM)
            {
                if (currentGear > 1)
                {
                    currentGear--;

                    switch (currentGear)
                    {
                        case 1:
                            transmissionForce = fourSpeedFirstGear;
                            break;
                        case 2:
                            transmissionForce = fourSpeedSecondGear;
                            break;
                        case 3:
                            transmissionForce = fourSpeedThirdGear;
                            break;
                    }
                }
                if (engineRPM < 0)
                {
                    transmissionForce = fourSpeedFirstGear;
                }
                else
                {
                    currentGear = 1;
                    transmissionForce = fourSpeedFirstGear;
                }
            }
        }

        //6 SPEED TRANSMISSION
        if (transmissionSelection == 1)
        {
            if (engineRPM >= maxRPM)
            {
                if (currentGear < gearNumber)
                {
                    currentGear++;

                    switch (currentGear)
                    {
                        case 2:
                            transmissionForce = sixSpeedSecondGear;
                            break;
                        case 3:
                            transmissionForce = sixSpeedThirdGear;
                            break;
                        case 4:
                            transmissionForce = sixSpeedFourthGear;
                            break;
                        case 5:
                            transmissionForce = sixSpeedFifthGear;
                            break;
                        case 6:
                            transmissionForce = sixSpeedSixthGear;
                            break;
                    }
                }
                else
                {
                    currentGear = 6;
                    transmissionForce = sixSpeedSixthGear;
                }
            }
            if (engineRPM <= minRPM)
            {
                if (currentGear > 1)
                {
                    currentGear--;

                    switch (currentGear)
                    {
                        case 1:
                            transmissionForce = sixSpeedFirstGear;
                            break;
                        case 2:
                            transmissionForce = sixSpeedSecondGear;
                            break;
                        case 3:
                            transmissionForce = sixSpeedThirdGear;
                            break;
                        case 4:
                            transmissionForce = sixSpeedFourthGear;
                            break;
                        case 5:
                            transmissionForce = sixSpeedFifthGear;
                            break;
                    }
                }
                if (engineRPM < 0)
                {
                    transmissionForce = sixSpeedFirstGear;
                }
                else
                {
                    currentGear = 1;
                    transmissionForce = sixSpeedFirstGear;
                }
            }
        }
        //6 SPEED SPORT
        if (transmissionSelection == 2)
        {
            if (engineRPM >= maxRPM)
            {
                if (currentGear < gearNumber)
                {
                    currentGear++;

                    switch (currentGear)
                    {
                        case 2:
                            transmissionForce = sixSpeedSportSecondGear;
                            break;
                        case 3:
                            transmissionForce = sixSpeedSportThirdGear;
                            break;
                        case 4:
                            transmissionForce = sixSpeedSportFourthGear;
                            break;
                        case 5:
                            transmissionForce = sixSpeedSportFifthGear;
                            break;
                        case 6:
                            transmissionForce = sixSpeedSportSixthGear;
                            break;
                    }
                }
                else
                {
                    currentGear = 6;
                    transmissionForce = sixSpeedSportSixthGear;
                }
            }
            if (engineRPM <= minRPM)
            {
                if (currentGear > 1)
                {
                    currentGear--;

                    switch (currentGear)
                    {
                        case 1:
                            transmissionForce = sixSpeedSportFirstGear;
                            break;
                        case 2:
                            transmissionForce = sixSpeedSportSecondGear;
                            break;
                        case 3:
                            transmissionForce = sixSpeedSportThirdGear;
                            break;
                        case 4:
                            transmissionForce = sixSpeedSportFourthGear;
                            break;
                        case 5:
                            transmissionForce = sixSpeedSportFifthGear;
                            break;
                    }
                }
                if (engineRPM < 0)
                {
                    transmissionForce = sixSpeedSportFirstGear;
                }
                else
                {
                    currentGear = 1;
                    transmissionForce = sixSpeedSportFirstGear;
                }
            }
        }

        //6 SPEED DRIFT
        if (transmissionSelection == 3)
        {
            if (engineRPM >= maxRPM)
            {
                if (currentGear < gearNumber)
                {
                    currentGear++;

                    switch (currentGear)
                    {
                        case 2:
                            transmissionForce = sixSpeedDriftSecondGear;
                            break;
                        case 3:
                            transmissionForce = sixSpeedDriftThirdGear;
                            break;
                        case 4:
                            transmissionForce = sixSpeedDriftFourthGear;
                            break;
                        case 5:
                            transmissionForce = sixSpeedDriftFifthGear;
                            break;
                        case 6:
                            transmissionForce = sixSpeedDriftSixthGear;
                            break;
                    }
                }
                else
                {
                    currentGear = 6;
                    transmissionForce = sixSpeedDriftSixthGear;
                }
            }
            if (engineRPM <= minRPM)
            {
                if (currentGear > 1)
                {
                    currentGear--;

                    switch (currentGear)
                    {
                        case 1:
                            transmissionForce = sixSpeedDriftFirstGear;
                            break;
                        case 2:
                            transmissionForce = sixSpeedDriftSecondGear;
                            break;
                        case 3:
                            transmissionForce = sixSpeedDriftThirdGear;
                            break;
                        case 4:
                            transmissionForce = sixSpeedDriftFourthGear;
                            break;
                        case 5:
                            transmissionForce = sixSpeedDriftFifthGear;
                            break;
                    }
                }
                if (engineRPM < 0)
                {
                    transmissionForce = sixSpeedDriftFirstGear;
                }
                else
                {
                    currentGear = 1;
                    transmissionForce = sixSpeedDriftFirstGear;
                }
            }
        }
    }

    private void ApplyBraking()
    {
        if (frontHandBrake)
        {
            frontRightWheelCollider.brakeTorque = currentBrakeForce;
            frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        }

        if (rearHandBrake)
        {
            backRightWheelCollider.brakeTorque = currentBrakeForce;
            backLeftWheelCollider.brakeTorque = currentBrakeForce;
        }

        WheelFrictionCurve frontLeftWheelSidewaysFriction = frontLeftWheelCollider.sidewaysFriction;
        WheelFrictionCurve frontRightWheelSidewaysFriction = frontRightWheelCollider.sidewaysFriction;
        WheelFrictionCurve backLeftWheelSidewaysFriction = backLeftWheelCollider.sidewaysFriction;
        WheelFrictionCurve backRightWheelSidewaysFriction = backRightWheelCollider.sidewaysFriction;

        WheelFrictionCurve frontLeftWheelForwardFriction = frontLeftWheelCollider.forwardFriction;
        WheelFrictionCurve frontRightWheelForwardFriction = frontRightWheelCollider.forwardFriction;
        WheelFrictionCurve backLeftWheelForwardFriction = backLeftWheelCollider.forwardFriction;
        WheelFrictionCurve backRightWheelForwardFriction = backRightWheelCollider.forwardFriction;

        switch (tireSelection)
        {
            case 0:
                standardSidewaysStiffness = basicBrakesStandardSidewaysStiffness;
                break;
            case 1:
                standardSidewaysStiffness = offRoadBrakesStandardSidewaysStiffness;
                break;
            case 2:
                standardSidewaysStiffness = driftBrakesStandardSidewaysStiffness;
                break;
        }

        //this if statement will compare the car transform's forward vector to the car's velocity's forward vector and adjust the tires' sideways friction as a result
        //this is to increase traction at slight adjustments while dropping traction for drifts and corners
        if (Vector3.Distance(transform.forward, Vector3.Normalize(carRigidBody.velocity)) < .05f)
        {
            standardSidewaysStiffness = standardSidewaysStiffness * 3f;
            //Debug.Log("big foo");
        }
        else if (Vector3.Distance(transform.forward, Vector3.Normalize(carRigidBody.velocity)) >= .05f && Vector3.Distance(transform.forward, Vector3.Normalize(carRigidBody.velocity)) < .2f)
        {
            standardSidewaysStiffness = standardSidewaysStiffness * 2.5f;
            //Debug.Log("Foo");
        }
        else if (Vector3.Distance(transform.forward, Vector3.Normalize(carRigidBody.velocity)) > .35f)
        {
            standardSidewaysStiffness = standardSidewaysStiffness * .9f;
            //Debug.Log("Bar");
        }
        else
        {
            //Debug.Log("spam");
        }

        //Debug.Log(Vector3.Distance(transform.forward, Vector3.Normalize(carRigidBody.velocity)));

        float currentDriftFrontSidewaysStiffness = (frontLeftWheelSidewaysFriction.stiffness + frontRightWheelSidewaysFriction.stiffness) / 2;
        float currentDriftRearSidewaysStiffness = (backLeftWheelSidewaysFriction.stiffness + backRightWheelSidewaysFriction.stiffness) / 2;

        if (isBraking)
        {
            //forward friction adjustment
            if (frontWheelDrive && !rearWheelDrive)
            {
                frontLeftWheelForwardFriction.stiffness = frontLeftWheelForwardFriction.stiffness * driftForwardStiffnessConstant;
                frontRightWheelForwardFriction.stiffness = frontRightWheelForwardFriction.stiffness * driftForwardStiffnessConstant;
            }
            if (rearWheelDrive && !frontWheelDrive)
            {
                backLeftWheelForwardFriction.stiffness = backLeftWheelForwardFriction.stiffness * driftForwardStiffnessConstant;
                backRightWheelForwardFriction.stiffness = backRightWheelForwardFriction.stiffness * driftForwardStiffnessConstant;
            }


            //sideways friction adjustment

            //lerp
            //frontLeftWheelFriction.stiffness = Mathf.Lerp(currentDriftFrontSidewaysStiffness, driftFrontSidewaysStiffness, driftBrakesLerpValue);
            //frontRightWheelFriction.stiffness = Mathf.Lerp(currentDriftFrontSidewaysStiffness, driftFrontSidewaysStiffness, driftBrakesLerpValue);
            //backLeftWheelFriction.stiffness = Mathf.Lerp(currentDriftRearSidewaysStiffness, driftRearSidewaysStiffness, driftBrakesLerpValue);
            //backRightWheelFriction.stiffness = Mathf.Lerp(currentDriftRearSidewaysStiffness, driftRearSidewaysStiffness, driftBrakesLerpValue);

            //non-lerp
            frontLeftWheelSidewaysFriction.stiffness = driftFrontSidewaysStiffness;
            frontRightWheelSidewaysFriction.stiffness = driftFrontSidewaysStiffness;
            backLeftWheelSidewaysFriction.stiffness = driftRearSidewaysStiffness;
            backRightWheelSidewaysFriction.stiffness = driftRearSidewaysStiffness;

            frontLeftWheelCollider.sidewaysFriction = frontLeftWheelSidewaysFriction;
            frontRightWheelCollider.sidewaysFriction = frontRightWheelSidewaysFriction;
            backLeftWheelCollider.sidewaysFriction = backLeftWheelSidewaysFriction;
            backRightWheelCollider.sidewaysFriction = backRightWheelSidewaysFriction;

            //Debug.Log(frontLeftWheelFriction.stiffness);
        }
        else if (!isBraking)
        {
            //lerp
            if (handbrakeSelection == 0)
            {
                frontLeftWheelSidewaysFriction.stiffness = Mathf.Lerp(currentDriftFrontSidewaysStiffness, standardSidewaysStiffness, (driftBrakesLerpValue - .01f));
                frontRightWheelSidewaysFriction.stiffness = Mathf.Lerp(currentDriftFrontSidewaysStiffness, standardSidewaysStiffness, (driftBrakesLerpValue - .01f));
                backLeftWheelSidewaysFriction.stiffness = Mathf.Lerp(currentDriftRearSidewaysStiffness, standardSidewaysStiffness, (driftBrakesLerpValue - .01f));
                backRightWheelSidewaysFriction.stiffness = Mathf.Lerp(currentDriftRearSidewaysStiffness, standardSidewaysStiffness, (driftBrakesLerpValue - .01f));
            }
            if (handbrakeSelection == 1 || handbrakeSelection == 2)
            {
                frontLeftWheelSidewaysFriction.stiffness = Mathf.Lerp(currentDriftFrontSidewaysStiffness, standardSidewaysStiffness, driftBrakesLerpValue);
                frontRightWheelSidewaysFriction.stiffness = Mathf.Lerp(currentDriftFrontSidewaysStiffness, standardSidewaysStiffness, driftBrakesLerpValue);
                backLeftWheelSidewaysFriction.stiffness = Mathf.Lerp(currentDriftRearSidewaysStiffness, standardSidewaysStiffness, driftBrakesLerpValue);
                backRightWheelSidewaysFriction.stiffness = Mathf.Lerp(currentDriftRearSidewaysStiffness, standardSidewaysStiffness, driftBrakesLerpValue);
            }
            

            //non-lerp
            //frontLeftWheelFriction.stiffness = standardSidewaysStiffness;
            //frontRightWheelFriction.stiffness = standardSidewaysStiffness;
            //backLeftWheelFriction.stiffness = standardSidewaysStiffness;
            //backRightWheelFriction.stiffness = standardSidewaysStiffness;

            frontLeftWheelCollider.sidewaysFriction = frontLeftWheelSidewaysFriction;
            frontRightWheelCollider.sidewaysFriction = frontRightWheelSidewaysFriction;
            backLeftWheelCollider.sidewaysFriction = backLeftWheelSidewaysFriction;
            backRightWheelCollider.sidewaysFriction = backRightWheelSidewaysFriction;
        }

        //set to zero when sliding
        if (slidingFlag)
        {
            frontLeftWheelSidewaysFriction.stiffness = 0;
            frontLeftWheelForwardFriction.stiffness = 0;
            frontLeftWheelCollider.sidewaysFriction = frontLeftWheelSidewaysFriction;
            frontLeftWheelCollider.forwardFriction = frontLeftWheelForwardFriction;
            frontRightWheelSidewaysFriction.stiffness = 0;
            frontRightWheelForwardFriction.stiffness = 0;
            frontRightWheelCollider.sidewaysFriction = frontRightWheelSidewaysFriction;
            frontRightWheelCollider.forwardFriction = frontRightWheelForwardFriction;
            backLeftWheelSidewaysFriction.stiffness = 0;
            backLeftWheelForwardFriction.stiffness = 0;
            backLeftWheelCollider.sidewaysFriction = backLeftWheelSidewaysFriction;
            backLeftWheelCollider.forwardFriction = backLeftWheelForwardFriction;
            backRightWheelSidewaysFriction.stiffness = 0;
            backRightWheelForwardFriction.stiffness = 0;
            backRightWheelCollider.sidewaysFriction = backRightWheelSidewaysFriction;
            backRightWheelCollider.forwardFriction = backRightWheelForwardFriction;
        }
    }

    private void HandleSteering()
    {
        //switch (currentGear)
        //{
        //    case 1:
        //        steerAngle = maxSteerAngle;
        //        break;
        //    case 2:
        //        steerAngle = maxSteerAngle;
        //        break;
        //    case 3:
        //        steerAngle = maxSteerAngle * .8f;
        //        break;
        //    case 4:
        //        steerAngle = maxSteerAngle * .6f;
        //        break;
        //    case 5:
        //        steerAngle = maxSteerAngle * .4f;
        //        break;
        //    case 6:
        //        steerAngle = maxSteerAngle * .2f;
        //        break;
        //}

        currentSteerAngle = (frontLeftWheelCollider.steerAngle + frontRightWheelCollider.steerAngle) / 2;

        switch (steeringAngleSelection)
        {
            case 0:
                maxSteerAngle = streetSteerAngle;
                break;
            case 1:
                maxSteerAngle = driftSteerAngle;
                break;
        }

        float velocity = carRigidBody.velocity.magnitude;
        if (!isBraking)
        {
            if (velocity < 10f)
            {
                steerAngle = maxSteerAngle * 2.5f;
            }
            if (velocity >= 10f && velocity < 15f)
            {
                steerAngle = maxSteerAngle * 1.7f;
            }
            if (velocity >= 15f && velocity < 25f)
            {
                steerAngle = maxSteerAngle * 1f;
            }
            if (velocity >= 25f && velocity < 45f)
            {
                steerAngle = maxSteerAngle * .7f;
            }
            if (velocity >= 45f && velocity < 75f)
            {
                steerAngle = maxSteerAngle * .5f;
            }
            if (velocity >= 75f && velocity < 110f)
            {
                steerAngle = maxSteerAngle * .35f;
            }
            if (velocity >= 110f)
            {
                steerAngle = maxSteerAngle * .35f;
            }
        }

        float newSteerAngle = steerAngle * horizontalInput;
        switch (steeringPowerSelection)
        {
            case 0:
                steeringLerpValue = unpoweredSteeringLerpValue;
                break;
            case 1:
                steeringLerpValue = poweredSteeringLerpValue;
                break;
        }
        //if (frontWheelDrive)
        //{
        //    switch (steeringPowerSelection)
        //    {
        //        case 0:
        //            steeringLerpValue = .6f;
        //            break;
        //        case 1:
        //            steeringLerpValue = .9f;
        //            break;
        //    }
        //}
        //else
        //{
        //    switch (steeringPowerSelection)
        //    {
        //        case 0:
        //            steeringLerpValue = .6f;
        //            break;
        //        case 1:
        //            steeringLerpValue = .9f;
        //            break;
        //    }
        //}
        

        frontLeftWheelCollider.steerAngle = Mathf.Lerp(currentSteerAngle, newSteerAngle, steeringLerpValue);
        frontRightWheelCollider.steerAngle = Mathf.Lerp(currentSteerAngle, newSteerAngle, steeringLerpValue);

        //steering angle deadzone
        //if (frontLeftWheelCollider.steerAngle <= 1 && frontLeftWheelCollider.steerAngle >= -1)
        //{
        //    frontLeftWheelCollider.steerAngle = 0;
        //    frontRightWheelCollider.steerAngle = 0;
        //}


        //currentSteerAngle = maxSteerAngle * horizontalInput;
        //frontLeftWheelCollider.steerAngle = currentSteerAngle;
        //frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void HandleRotation()
    {
        if (isStalling)
        {
            if (stallCounter > 0 && !touchingGround)
            {
                carRigidBody.angularDrag = 100;

                //carRigidBody.freezeRotation = true;
                stallCounter -= 1f;
                frontLeftWheelCollider.motorTorque = 0;
                frontRightWheelCollider.motorTorque = 0;
                backLeftWheelCollider.motorTorque = 0;
                backRightWheelCollider.motorTorque = 0;
                ApplyBraking();
            }
            else
            {
                carRigidBody.angularDrag = .05f;

                //carRigidBody.freezeRotation = false;
            }

            //carRigidBody.freezeRotation = true;
            //ApplyBraking();
            //carRigidBody.constraints = RigidbodyConstraints.FreezeRotationX;
            //carRigidBody.constraints = RigidbodyConstraints.FreezeRotationY;
            //carRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ;
        }

        if (!isStalling)
        {
            carRigidBody.angularDrag = .05f;

            //carRigidBody.freezeRotation = false;

            if (stallCounter < 40)
            {
                stallCounter = 40;
            }

            //carRigidBody.constraints = RigidbodyConstraints.None;
        }
        //Debug.Log("stallCounter: " + stallCounter);

        //if (touchingGround)
        //{
        //    if (stallCounter < 10)
        //    {
        //        stallCounter = 10;
        //    }
        //}

        if (touchingGround == false)
        {
            if (frontWheelDrive && !rearWheelDrive)
            {
                centerOfMassCurrent.localPosition = Vector3.Lerp(centerOfMassCurrent.localPosition, centerOfMassFrontAir.localPosition, 0.1f);
            }
            if (!frontWheelDrive && rearWheelDrive)
            {
                centerOfMassCurrent.localPosition = Vector3.Lerp(centerOfMassCurrent.localPosition, centerOfMassRearAir.localPosition, 0.1f);
            }
            if (frontWheelDrive && rearWheelDrive)
            {
                centerOfMassCurrent.localPosition = Vector3.Lerp(centerOfMassCurrent.localPosition, centerOfMassCenterAir.localPosition, 0.1f);
            }
            
            //carRigidBody.centerOfMass = centerOfMassAir.localPosition;

            float pitch;
            float yaw;
            float roll;

            if (isBraking == false)
            {
                pitch = transform.rotation.x + verticalInput * controlPitchFactor;
                if (gas < 0)
                {
                    yaw = transform.rotation.y + -horizontalInput * controlYawFactor;
                }
                else
                {
                    yaw = transform.rotation.y + horizontalInput * controlYawFactor;
                }
                //yaw = transform.rotation.y + horizontalInput * controlYawFactor;
                carRigidBody.AddRelativeTorque(Vector3.right * pitch);
                carRigidBody.AddRelativeTorque(Vector3.up * yaw);
            }
            else if (isBraking)
            {
                pitch = transform.rotation.x + verticalInput * controlPitchFactor; 
                roll = transform.rotation.z + horizontalInput * -controlRollFactor;
                carRigidBody.AddRelativeTorque(Vector3.right * pitch);
                carRigidBody.AddRelativeTorque(Vector3.forward * roll);
            }
        }

        //big test right here
        if (touchingGround)
        {
            if (frontWheelDrive && !rearWheelDrive)
            {
                centerOfMassCurrent.localPosition = Vector3.Lerp(centerOfMassCurrent.localPosition, centerOfMassFrontGround.localPosition, 0.9f);
            }
            if (!frontWheelDrive && rearWheelDrive)
            {
                centerOfMassCurrent.localPosition = Vector3.Lerp(centerOfMassCurrent.localPosition, centerOfMassRearGround.localPosition, 0.9f);
            }
            if (frontWheelDrive && rearWheelDrive)
            {
                centerOfMassCurrent.localPosition = Vector3.Lerp(centerOfMassCurrent.localPosition, centerOfMassCenterGround.localPosition, 0.9f);
            }
        }

        //Debug.Log(centerOfMassCurrent.localPosition);
    }
    private void HandleSwitching(InputAction.CallbackContext context)
    {
        if (controls.Player.Passiveitemswap.ReadValue<float>() > .5 && Time.timeScale > 0.1) //timescale is kinda hacky to use
        {
            PlayerPrefs.SetInt("passiveIndex", (PlayerPrefs.GetInt("passiveIndex") + 1));

            if (PlayerPrefs.GetInt("passiveIndex") == 3) //this is whats gonna need updated
            {
                PlayerPrefs.SetInt("passiveIndex", 0);
            }

            pauseMenu.SetPassive(PlayerPrefs.GetInt("passiveIndex"));
            pauseMenu.PassiveDropDown.value = PlayerPrefs.GetInt("passiveIndex");

        }

        if (controls.Player.Useitemswap.ReadValue<float>() > .5 && Time.timeScale > 0.1)  //idk if I'll fix it tho Its probably fine
        {
            PlayerPrefs.SetInt("useButtonIndex", (PlayerPrefs.GetInt("useButtonIndex") + 1));

            if (PlayerPrefs.GetInt("useButtonIndex") == 4) //this also, thank me later
            {
                PlayerPrefs.SetInt("useButtonIndex", 0);
            }

            pauseMenu.SetUseButton(PlayerPrefs.GetInt("useButtonIndex"));
            pauseMenu.UseButtonDropDown.value = PlayerPrefs.GetInt("useButtonIndex");

        }




        //Debug.Log("passiveIndex: " + PlayerPrefs.GetInt("passiveIndex"));
        //Debug.Log("useButtonIndex: " + PlayerPrefs.GetInt("useButtonIndex"));



        //still needs work

        //if (isPassiveSwitching == true)
        //{
        //    PlayerPrefs.SetInt("passiveIndex", (PlayerPrefs.GetInt("passiveIndex") + 1));
        //    if (PlayerPrefs.GetInt("passiveIndex") == 4) //this is whats gonna need updated
        //    {
        //        PlayerPrefs.SetInt("passiveIndex", 0);
        //    }
        //}

        //if (isUseSwitching == true)
        //{
        //    PlayerPrefs.SetInt("useButtonIndex", (PlayerPrefs.GetInt("useButtonIndex") + 1));
        //    if (PlayerPrefs.GetInt("useButtonIndex") == 3) //this too, saved you the trouble
        //    {
        //        PlayerPrefs.SetInt("useButtonIndex", 0);
        //    }
        //}
    }
    public void HandlePassive()
    {
        if (passiveSelection == 1)
        {
            float velocity = Vector3.Dot(carRigidBody.velocity, transform.forward);

            if (carRigidBody.velocity.magnitude >= 50f && Vector3.Dot(carRigidBody.velocity, transform.forward) > -.9f && Physics.Raycast(transform.position, Vector3.down, 200f))
            {
                carRigidBody.useGravity = false;
                carRigidBody.AddForce(0, -10000, 0); //false gravity
                Vector3 newDirection = carRigidBody.velocity.normalized;

                //carRigidBody.transform.LookAt(Vector3.Lerp(carRigidBody.transform.forward, (newPosition + transform.position), .9f));
                //carRigidBody.transform.LookAt(newPosition + transform.position);

                Vector3 nonGlobalUpwardVector = transform.up;
                nonGlobalUpwardVector.y = 0;

                float carBackwardAngle = transform.forward.y;
                if (carBackwardAngle > .2f)
                {
                    carBackwardAngle = .2f;
                }
                if (carBackwardAngle > 0f) // tilt back
                {
                    carRigidBody.AddForce(transform.up * velocity * flightGravity * carBackwardAngle);
                }

                //test, generic upwards force dependent from velocity independent from angle
                float velocityCapped = velocity;
                if (velocityCapped >= 100f)
                {
                    velocityCapped = 100f;
                }
                carRigidBody.AddForce(transform.up * velocityCapped * flightGravity * .15f);

                float carForwardAngle = transform.forward.y;
                if (carForwardAngle < -.5f)
                {
                    carForwardAngle = -.5f;
                }
                if (carForwardAngle < 0f) // tilt forward
                {
                    carRigidBody.AddForce(transform.forward * velocity * flightGravity * -carForwardAngle);
                }

                float carRollAngle = carRigidBody.transform.eulerAngles.z;
                
                if (carRollAngle > 80f && carRollAngle < 180f)
                {
                    carRollAngle = 80f;
                }
                if (carRollAngle < 280f && carRollAngle > 180f)
                {
                    carRollAngle = 280f;
                }


                if (carRollAngle > 15f) // roll side to side
                {
                    carRigidBody.AddForce(nonGlobalUpwardVector * velocity * flightGravity * (carRollAngle * .002f));
                    //carRigidBody.AddForce(transform.up * velocity * flightGravity * (carRollAngle * .0005f));
                }
                if (carRollAngle < 345f) // roll side to side
                {
                    carRigidBody.AddForce(nonGlobalUpwardVector * velocity * flightGravity * ((360f - carRollAngle) * .002f));
                    //carRigidBody.AddForce(transform.up * velocity * flightGravity * ((360f - carRollAngle) * .0005f));
                }
                
            }
            else
            {
                carRigidBody.useGravity = true;
            }

            //handle wing animations
            if (carRigidBody.velocity.magnitude >= 50f)
            {
                if (carEffects.wingsOpen == false)
                {
                    carEffects.AnimateWingsOpen();
                }
            }
            
            if (carRigidBody.velocity.magnitude < 50f)
            {
                if (carEffects.wingsOpen == true)
                {
                    carEffects.AnimateWingsClose();
                }

            }


            //Debug.Log(flightGravityActual);
            //Debug.Log(transform.forward.y);



            //float upwardsPullPoint = velocity / 50f;

            //float flightGravityPercentage = velocity / 100f;
            //float flightGravityActual = flightGravity * flightGravityPercentage;
            //if (carRigidBody.velocity.magnitude >= 50f && Vector3.Dot(carRigidBody.velocity, transform.forward) > 0)
            //{
            //    carRigidBody.useGravity = false;
            //    carRigidBody.AddForce(0, -10000, 0); //false gravity
            //    carRigidBody.AddForce(transform.up * flightGravityActual);
            //}
            //else
            //{
            //    carRigidBody.useGravity = true;
            //}



            //upwardsPull = flightUpwardsForce * upwardsPullPoint;
            //if (upwardsPull > 60000)
            //{
            //    upwardsPull = 60000;
            //}
            //if (carRigidBody.velocity.magnitude >= 50f && Vector3.Dot(carRigidBody.velocity, transform.forward) > 0)
            //{
            //    carRigidBody.AddForce(transform.up * upwardsPull);
            //}

            //Debug.Log(transform.forward.y);

            //if (Vector3.Distance(transform.forward, Vector3.Normalize(carRigidBody.velocity)) > .02f)
            //{
            //    Vector3 carForward = transform.forward;
            //    Vector3 velocityForward = Vector3.Normalize(carRigidBody.velocity);
            //    transform.forward = Vector3.MoveTowards(carForward, velocityForward, .1f);
            //    //Vector3.Lerp(carForward, velocityForward, .9f);
            //}
        }

        if (passiveSelection == 2)
        {
            regularWheelGroup.SetActive(false);
            bigWheelGroup.SetActive(true);

            frontLeftWheelCollider = frontLeftBigWheelCollider;
            frontRightWheelCollider = frontRightBigWheelCollider;
            backLeftWheelCollider = backLeftBigWheelCollider;
            backRightWheelCollider = backRightBigWheelCollider;

            frontLeftWheelTransform = frontLeftBigWheelTransform;
            frontRightWheelTransform = frontRightBigWheelTransform;
            backLeftWheelTransform = backLeftBigWheelTransform;
            backRightWheelTransform = backRightBigWheelTransform;
        }
        else
        {
            regularWheelGroup.SetActive(true);
            bigWheelGroup.SetActive(false);

            frontLeftWheelCollider = frontLeftRegularWheelCollider;
            frontRightWheelCollider = frontRightRegularWheelCollider;
            backLeftWheelCollider = backLeftRegularWheelCollider;
            backRightWheelCollider = backRightRegularWheelCollider;

            frontLeftWheelTransform = frontLeftRegularWheelTransform;
            frontRightWheelTransform = frontRightRegularWheelTransform;
            backLeftWheelTransform = backLeftRegularWheelTransform;
            backRightWheelTransform = backRightRegularWheelTransform;
        }
    }

    public void EngageHandler(InputAction.CallbackContext context)
    {
        if (useButtonSelection == 1)
        {
            carEffects.AnimateJump();

            if (touchingGround)
            {
                carRigidBody.AddForce(transform.up * jumpForce);
                carRigidBody.AddForce(transform.forward * (jumpForce / 10));
            }
        }
    }
    public void HandleThruster()
    {
        //Air thruster
        if (useButtonSelection == 2 && controls.Player.Engage.ReadValue<float>() > 0 && playerAirThrusterFuel > 0 && airThrusterFlag)
        {
            carRigidBody.AddForce(transform.forward * thrusterForce);
            playerAirThrusterFuel -= airThrusterDrain;
            airBoosting = true;
        }
        else
        {
            if (playerAirThrusterFuel <= maxAirThrusterFuel)
            {
                if (playerAirThrusterFuel <= airThrusterCutoff) { airThrusterFlag = false; } 
                else { airThrusterFlag = true; }

                if (!touchingGround)
                {
                    playerAirThrusterFuel += (airThrusterRegen * 4);
                }
                else
                {
                    playerAirThrusterFuel += airThrusterRegen;
                }
            }

            airBoosting = false;
        }

        //Ground booster
        if (useButtonSelection == 3 && controls.Player.Engage.ReadValue<float>() > 0 && playerGroundBoostFuel > 0 && groundBoostFlag)
        {
            if (touchingGround)
            {
                carRigidBody.AddForce(transform.forward * groundBoostForce);
                groundBoosting = true;
                playerGroundBoostFuel -= groundBoostDrain;


                //frontLeftWheelCollider.motorTorque = frontLeftWheelCollider.motorTorque * 10f;
                //frontRightWheelCollider.motorTorque = frontRightWheelCollider.motorTorque * 10f;
                //backLeftWheelCollider.motorTorque = backLeftWheelCollider.motorTorque * 10f;
                //backRightWheelCollider.motorTorque = backRightWheelCollider.motorTorque * 10f;
            }
            else
            {
                groundBoosting = false;
                playerGroundBoostFuel += groundBoostRegen;
            }
            //playerGroundBoostFuel -= groundBoostDrain;
        }
        else
        {
            if (playerGroundBoostFuel <= maxGroundBoostFuel)
            {
                if (playerGroundBoostFuel <= groundBoostCutoff) { groundBoostFlag = false; }
                else { groundBoostFlag = true; }

                playerGroundBoostFuel += groundBoostRegen;
            }

            groundBoosting = false;
        }
    }
    public void PauseHandler(InputAction.CallbackContext context)
    {
        pauseMenu.OnPause();
    }

    private void HandleSpeedometer()
    {
        Vector3 carVelocity = carRigidBody.velocity;
        carVelocity.y = 0;                          //ignore inaccuracies due to y axis
        mph = carVelocity.magnitude * 2.237;        //calculate accurate mph
        //kph = carRigidBody.velocity.magnitude * 3.6;      //calculate accurate kph
        gearBox.text = "Gear: " + currentGear.ToString();
        rpmOutput.text = "eRPM: " + engineRPM.ToString("F0");
        velocityOutput.text = "Units: " + carVelocity.magnitude.ToString("F0");
        speedOutput.text = "MPH: " + mph.ToString("F0");
        if (useButtonSelection == 0 || useButtonSelection == 1)
        {
            boostCanvasGroup.alpha = 0;
        }
        if (useButtonSelection == 2)
        {
            boostCanvasGroup.alpha = 1;
            boostMeter.fillAmount = playerAirThrusterFuel / maxAirThrusterFuel;
            if (playerAirThrusterFuel <= airThrusterCutoff)
            {
                boostMeter.color = Color.red;
            }
            else
            {
                boostMeter.color = thatPurpleyColor;
            }
        }
        if (useButtonSelection == 3)
        {
            boostCanvasGroup.alpha = 1;
            boostMeter.fillAmount = playerGroundBoostFuel / maxGroundBoostFuel;
            if (playerGroundBoostFuel <= groundBoostCutoff)
            {
                boostMeter.color = Color.red;
            }
            else
            {
                boostMeter.color = thatPurpleyColor;
            }
        }
    }
    private void HandleCamera()  //fixes camera when in air
    {
        if (camFlopFlag)
        {
            if (!touchingGround || slidingFlag)
            {
                pauseMenu.CameraFlop(true);
                //if (PlayerPrefs.GetInt("cameraIndex") == 0 || PlayerPrefs.GetInt("cameraIndex") == 1 || PlayerPrefs.GetInt("cameraIndex") == 2)
                //{
                //    pauseMenu.CameraFlop(true);
                //}
            }
            if (touchingGround && !slidingFlag)
            {
                pauseMenu.CameraFlop(false);
            }
        }
    }
    //public void CameraLocker(InputAction.CallbackContext context)
    //{
    //    pauseMenu.CameraActionSwitch();
    //}
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void ResetCheck()
    {
        if (isResetting == true)
        {
            int cameraChoiceTemp = PlayerPrefs.GetInt("cameraIndex");
            pauseMenu.SetCamera(cameraChoiceTemp);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            pauseMenu.SetCamera(cameraChoiceTemp);
        }
        if (isFlipping == true)
        {
            carRigidBody.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        }
    }

    private void DebugToConsole()
    {
        //Debug.Log("touchingGround: " + touchingGround);
        //WheelFrictionCurve frontLeftWheelSidewaysFriction = frontLeftWheelCollider.sidewaysFriction;
        //Debug.Log("frontLeftWheelSidewaysFriction.stiffness: " + frontLeftWheelSidewaysFriction.stiffness);
        //var flSpring = frontLeftWheelCollider.suspensionSpring;
        //Debug.Log("flspring.damper: " + flSpring.damper);

    }
}



//~~~~~~~~~~~Old code graveyard~~~~~~~~~~~//

//HandleRotation Class

////with Euler angles, transform.rotation, breaks when upside down
//if (isBraking == false)
//{
//    pitch = transform.eulerAngles.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    yaw = transform.eulerAngles.y + horizontalInput * controlYawFactor;
//    transform.rotation = Quaternion.Euler(pitch, yaw, transform.eulerAngles.z);
//}
//else if (isBraking)
//{
//    pitch = transform.eulerAngles.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    roll = transform.eulerAngles.z + horizontalInput * -controlRollFactor;
//    transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, roll);
//    Debug.Log(roll);
//}

////without Euler angles, transform.Rotate() with float angles, breaks when upside down
//if (isBraking == false)
//{
//    pitch = transform.rotation.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    yaw = transform.rotation.y + horizontalInput * controlYawFactor;
//    transform.Rotate(pitch, yaw, transform.rotation.z, Space.Self);
//}
//else if (isBraking)
//{
//    pitch = transform.rotation.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    //roll = transform.rotation.z + horizontalInput * -controlRollFactor;
//    roll = transform.rotation.z + horizontalInput * -controlRollFactor;
//    transform.Rotate(transform.rotation.x, transform.rotation.y, roll, Space.Self);
//    Debug.Log(roll);
//}

////without Euler angles, transform.Rotate() with Vector3, still fucking breaks upside down
//if (isBraking == false)
//{
//    pitch = transform.rotation.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    yaw = transform.rotation.y + horizontalInput * controlYawFactor;
//    transform.Rotate(Vector3.right, pitch, Space.World);
//    transform.Rotate(Vector3.up, yaw, Space.World);
//}
//else if (isBraking)
//{
//    //pitch = transform.rotation.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    roll = transform.rotation.z + horizontalInput * -controlRollFactor;
//    transform.Rotate(Vector3.forward, roll, Space.World);
//    Debug.Log(roll);
//}

//without Euler angles, transform.rotation, breaks when upside down
//if (isBraking == false)
//{
//    //pitch = transform.rotation.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    //yaw = transform.rotation.y + horizontalInput * controlYawFactor;
//    pitch = gamepadVerticalInput;
//    yaw = horizontalInput;
//    transform.rotation *= Quaternion.AngleAxis(pitch, Vector3.right);
//    transform.rotation *= Quaternion.AngleAxis(yaw, Vector3.up);
//}
//else if (isBraking)
//{
//    //pitch = transform.rotation.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    //roll = transform.rotation.z + horizontalInput * -controlRollFactor;
//    roll = -horizontalInput;
//    transform.rotation *= Quaternion.AngleAxis(roll, Vector3.forward);
//    Debug.Log(roll);
//}

////idk dude I found this one in a youtube video, breaks when upside down
//if (isBraking == false)
//{
//    pitch = transform.rotation.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    yaw = transform.rotation.y + horizontalInput * controlYawFactor;
//    transform.rotation *= Quaternion.AngleAxis(pitch, Vector3.right);
//    transform.rotation *= Quaternion.AngleAxis(yaw, Vector3.up);
//}
//else if (isBraking)
//{
//    //pitch = transform.rotation.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    roll = transform.rotation.z + horizontalInput * -controlRollFactor;
//    transform.rotation *= Quaternion.AngleAxis(roll, Vector3.forward);
//    Debug.Log(roll);
//}

//split up.  set destination rotation position as new vector3, then transform to it with eulerAngles
//if (isBraking == false)
//{
//    pitch = transform.rotation.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    yaw = transform.rotation.y + horizontalInput * controlYawFactor;
//    Vector3 newRotation = new Vector3(pitch, yaw, transform.rotation.z);
//    transform.Rotate(newRotation);
//}
//else if (isBraking)
//{
//    pitch = transform.rotation.x + gamepadVerticalInput * controlPitchFactor; //specific to gamepad for time being, needs fixing
//    //roll = transform.rotation.z + horizontalInput * -controlRollFactor;
//    roll = transform.rotation.z + horizontalInput * -controlRollFactor;
//    Vector3 newRotation = new Vector3(transform.rotation.x, transform.rotation.y, roll);
//    transform.Rotate(newRotation);
//    Debug.Log(roll);
//}



//new input menu
//horizontalPause = controls.Menu.LeftRight.ReadValue<float>();
//verticalPause = controls.Menu.UpDown.ReadValue<float>();
//controls.Menu.Pause.performed += PauseHandler;

//if (pauseCheck > .5)
//{ pressingPause = true; }
//else { pressingPause = false; }

//if (controls.Player.Handbrake.triggered)
//{
//    isBraking = true;
//}

//if (controls.Player.Reset.triggered)
//{
//    isResetting = true;
//    Debug.Log(isResetting);
//}

//if (controls.Player.Flip.triggered)
//{
//    isFlipping = true;
//}

//if (controls.Player.Pause.triggered)
//{
//    pressingPause = true;
//}

//horizontalInput = Input.GetAxis(HORIZONTAL);
//verticalInput = Input.GetAxis(VERTICAL);
//isBraking = Input.GetKey(KeyCode.Space);

//brakeCheck = handbrake.ReadValue<float>();
//if (brakeCheck > .5)
//{ isBraking = true; } else { isBraking = false; }

//resetCheck = reset.ReadValue<float>();
//if (resetCheck > .5)
//{ isResetting = true; } else { isResetting = false; }

//flipCheck = flip.ReadValue<float>();
//if (flipCheck > .5)
//{ isFlipping = true; } else { isFlipping = false; }

//pauseCheck = pause.ReadValue<float>();
//if (pauseCheck > .5)
//{ pressingPause = true; } else { pressingPause = false; }