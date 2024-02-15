using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    private Renderer rend;
    public Vector3 altura;
    public Vector3 centro_torre;
    BuildManager buildManager;
    public Color hoverColor;
    private Color startColor;

    [HideInInspector]
    public bool isUpgraded = false;
    [HideInInspector]
    public GameObject angel;
    [HideInInspector]
    public AngelWrapper angelWrapper;

    SFXController controladorSFX;

    public GameController gm;

    public Shop shop;
    bool puede = false;

    void Start()
    {
        shop = GameObject.FindGameObjectWithTag("PANELTIENDA").GetComponent<Shop>();
        transform.LookAt(centro_torre);
        rend = this.GetComponent<Renderer>();
        buildManager = BuildManager.instance;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameController>();
    }

    private void OnMouseEnter()
    {
        
        transform.localScale += new Vector3(0.025F, 0.025F, 0.025F);

    }
    private void OnMouseExit()
    {
        transform.localScale += new Vector3(-0.025F, -0.025F, -0.025F);
    }
    private void OnMouseDown()
    {
        if(shop.traspasa){
            Debug.Log(shop.traspasa);
            return;
        }
        if (angel != null)
        {
            buildManager.SelectAltar(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if(gm.menuPausaActivo){return;}
        ContruirAngel();
    }
    public void ContruirAngel()
    {
        this.angelWrapper = buildManager.AngelParaColocar;
        if (buildManager.AngelParaColocar == null) return;
        if (PlayerStats.Money < buildManager.AngelParaColocar.cost)
        {
            Debug.Log("No tienes suficiente dinero");
            return;
        }
        PlayerStats.Money -= buildManager.AngelParaColocar.cost;

        controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
        controladorSFX.PlayInvocarAngel();

        GameObject angel = (GameObject)Instantiate(buildManager.AngelParaColocar.prefab, this.transform.position + this.altura, Quaternion.identity);
        angel.transform.LookAt(centro_torre);
        if(angel.GetComponent<angel>().Name=="Principado"){
            angel.transform.rotation*=Quaternion.Euler(270f,90f,0);
            angel.transform.position += new Vector3(0,4,0);
        }
        if(angel.GetComponent<angel>().Name=="Virtud"){
            angel.transform.rotation*=Quaternion.Euler(120f,0f,0);
            //angel.transform.position += new Vector3(0,1,0);
        }
        
        this.angel = angel;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + altura;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < angelWrapper.upgradeCost)
        {
            Debug.Log("No tienes suficiente dinero");
            return;
        }

        PlayerStats.Money -= angelWrapper.upgradeCost;

        Destroy(angel);

        GameObject _turret = (GameObject)Instantiate(angelWrapper.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        angel = _turret;

        isUpgraded = true;

        Debug.Log("Angel mejorado!");
    }

    public void SellTurret(int dinero)
    {
        PlayerStats.Money += dinero;
        isUpgraded = false;
        Destroy(angel);
        angelWrapper = null;
    }
}
