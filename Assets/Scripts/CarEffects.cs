using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEffects : MonoBehaviour
{
    [SerializeField] public GameObject carBody;

    [SerializeField] public GameObject flWheel;
    [SerializeField] public GameObject frWheel;
    [SerializeField] public GameObject rlWheel;
    [SerializeField] public GameObject rrWheel;

    [SerializeField] public GameObject flBigWheel;
    [SerializeField] public GameObject frBigWheel;
    [SerializeField] public GameObject rlBigWheel;
    [SerializeField] public GameObject rrBigWheel;
    [Space]
    [Header("Trail Lights")]
    [SerializeField] public TrailRenderer leftTrailBMWM1;
    [SerializeField] public TrailRenderer rightTrailBMWM1;
    [SerializeField] public TrailRenderer leftTrailBMWM3;
    [SerializeField] public TrailRenderer rightTrailBMWM3;
    [SerializeField] public TrailRenderer leftTrailCamaroZ28;
    [SerializeField] public TrailRenderer rightTrailCamaroZ28;
    [SerializeField] public TrailRenderer leftTrailChevyBelAir;
    [SerializeField] public TrailRenderer rightTrailChevyBelAir;
    [SerializeField] public TrailRenderer leftTrailDatsun240Z;
    [SerializeField] public TrailRenderer rightTrailDatsun240Z;
    [SerializeField] public TrailRenderer leftTrailDodgeHellcat;
    [SerializeField] public TrailRenderer rightTrailDodgeHellcat;
    [SerializeField] public TrailRenderer leftTrailElCamino;
    [SerializeField] public TrailRenderer rightTrailElCamino;
    [SerializeField] public TrailRenderer leftTrailFerrariF40;
    [SerializeField] public TrailRenderer rightTrailFerrariF40;
    [SerializeField] public TrailRenderer leftTrailFerrariLaferrari;
    [SerializeField] public TrailRenderer rightTrailFerrariLaferrari;
    [SerializeField] public TrailRenderer leftTrailFumigator;
    [SerializeField] public TrailRenderer rightTrailFumigator;
    [SerializeField] public TrailRenderer leftTrailHondaCivic;
    [SerializeField] public TrailRenderer rightTrailHondaCivic;
    [SerializeField] public TrailRenderer leftTrailHondaS2000;
    [SerializeField] public TrailRenderer rightTrailHondaS2000;
    [SerializeField] public TrailRenderer leftTrailMazdaRX7;
    [SerializeField] public TrailRenderer rightTrailMazdaRX7;
    [SerializeField] public TrailRenderer leftTrailMustangShelby;
    [SerializeField] public TrailRenderer rightTrailMustangShelby;
    [SerializeField] public TrailRenderer leftTrailNissan300ZX;
    [SerializeField] public TrailRenderer rightTrailNissan300ZX;
    [SerializeField] public TrailRenderer leftTrailPontiacGTO;
    [SerializeField] public TrailRenderer rightTrailPontiacGTO;
    [SerializeField] public TrailRenderer leftTrailPorsche918;
    [SerializeField] public TrailRenderer rightTrailPorsche918;
    [SerializeField] public TrailRenderer leftTrailSkylineGTR;
    [SerializeField] public TrailRenderer rightTrailSkylineGTR;
    [SerializeField] public TrailRenderer leftTrailToyotaAE86;
    [SerializeField] public TrailRenderer rightTrailToyotaAE86;
    [SerializeField] public TrailRenderer leftTrailToyotaMR2;
    [SerializeField] public TrailRenderer rightTrailToyotaMR2;
    [SerializeField] public TrailRenderer leftTrailToyotaSupra;
    [SerializeField] public TrailRenderer rightTrailToyotaSupra;
    [SerializeField] public TrailRenderer leftTrailWRXSTI;
    [SerializeField] public TrailRenderer rightTrailWRXSTI;
    [SerializeField] public TrailRenderer leftTrailPontiacBonneville;
    [SerializeField] public TrailRenderer rightTrailPontiacBonneville;
    [SerializeField] public TrailRenderer leftTrailGrandPrix;
    [SerializeField] public TrailRenderer rightTrailGrandPrix;
    [SerializeField] public TrailRenderer leftTrailBuickEstate;
    [SerializeField] public TrailRenderer rightTrailBuickEstate;
    [SerializeField] public TrailRenderer leftTrailCadillacHearse;
    [SerializeField] public TrailRenderer rightTrailCadillacHearse;
    [SerializeField] public TrailRenderer leftTrailDodgeVan;
    [SerializeField] public TrailRenderer rightTrailDodgeVan;
    [SerializeField] public TrailRenderer leftTrailHovercar;
    [SerializeField] public TrailRenderer rightTrailHovercar;
    //[SerializeField] public TrailRenderer leftAkiraTrailCamino;
    //[SerializeField] public TrailRenderer rightAkiraTrailCamino;
    //[SerializeField] public TrailRenderer leftAkiraTrailAE86;
    //[SerializeField] public TrailRenderer rightAkiraTrailAE86;

    [SerializeField] public ParticleSystem thruster;

    //hvoercar particles
    [SerializeField] public ParticleSystem flHover;
    [SerializeField] public ParticleSystem frHover;
    [SerializeField] public ParticleSystem rlHover;
    [SerializeField] public ParticleSystem rrHover;

    [SerializeField] public GameObject caminoTailLightGroup;
    [SerializeField] public Transform leftTailLight;
    [SerializeField] public Transform rightTailLight;
    [SerializeField] public GameObject ae86TailLightGroup;
    [SerializeField] public Transform leftTailLightAE86;
    [SerializeField] public Transform rightTailLightAE86;
    [Space]
    [Header("Taillight groups")]
    [SerializeField] public GameObject bMWM1TLGroup;
    [SerializeField] public GameObject bMWM3TLGroup;
    [SerializeField] public GameObject cameroZ28TLGroup;
    [SerializeField] public GameObject chevyBelAirTLGroup;
    [SerializeField] public GameObject datsun240ZTLGroup;
    [SerializeField] public GameObject dodgeHellcatTLGroup;
    [SerializeField] public GameObject elCaminoTLGroup;
    [SerializeField] public GameObject ferrariF40TLGroup;
    [SerializeField] public GameObject ferrariLaferrariTLGroup;
    [SerializeField] public GameObject fumigatorTLGroup;
    [SerializeField] public GameObject hondaCivicTLGroup;
    [SerializeField] public GameObject hondaS2000TLGroup;
    [SerializeField] public GameObject mazdaRX7TLGroup;
    [SerializeField] public GameObject mustangShelbyTLGroup;
    [SerializeField] public GameObject nissan300ZXTLGroup;
    [SerializeField] public GameObject pontiacGTOTLGroup;
    [SerializeField] public GameObject porsche918TLGroup;
    [SerializeField] public GameObject skylineGTRTLGroup;
    [SerializeField] public GameObject toyotaAE86TLGroup;
    [SerializeField] public GameObject toyotaMR2TLGroup;
    [SerializeField] public GameObject toyotaSupraTLGroup;
    [SerializeField] public GameObject wRXSTITLGroup;
    [SerializeField] public GameObject pontiacBonnevilleTLGroup;
    [SerializeField] public GameObject grandPrixTLGroup;
    [SerializeField] public GameObject buickEstateTLGroup;
    [SerializeField] public GameObject cadillacHearseTLGroup;
    [SerializeField] public GameObject dodgeVanTLGroup;
    [SerializeField] public GameObject hovercarTLGroup;
    [Space]
    [Header("Taillights")]
    [SerializeField] public Transform bMWM1TL;
    [SerializeField] public Transform bMWM3TL;
    [SerializeField] public Transform cameroZ28TL;
    [SerializeField] public Transform chevyBelAirTL;
    [SerializeField] public Transform datsun240ZTL;
    [SerializeField] public Transform dodgeHellcatTL;
    [SerializeField] public Transform elCaminoTL;
    [SerializeField] public Transform ferrariF40TL;
    [SerializeField] public Transform ferrariLaferrariTL;
    [SerializeField] public Transform fumigatorTL;
    [SerializeField] public Transform hondaCivicTL;
    [SerializeField] public Transform hondaS2000TL;
    [SerializeField] public Transform mazdaRX7TL;
    [SerializeField] public Transform mustangShelbyTL;
    [SerializeField] public Transform nissan300ZXTL;
    [SerializeField] public Transform pontiacGTOTL;
    [SerializeField] public Transform porsche918TL;
    [SerializeField] public Transform skylineGTRTL;
    [SerializeField] public Transform toyotaAE86TL;
    [SerializeField] public Transform toyotaMR2TL;
    [SerializeField] public Transform toyotaSupraTL;
    [SerializeField] public Transform wRXSTITL;
    [SerializeField] public Transform pontiacBonnevilleTL;
    [SerializeField] public Transform grandPrixTL;
    [SerializeField] public Transform buickEstateTL;
    [SerializeField] public Transform cadillacHearseTL;
    [SerializeField] public Transform dodgeVanTL;
    [SerializeField] public Transform hovercarTL;
    [Space]

    public Renderer leftTailLightRenderer;
    public Renderer rightTailLightRenderer;

    public Renderer tailLightRenderer;

    [SerializeField] public GameObject airThrusters;
    [SerializeField] public GameObject groundBoosters;
    [SerializeField] public GameObject fireTrails;
    [SerializeField] public GameObject wings;
    [SerializeField] Animator wingsAnimator;

    [SerializeField] public GameObject jumpJacks;
    [SerializeField] Animator jumpAnimator;

    [SerializeField] public GameObject hydraulics;

    [Space]
    [Header("body meshes")]
    [SerializeField] private Mesh elCaminoMesh;
    [SerializeField] private Mesh fumigatorMesh;
    [SerializeField] private Mesh ae86Mesh;
    [SerializeField] private Mesh BMWM1Mesh;
    [SerializeField] private Mesh BMWM3Mesh;
    [SerializeField] private Mesh camaroZ28Mesh;
    [SerializeField] private Mesh chevyBelAirMesh;
    [SerializeField] private Mesh datsun240ZMesh;
    [SerializeField] private Mesh dodgeHellcatMesh;
    [SerializeField] private Mesh ferrariF40Mesh;
    [SerializeField] private Mesh ferrariLaferrariMesh;
    [SerializeField] private Mesh hondaCivicMesh;
    [SerializeField] private Mesh hondaS2000Mesh;
    [SerializeField] private Mesh mazdaRX7Mesh;
    [SerializeField] private Mesh toyotaMR2Mesh;
    [SerializeField] private Mesh mustangShelbyMesh;
    [SerializeField] private Mesh nissan300ZXMesh;
    [SerializeField] private Mesh pontiacGTOMesh;
    [SerializeField] private Mesh porsche918Mesh;
    [SerializeField] private Mesh skylineGTRMesh;
    [SerializeField] private Mesh toyotaSupraMesh;
    [SerializeField] private Mesh wrxSTIMesh;
    [SerializeField] private Mesh pontiacBonnevilleMesh;
    [SerializeField] private Mesh grandPrixMesh;
    [SerializeField] private Mesh buickEstateMesh;
    [SerializeField] private Mesh cadillacHearseMesh;
    [SerializeField] private Mesh dodgeVanMesh;
    [SerializeField] private Mesh hoverCarMesh;
    [Space]
    [Space]
    [Header("body paint")]
    [SerializeField] private Material elCaminoPaint;
    [SerializeField] private Material fumigatorPaint;
    [SerializeField] private Material ae86Paint;
    [SerializeField] private Material BMWM1Paint;
    [SerializeField] private Material BMWM3Paint;
    [SerializeField] private Material camaroZ28Paint;
    [SerializeField] private Material chevyBelAirPaint;
    [SerializeField] private Material datsun240ZPaint;
    [SerializeField] private Material dodgeHellcatPaint;
    [SerializeField] private Material ferrariF40Paint;
    [SerializeField] private Material ferrariLaferrariPaint;
    [SerializeField] private Material hondaCivicPaint;
    [SerializeField] private Material hondaS2000Paint;
    [SerializeField] private Material mazdaRX7Paint;
    [SerializeField] private Material toyotaMR2Paint;
    [SerializeField] private Material mustangShelbyPaint;
    [SerializeField] private Material nissan300ZXPaint;
    [SerializeField] private Material pontiacGTOPaint;
    [SerializeField] private Material porsche918Paint;
    [SerializeField] private Material skylineGTRPaint;
    [SerializeField] private Material toyotaSupraPaint;
    [SerializeField] private Material wrxSTIPaint;
    [SerializeField] private Material pontiacBonnevillePaint;
    [SerializeField] private Material grandPrixPaint;
    [SerializeField] private Material buickEstatePaint;
    [SerializeField] private Material cadillacHearsePaint;
    [SerializeField] private Material dodgeVanPaint;
    [SerializeField] private Material hoverCarPaint;
    [Space]
    [Header("Tire Meshes and Paint")]
    [SerializeField] private Mesh offRoadTireMesh;
    [SerializeField] private Material offRoadTirePaint;
    [SerializeField] private Mesh driftTireMesh;
    [SerializeField] private Material driftTirePaint;
    [SerializeField] private Mesh standardTireMesh;
    [SerializeField] private Material standardTirePaint;

    CarController carController;
    PauseMenu pauseMenu;
    
    private bool tireMarksFLFlag;
    private bool tireMarksFRFlag;
    private bool tireMarksBLFlag;
    private bool tireMarksBRFlag;

    [SerializeField] private bool fireMarksSwitch;
    private bool fireMarksFlag = false;
    [SerializeField] private bool akiraTrailSwitch;
    private bool akiraTrailFlag = false;

    private bool thrusterFlag = false;

    private float sideSlipFL;
    private float sideSlipFR;
    private float sideSlipBL;
    private float sideSlipBR;

    private float frontSlipFL;
    private float frontSlipFR;
    private float frontSlipBL;
    private float frontSlipBR;

    public bool wingsOpen = false;

    //public int bodySelection;

    [SerializeField] float sideSlipThreshold;
    [SerializeField] float frontSlipThreshold;

    [SerializeField] public TrailRenderer frontLeftTireMarks;
    [SerializeField] public TrailRenderer frontRightTireMarks;
    [SerializeField] public TrailRenderer backLeftTireMarks;
    [SerializeField] public TrailRenderer backRightTireMarks;

    [SerializeField] public TrailRenderer backLeftFireMarks;
    [SerializeField] public TrailRenderer backRightFireMarks;

    //regular
    [SerializeField] public TrailRenderer frontLeftRegularTireMarks;
    [SerializeField] public TrailRenderer frontRightRegularTireMarks;
    [SerializeField] public TrailRenderer backLeftRegularTireMarks;
    [SerializeField] public TrailRenderer backRightRegularTireMarks;

    [SerializeField] public TrailRenderer backLeftRegularFireMarks;
    [SerializeField] public TrailRenderer backRightRegularFireMarks;

    //big
    [SerializeField] public TrailRenderer frontLeftBigTireMarks;
    [SerializeField] public TrailRenderer frontRightBigTireMarks;
    [SerializeField] public TrailRenderer backLeftBigTireMarks;
    [SerializeField] public TrailRenderer backRightBigTireMarks;

    [SerializeField] public TrailRenderer backLeftBigFireMarks;
    [SerializeField] public TrailRenderer backRightBigFireMarks;
    


    private void Awake()
    {
        carController = GameObject.Find("Camino").GetComponent<CarController>();
        var thrusterEmission = thruster.emission;
        thrusterEmission.enabled = false;
        
        var tailLightRenderer = elCaminoTL.GetComponent<MeshRenderer>();
        tailLightRenderer.enabled = true;

        var leftTailLightRenderer = leftTailLight.GetComponent<MeshRenderer>();
        var rightTailLightRenderer = rightTailLight.GetComponent<MeshRenderer>();
        leftTailLightRenderer.enabled = false;
        rightTailLightRenderer.enabled = false;

        
    }
    private void Update()
    {
        CheckTransforms();
        CheckDrift();
        CheckBoost();
        CheckLights();
        //Debug.Log("GroundBoosting: " + carController.groundBoosting);
        //Debug.Log("akiraTrailFlag: " + akiraTrailFlag);
        //Debug.Log("leftTrailBMWM1 emitting: " + leftTrailBMWM1.emitting);
        //Debug.Log("Playerprefs UseButtonIndex: " + PlayerPrefs.GetInt("useButtonIndex"));
    }

    private void CheckTransforms()
    {
        switch (carController.useButtonSelection)
        {
            case 0: //nothin
                jumpJacks.SetActive(false);
                hydraulics.SetActive(false);
                wings.SetActive(false);
                break;
            case 1: //jump jacks
                jumpJacks.SetActive(true);
                hydraulics.SetActive(true);
                wings.SetActive(false);
                break;
            case 2: //wings
                jumpJacks.SetActive(false);
                hydraulics.SetActive(false);
                wings.SetActive(true);
                break;
        }

        switch (carController.boostButtonSelection)
        {
            case 0: //nothin
                groundBoosters.SetActive(false);
                airThrusters.SetActive(false);
                fireTrails.SetActive(false);
                break;
            case 1: //ground boost
                groundBoosters.SetActive(true);
                airThrusters.SetActive(false);
                fireTrails.SetActive(false);
                break;
            case 2: //air boost
                groundBoosters.SetActive(false);
                airThrusters.SetActive(true);
                fireTrails.SetActive(false);
                break;
            case 3: //flux capacitor
                groundBoosters.SetActive(false);
                airThrusters.SetActive(false);
                fireTrails.SetActive(true);
                break;
        }

        switch (carController.passiveSelection)
        {
            case 0: //depreciated? methinks vvv
                break;
        }

        if (carController.passiveSelection == 1)
        {
            frontLeftTireMarks = frontLeftBigTireMarks;
            frontRightTireMarks = frontRightBigTireMarks;
            backLeftTireMarks = backLeftBigTireMarks;
            backRightTireMarks = backRightBigTireMarks;
            backLeftFireMarks = backLeftBigFireMarks;
            backRightFireMarks = backRightBigFireMarks;
        }
        else
        {
            frontLeftTireMarks = frontLeftRegularTireMarks;
            frontRightTireMarks = frontRightRegularTireMarks;
            backLeftTireMarks = backLeftRegularTireMarks;
            backRightTireMarks = backRightRegularTireMarks;
            backLeftFireMarks = backLeftRegularFireMarks;
            backRightFireMarks = backRightRegularFireMarks;
        }

        //hovercar specials
        if (PlayerPrefs.GetInt("bodyIndex") == 27)
        {
            flWheel.GetComponent<MeshRenderer>().enabled = false;
            frWheel.GetComponent<MeshRenderer>().enabled = false;
            rlWheel.GetComponent<MeshRenderer>().enabled = false;
            rrWheel.GetComponent<MeshRenderer>().enabled = false;

            flBigWheel.GetComponent<MeshRenderer>().enabled = false;
            frBigWheel.GetComponent<MeshRenderer>().enabled = false;
            rlBigWheel.GetComponent<MeshRenderer>().enabled = false;
            rrBigWheel.GetComponent<MeshRenderer>().enabled = false;

            var flHoverEmission = flHover.emission;
            var frHoverEmission = frHover.emission;
            var rlHoverEmission = rlHover.emission;
            var rrHoverEmission = rrHover.emission;

            flHoverEmission.enabled = true;
            frHoverEmission.enabled = true;
            rlHoverEmission.enabled = true;
            rrHoverEmission.enabled = true;
        }
        else
        {
            flWheel.GetComponent<MeshRenderer>().enabled = true;
            frWheel.GetComponent<MeshRenderer>().enabled = true;
            rlWheel.GetComponent<MeshRenderer>().enabled = true;
            rrWheel.GetComponent<MeshRenderer>().enabled = true;

            flBigWheel.GetComponent<MeshRenderer>().enabled = true;
            frBigWheel.GetComponent<MeshRenderer>().enabled = true;
            rlBigWheel.GetComponent<MeshRenderer>().enabled = true;
            rrBigWheel.GetComponent<MeshRenderer>().enabled = true;

            var flHoverEmission = flHover.emission;
            var frHoverEmission = frHover.emission;
            var rlHoverEmission = rlHover.emission;
            var rrHoverEmission = rrHover.emission;

            flHoverEmission.enabled = false;
            frHoverEmission.enabled = false;
            rlHoverEmission.enabled = false;
            rrHoverEmission.enabled = false;
        }
    }

    private void CheckDrift()    {
        carController.frontLeftWheelCollider.GetGroundHit(out WheelHit wheelDataFL);
        sideSlipFL = wheelDataFL.sidewaysSlip;
        frontSlipFL = wheelDataFL.forwardSlip;
        carController.frontRightWheelCollider.GetGroundHit(out WheelHit wheelDataFR);
        sideSlipFR = wheelDataFR.sidewaysSlip;
        frontSlipFR = wheelDataFR.forwardSlip;
        carController.backLeftWheelCollider.GetGroundHit(out WheelHit wheelDataBL);
        sideSlipBL = wheelDataBL.sidewaysSlip;
        frontSlipBL = wheelDataBL.forwardSlip;
        carController.backRightWheelCollider.GetGroundHit(out WheelHit wheelDataBR);
        sideSlipBR = wheelDataBR.sidewaysSlip;
        frontSlipBR = wheelDataBR.forwardSlip;

        if (Mathf.Abs(sideSlipFL) > sideSlipThreshold || Mathf.Abs(frontSlipFL) > frontSlipThreshold)
        { startEmitterFL(); } else { stopEmitterFL(); }
        if (Mathf.Abs(sideSlipFR) > sideSlipThreshold || Mathf.Abs(frontSlipFR) > frontSlipThreshold)
        { startEmitterFR(); } else { stopEmitterFR(); }
        if (Mathf.Abs(sideSlipBL) > sideSlipThreshold || Mathf.Abs(frontSlipBL) > frontSlipThreshold)
        { startEmitterBL(); } else { stopEmitterBL(); }
        if (Mathf.Abs(sideSlipBR) > sideSlipThreshold || Mathf.Abs(frontSlipBR) > frontSlipThreshold)
        { startEmitterBR(); } else { stopEmitterBR(); }


        //if (carController.isBraking)
        //{
        //    if (carController.frontLeftWheelCollider.isGrounded)
        //    { startEmitterFL(); } else { stopEmitterFL(); }
        //    if (carController.frontRightWheelCollider.isGrounded)
        //    { startEmitterFR(); } else { stopEmitterFR(); }
        //    if (carController.backLeftWheelCollider.isGrounded)
        //    { startEmitterBL(); } else { stopEmitterBL(); }
        //    if (carController.backRightWheelCollider.isGrounded)
        //    { startEmitterBR(); } else { stopEmitterBR(); }
        //}
        //else
        //{
        //    stopEmitterFL();
        //    stopEmitterFR();
        //    stopEmitterBL();
        //    stopEmitterBR();
        //}
    }

    private void startEmitterFL()
    {
        if (tireMarksFLFlag) return;
        frontLeftTireMarks.emitting = true;
        tireMarksFLFlag = true;
    }
    private void startEmitterFR()
    {
        if (tireMarksFRFlag) return;
        frontRightTireMarks.emitting = true;
        tireMarksFRFlag = true;
    }
    private void startEmitterBL()
    {
        if (tireMarksBLFlag) return;
        backLeftTireMarks.emitting = true;
        tireMarksBLFlag = true;
    }
    private void startEmitterBR()
    {
        if (tireMarksBRFlag) return;
        backRightTireMarks.emitting = true;
        tireMarksBRFlag = true;
    }
    private void stopEmitterFL()
    {
        if (!tireMarksFLFlag) return;
        frontLeftTireMarks.emitting = false;
        tireMarksFLFlag = false;
    }
    private void stopEmitterFR()
    {
        if (!tireMarksFRFlag) return;
        frontRightTireMarks.emitting = false;
        tireMarksFRFlag = false;
    }
    private void stopEmitterBL()
    {
        if (!tireMarksBLFlag) return;
        backLeftTireMarks.emitting = false;
        tireMarksBLFlag = false;
    }
    private void stopEmitterBR()
    {
        if (!tireMarksBRFlag) return;
        backRightTireMarks.emitting = false;
        tireMarksBRFlag = false;
    }

    private void CheckBoost()
    {
        if (carController.fluxing && fireMarksSwitch)
        {
            startFireTrail();
        }
        else
        {
            stopFireTrail();
        }

        if (carController.groundBoosting && akiraTrailSwitch)
        {
            startAkiraTrail();
        }
        else if (!carController.groundBoosting)
        {
            stopAkiraTrail();
        }
        else
        {
            stopAkiraTrail();
        }

        if (carController.airBoosting)
        {
            startThrusterTrail();
        }
        else
        {
            stopThrusterTrail();
        }
    }

    private void startFireTrail()
    {
        if (fireMarksFlag) return;
        backLeftFireMarks.emitting = true;
        backRightFireMarks.emitting = true;
        fireMarksFlag = true;
    }
    private void stopFireTrail()
    {
        if (!fireMarksFlag) return;
        backLeftFireMarks.emitting = false;
        backRightFireMarks.emitting = false;
        fireMarksFlag = false;
    }
    private void startAkiraTrail()
    {
        if (PlayerPrefs.GetInt("boostButtonIndex") == 1)
        {
            switch (PlayerPrefs.GetInt("bodyIndex"))
            {
                case 0:
                    if (akiraTrailFlag) return;
                    leftTrailBMWM1.emitting = true;
                    rightTrailBMWM1.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 1:
                    if (akiraTrailFlag) return;
                    leftTrailBMWM3.emitting = true;
                    rightTrailBMWM3.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 2:
                    if (akiraTrailFlag) return;
                    leftTrailCamaroZ28.emitting = true;
                    rightTrailCamaroZ28.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 3:
                    if (akiraTrailFlag) return;
                    leftTrailChevyBelAir.emitting = true;
                    rightTrailChevyBelAir.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 4:
                    if (akiraTrailFlag) return;
                    leftTrailDatsun240Z.emitting = true;
                    rightTrailDatsun240Z.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 5:
                    if (akiraTrailFlag) return;
                    leftTrailDodgeHellcat.emitting = true;
                    rightTrailDodgeHellcat.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 6:
                    if (akiraTrailFlag) return;
                    leftTrailElCamino.emitting = true;
                    rightTrailElCamino.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 7:
                    if (akiraTrailFlag) return;
                    leftTrailFerrariF40.emitting = true;
                    rightTrailFerrariF40.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 8:
                    if (akiraTrailFlag) return;
                    leftTrailFerrariLaferrari.emitting = true;
                    rightTrailFerrariLaferrari.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 9:
                    if (akiraTrailFlag) return;
                    leftTrailFumigator.emitting = true;
                    rightTrailFumigator.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 10:
                    if (akiraTrailFlag) return;
                    leftTrailHondaCivic.emitting = true;
                    rightTrailHondaCivic.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 11:
                    if (akiraTrailFlag) return;
                    leftTrailHondaS2000.emitting = true;
                    rightTrailHondaS2000.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 12:
                    if (akiraTrailFlag) return;
                    leftTrailMazdaRX7.emitting = true;
                    rightTrailMazdaRX7.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 13:
                    if (akiraTrailFlag) return;
                    leftTrailMustangShelby.emitting = true;
                    rightTrailMustangShelby.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 14:
                    if (akiraTrailFlag) return;
                    leftTrailNissan300ZX.emitting = true;
                    rightTrailNissan300ZX.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 15:
                    if (akiraTrailFlag) return;
                    leftTrailPontiacGTO.emitting = true;
                    rightTrailPontiacGTO.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 16:
                    if (akiraTrailFlag) return;
                    leftTrailPorsche918.emitting = true;
                    rightTrailPorsche918.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 17:
                    if (akiraTrailFlag) return;
                    leftTrailSkylineGTR.emitting = true;
                    rightTrailSkylineGTR.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 18:
                    if (akiraTrailFlag) return;
                    leftTrailToyotaAE86.emitting = true;
                    rightTrailToyotaAE86.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 19:
                    if (akiraTrailFlag) return;
                    leftTrailToyotaMR2.emitting = true;
                    rightTrailToyotaMR2.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 20:
                    if (akiraTrailFlag) return;
                    leftTrailToyotaSupra.emitting = true;
                    rightTrailToyotaSupra.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 21:
                    if (akiraTrailFlag) return;
                    leftTrailWRXSTI.emitting = true;
                    rightTrailWRXSTI.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 22:
                    if (akiraTrailFlag) return;
                    leftTrailPontiacBonneville.emitting = true;
                    rightTrailPontiacBonneville.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 23:
                    if (akiraTrailFlag) return;
                    leftTrailGrandPrix.emitting = true;
                    rightTrailGrandPrix.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 24:
                    if (akiraTrailFlag) return;
                    leftTrailBuickEstate.emitting = true;
                    rightTrailBuickEstate.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 25:
                    if (akiraTrailFlag) return;
                    leftTrailCadillacHearse.emitting = true;
                    rightTrailCadillacHearse.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 26:
                    if (akiraTrailFlag) return;
                    leftTrailDodgeVan.emitting = true;
                    rightTrailDodgeVan.emitting = true;
                    akiraTrailFlag = true;
                    break;
                case 27:
                    if (akiraTrailFlag) return;
                    leftTrailHovercar.emitting = true;
                    rightTrailHovercar.emitting = true;
                    akiraTrailFlag = true;
                    break;
                default:
                    akiraTrailFlag = false;
                    break;
            }
        }
        else
        {
            leftTrailBMWM1.emitting = false;
            rightTrailBMWM1.emitting = false;
            leftTrailBMWM3.emitting = false;
            rightTrailBMWM3.emitting = false;
            leftTrailCamaroZ28.emitting = false;
            rightTrailCamaroZ28.emitting = false;
            leftTrailChevyBelAir.emitting = false;
            rightTrailChevyBelAir.emitting = false;
            leftTrailDatsun240Z.emitting = false;
            rightTrailDatsun240Z.emitting = false;
            leftTrailDodgeHellcat.emitting = false;
            rightTrailDodgeHellcat.emitting = false;
            leftTrailElCamino.emitting = false;
            rightTrailElCamino.emitting = false;
            leftTrailFerrariF40.emitting = false;
            rightTrailFerrariF40.emitting = false;
            leftTrailFerrariLaferrari.emitting = false;
            rightTrailFerrariLaferrari.emitting = false;
            leftTrailFumigator.emitting = false;
            rightTrailFumigator.emitting = false;
            leftTrailHondaCivic.emitting = false;
            rightTrailHondaCivic.emitting = false;
            leftTrailHondaS2000.emitting = false;
            rightTrailHondaS2000.emitting = false;
            leftTrailMazdaRX7.emitting = false;
            rightTrailMazdaRX7.emitting = false;
            leftTrailMustangShelby.emitting = false;
            rightTrailMustangShelby.emitting = false;
            leftTrailNissan300ZX.emitting = false;
            rightTrailNissan300ZX.emitting = false;
            leftTrailPontiacGTO.emitting = false;
            rightTrailPontiacGTO.emitting = false;
            leftTrailPorsche918.emitting = false;
            rightTrailPorsche918.emitting = false;
            leftTrailSkylineGTR.emitting = false;
            rightTrailSkylineGTR.emitting = false;
            leftTrailToyotaAE86.emitting = false;
            rightTrailToyotaAE86.emitting = false;
            leftTrailToyotaMR2.emitting = false;
            rightTrailToyotaMR2.emitting = false;
            leftTrailToyotaSupra.emitting = false;
            rightTrailToyotaSupra.emitting = false;
            leftTrailWRXSTI.emitting = false;
            rightTrailWRXSTI.emitting = false;
            leftTrailPontiacBonneville.emitting = false;
            rightTrailPontiacBonneville.emitting = false;
            leftTrailGrandPrix.emitting = false;
            rightTrailGrandPrix.emitting = false;
            leftTrailBuickEstate.emitting = false;
            rightTrailBuickEstate.emitting = false;
            leftTrailCadillacHearse.emitting = false;
            rightTrailCadillacHearse.emitting = false;
            leftTrailDodgeVan.emitting = false;
            rightTrailDodgeVan.emitting = false;
            leftTrailHovercar.emitting = false;
            rightTrailHovercar.emitting = false;
        }
        {
            //switch (PlayerPrefs.GetInt("bodyIndex"))
            //{
            //    case 0:
            //        if (akiraTrailFlag) return;
            //        leftTrailBMWM1.emitting = true;
            //        rightTrailBMWM1.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 1:
            //        if (akiraTrailFlag) return;
            //        leftTrailBMWM3.emitting = true;
            //        rightTrailBMWM3.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 2:
            //        if (akiraTrailFlag) return;
            //        leftTrailCamaroZ28.emitting = true;
            //        rightTrailCamaroZ28.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 3:
            //        if (akiraTrailFlag) return;
            //        leftTrailChevyBelAir.emitting = true;
            //        rightTrailChevyBelAir.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 4:
            //        if (akiraTrailFlag) return;
            //        leftTrailDatsun240Z.emitting = true;
            //        rightTrailDatsun240Z.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 5:
            //        if (akiraTrailFlag) return;
            //        leftTrailDodgeHellcat.emitting = true;
            //        rightTrailDodgeHellcat.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 6:
            //        if (akiraTrailFlag) return;
            //        leftTrailElCamino.emitting = true;
            //        rightTrailElCamino.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 7:
            //        if (akiraTrailFlag) return;
            //        leftTrailFerrariF40.emitting = true;
            //        rightTrailFerrariF40.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 8:
            //        if (akiraTrailFlag) return;
            //        leftTrailFerrariLaferrari.emitting = true;
            //        rightTrailFerrariLaferrari.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 9:
            //        if (akiraTrailFlag) return;
            //        leftTrailFumigator.emitting = true;
            //        rightTrailFumigator.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 10:
            //        if (akiraTrailFlag) return;
            //        leftTrailHondaCivic.emitting = true;
            //        rightTrailHondaCivic.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 11:
            //        if (akiraTrailFlag) return;
            //        leftTrailHondaS2000.emitting = true;
            //        rightTrailHondaS2000.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 12:
            //        if (akiraTrailFlag) return;
            //        leftTrailMazdaRX7.emitting = true;
            //        rightTrailMazdaRX7.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 13:
            //        if (akiraTrailFlag) return;
            //        leftTrailMustangShelby.emitting = true;
            //        rightTrailMustangShelby.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 14:
            //        if (akiraTrailFlag) return;
            //        leftTrailNissan300ZX.emitting = true;
            //        rightTrailNissan300ZX.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 15:
            //        if (akiraTrailFlag) return;
            //        leftTrailPontiacGTO.emitting = true;
            //        rightTrailPontiacGTO.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 16:
            //        if (akiraTrailFlag) return;
            //        leftTrailPorsche918.emitting = true;
            //        rightTrailPorsche918.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 17:
            //        if (akiraTrailFlag) return;
            //        leftTrailSkylineGTR.emitting = true;
            //        rightTrailSkylineGTR.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 18:
            //        if (akiraTrailFlag) return;
            //        leftTrailToyotaAE86.emitting = true;
            //        rightTrailToyotaAE86.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 19:
            //        if (akiraTrailFlag) return;
            //        leftTrailToyotaMR2.emitting = true;
            //        rightTrailToyotaMR2.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 20:
            //        if (akiraTrailFlag) return;
            //        leftTrailToyotaSupra.emitting = true;
            //        rightTrailToyotaSupra.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    case 21:
            //        if (akiraTrailFlag) return;
            //        leftTrailWRXSTI.emitting = true;
            //        rightTrailWRXSTI.emitting = true;
            //        akiraTrailFlag = true;
            //        break;
            //    default:
            //        akiraTrailFlag = false;
            //        break;
            //}
        }


        //if (akiraTrailFlag) return;
        //leftAkiraTrail.emitting = true;
        //rightAkiraTrail.emitting = true;
        //akiraTrailFlag = true;
    }
    private void stopAkiraTrail()
    {
        switch (PlayerPrefs.GetInt("bodyIndex"))
        {
            case 0:
                
                leftTrailBMWM1.emitting = false;
                rightTrailBMWM1.emitting = false;
                akiraTrailFlag = false;
                break;
            case 1:
                
                leftTrailBMWM3.emitting = false;
                rightTrailBMWM3.emitting = false;
                akiraTrailFlag = false;
                break;
            case 2:
                
                leftTrailCamaroZ28.emitting = false;
                rightTrailCamaroZ28.emitting = false;
                akiraTrailFlag = false;
                break;
            case 3:
                
                leftTrailChevyBelAir.emitting = false;
                rightTrailChevyBelAir.emitting = false;
                akiraTrailFlag = false;
                break;
            case 4:
                
                leftTrailDatsun240Z.emitting = false;
                rightTrailDatsun240Z.emitting = false;
                akiraTrailFlag = false;
                break;
            case 5:
                
                leftTrailDodgeHellcat.emitting = false;
                rightTrailDodgeHellcat.emitting = false;
                akiraTrailFlag = false;
                break;
            case 6:
                
                leftTrailElCamino.emitting = false;
                rightTrailElCamino.emitting = false;
                akiraTrailFlag = false;
                break;
            case 7:
                
                leftTrailFerrariF40.emitting = false;
                rightTrailFerrariF40.emitting = false;
                akiraTrailFlag = false;
                break;
            case 8:
                
                leftTrailFerrariLaferrari.emitting = false;
                rightTrailFerrariLaferrari.emitting = false;
                akiraTrailFlag = false;
                break;
            case 9:
                
                leftTrailFumigator.emitting = false;
                rightTrailFumigator.emitting = false;
                akiraTrailFlag = false;
                break;
            case 10:
                
                leftTrailHondaCivic.emitting = false;
                rightTrailHondaCivic.emitting = false;
                akiraTrailFlag = false;
                break;
            case 11:
                
                leftTrailHondaS2000.emitting = false;
                rightTrailHondaS2000.emitting = false;
                akiraTrailFlag = false;
                break;
            case 12:
                
                leftTrailMazdaRX7.emitting = false;
                rightTrailMazdaRX7.emitting = false;
                akiraTrailFlag = false;
                break;
            case 13:
                
                leftTrailMustangShelby.emitting = false;
                rightTrailMustangShelby.emitting = false;
                akiraTrailFlag = false;
                break;
            case 14:
                
                leftTrailNissan300ZX.emitting = false;
                rightTrailNissan300ZX.emitting = false;
                akiraTrailFlag = false;
                break;
            case 15:
                
                leftTrailPontiacGTO.emitting = false;
                rightTrailPontiacGTO.emitting = false;
                akiraTrailFlag = false;
                break;
            case 16:
                
                leftTrailPorsche918.emitting = false;
                rightTrailPorsche918.emitting = false;
                akiraTrailFlag = false;
                break;
            case 17:
                
                leftTrailSkylineGTR.emitting = false;
                rightTrailSkylineGTR.emitting = false;
                akiraTrailFlag = false;
                break;
            case 18:
                
                leftTrailToyotaAE86.emitting = false;
                rightTrailToyotaAE86.emitting = false;
                akiraTrailFlag = false;
                break;
            case 19:
                
                leftTrailToyotaMR2.emitting = false;
                rightTrailToyotaMR2.emitting = false;
                akiraTrailFlag = false;
                break;
            case 20:
                
                leftTrailToyotaSupra.emitting = false;
                rightTrailToyotaSupra.emitting = false;
                akiraTrailFlag = false;
                break;
            case 21:
                
                leftTrailWRXSTI.emitting = false;
                rightTrailWRXSTI.emitting = false;
                akiraTrailFlag = false;
                break;
            case 22:

                leftTrailPontiacBonneville.emitting = false;
                rightTrailPontiacBonneville.emitting = false;
                akiraTrailFlag = false;
                break;
            case 23:

                leftTrailGrandPrix.emitting = false;
                rightTrailGrandPrix.emitting = false;
                akiraTrailFlag = false;
                break;
            case 24:

                leftTrailBuickEstate.emitting = false;
                rightTrailBuickEstate.emitting = false;
                akiraTrailFlag = false;
                break;
            case 25:

                leftTrailCadillacHearse.emitting = false;
                rightTrailCadillacHearse.emitting = false;
                akiraTrailFlag = false;
                break;
            case 26:

                leftTrailDodgeVan.emitting = false;
                rightTrailDodgeVan.emitting = false;
                akiraTrailFlag = false;
                break;
            case 27:

                leftTrailHovercar.emitting = false;
                rightTrailHovercar.emitting = false;
                akiraTrailFlag = false;
                break;
            default:
                akiraTrailFlag = false;
                break;
        }

        //switch (PlayerPrefs.GetInt("bodyIndex"))
        //{
        //    case 0:
        //        if (!akiraTrailFlag) return;
        //        leftAkiraTrailCamino.emitting = false;
        //        rightAkiraTrailCamino.emitting = false;
        //        akiraTrailFlag = false;
        //        break;
        //    case 1:
        //        if (!akiraTrailFlag) return;
        //        leftAkiraTrailCamino.emitting = false;
        //        rightAkiraTrailCamino.emitting = false;
        //        akiraTrailFlag = false;
        //        break;
        //    case 2:
        //        if (!akiraTrailFlag) return;
        //        leftAkiraTrailAE86.emitting = false;
        //        rightAkiraTrailAE86.emitting = false;
        //        akiraTrailFlag = false;
        //        break;
        //    default:
        //        akiraTrailFlag = false;
        //        break;
        //}


        //if (!akiraTrailFlag) return;
        //leftAkiraTrail.emitting = false;
        //rightAkiraTrail.emitting = false;
        //akiraTrailFlag = false;
    }
    private void startThrusterTrail()
    {
        if (thrusterFlag) return;
        var thrusterEmission = thruster.emission;
        thrusterEmission.enabled = true;
        thrusterFlag = true;
    }
    private void stopThrusterTrail()
    {
        if (!thrusterFlag) return;
        var thrusterEmission = thruster.emission;
        thrusterEmission.enabled = false;
        thrusterFlag = false;
    }

    private void CheckLights()
    {
        switch (PlayerPrefs.GetInt("bodyIndex"))
        {
            case 0:
                tailLightRenderer = bMWM1TL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(true);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 1:
                tailLightRenderer = bMWM3TL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(true);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 2:
                tailLightRenderer = cameroZ28TL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(true);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 3:
                tailLightRenderer = chevyBelAirTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(true);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 4:
                tailLightRenderer = datsun240ZTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(true);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 5:
                tailLightRenderer = dodgeHellcatTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(true);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 6:
                tailLightRenderer = elCaminoTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(true);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 7:
                tailLightRenderer = ferrariF40TL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(true);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 8:
                tailLightRenderer = ferrariLaferrariTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(true);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 9:
                tailLightRenderer = fumigatorTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(true);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 10:
                tailLightRenderer = hondaCivicTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(true);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 11:
                tailLightRenderer = hondaS2000TL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(true);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 12:
                tailLightRenderer = mazdaRX7TL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(true);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 13:
                tailLightRenderer = mustangShelbyTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(true);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 14:
                tailLightRenderer = nissan300ZXTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(true);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 15:
                tailLightRenderer = pontiacGTOTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(true);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 16:
                tailLightRenderer = porsche918TL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(true);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 17:
                tailLightRenderer = skylineGTRTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(true);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 18:
                tailLightRenderer = toyotaAE86TL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(true);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 19:
                tailLightRenderer = toyotaMR2TL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(true);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 20:
                tailLightRenderer = toyotaSupraTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(true);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 21:
                tailLightRenderer = wRXSTITL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(true);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 22:
                tailLightRenderer = pontiacBonnevilleTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(true);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 23:
                tailLightRenderer = grandPrixTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(true);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 24:
                tailLightRenderer = buickEstateTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(true);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 25:
                tailLightRenderer = cadillacHearseTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(true);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(false);
                break;
            case 26:
                tailLightRenderer = dodgeVanTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(true);
                hovercarTLGroup.SetActive(false);
                break;
            case 27:
                tailLightRenderer = hovercarTL.GetComponent<MeshRenderer>();
                bMWM1TLGroup.SetActive(false);
                bMWM3TLGroup.SetActive(false);
                cameroZ28TLGroup.SetActive(false);
                chevyBelAirTLGroup.SetActive(false);
                datsun240ZTLGroup.SetActive(false);
                dodgeHellcatTLGroup.SetActive(false);
                elCaminoTLGroup.SetActive(false);
                ferrariF40TLGroup.SetActive(false);
                ferrariLaferrariTLGroup.SetActive(false);
                fumigatorTLGroup.SetActive(false);
                hondaCivicTLGroup.SetActive(false);
                hondaS2000TLGroup.SetActive(false);
                mazdaRX7TLGroup.SetActive(false);
                mustangShelbyTLGroup.SetActive(false);
                nissan300ZXTLGroup.SetActive(false);
                pontiacGTOTLGroup.SetActive(false);
                porsche918TLGroup.SetActive(false);
                skylineGTRTLGroup.SetActive(false);
                toyotaAE86TLGroup.SetActive(false);
                toyotaMR2TLGroup.SetActive(false);
                toyotaSupraTLGroup.SetActive(false);
                wRXSTITLGroup.SetActive(false);
                pontiacBonnevilleTLGroup.SetActive(false);
                grandPrixTLGroup.SetActive(false);
                buickEstateTLGroup.SetActive(false);
                cadillacHearseTLGroup.SetActive(false);
                dodgeVanTLGroup.SetActive(false);
                hovercarTLGroup.SetActive(true);
                break;
        }

        //switch (bodySelection)
        //{
        //    case 0:
        //        leftTailLightRenderer = leftTailLight.GetComponent<MeshRenderer>();
        //        rightTailLightRenderer = rightTailLight.GetComponent<MeshRenderer>();
        //        caminoTailLightGroup.SetActive(true);
        //        ae86TailLightGroup.SetActive(false);
        //        leftAkiraTrailCamino.emitting = false;
        //        rightAkiraTrailCamino.emitting = false;
        //        break;
        //    case 1:
        //        leftTailLightRenderer = leftTailLight.GetComponent<MeshRenderer>();
        //        rightTailLightRenderer = rightTailLight.GetComponent<MeshRenderer>();
        //        caminoTailLightGroup.SetActive(true);
        //        ae86TailLightGroup.SetActive(false);
        //        leftAkiraTrailCamino.emitting = false;
        //        rightAkiraTrailCamino.emitting = false;
        //        break;
        //    case 2:
        //        leftTailLightRenderer = leftTailLightAE86.GetComponent<MeshRenderer>();
        //        rightTailLightRenderer = rightTailLightAE86.GetComponent<MeshRenderer>();
        //        caminoTailLightGroup.SetActive(false);
        //        ae86TailLightGroup.SetActive(true);
        //        leftAkiraTrailAE86.emitting = false;
        //        rightAkiraTrailAE86.emitting = false;
        //        break;
        //}

        if (carController.isBraking || carController.isReversing || akiraTrailFlag)
        {
            tailLightRenderer.enabled = true;
            //leftTailLightRenderer.enabled = true;
            //rightTailLightRenderer.enabled = true;
        }
        else
        {
            tailLightRenderer.enabled = false;
            //leftTailLightRenderer.enabled = false;
            //rightTailLightRenderer.enabled = false;
        }
    }

    public void AnimateJump()
    {
        if (jumpAnimator != null)
        {
            jumpAnimator.SetTrigger("Jump");
        }
    }
    public void AnimateWingsOpen()
    {
        if (wingsAnimator != null)
        {
            wingsAnimator.SetTrigger("Open");
            wingsOpen = true;
        }
    }
    public void AnimateWingsClose()
    {
        if (wingsAnimator != null)
        {
            wingsAnimator.SetTrigger("Close");
            wingsOpen = false;
        }
    }

    /*
    public void SetBodyElCamino()
    {
        carBody.GetComponent<MeshFilter>().mesh = elCaminoMesh;
        carBody.GetComponent<Renderer>().material = elCaminoPaint;

        leftAkiraTrailCamino.emitting = false;
        rightAkiraTrailCamino.emitting = false;
    }
    public void SetBodyFumigator()
    {
        carBody.GetComponent<MeshFilter>().mesh = fumigatorMesh;
        carBody.GetComponent<Renderer>().material = fumigatorPaint;

        leftAkiraTrailCamino.emitting = false;
        rightAkiraTrailCamino.emitting = false;
    }
    public void SetBodyAE86()
    {
        carBody.GetComponent<MeshFilter>().mesh = ae86Mesh;
        carBody.GetComponent<Renderer>().material = ae86Paint;

        leftAkiraTrailAE86.emitting = false;
        rightAkiraTrailAE86.emitting = false;
    }
    public void SetBodyBMWM1()
    {
        carBody.GetComponent<MeshFilter>().mesh = BMWM1Mesh;
        carBody.GetComponent<Renderer>().material = BMWM1Paint;
    }
    public void SetBodyBMWM3()
    {
        carBody.GetComponent<MeshFilter>().mesh = BMWM3Mesh;
        carBody.GetComponent<Renderer>().material = BMWM3Paint;
    }
    public void SetBodyCamaroZ28()
    {
        carBody.GetComponent<MeshFilter>().mesh = camaroZ28Mesh;
        carBody.GetComponent<Renderer>().material = camaroZ28Paint;
    }
    public void SetBodyChevyBelAir()
    {
        carBody.GetComponent<MeshFilter>().mesh = chevyBelAirMesh;
        carBody.GetComponent<Renderer>().material = chevyBelAirPaint;
    }
    public void SetBodyDatsun240Z()
    {
        carBody.GetComponent<MeshFilter>().mesh = datsun240ZMesh;
        carBody.GetComponent<Renderer>().material = datsun240ZPaint;
    }
    public void SetBodyDodgeHellcat()
    {
        carBody.GetComponent<MeshFilter>().mesh = dodgeHellcatMesh;
        carBody.GetComponent<Renderer>().material = dodgeHellcatPaint;
    }
    public void SetBodyFerrariF40()
    {
        carBody.GetComponent<MeshFilter>().mesh = ferrariF40Mesh;
        carBody.GetComponent<Renderer>().material = ferrariF40Paint;
    }
    public void SetBodyFerrariLaferrari()
    {
        carBody.GetComponent<MeshFilter>().mesh = ferrariLaferrariMesh;
        carBody.GetComponent<Renderer>().material = ferrariLaferrariPaint;
    }
    public void SetBodyHondaCivic()
    {
        carBody.GetComponent<MeshFilter>().mesh = hondaCivicMesh;
        carBody.GetComponent<Renderer>().material = hondaCivicPaint;
    }
    public void SetBodyHondaS2000()
    {
        carBody.GetComponent<MeshFilter>().mesh = hondaS2000Mesh;
        carBody.GetComponent<Renderer>().material = hondaS2000Paint;
    }
    public void SetBodyMazdaRX7()
    {
        carBody.GetComponent<MeshFilter>().mesh = mazdaRX7Mesh;
        carBody.GetComponent<Renderer>().material = mazdaRX7Paint;
    }
    public void SetBodyToyotaMR2()
    {
        carBody.GetComponent<MeshFilter>().mesh = toyotaMR2Mesh;
        carBody.GetComponent<Renderer>().material = toyotaMR2Paint;
    }
    public void SetBodyMustangShelby()
    {
        carBody.GetComponent<MeshFilter>().mesh = mustangShelbyMesh;
        carBody.GetComponent<Renderer>().material = mustangShelbyPaint;
    }
    public void SetBodyNissan300ZX()
    {
        carBody.GetComponent<MeshFilter>().mesh = nissan300ZXMesh;
        carBody.GetComponent<Renderer>().material = nissan300ZXPaint;
    }
    public void SetBodyPontiacGTO()
    {
        carBody.GetComponent<MeshFilter>().mesh = pontiacGTOMesh;
        carBody.GetComponent<Renderer>().material = pontiacGTOPaint;
    }
    public void SetBodyPorsche918()
    {
        carBody.GetComponent<MeshFilter>().mesh = porsche918Mesh;
        carBody.GetComponent<Renderer>().material = porsche918Paint;
    }
    public void SetBodySkylineGTR()
    {
        carBody.GetComponent<MeshFilter>().mesh = skylineGTRMesh;
        carBody.GetComponent<Renderer>().material = skylineGTRPaint;
    }
    public void SetBodyToyotaSupra()
    {
        carBody.GetComponent<MeshFilter>().mesh = toyotaSupraMesh;
        carBody.GetComponent<Renderer>().material = toyotaSupraPaint;
    }
    public void SetBodyWRXSTI()
    {
        carBody.GetComponent<MeshFilter>().mesh = wrxSTIMesh;
        carBody.GetComponent<Renderer>().material = wrxSTIPaint;
    }
    */

    public void SetOffRoadTire()
    {
        flWheel.GetComponent<MeshFilter>().mesh = offRoadTireMesh;
        flWheel.GetComponent<Renderer>().material = offRoadTirePaint;
        frWheel.GetComponent<MeshFilter>().mesh = offRoadTireMesh;
        frWheel.GetComponent<Renderer>().material = offRoadTirePaint;
        rlWheel.GetComponent<MeshFilter>().mesh = offRoadTireMesh;
        rlWheel.GetComponent<Renderer>().material = offRoadTirePaint;
        rrWheel.GetComponent<MeshFilter>().mesh = offRoadTireMesh;
        rrWheel.GetComponent<Renderer>().material = offRoadTirePaint;

        flBigWheel.GetComponent<MeshFilter>().mesh = offRoadTireMesh;
        flBigWheel.GetComponent<Renderer>().material = offRoadTirePaint;
        frBigWheel.GetComponent<MeshFilter>().mesh = offRoadTireMesh;
        frBigWheel.GetComponent<Renderer>().material = offRoadTirePaint;
        rlBigWheel.GetComponent<MeshFilter>().mesh = offRoadTireMesh;
        rlBigWheel.GetComponent<Renderer>().material = offRoadTirePaint;
        rrBigWheel.GetComponent<MeshFilter>().mesh = offRoadTireMesh;
        rrBigWheel.GetComponent<Renderer>().material = offRoadTirePaint;
    }
    public void SetDriftTire()
    {
        flWheel.GetComponent<MeshFilter>().mesh = driftTireMesh;
        flWheel.GetComponent<Renderer>().material = driftTirePaint;
        frWheel.GetComponent<MeshFilter>().mesh = driftTireMesh;
        frWheel.GetComponent<Renderer>().material = driftTirePaint;
        rlWheel.GetComponent<MeshFilter>().mesh = driftTireMesh;
        rlWheel.GetComponent<Renderer>().material = driftTirePaint;
        rrWheel.GetComponent<MeshFilter>().mesh = driftTireMesh;
        rrWheel.GetComponent<Renderer>().material = driftTirePaint;

        flBigWheel.GetComponent<MeshFilter>().mesh = driftTireMesh;
        flBigWheel.GetComponent<Renderer>().material = driftTirePaint;
        frBigWheel.GetComponent<MeshFilter>().mesh = driftTireMesh;
        frBigWheel.GetComponent<Renderer>().material = driftTirePaint;
        rlBigWheel.GetComponent<MeshFilter>().mesh = driftTireMesh;
        rlBigWheel.GetComponent<Renderer>().material = driftTirePaint;
        rrBigWheel.GetComponent<MeshFilter>().mesh = driftTireMesh;
        rrBigWheel.GetComponent<Renderer>().material = driftTirePaint;
    }
    public void SetStandardTire()
    {
        flWheel.GetComponent<MeshFilter>().mesh = standardTireMesh;
        flWheel.GetComponent<Renderer>().material = standardTirePaint;
        frWheel.GetComponent<MeshFilter>().mesh = standardTireMesh;
        frWheel.GetComponent<Renderer>().material = standardTirePaint;
        rlWheel.GetComponent<MeshFilter>().mesh = standardTireMesh;
        rlWheel.GetComponent<Renderer>().material = standardTirePaint;
        rrWheel.GetComponent<MeshFilter>().mesh = standardTireMesh;
        rrWheel.GetComponent<Renderer>().material = standardTirePaint;

        flBigWheel.GetComponent<MeshFilter>().mesh = standardTireMesh;
        flBigWheel.GetComponent<Renderer>().material = standardTirePaint;
        frBigWheel.GetComponent<MeshFilter>().mesh = standardTireMesh;
        frBigWheel.GetComponent<Renderer>().material = standardTirePaint;
        rlBigWheel.GetComponent<MeshFilter>().mesh = standardTireMesh;
        rlBigWheel.GetComponent<Renderer>().material = standardTirePaint;
        rrBigWheel.GetComponent<MeshFilter>().mesh = standardTireMesh;
        rrBigWheel.GetComponent<Renderer>().material = standardTirePaint;
    }
}
