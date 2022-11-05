using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Cinemachine;

public class CarController : MonoBehaviour
{
    public InputMaster controls;
    CarEffects carEffects;
    [Space]

    [SerializeField] public Image boostMeter;
    [Space]
    public PauseMenu pauseMenu;
    [Space]
    
    [Header("Center of Masses")]
    [SerializeField] private Rigidbody carRigidBody;
    [SerializeField] public Transform centerOfMassCenterAir;
    [SerializeField] public Transform centerOfMassCenterGround;
    [SerializeField] public Transform centerOfMassFrontAir;
    [SerializeField] public Transform centerOfMassFrontGround;
    [SerializeField] public Transform centerOfMassRearAir;
    [SerializeField] public Transform centerOfMassRearGround;
    [SerializeField] public Transform centerOfMassCurrent;
    [Space]
    
    CarBodySelection carBodySelection;
    [Space]
    
    [Header("Inputs")]
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float gas;
    [SerializeField] private float cameraVerticalInput;
    [SerializeField] private float cameraHorizontalInput;
    [Space]

    [SerializeField] private float brakeCheck;
    [SerializeField] private float resetCheck;
    [SerializeField] private float flipCheck;
    [SerializeField] private float engageCheck;
    [SerializeField] private float stallCheck;
    [SerializeField] private float boostCheck;
    [Space]
    
    [Header("Input Checks")]
    [SerializeField] public bool isBraking;
    [SerializeField] public bool isReversing;
    [SerializeField] private bool isResetting;
    [SerializeField] private bool isFlipping;
    [SerializeField] private bool isEngaging;
    [SerializeField] public bool isCamming;
    [SerializeField] private bool isStalling;
    [SerializeField] private bool isBoosting;
    [Space]

    [Header("Wheel Collider Handles")]
    [SerializeField] public GameObject wheelColliderGroup;
    [SerializeField] public WheelCollider frontLeftWheelCollider;
    [SerializeField] public WheelCollider frontRightWheelCollider;
    [SerializeField] public WheelCollider backLeftWheelCollider;
    [SerializeField] public WheelCollider backRightWheelCollider;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;
    [Header("Wheel Colliders Regular")]
    [SerializeField] public GameObject regularWheelGroup;
    [SerializeField] public WheelCollider frontLeftRegularWheelCollider;
    [SerializeField] public WheelCollider frontRightRegularWheelCollider;
    [SerializeField] public WheelCollider backLeftRegularWheelCollider;
    [SerializeField] public WheelCollider backRightRegularWheelCollider;
    [SerializeField] private Transform frontLeftRegularWheelTransform;
    [SerializeField] private Transform frontRightRegularWheelTransform;
    [SerializeField] private Transform backLeftRegularWheelTransform;
    [SerializeField] private Transform backRightRegularWheelTransform;
    [Header("Wheel Colliders Big")]
    [SerializeField] public GameObject bigWheelGroup;
    [SerializeField] public WheelCollider frontLeftBigWheelCollider;
    [SerializeField] public WheelCollider frontRightBigWheelCollider;
    [SerializeField] public WheelCollider backLeftBigWheelCollider;
    [SerializeField] public WheelCollider backRightBigWheelCollider;
    [SerializeField] private Transform frontLeftBigWheelTransform;
    [SerializeField] private Transform frontRightBigWheelTransform;
    [SerializeField] private Transform backLeftBigWheelTransform;
    [SerializeField] private Transform backRightBigWheelTransform;
    [Space]

    [Header("Ground hit checks")]
    [SerializeField] public bool touchingGround;
    public bool flTouchingGround;
    public bool frTouchingGround;
    public bool blTouchingGround;
    public bool brTouchingGround;
    [SerializeField] public bool slidingFlag;
    public bool flSlidingFlag;
    public bool frSlidingFlag;
    public bool blSlidingFlag;
    public bool brSlidingFlag;
    [Header("Wheel Cover colliders, ground hit references")]
    [SerializeField] WheelCoverCode flCoverCode;
    [SerializeField] WheelCoverCode frCoverCode;
    [SerializeField] WheelCoverCode blCoverCode;
    [SerializeField] WheelCoverCode brCoverCode;
    [Space]
    [SerializeField] private Collider frWheelCover;
    [SerializeField] private Collider flWheelCover;
    [SerializeField] private Collider brWheelCover;
    [SerializeField] private Collider blWheelCover;
    [Space]
    [SerializeField] private GameObject frWheelRigid;
    [SerializeField] private GameObject flWheelRigid;
    [SerializeField] private GameObject brWheelRigid;
    [SerializeField] private GameObject blWheelRigid;
    [Space]

    [SerializeField][Header("temp friction values")]
    float frontLeftWheelSidewaysFrictionTemp = 99;
    float frontLeftWheelForwardFrictionTemp = 99;
    float frontRightWheelSidewaysFrictionTemp = 99;
    float frontRightWheelForwardFrictionTemp = 99;
    float backLeftWheelSidewaysFrictionTemp = 99;
    float backLeftWheelForwardFrictionTemp = 99;
    float backRightWheelSidewaysFrictionTemp = 99;
    float backRightWheelForwardFrictionTemp = 99;
    [Space]

    [Header("Suspension values")]
    [SerializeField] public int suspensionSelection;
    [SerializeField] private float bouncySuspensionValue;
    [SerializeField] private float middleSuspensionValue;
    [SerializeField] private float sturdySuspensionValue;
    [SerializeField] private float rockSuspensionValue;
    [Space]
    float flSpringTemp;
    float frSpringTemp;
    float blSpringTemp;
    float brSpringTemp;
    [Space]

    [Header("Handbrake values")]
    [SerializeField] public int handbrakeSelection;
    [SerializeField] private bool frontHandBrake;
    [SerializeField] private bool rearHandBrake;
    [SerializeField] private float brakeForce;
    [SerializeField] private float moreDriftBrakeForce;
    [SerializeField] private float lessDriftBrakeForce;
    [Space]
    [SerializeField] private float standardSidewaysStiffness;
    [SerializeField] private float driftForwardStiffnessConstant;
    [SerializeField] private float driftBrakesLerpValue;
    [SerializeField] private float driftFrontSidewaysStiffness;
    [SerializeField] private float driftRearSidewaysStiffness;
    [Space]
    [SerializeField] private float driftBrakesDriftFrontSidewaysStiffness;
    [SerializeField] private float driftBrakesDriftRearSidewaysStiffness;
    [SerializeField] private float basicBrakesDriftFrontSidewaysStiffness;
    [SerializeField] private float basicBrakesDriftRearSidewaysStiffness;
    [SerializeField] private float offRoadBrakesDriftFrontSidewaysStiffness;
    [SerializeField] private float offRoadBrakesDriftRearSidewaysStiffness;
    [Space]
    private float currentBrakeForce;
    [Space]
    [SerializeField] public int tireSelection;
    [SerializeField] private float basicTiresStandardSidewaysStiffness;
    [SerializeField] private float offRoadTiresStandardSidewaysStiffness;
    [SerializeField] private float driftTiresStandardSidewaysStiffness;
    [Space]

    [Header("Powered Axle")]
    [SerializeField] public bool frontWheelDrive;
    [SerializeField] public bool rearWheelDrive;
    [SerializeField] private float singleAxleMFAdjustment;
    [Space]

    [Header("Motor Values")]
    [SerializeField] private bool dragExists;
    [SerializeField] private float dragMultiple;
    [Space]
    [SerializeField] public int motorSelection;
    [SerializeField] private float motorForce;
    [SerializeField] private float streetMotorForce;
    [SerializeField] private float racingMotorForce;
    [Space]

    [Header("Transmission Values")]
    [SerializeField] public int transmissionSelection;
    private float transmissionForce;
    private float engineRPM;
    [SerializeField] private float minRPM;
    [SerializeField] private float maxRPM;
    private float currentGear = 1f;
    private float gearNumber = 6f;
    [Space]

    [Header("4 Speed")]
    [SerializeField] public float fourSpeedFirstGear;
    [SerializeField] public float fourSpeedSecondGear;
    [SerializeField] public float fourSpeedThirdGear;
    [SerializeField] public float fourSpeedFourthGear;
    [Space]

    [Header("6 Speed")]
    [SerializeField] public float sixSpeedFirstGear;
    [SerializeField] public float sixSpeedSecondGear;
    [SerializeField] public float sixSpeedThirdGear;
    [SerializeField] public float sixSpeedFourthGear;
    [SerializeField] public float sixSpeedFifthGear;
    [SerializeField] public float sixSpeedSixthGear;
    [Space]

    [Header("6 Speed Sport")]
    [SerializeField] public float sixSpeedSportFirstGear;
    [SerializeField] public float sixSpeedSportSecondGear;
    [SerializeField] public float sixSpeedSportThirdGear;
    [SerializeField] public float sixSpeedSportFourthGear;
    [SerializeField] public float sixSpeedSportFifthGear;
    [SerializeField] public float sixSpeedSportSixthGear;
    [Space]

    [Header("6 Speed Drift")]
    [SerializeField] public float sixSpeedDriftFirstGear;
    [SerializeField] public float sixSpeedDriftSecondGear;
    [SerializeField] public float sixSpeedDriftThirdGear;
    [SerializeField] public float sixSpeedDriftFourthGear;
    [SerializeField] public float sixSpeedDriftFifthGear;
    [SerializeField] public float sixSpeedDriftSixthGear;
    [Space]

    [Header("Steering Values")]
    [SerializeField] public int steeringAngleSelection;
    private float currentSteerAngle;
    private float steerAngle;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private float streetSteerAngle;
    [SerializeField] private float driftSteerAngle;
    [SerializeField] public int steeringPowerSelection;
    [SerializeField] private float steeringLerpValue;
    [SerializeField] private float unpoweredSteeringLerpValue;
    [SerializeField] private float poweredSteeringLerpValue;
    [Space]

    [Header("Rotation Values")]
    [SerializeField] public float stallCounter = 40f;
    [SerializeField] private float controlPitchFactor;
    [SerializeField] private float controlYawFactor;
    [SerializeField] private float controlRollFactor;
    [Space]

    [Header("Passive Values")]
    [SerializeField] public int passiveSelection;
    [SerializeField] private float flightGravity;
    [Space]

    [Header("Use Button Values")]
    [SerializeField] public int useButtonSelection;
    [SerializeField] public int boostButtonSelection;
    public bool wingsOpen = false;
    [Space]
    [Header("Flux Capacitor")]
    [SerializeField] public bool fluxing = false;
    public bool fluxFlag = false;
    public float playerFluxFuel = 100f;
    [SerializeField] private float fluxForce;
    [SerializeField] private float maxFluxFuel = 100f;
    [SerializeField] private float fluxDrain;
    [SerializeField] private float fluxRegen;
    [SerializeField] private float fluxCutoff;
    [Space]
    [Header("Air Thruster")]
    [SerializeField] public bool airBoosting = false;
    public bool airThrusterFlag = false;
    public float playerAirThrusterFuel = 100f;
    [SerializeField] private float thrusterForce;
    [SerializeField] private float maxAirThrusterFuel = 100f;
    [SerializeField] private float airThrusterDrain = 0.5f;
    [SerializeField] private float airThrusterRegen = 0.5f;
    [SerializeField] private float airThrusterCutoff = 25f;
    [Space]
    [Header("Ground Thruster")]
    [SerializeField] public bool groundBoosting = false;
    public bool groundBoostFlag = false;
    public float playerGroundBoostFuel = 100f;
    [SerializeField] private float groundBoostForce;
    [SerializeField] private float maxGroundBoostFuel = 100f;
    [SerializeField] private float groundBoostDrain = 0.5f;
    [SerializeField] private float groundBoostRegen = 0.5f;
    [SerializeField] private float groundBoostCutoff = 25f;
    [Space]
    [Header("Jump Jacks")]
    [SerializeField] private float jumpForce;
    [Space]

    [Header("Speedometer Values")]
    [SerializeField] Color thatPurpleyColor;
    double mph;
    [SerializeField] public Text gearBox;
    [SerializeField] public Text rpmOutput;
    [SerializeField] public Text velocityOutput;
    [SerializeField] public Text speedOutput;
    [SerializeField] public CanvasGroup boostCanvasGroup;
    [SerializeField] public float spedLerpValue;
    public float prevGear = 0;
    public float prevERPM = 0;
    public float prevUnits = 0;
    public float prevMPH = 0;
    [Space]

    [Header("Camera Values")]
    [SerializeField] public bool camFlopFlag;



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

        //carBodySelection.BodyCheck();
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
        HandleSuspension();
        HandleMotor();
        HandleHandbrakeSelection();
        HandleSteering();
        HandleRotation();
        HandlePassive();
        HandleUseButtonOnUpdate(); //sloppy becuase of new input system
        HandleBoostButton();
        HandleSpeedometer();
        HandleCamera();
        UpdateWheels();
        ResetCheck();
        
        DebugToConsole();
    }

    private void GetInput()
    {
        //new input player

        horizontalInput = controls.Player.Steering.ReadValue<float>();
        verticalInput = controls.Player.UpDown.ReadValue<float>();
        gas = controls.Player.ForwardReverse.ReadValue<float>();

        brakeCheck = controls.Player.Handbrake.ReadValue<float>();
        resetCheck = controls.Player.Reset.ReadValue<float>();
        flipCheck = controls.Player.Flip.ReadValue<float>();
        controls.Player.Engage.performed += UseButtonHandler;
        engageCheck = controls.Player.Engage.ReadValue<float>();
        controls.Player.Passiveitemswap.performed += HandleSwitching;
        controls.Player.Useitemswap.performed += HandleSwitching;
        controls.Player.Boostswap.performed += HandleSwitching;
        controls.Player.Pause.performed += PauseHandler;
        stallCheck = controls.Player.Stall.ReadValue<float>();
        boostCheck = controls.Player.Boost.ReadValue<float>();

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

        if (boostCheck > .5)
        { isBoosting = true; }
        else { isBoosting = false; }
    }

    void CheckGround()
    {
        //instantiate
        WheelFrictionCurve frontLeftWheelSidewaysFriction = frontLeftWheelCollider.sidewaysFriction;
        WheelFrictionCurve frontLeftWheelForwardFriction = frontLeftWheelCollider.forwardFriction;
        WheelFrictionCurve frontRightWheelSidewaysFriction = frontRightWheelCollider.sidewaysFriction;
        WheelFrictionCurve frontRightWheelForwardFriction = frontRightWheelCollider.forwardFriction;
        WheelFrictionCurve backLeftWheelSidewaysFriction = backLeftWheelCollider.sidewaysFriction;
        WheelFrictionCurve backLeftWheelForwardFriction = backLeftWheelCollider.forwardFriction;
        WheelFrictionCurve backRightWheelSidewaysFriction = backRightWheelCollider.sidewaysFriction;
        WheelFrictionCurve backRightWheelForwardFriction = backRightWheelCollider.forwardFriction;

        //Check various wheels for ground
        //front left
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
        
        //front right
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

        //back left
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

        //back right
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

        //check for all 4 wheels touching ground
        if (flTouchingGround && frTouchingGround && blTouchingGround && brTouchingGround)
        {
            touchingGround = true;
        }
        else
        {
            touchingGround = false;
        }

        //check for all 4 wheels sliding
        if (flSlidingFlag || frSlidingFlag || blSlidingFlag || brSlidingFlag)
        {
            slidingFlag = true;
        }
        else
        {
            slidingFlag = false;
        }


        //check if wheel covers are colliding with ground. This is for controlling wheel suspension while in air
        //front left
        if (flCoverCode.coverTouchingGround == false)
        {
            flWheelRigid.gameObject.SetActive(true);
        }
        else
        {
            flWheelRigid.gameObject.SetActive(false);
        }

        //front right
        if (frCoverCode.coverTouchingGround == false)
        {
            frWheelRigid.gameObject.SetActive(true);
        }
        else
        {
            frWheelRigid.gameObject.SetActive(false);
        }

        //back left
        if (blCoverCode.coverTouchingGround == false)
        {
            blWheelRigid.gameObject.SetActive(true);
        }
        else
        {
            blWheelRigid.gameObject.SetActive(false);
        }

        //back right
        if (brCoverCode.coverTouchingGround == false)
        {
            brWheelRigid.gameObject.SetActive(true);
        }
        else
        {
            brWheelRigid.gameObject.SetActive(false);
        }
    }

    private void HandleSuspension()
    {
        var flSpring = frontLeftWheelCollider.suspensionSpring;
        var frSpring = frontRightWheelCollider.suspensionSpring;
        var blSpring = backLeftWheelCollider.suspensionSpring;
        var brSpring = backRightWheelCollider.suspensionSpring;

        //player suspension choice switch
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

        //controls suspension when all four wheels are in air
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

        //controls suspension when all four wheels are sliding
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

        //returns suspension values when not sliding or in air
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

        //instantiate friction curves
        //sideways
        WheelFrictionCurve frontLeftWheelSidewaysFriction = frontLeftWheelCollider.sidewaysFriction;
        WheelFrictionCurve frontRightWheelSidewaysFriction = frontRightWheelCollider.sidewaysFriction;
        WheelFrictionCurve backLeftWheelSidewaysFriction = backLeftWheelCollider.sidewaysFriction;
        WheelFrictionCurve backRightWheelSidewaysFriction = backRightWheelCollider.sidewaysFriction;
        //forward
        WheelFrictionCurve frontLeftWheelForwardFriction = frontLeftWheelCollider.forwardFriction;
        WheelFrictionCurve frontRightWheelForwardFriction = frontRightWheelCollider.forwardFriction;
        WheelFrictionCurve backLeftWheelForwardFriction = backLeftWheelCollider.forwardFriction;
        WheelFrictionCurve backRightWheelForwardFriction = backRightWheelCollider.forwardFriction;

        //handle player tire selection
        switch (tireSelection)
        {
            case 0:
                standardSidewaysStiffness = basicTiresStandardSidewaysStiffness;
                break;
            case 1:
                standardSidewaysStiffness = offRoadTiresStandardSidewaysStiffness;
                break;
            case 2:
                standardSidewaysStiffness = driftTiresStandardSidewaysStiffness;
                break;
        }

        //this if statement will compare the car transform's forward vector to the car's velocity's forward vector and adjust the tires' sideways friction as a result
        //this is to increase traction during slight steering adjustments while dropping traction for drifts and corners
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

        float currentDriftFrontSidewaysStiffness = (frontLeftWheelSidewaysFriction.stiffness + frontRightWheelSidewaysFriction.stiffness) / 2;
        float currentDriftRearSidewaysStiffness = (backLeftWheelSidewaysFriction.stiffness + backRightWheelSidewaysFriction.stiffness) / 2;

        //handle braking and not braking
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
            frontLeftWheelSidewaysFriction.stiffness = driftFrontSidewaysStiffness;
            frontRightWheelSidewaysFriction.stiffness = driftFrontSidewaysStiffness;
            backLeftWheelSidewaysFriction.stiffness = driftRearSidewaysStiffness;
            backRightWheelSidewaysFriction.stiffness = driftRearSidewaysStiffness;

            frontLeftWheelCollider.sidewaysFriction = frontLeftWheelSidewaysFriction;
            frontRightWheelCollider.sidewaysFriction = frontRightWheelSidewaysFriction;
            backLeftWheelCollider.sidewaysFriction = backLeftWheelSidewaysFriction;
            backRightWheelCollider.sidewaysFriction = backRightWheelSidewaysFriction;
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
        //handle player motor selection
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

        //handle player transmission selection
        switch (transmissionSelection)
        {
            case 0:
                Transmission4Speed();
                break;
            case 1:
                Transmission6Speed();
                break;
            case 2:
                Transmission6SpeedSport();
                break;
            case 3:
                Transmission6SpeedDrift();
                break;
        }

        //Determine and apply motor force
        if (frontWheelDrive && rearWheelDrive)
        {
            frontLeftWheelCollider.motorTorque = gas * motorForce * transmissionForce;
            frontRightWheelCollider.motorTorque = gas * motorForce * transmissionForce;
            backLeftWheelCollider.motorTorque = gas * motorForce * transmissionForce;
            backRightWheelCollider.motorTorque = gas * motorForce * transmissionForce;
        }
        else if (frontWheelDrive && !rearWheelDrive)
        {
            frontLeftWheelCollider.motorTorque = gas * (motorForce * singleAxleMFAdjustment) * transmissionForce;
            frontRightWheelCollider.motorTorque = gas * (motorForce * singleAxleMFAdjustment) * transmissionForce;
            backLeftWheelCollider.motorTorque = 0f;
            backRightWheelCollider.motorTorque = 0f;
        }
        else if (rearWheelDrive && !frontWheelDrive)
        {
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
    private void Transmission4Speed()
    {
        //determine engine rpms from axle choice
        if (frontWheelDrive)
        {
            engineRPM = (frontLeftWheelCollider.rpm + frontRightWheelCollider.rpm) / 2f * transmissionForce;
        }
        else
        {
            engineRPM = (backLeftWheelCollider.rpm + backRightWheelCollider.rpm) / 2f * transmissionForce;
        }

        //gearbox
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
    private void Transmission6Speed()
    {
        //determine engine rpms from axle choice
        if (frontWheelDrive)
        {
            engineRPM = (frontLeftWheelCollider.rpm + frontRightWheelCollider.rpm) / 2f * transmissionForce;
        }
        else
        {
            engineRPM = (backLeftWheelCollider.rpm + backRightWheelCollider.rpm) / 2f * transmissionForce;
        }

        //gearbox
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
    private void Transmission6SpeedSport()
    {
        //determine engine rpms from axle choice
        if (frontWheelDrive)
        {
            engineRPM = (frontLeftWheelCollider.rpm + frontRightWheelCollider.rpm) / 2f * transmissionForce;
        }
        else
        {
            engineRPM = (backLeftWheelCollider.rpm + backRightWheelCollider.rpm) / 2f * transmissionForce;
        }

        //gearbox
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
    private void Transmission6SpeedDrift()
    {
        //determine engine rpms from axle choice
        if (frontWheelDrive)
        {
            engineRPM = (frontLeftWheelCollider.rpm + frontRightWheelCollider.rpm) / 2f * transmissionForce;
        }
        else
        {
            engineRPM = (backLeftWheelCollider.rpm + backRightWheelCollider.rpm) / 2f * transmissionForce;
        }

        //gearbox
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
    private void HandleHandbrakeSelection()
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
    }
    private void HandleSteering()
    {
        currentSteerAngle = (frontLeftWheelCollider.steerAngle + frontRightWheelCollider.steerAngle) / 2;

        //handle player's steering angle choice
        switch (steeringAngleSelection)
        {
            case 0:
                maxSteerAngle = streetSteerAngle;
                break;
            case 1:
                maxSteerAngle = driftSteerAngle;
                break;
        }

        //adjust steering angle according to velocity, to prevent oversteering at speed and understeering at low speed
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
        
        //handles powered vs unpowered steering.  controls how aggressive the lerped steering angle responds
        switch (steeringPowerSelection)
        {
            case 0:
                steeringLerpValue = unpoweredSteeringLerpValue;
                break;
            case 1:
                steeringLerpValue = poweredSteeringLerpValue;
                break;
        }

        frontLeftWheelCollider.steerAngle = Mathf.Lerp(currentSteerAngle, newSteerAngle, steeringLerpValue);
        frontRightWheelCollider.steerAngle = Mathf.Lerp(currentSteerAngle, newSteerAngle, steeringLerpValue);
    }
    private void HandleRotation()
    {
        //slows down rigidbody rotation when player presses stall button
        if (isStalling)
        {
            if (stallCounter > 0 && !touchingGround)
            {
                carRigidBody.angularDrag = 100;

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
            }
        }
        //resets stall counter
        if (!isStalling)
        {
            carRigidBody.angularDrag = .05f;

            if (stallCounter < 40)
            {
                stallCounter = 40;
            }
        }

        //moves center of mass to center of volume, rather than like 20 feet below the ground
        if (touchingGround == false)
        {
            //limit rotation speed in air
            carRigidBody.maxAngularVelocity = 4.5f;

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

            float pitch;
            float yaw;
            float roll;

            if (isBraking == false)
            {
                pitch = transform.rotation.x + verticalInput * controlPitchFactor;
                yaw = transform.rotation.y + horizontalInput * controlYawFactor;

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

        //remove rotation speed limit on ground
        if (flTouchingGround || frTouchingGround || blTouchingGround || brTouchingGround)
        {
            carRigidBody.maxAngularVelocity = 7;
        }

        //return center of mass to below the ground
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
    }
    private void HandlePassive()
    {
        if (passiveSelection == 1) //big wheels
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
    public void HandleUseButtonOnUpdate()
    {
        if (wingsOpen == true)
        {
            float velocity = Vector3.Dot(carRigidBody.velocity, transform.forward);

            //carRigidBody.useGravity = false;
            //carRigidBody.AddForce(0, -10000, 0); //false gravity
            Vector3 newDirection = carRigidBody.velocity.normalized;

            Vector3 nonGlobalUpwardVector = transform.up;
            nonGlobalUpwardVector.y = 0;

            float carBackwardAngle = transform.forward.y;

            if (carBackwardAngle > .2f)
            {
                carBackwardAngle = .2f;
            }
            if (carBackwardAngle > 0f) // gain height from tilting back
            {
                carRigidBody.AddForce(transform.up * velocity * flightGravity * carBackwardAngle * .2f);
            }

            //test, generic upwards force dependent from velocity independent from angle
            float velocityCapped = velocity;
            if (velocityCapped >= 100f)
            {
                velocityCapped = 100f;
            }
            carRigidBody.AddForce(transform.up * velocityCapped * flightGravity);

            //adjust height from angle
            float carForwardAngle = transform.forward.y;
            if (carForwardAngle < -.5f)
            {
                carForwardAngle = -.5f;
            }
            if (carForwardAngle < 0f) // gain speed and lose height from tilting forward
            {
                carRigidBody.AddForce(transform.forward * velocity * flightGravity * -carForwardAngle * .05f);
            }

            //cap rolling left and right
            float carRollAngle = carRigidBody.transform.eulerAngles.z;
            if (carRollAngle > 80f && carRollAngle < 180f)
            {
                carRollAngle = 80f;
            }
            if (carRollAngle < 280f && carRollAngle > 180f)
            {
                carRollAngle = 280f;
            }

            //add force according to left and right rolling
            if (carRollAngle > 15f) // roll side to side
            {
                carRigidBody.AddForce(nonGlobalUpwardVector * velocity * flightGravity * (carRollAngle * .002f) * .3f);
            }
            if (carRollAngle < 345f) // roll side to side
            {
                carRigidBody.AddForce(nonGlobalUpwardVector * velocity * flightGravity * ((360f - carRollAngle) * .002f) * .3f);
            }

            //airbrake
            if (isReversing == true && touchingGround == false && velocity > 0f)
            {
                carRigidBody.AddForce(-transform.forward * 50000f);
            }
        }
    }
    public void HandleBoostButton()
    {
        //Flux boosting
        if (boostButtonSelection == 3 && controls.Player.Boost.ReadValue<float>() > 0 && playerFluxFuel > 0 && fluxFlag)
        {
            carRigidBody.AddForce(transform.forward * fluxForce);
            playerFluxFuel -= fluxDrain;
            fluxing = true;
        }
        else
        {
            if (playerFluxFuel <= maxFluxFuel)
            {
                if (playerFluxFuel <= fluxCutoff) { fluxFlag = false; }
                else { fluxFlag = true; }

                playerFluxFuel += fluxRegen;
            }

            fluxing = false;
        }

        //Air thruster
        if (boostButtonSelection == 2 && controls.Player.Boost.ReadValue<float>() > 0 && playerAirThrusterFuel > 0 && airThrusterFlag)
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
        if (boostButtonSelection == 1 && controls.Player.Boost.ReadValue<float>() > 0 && playerGroundBoostFuel > 0 && groundBoostFlag)
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
    private void HandleSpeedometer()
    {
        //determine speedometer values
        Vector3 carVelocity = carRigidBody.velocity;
        carVelocity.y = 0;                          //ignore inaccuracies due to y axis
        mph = carVelocity.magnitude * 2.237;        //calculate accurate mph
        //kph = carRigidBody.velocity.magnitude * 3.6;      //calculate accurate kph

        //output speedometer values
        float newGear = Mathf.Lerp(prevGear, currentGear, spedLerpValue);
        float newERPM = Mathf.Lerp(prevERPM, engineRPM, spedLerpValue);
        float newUnits = Mathf.Lerp(prevUnits, carVelocity.magnitude, spedLerpValue);
        float newMPH = Mathf.Lerp(prevMPH, (float)mph, spedLerpValue);

        gearBox.text = "Gear: " + newGear.ToString("F0");
        rpmOutput.text = "eRPM: " + newERPM.ToString("F0");
        velocityOutput.text = "Units: " + newUnits.ToString("F0");
        speedOutput.text = "MPH: " + newMPH.ToString("F0");

        //gearBox.text = "Gear: " + currentGear.ToString();
        //rpmOutput.text = "eRPM: " + engineRPM.ToString("F0");
        //velocityOutput.text = "Units: " + carVelocity.magnitude.ToString("F0");
        //speedOutput.text = "MPH: " + mph.ToString("F0");

        prevGear = newGear;
        prevERPM = newERPM;
        prevUnits = newUnits;
        prevMPH = newMPH;

        //handle boost bar
        if (boostButtonSelection == 3)
        {
            boostCanvasGroup.alpha = 1;
            boostMeter.fillAmount = playerFluxFuel / maxFluxFuel;
            if (playerFluxFuel <= fluxCutoff)
            {
                boostMeter.color = Color.red;
            }
            else
            {
                boostMeter.color = thatPurpleyColor;
            }
        }
        if (boostButtonSelection == 2)
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
        if (boostButtonSelection == 1)
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
        if (boostButtonSelection == 0)
        {
            boostCanvasGroup.alpha = 0;
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

    }

    public void PauseHandler(InputAction.CallbackContext context)
    {
        pauseMenu.OnPause();
    }
    public void UseButtonHandler(InputAction.CallbackContext context)
    {
        //Jump jacks
        if (useButtonSelection == 1)
        {
            carEffects.AnimateJump();

            if (flTouchingGround || frTouchingGround || blTouchingGround || brTouchingGround || slidingFlag)
            {
                carRigidBody.AddForce(transform.up * jumpForce);
                carRigidBody.AddForce(transform.forward * (jumpForce / 10));
            }
        }

        //Wings
        if (useButtonSelection == 2)
        {
            HandleWings(wingsOpen);

            //dummy wings
            {
                //if (useButtonSelection == 3)
                //{
                //    float velocity = Vector3.Dot(carRigidBody.velocity, transform.forward);

                //    if (carRigidBody.velocity.magnitude >= 50f && Vector3.Dot(carRigidBody.velocity, transform.forward) > -.9f && Physics.Raycast(transform.position, Vector3.down, 200f))
                //    {
                //        carRigidBody.useGravity = false;
                //        carRigidBody.AddForce(0, -10000, 0); //false gravity
                //        Vector3 newDirection = carRigidBody.velocity.normalized;

                //        Vector3 nonGlobalUpwardVector = transform.up;
                //        nonGlobalUpwardVector.y = 0;

                //        float carBackwardAngle = transform.forward.y;
                //        if (carBackwardAngle > .2f)
                //        {
                //            carBackwardAngle = .2f;
                //        }
                //        if (carBackwardAngle > 0f) // tilt back
                //        {
                //            carRigidBody.AddForce(transform.up * velocity * flightGravity * carBackwardAngle);
                //        }

                //        //test, generic upwards force dependent from velocity independent from angle
                //        float velocityCapped = velocity;
                //        if (velocityCapped >= 100f)
                //        {
                //            velocityCapped = 100f;
                //        }
                //        carRigidBody.AddForce(transform.up * velocityCapped * flightGravity * .15f);

                //        float carForwardAngle = transform.forward.y;
                //        if (carForwardAngle < -.5f)
                //        {
                //            carForwardAngle = -.5f;
                //        }
                //        if (carForwardAngle < 0f) // tilt forward
                //        {
                //            carRigidBody.AddForce(transform.forward * velocity * flightGravity * -carForwardAngle);
                //        }

                //        float carRollAngle = carRigidBody.transform.eulerAngles.z;

                //        if (carRollAngle > 80f && carRollAngle < 180f)
                //        {
                //            carRollAngle = 80f;
                //        }
                //        if (carRollAngle < 280f && carRollAngle > 180f)
                //        {
                //            carRollAngle = 280f;
                //        }


                //        if (carRollAngle > 15f) // roll side to side
                //        {
                //            carRigidBody.AddForce(nonGlobalUpwardVector * velocity * flightGravity * (carRollAngle * .002f));
                //        }
                //        if (carRollAngle < 345f) // roll side to side
                //        {
                //            carRigidBody.AddForce(nonGlobalUpwardVector * velocity * flightGravity * ((360f - carRollAngle) * .002f));
                //        }

                //    }
                //    else
                //    {
                //        carRigidBody.useGravity = true;
                //    }

                //    //handle wing animations
                //    if (carRigidBody.velocity.magnitude >= 50f)
                //    {
                //        if (carEffects.wingsOpen == false)
                //        {
                //            carEffects.AnimateWingsOpen();
                //        }
                //    }

                //    if (carRigidBody.velocity.magnitude < 50f)
                //    {
                //        if (carEffects.wingsOpen == true)
                //        {
                //            carEffects.AnimateWingsClose();
                //        }

                //    }
                //}
            }
        }
    }
    public void HandleWings(bool areWingsOpen)
    {
        if (areWingsOpen == false)
        {
            wingsOpen = true;

            carEffects.AnimateWingsOpen();
        }

        if (areWingsOpen == true)
        {
            wingsOpen = false;

            carEffects.AnimateWingsClose();

            //carRigidBody.useGravity = true;
        }
    }

    private void HandleSwitching(InputAction.CallbackContext context) //for swapping equipment without needing to pause the game first
    {
        if (controls.Player.Passiveitemswap.ReadValue<float>() > .5 && Time.timeScale > 0.1) //timescale is kinda hacky to use
        {
            PlayerPrefs.SetInt("passiveIndex", (PlayerPrefs.GetInt("passiveIndex") + 1));

            if (PlayerPrefs.GetInt("passiveIndex") == 2) //this is whats gonna need updated
            {
                PlayerPrefs.SetInt("passiveIndex", 0);
            }

            pauseMenu.SetPassive(PlayerPrefs.GetInt("passiveIndex"));
            pauseMenu.PassiveDropDown.value = PlayerPrefs.GetInt("passiveIndex");

        }

        if (controls.Player.Useitemswap.ReadValue<float>() > .5 && Time.timeScale > 0.1)  //idk if I'll fix it tho Its probably fine
        {
            PlayerPrefs.SetInt("useButtonIndex", (PlayerPrefs.GetInt("useButtonIndex") + 1));

            if (PlayerPrefs.GetInt("useButtonIndex") == 3) //this also, thank me later
            {
                PlayerPrefs.SetInt("useButtonIndex", 0);
            }

            //fix wings and gravity when navigating away without disengaging
            if (PlayerPrefs.GetInt("useButtonIndex") != 2)
            {
                HandleWings(true);
            }

            pauseMenu.SetUseButton(PlayerPrefs.GetInt("useButtonIndex"));
            pauseMenu.UseButtonDropDown.value = PlayerPrefs.GetInt("useButtonIndex");

        }

        if (controls.Player.Boostswap.ReadValue<float>() > .5 && Time.timeScale > 0.1)  //lol i did it again
        {
            PlayerPrefs.SetInt("boostButtonIndex", (PlayerPrefs.GetInt("boostButtonIndex") + 1));

            if (PlayerPrefs.GetInt("boostButtonIndex") == 4) //this also, thank me later
            {
                PlayerPrefs.SetInt("boostButtonIndex", 0);
            }

            pauseMenu.SetBoostButton(PlayerPrefs.GetInt("boostButtonIndex"));
            pauseMenu.BoostButtonDropDown.value = PlayerPrefs.GetInt("boostButtonIndex");

        }
    }
}

