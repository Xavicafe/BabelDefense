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

	[SerializeField]
	public List<GameObject> textosConCosteMejora;

	public int[] coste = {100,150,200,250,300,350};

	private Altar altarObjetivo;

	public Image imagen;
	public TMP_Text nombre;
	private AngelWrapper datosAngel;
	public GameObject angel;

	public List<GameObject> estrellas_cadencia;
	public List<GameObject> estrellas_daño;
	public List<GameObject> estrellas_rango;

	public List<GameObject> candados_cadencia;
	public List<GameObject> candados_daño;
	public List<GameObject> candados_rango;
	private PassaEscenas pas;

	void Start(){
		StartCoroutine(InitializeWithPassaEscenas());		
	}

	private IEnumerator InitializeWithPassaEscenas()
    {
        while (PassaEscenas.Instance == null || !PassaEscenas.Instance.IsInitialized)
        {
            Debug.Log("Esperando a que PassaEscenas esté inicializado...");
            yield return null; // Espera un frame antes de volver a intentar
        }

        // Una vez que se encuentra y está inicializado, asigna y continúa
        pas = PassaEscenas.Instance;

        Debug.Log("habilidades: PassaEscenas inicializado correctamente");
    }
	public void Ajustar_Costes(){
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
		if(i==5){
			textosConCosteMejora[0].GetComponent<TMP_Text>().text="MAX";
		}
		else{
			textosConCosteMejora[0].GetComponent<TMP_Text>().text=coste[i].ToString();
		}
		if(j==5){
			textosConCosteMejora[1].GetComponent<TMP_Text>().text="MAX";
		}
		else{
			textosConCosteMejora[1].GetComponent<TMP_Text>().text=coste[j].ToString();
		}
		if(z==5){
			textosConCosteMejora[2].GetComponent<TMP_Text>().text="MAX";
		}
		else{
			textosConCosteMejora[2].GetComponent<TMP_Text>().text=coste[z].ToString();
		}
	}

	public void SetTarget(Altar target)
	{	
		angel=target.angel;
		altarObjetivo = target;
		datosAngel = altarObjetivo.angelWrapper;
		transform.position = altarObjetivo.transform.position + new Vector3(0,10,0);
		nombre.text=datosAngel.prefab.GetComponent<angel>().Name;
		/*textoPropiedades.text = "Dato: " + datosAngel.Daño +  "\n Velocidad de ataque: " + datosAngel.VelocidadDeAtaque
							+ "\n Daño mejorado: " + datosAngel.DañoMejorado + "\n Velocidad de ataque mejorada: " + datosAngel.VelocidadDeAtaqueMejorada+
							 "\n Daño en Area: " + datosAngel.DañoDeArea + "\n Slow: " + datosAngel.Slow;*/
		Adaptar();
		Ajustar_Candados();
		Ajustar_Costes();
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
	private void Reset_Candados(){
		for(int i=0;i<=3;i++){
           candados_rango[i].SetActive(false);
            candados_daño[i].SetActive(false);
            candados_cadencia[i].SetActive(false);
        }
	}

	private void Ajustar_Candados(){
		Reset_Candados();
		int i=4;
		int j=4;
		int z=4;
		while(i>angel.GetComponent<angel>().cadencia){
			candados_cadencia[i-1].SetActive(true);
			if(i==1){break;}
			i--;
		}
		while(j>angel.GetComponent<angel>().rango){
			candados_rango[j-1].SetActive(true);
			if(j==1){break;}
			j--;
		}
		while(z>angel.GetComponent<angel>().daño){
			candados_daño[z-1].SetActive(true);
			if(z==1){break;}
			z--;
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
		Ajustar_Costes();
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
		Ajustar_Costes();
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
		Ajustar_Costes();
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
