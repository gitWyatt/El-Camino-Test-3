using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarBodySelection : MonoBehaviour
{
    public InputMaster controls;

    CarController carController;

    [SerializeField] public GameObject carBody;

    CarEffects carEffects;

    public GameObject pauseMenuUI;
    public GameObject pauseFirstButton;
    public GameObject bodySelectionUI;


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


    private void Awake()
    {
        carController = GameObject.Find("Camino").GetComponent<CarController>();
        carEffects = GameObject.Find("Camino").GetComponent<CarEffects>();
        controls = new InputMaster();
        BodyCheck();
    }

    public void OpenPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        bodySelectionUI.SetActive(false);
    }

    public void BodyCheck()
    {
        switch (PlayerPrefs.GetInt("bodyIndex"))
        {
            case 0:
                SetBodyBMWM1();
                break;
            case 1:
                SetBodyBMWM3();
                break;
            case 2:
                SetBodyCamaroZ28();
                break;
            case 3:
                SetBodyChevyBelAir();
                break;
            case 4:
                SetBodyDatsun240Z();
                break;
            case 5:
                SetBodyDodgeHellcat();
                break;
            case 6:
                SetBodyElCamino();
                break;
            case 7:
                SetBodyFerrariF40();
                break;
            case 8:
                SetBodyFerrariLaferrari();
                break;
            case 9:
                SetBodyFumigator();
                break;
            case 10:
                SetBodyHondaCivic();
                break;
            case 11:
                SetBodyHondaS2000();
                break;
            case 12:
                SetBodyMazdaRX7();
                break;
            case 13:
                SetBodyMustangShelby();
                break;
            case 14:
                SetBodyNissan300ZX();
                break;
            case 15:
                SetBodyPontiacGTO();
                break;
            case 16:
                SetBodyPorsche918();
                break;
            case 17:
                SetBodySkylineGTR();
                break;
            case 18:
                SetBodyToyotaAE86();
                break;
            case 19:
                SetBodyToyotaMR2();
                break;
            case 20:
                SetBodyToyotaSupra();
                break;
            case 21:
                SetBodyWRXSTI();
                break;
        }

    }

    public void SetBodyBMWM1()
    {
        PlayerPrefs.SetInt("bodyIndex", 0);
        carBody.GetComponent<MeshFilter>().mesh = BMWM1Mesh;
        carBody.GetComponent<Renderer>().material = BMWM1Paint;
    }
    public void SetBodyBMWM3()
    {
        PlayerPrefs.SetInt("bodyIndex", 1);
        carBody.GetComponent<MeshFilter>().mesh = BMWM3Mesh;
        carBody.GetComponent<Renderer>().material = BMWM3Paint;
    }
    public void SetBodyCamaroZ28()
    {
        PlayerPrefs.SetInt("bodyIndex", 2);
        carBody.GetComponent<MeshFilter>().mesh = camaroZ28Mesh;
        carBody.GetComponent<Renderer>().material = camaroZ28Paint;
    }
    public void SetBodyChevyBelAir()
    {
        PlayerPrefs.SetInt("bodyIndex", 3);
        carBody.GetComponent<MeshFilter>().mesh = chevyBelAirMesh;
        carBody.GetComponent<Renderer>().material = chevyBelAirPaint;
    }
    public void SetBodyDatsun240Z()
    {
        PlayerPrefs.SetInt("bodyIndex", 4);
        carBody.GetComponent<MeshFilter>().mesh = datsun240ZMesh;
        carBody.GetComponent<Renderer>().material = datsun240ZPaint;
    }
    public void SetBodyDodgeHellcat()
    {
        PlayerPrefs.SetInt("bodyIndex", 5);
        carBody.GetComponent<MeshFilter>().mesh = dodgeHellcatMesh;
        carBody.GetComponent<Renderer>().material = dodgeHellcatPaint;
    }
    public void SetBodyElCamino()
    {
        PlayerPrefs.SetInt("bodyIndex", 6);
        carBody.GetComponent<MeshFilter>().mesh = elCaminoMesh;
        carBody.GetComponent<Renderer>().material = elCaminoPaint;
    }
    public void SetBodyFerrariF40()
    {
        PlayerPrefs.SetInt("bodyIndex", 7);
        carBody.GetComponent<MeshFilter>().mesh = ferrariF40Mesh;
        carBody.GetComponent<Renderer>().material = ferrariF40Paint;
    }
    public void SetBodyFerrariLaferrari()
    {
        PlayerPrefs.SetInt("bodyIndex", 8);
        carBody.GetComponent<MeshFilter>().mesh = ferrariLaferrariMesh;
        carBody.GetComponent<Renderer>().material = ferrariLaferrariPaint;
    }
    public void SetBodyFumigator()
    {
        PlayerPrefs.SetInt("bodyIndex", 9);
        carBody.GetComponent<MeshFilter>().mesh = fumigatorMesh;
        carBody.GetComponent<Renderer>().material = fumigatorPaint;
    }
    public void SetBodyHondaCivic()
    {
        PlayerPrefs.SetInt("bodyIndex", 10);
        carBody.GetComponent<MeshFilter>().mesh = hondaCivicMesh;
        carBody.GetComponent<Renderer>().material = hondaCivicPaint;
    }
    public void SetBodyHondaS2000()
    {
        PlayerPrefs.SetInt("bodyIndex", 11);
        carBody.GetComponent<MeshFilter>().mesh = hondaS2000Mesh;
        carBody.GetComponent<Renderer>().material = hondaS2000Paint;
    }
    public void SetBodyMazdaRX7()
    {
        PlayerPrefs.SetInt("bodyIndex", 12);
        carBody.GetComponent<MeshFilter>().mesh = mazdaRX7Mesh;
        carBody.GetComponent<Renderer>().material = mazdaRX7Paint;
    }
    public void SetBodyMustangShelby()
    {
        PlayerPrefs.SetInt("bodyIndex", 13);
        carBody.GetComponent<MeshFilter>().mesh = mustangShelbyMesh;
        carBody.GetComponent<Renderer>().material = mustangShelbyPaint;
    }
    public void SetBodyNissan300ZX()
    {
        PlayerPrefs.SetInt("bodyIndex", 14);
        carBody.GetComponent<MeshFilter>().mesh = nissan300ZXMesh;
        carBody.GetComponent<Renderer>().material = nissan300ZXPaint;
    }
    public void SetBodyPontiacGTO()
    {
        PlayerPrefs.SetInt("bodyIndex", 15);
        carBody.GetComponent<MeshFilter>().mesh = pontiacGTOMesh;
        carBody.GetComponent<Renderer>().material = pontiacGTOPaint;
    }
    public void SetBodyPorsche918()
    {
        PlayerPrefs.SetInt("bodyIndex", 16);
        carBody.GetComponent<MeshFilter>().mesh = porsche918Mesh;
        carBody.GetComponent<Renderer>().material = porsche918Paint;
    }
    public void SetBodySkylineGTR()
    {
        PlayerPrefs.SetInt("bodyIndex", 17);
        carBody.GetComponent<MeshFilter>().mesh = skylineGTRMesh;
        carBody.GetComponent<Renderer>().material = skylineGTRPaint;
    }
    public void SetBodyToyotaAE86()
    {
        PlayerPrefs.SetInt("bodyIndex", 18);
        carBody.GetComponent<MeshFilter>().mesh = ae86Mesh;
        carBody.GetComponent<Renderer>().material = ae86Paint;
    }
    public void SetBodyToyotaMR2()
    {
        PlayerPrefs.SetInt("bodyIndex", 19);
        carBody.GetComponent<MeshFilter>().mesh = toyotaMR2Mesh;
        carBody.GetComponent<Renderer>().material = toyotaMR2Paint;
    }
    public void SetBodyToyotaSupra()
    {
        PlayerPrefs.SetInt("bodyIndex", 20);
        carBody.GetComponent<MeshFilter>().mesh = toyotaSupraMesh;
        carBody.GetComponent<Renderer>().material = toyotaSupraPaint;
    }
    public void SetBodyWRXSTI()
    {
        PlayerPrefs.SetInt("bodyIndex", 21);
        carBody.GetComponent<MeshFilter>().mesh = wrxSTIMesh;
        carBody.GetComponent<Renderer>().material = wrxSTIPaint;
    }
}

