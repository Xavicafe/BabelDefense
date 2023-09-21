using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{

	public GameObject ui;
	public Text upgradeCost;
	public Button upgradeButton;
	public Text textoPropiedades;
	public Text sellAmount;
	public int[] coste = {100,150,200,250,300,350};

	private Altar altarObjetivo;

	public Image imagen;
	public TMP_Text nombre;
	private AngelWrapper datosAngel;
	private GameObject angel;

	public List<GameObject> estrellas_cadencia;
	public List<GameObject> estrellas_daño;
	public List<GameObject> estrellas_rango;
	private PassaEscenas pas;

	void Start(){
		pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();
	}

	public void SetTarget(Altar target)
	{	
		angel=target.angel;
		altarObjetivo = target;
		datosAngel = altarObjetivo.angelWrapper;
		transform.position = altarObjetivo.transform.position + new Vector3(0,10,0);
		imagen.sprite=datosAngel.logo;
		nombre.text=datosAngel.prefab.GetComponent<angel>().Name;
		/*textoPropiedades.text = "Dato: " + datosAngel.Daño +  "\n Velocidad de ataque: " + datosAngel.VelocidadDeAtaque
							+ "\n Daño mejorado: " + datosAngel.DañoMejorado + "\n Velocidad de ataque mejorada: " + datosAngel.VelocidadDeAtaqueMejorada+
							 "\n Daño en Area: " + datosAngel.DañoDeArea + "\n Slow: " + datosAngel.Slow;*/
		Adaptar();
		if (!altarObjetivo.isUpgraded)
        {
            upgradeCost.text = datosAngel.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MEJORADO";
            upgradeButton.interactable = false;
        }

        ajustar_dinero();

        ui.SetActive(true);
    }

	public void Hide()
	{
		ui.SetActive(false);
	}

	public void Upgrade()
	{
		altarObjetivo.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}

	public void Sell()
	{
		altarObjetivo.SellTurret(Dinero_Venta());
		BuildManager.instance.DeselectNode();
	}

	private void Reset_stars(){
		for(int i=0;i<=4;i++){
            estrellas_rango[i].SetActive(false);
            estrellas_daño[i].SetActive(false);
            estrellas_cadencia[i].SetActive(false);
        }
	}

	private void Adaptar(){
		Reset_stars();
		int i=0;
		int j=0;
		int z=0;
		while(i<=4){
			if(!angel.GetComponent<angel>().mejora_cadencia[i]){
				break;
			}
			i++;
		}	
		while(j<=4){
			if(!angel.GetComponent<angel>().mejora_daño[j]){
				break;
			}
			j++;
		}	
		while(z<=4){
			if(!angel.GetComponent<angel>().mejora_rango[z]){
				break;
			}
			z++;
		}
		while(i>0){
			i--;
			estrellas_cadencia[i].SetActive(true);
			
			
		}
		while(j>0){
			j--;
			estrellas_daño[j].SetActive(true);
			
		}
		while(z>0){
			z--;
			estrellas_rango[z].SetActive(true);	
			
		}
	}

	public void mejorar_Cadencia(){
		int i=0;
		while(i<4){
			if(!angel.GetComponent<angel>().mejora_cadencia[i]){
				break;
			}
			i++;
		}	
		if(PlayerStats.Money>=coste[i] && i<=angel.GetComponent<angel>().cadencia && !estrellas_cadencia[i].activeSelf){
			PlayerStats.Money-=coste[i];
			estrellas_cadencia[i].SetActive(true);
			angel.GetComponent<angel>().mejorar_Cadencia(i);
		}
		else{
			Debug.Log("O no tienes dinero o no tienes esta mejora desbloqueada");
		}
		sellAmount.text = Dinero_Venta() + "";
	}
	public void mejorar_Rango(){
		int i=0;
		while(i<4){
			if(!angel.GetComponent<angel>().mejora_rango[i]){
				break;
			}
			i++;
		}	

		if(PlayerStats.Money>=coste[i] && i<=angel.GetComponent<angel>().rango && !estrellas_rango[i].activeSelf){
			PlayerStats.Money-=coste[i];
			estrellas_rango[i].SetActive(true);
			angel.GetComponent<angel>().mejorar_Rango(i);
		}
		else{
			Debug.Log("O no tienes dinero o no tienes esta mejora desbloqueada");
		}
		sellAmount.text = Dinero_Venta() + "";
	}
	public void mejorar_Daño(){
		int i=0;
		while(i<4){
			if(!angel.GetComponent<angel>().mejora_daño[i]){
				break;
			}
			i++;
		}		
		if(PlayerStats.Money>=coste[i] && i<=angel.GetComponent<angel>().daño && !estrellas_daño[i].activeSelf){
			PlayerStats.Money-=coste[i];
			estrellas_daño[i].SetActive(true);
			angel.GetComponent<angel>().mejorar_Daño(i);
		}
		else{
			Debug.Log("O no tienes dinero o no tienes esta mejora desbloqueada");
		}
		sellAmount.text = Dinero_Venta() + "";
	}

	public int Dinero_Venta(){
		int dinero=0;
		int i=0;
		int j=0;
		int z=0;
		while(i<=4){
			if(!angel.GetComponent<angel>().mejora_cadencia[i]){
				break;
			}
			i++;
		}	
		while(j<=4){
			if(!angel.GetComponent<angel>().mejora_daño[j]){
				break;
			}
			j++;
		}	
		while(z<=4){
			if(!angel.GetComponent<angel>().mejora_rango[z]){
				break;
			}
			z++;
		}
		while(i>0){
			i--;
			dinero+=coste[i];
			
		}
		while(j>0){
			j--;
			dinero+=coste[j];
			
		}
		while(z>0){
			z--;
			dinero+=coste[z];
			
		}
		dinero+=datosAngel.cost;
		return dinero/2;

	}
	public void ajustar_dinero(){
		sellAmount.text = Dinero_Venta() + "";
	}
}
