using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MejorasController : MonoBehaviour
{

    public AudioSource audiosource;
    public AudioClip botonvolver;
    private PassaEscenas pas;

    public int Num_MaxPisos;

    public TMP_Text text;
    public List<GameObject> estrellas_rango;
    public List<GameObject> estrellas_daño;
    public List<GameObject> estrellas_cadencia;
    public List<GameObject> pisos_torre;
    public int[] coste = {1,2,3,4,5,6};
    public int[] coste_pisos = {1,2,3,4,5,6,7,8,9,10,11,12};
    public TMP_Text Texto_costepisos;

    public TMP_Text Texto_costeMejora1; 
    public TMP_Text Texto_costeMejora2; 
    public TMP_Text Texto_costeMejora3; 


    public GameObject Setu_g;

    public GameObject Setu_a;

    public GameObject Setu_h;

    private Camera camara;

    public Seleccion_habilidades sel_hab;
    public angeles sel_an;

    public TMP_Text Mejora1;
    public TMP_Text Mejora1_DUR;
    public TMP_Text Mejora2;
    public TMP_Text Mejora2_COOL;
    public TMP_Text Mejora3;
    public TMP_Text Mejora3_Ganancia;
    public TMP_Text Mejora3_Daño;
    public TMP_Text Mejora3_Relen;
    public TMP_Text n_pisos;
    public GameObject comun;
    public GameObject Name;
    public GameObject desbloquear;

    public GameObject Icono_rango;
    public GameObject Icono_duraci;

    public GameObject Icono_daño;
    public GameObject Icono_cooldown;

    public GameObject Icono_cadencia;
    public GameObject Icono_ganancia;
    public GameObject Icono_ralenti;
    public GameObject Icono_dañoo;


    public List<GameObject> candados;

   

    // Start is called before the first frame update
    void Start()
    {
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();
        camara=Camera.main;
        ActualizarCandados();
        Texto_costepisos.text= coste_pisos[pas.n_pisos]+" EXP";
        Actualizar_Pisos();

    }

    public void ActualizarCandados(){
        for(int i=0 ; i<candados.Count ; i++){
            if(pas.angeles_bloqueados[i]){
                candados[i].SetActive(true);
            }else{
                candados[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            ocultar_mejoras();
        } 
    }

    public void Actualizar_Pisos(){
        if(pas.n_pisos==1){

        }
        else{
            for(int i = 0; i<pas.n_pisos; i++){
            pisos_torre[i].SetActive(true);
        }
        }
        
    }

    public void ocultar_mejoras()
    {
        SceneManager.LoadScene("inicio");
        audiosource.PlayOneShot(botonvolver);
    }


    


    public void Menu_selected(int index){
        Animator animator = camara.GetComponent<Animator>();
        comun.SetActive(true);
        Name.SetActive(true);
        text.transform.parent.gameObject.SetActive(true);
        if(index==0){
            comun.SetActive(false);
            Name.SetActive(false);
            text.transform.parent.gameObject.SetActive(false);
            if(pas.n_pisos==Num_MaxPisos){
                n_pisos.text = "MAX";
            }else{
                n_pisos.text=pas.n_pisos.ToString();
            }
            
            animator.SetInteger("Transiciones", 0);
            Setu_g.SetActive(true);
            Setu_a.SetActive(false);
            Setu_h.SetActive(false);
            desbloquear.SetActive(false);
        }
        if(index==1){
            int indice =-1;
            animator.SetInteger("Transiciones", 1);
            Setu_g.SetActive(false);
            Setu_a.SetActive(true);
            Setu_h.SetActive(false);
            for(int i=0;i<sel_an.total_angeles.Count;i++){
                if(sel_an.total_angeles[i].activeSelf){
                    indice =i;
                    break;
                }
            }
            sel_an.OnMouseDown(indice);
            //textos
            Mejora1.gameObject.SetActive(true);
            Mejora1_DUR.gameObject.SetActive(false);
            Mejora2.gameObject.SetActive(true);
            Mejora2_COOL.gameObject.SetActive(false);
            Mejora3.gameObject.SetActive(true);
            Mejora3_Ganancia.gameObject.SetActive(false);
            Mejora3_Relen.gameObject.SetActive(false);
            Mejora3_Daño.gameObject.SetActive(false);

            //Iconos

            Icono_rango.gameObject.SetActive(true);
            Icono_duraci.gameObject.SetActive(false);

            Icono_daño.gameObject.SetActive(true);
            Icono_cooldown.gameObject.SetActive(false);

            Icono_cadencia.gameObject.SetActive(true);
            Icono_ganancia.gameObject.SetActive(false);
            Icono_ralenti.gameObject.SetActive(false);
            Icono_dañoo.gameObject.SetActive(false);
        }
        if(index==2){
            int indice =-1;
            animator.SetInteger("Transiciones", 2);
            Setu_g.SetActive(false);
            Setu_a.SetActive(false);
            Setu_h.SetActive(true);
            for(int i=0;i<sel_hab.total_habilidades.Count;i++){
                if(sel_hab.total_habilidades[i].activeSelf){
                    indice = i;
                    break;
                }
            }

            //cambiar textos por Ñ
            sel_hab.OnMouseDown(indice);
            Mejora1.gameObject.SetActive(false);
            Mejora1_DUR.gameObject.SetActive(true);
            Mejora2.gameObject.SetActive(false);
            Mejora2_COOL.gameObject.SetActive(true);

            //Iconos

            Icono_rango.gameObject.SetActive(false);
            Icono_duraci.gameObject.SetActive(true);

            Icono_daño.gameObject.SetActive(false);
            Icono_cooldown.gameObject.SetActive(true);

            Icono_cadencia.gameObject.SetActive(false);

            //Según la habilidad seleccionada

            if(indice==0){
                Mejora3.gameObject.SetActive(false);
                Mejora3_Ganancia.gameObject.SetActive(true);
                Mejora3_Relen.gameObject.SetActive(false);
                Mejora3_Daño.gameObject.SetActive(false);

                Icono_ganancia.gameObject.SetActive(true);
            }else if(indice==1){
                Mejora3.gameObject.SetActive(false);
                Mejora3_Ganancia.gameObject.SetActive(false);
                Mejora3_Relen.gameObject.SetActive(true);
                Mejora3_Daño.gameObject.SetActive(false);

                Icono_ralenti.gameObject.SetActive(true);
            }else if(indice==2){
                Mejora3.gameObject.SetActive(false);
                Mejora3_Ganancia.gameObject.SetActive(false);
                Mejora3_Relen.gameObject.SetActive(false);
                Mejora3_Daño.gameObject.SetActive(true);

                Icono_dañoo.gameObject.SetActive(true);
            }
            desbloquear.SetActive(false);
        }
    }

    public void mejorar_pisos(){
        if(pas.n_pisos<Num_MaxPisos && pas.experiencia>=5){
            pisos_torre[pas.n_pisos].SetActive(true);
            pas.RemoveEXP(coste_pisos[pas.n_pisos]);
            pas.n_pisos +=1;
            n_pisos.text = pas.n_pisos.ToString();
            Texto_costepisos.text= coste_pisos[pas.n_pisos]+" EXP";
            
            if(pas.n_pisos==Num_MaxPisos){
                n_pisos.text = "MAX";
            }
        }
        else{Debug.Log("Nivel Máximo o no tienes suficiente experiencia");}
    }

    public void mejorar_Rango(){
        if(Setu_a.activeSelf){
            if (text.text=="ÁNGEL" && pas.experiencia>=coste[pas.rango_angelsimple]){
                if (pas.rango_angelsimple<4){
                    
                    pas.RemoveEXP(coste[pas.rango_angelsimple]);
                    pas.rango_angelsimple++;
                    estrellas_rango[pas.rango_angelsimple].SetActive(true);
                    if(pas.rango_angelsimple==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                        Texto_costeMejora1.text = coste[pas.rango_angelsimple]+" EXP";
                    }
                }
            }else if(text.text=="ARCÁNGEL" && pas.experiencia>=coste[pas.rango_arcangel]){
                if (pas.rango_arcangel<4){
                    pas.RemoveEXP(coste[pas.rango_arcangel]);
                    pas.rango_arcangel++;
                    estrellas_rango[pas.rango_arcangel].SetActive(true);
                    if(pas.rango_arcangel==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                    Texto_costeMejora1.text = coste[pas.rango_arcangel]+" EXP";}
                }
            }else if(text.text=="PRINCIPADO" && pas.experiencia>=coste[pas.rango_principado]){
                if (pas.rango_principado<4){
                    pas.RemoveEXP(coste[pas.rango_principado]);
                    pas.rango_principado++;
                    estrellas_rango[pas.rango_principado].SetActive(true);
                    if(pas.rango_principado==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                    Texto_costeMejora1.text = coste[pas.rango_principado]+" EXP";}
                }
            }else if(text.text=="VIRTUD" && pas.experiencia>=coste[pas.rango_virtud]){
                if (pas.rango_virtud<4){
                    pas.RemoveEXP(coste[pas.rango_virtud]);
                    pas.rango_virtud++;
                    estrellas_rango[pas.rango_virtud].SetActive(true);
                    if(pas.rango_virtud==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                    Texto_costeMejora1.text = coste[pas.rango_virtud]+" EXP";}
                }
            }else if(text.text=="POTESTAD" && pas.experiencia>=coste[pas.rango_potestad]){
                if (pas.rango_potestad<4){
                    pas.RemoveEXP(coste[pas.rango_potestad]);
                    pas.rango_potestad++;
                    estrellas_rango[pas.rango_potestad].SetActive(true);
                    if(pas.rango_potestad==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                    Texto_costeMejora1.text = coste[pas.rango_potestad]+" EXP";}
                }
            }else if(text.text=="DOMINIO" && pas.experiencia>=coste[pas.rango_dominio]){
                if (pas.rango_dominio<4){
                    pas.RemoveEXP(coste[pas.rango_dominio]);
                    pas.rango_dominio++;
                    estrellas_rango[pas.rango_dominio].SetActive(true);
                    if(pas.rango_dominio==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                    Texto_costeMejora1.text = coste[pas.rango_dominio]+" EXP";}
                }
            }else if(text.text=="TRONO" && pas.experiencia>=coste[pas.rango_trono]){
                if (pas.rango_trono<4){
                    pas.RemoveEXP(coste[pas.rango_trono]);
                    pas.rango_trono++;
                    estrellas_rango[pas.rango_trono].SetActive(true);
                    if(pas.rango_trono==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                    Texto_costeMejora1.text = coste[pas.rango_trono]+" EXP";}
                }
            }else if(text.text=="QUERUBÍN" && pas.experiencia>=coste[pas.rango_querubin]){
                if (pas.rango_querubin<4){
                    pas.RemoveEXP(coste[pas.rango_querubin]);
                    pas.rango_querubin++;
                    estrellas_rango[pas.rango_querubin].SetActive(true);
                    if(pas.rango_querubin==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                    Texto_costeMejora1.text = coste[pas.rango_querubin]+" EXP";}
                }
            }else if(text.text=="SERAFÍN" && pas.experiencia>=coste[pas.rango_serafin]){
                if (pas.rango_serafin<4){
                    pas.RemoveEXP(coste[pas.rango_serafin]);
                    pas.rango_serafin++;
                    estrellas_rango[pas.rango_serafin].SetActive(true);
                    if(pas.rango_serafin==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                    Texto_costeMejora1.text = coste[pas.rango_serafin]+" EXP";}
                }
            }
        }
        else if(Setu_h.activeSelf){
            if (text.text=="FURIA DEL ORO" && pas.experiencia>=coste[pas.duracion_GF]){
                if (pas.duracion_GF<4){
                    pas.RemoveEXP(coste[pas.duracion_GF]);
                    pas.duracion_GF++;
                    estrellas_rango[pas.duracion_GF].SetActive(true);
                    if(pas.duracion_GF==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                    Texto_costeMejora1.text = coste[pas.duracion_GF]+" EXP";}
                    
                }
            }else if(text.text=="ERA DE HIELO" && pas.experiencia>=coste[pas.duracion_EH]){
                if (pas.duracion_EH<4){
                    pas.RemoveEXP(coste[pas.duracion_EH]);
                    pas.duracion_EH++;
                    estrellas_rango[pas.duracion_EH].SetActive(true);
                    if(pas.duracion_EH==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                    Texto_costeMejora1.text = coste[pas.duracion_EH]+" EXP";}
                }
            }else if(text.text=="APOCALIPSIS" && pas.experiencia>=coste[pas.duracion_A]){
                if (pas.duracion_A<4){
                    pas.RemoveEXP(coste[pas.duracion_A]);
                    pas.duracion_A++;
                    estrellas_rango[pas.duracion_A].SetActive(true);
                    if(pas.duracion_A==4){
                        Texto_costeMejora1.text = "MAX";
                    }else{
                    Texto_costeMejora1.text = coste[pas.duracion_A]+" EXP";}
                }
            }
        }
    }
    public void  mejorar_Daño(){
        if(Setu_a.activeSelf){
            if (text.text=="ÁNGEL" && pas.experiencia>=coste[pas.daño_angelsimple]){
                if (pas.daño_angelsimple<4){
                    pas.RemoveEXP(coste[pas.daño_angelsimple]);
                    pas.daño_angelsimple++;
                    estrellas_daño[pas.daño_angelsimple].SetActive(true);
                    if(pas.daño_angelsimple==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.daño_angelsimple]+" EXP";}
                }
            }else if(text.text=="ARCÁNGEL" && pas.experiencia>=coste[pas.daño_arcangel]){
                if (pas.daño_arcangel<4){
                    pas.RemoveEXP(coste[pas.daño_arcangel]);
                    pas.daño_arcangel++;
                    estrellas_daño[pas.daño_arcangel].SetActive(true);
                    if(pas.daño_arcangel==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.daño_arcangel]+" EXP";}
                }
            }else if(text.text=="PRINCIPADO" && pas.experiencia>=coste[pas.daño_principado]){
                if (pas.daño_principado<4){
                    pas.RemoveEXP(coste[pas.daño_principado]);
                    pas.daño_principado++;
                    estrellas_daño[pas.daño_principado].SetActive(true);
                    if(pas.daño_principado==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.daño_principado]+" EXP";}
                }
            }else if(text.text=="VIRTUD" && pas.experiencia>=coste[pas.daño_virtud]){
                if (pas.daño_virtud<4){
                    pas.RemoveEXP(coste[pas.daño_virtud]);
                    pas.daño_virtud++;
                    estrellas_daño[pas.daño_virtud].SetActive(true);
                    if(pas.daño_virtud==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.daño_virtud]+" EXP";}
                }
            }else if(text.text=="POTESTAD" && pas.experiencia>=coste[pas.daño_potestad]){
                if (pas.daño_potestad<4){
                    pas.RemoveEXP(coste[pas.daño_potestad]);
                    pas.daño_potestad++;
                    estrellas_daño[pas.daño_potestad].SetActive(true);
                    if(pas.daño_potestad==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.daño_potestad]+" EXP";}
                }
            }else if(text.text=="DOMINIO" && pas.experiencia>=coste[pas.daño_dominio]){
                if (pas.daño_dominio<4){
                    pas.RemoveEXP(coste[pas.daño_dominio]);
                    pas.daño_dominio++;
                    estrellas_daño[pas.daño_dominio].SetActive(true);
                    if(pas.daño_dominio==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.daño_dominio]+" EXP";}
                }
            }else if(text.text=="TRONO" && pas.experiencia>=coste[pas.daño_trono]){
                if (pas.daño_trono<4){
                    pas.RemoveEXP(coste[pas.daño_trono]);
                    pas.daño_trono++;
                    estrellas_daño[pas.daño_trono].SetActive(true);
                    if(pas.daño_trono==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.daño_trono]+" EXP";}
                }
            }else if(text.text=="QUERUBÍN" && pas.experiencia>=coste[pas.daño_querubin]){
                if (pas.daño_querubin<4){
                    pas.RemoveEXP(coste[pas.daño_querubin]);
                    pas.daño_querubin++;
                    estrellas_daño[pas.daño_querubin].SetActive(true);
                    if(pas.daño_querubin==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.daño_querubin]+" EXP";}
                }
            }else if(text.text=="SERAFÍN" && pas.experiencia>=coste[pas.daño_serafin]){
                if (pas.daño_serafin<4){
                    pas.RemoveEXP(coste[pas.daño_serafin]);
                    pas.daño_serafin++;
                    estrellas_daño[pas.daño_serafin].SetActive(true);
                    if(pas.daño_serafin==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.daño_serafin]+" EXP";}
                }
            }
        }
        else if(Setu_h.activeSelf){
            if (text.text=="FURIA DEL ORO" && pas.experiencia>=coste[pas.cooldown_GF]){
                if (pas.cooldown_GF<4){
                    pas.RemoveEXP(coste[pas.cooldown_GF]);
                    pas.cooldown_GF++;
                    estrellas_daño[pas.cooldown_GF].SetActive(true);
                    if(pas.cooldown_GF==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.cooldown_GF]+" EXP";}
            }
            }else if(text.text=="ERA DE HIELO" && pas.experiencia>=coste[pas.cooldown_EH]){
                if (pas.cooldown_EH<4){
                    pas.RemoveEXP(coste[pas.cooldown_EH]);
                    pas.cooldown_EH++;
                    estrellas_daño[pas.cooldown_EH].SetActive(true);
                    if(pas.cooldown_EH==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.cooldown_EH]+" EXP";}
                    
                }
            }else if(text.text=="APOCALIPSIS" && pas.experiencia>=coste[pas.cooldown_A]){
                if (pas.cooldown_A<4){
                    pas.RemoveEXP(coste[pas.cooldown_A]);
                    pas.cooldown_A++;
                    estrellas_daño[pas.cooldown_A].SetActive(true);
                    if(pas.cooldown_A==4){
                        Texto_costeMejora2.text = "MAX";
                    }else{
                    Texto_costeMejora2.text = coste[pas.cooldown_A]+" EXP";}
                }
            }
        }
        
    }
    public void mejorar_Cadencia(){
        if(Setu_a.activeSelf){
            if (text.text=="ÁNGEL" && pas.experiencia>=coste[pas.cadencia_angelsimple]){
                if (pas.cadencia_angelsimple<4){
                    pas.RemoveEXP(coste[pas.cadencia_angelsimple]);
                    pas.cadencia_angelsimple++;
                    estrellas_cadencia[pas.cadencia_angelsimple].SetActive(true);
                    if(pas.cadencia_angelsimple==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.cadencia_angelsimple]+" EXP";}
                }
            }else if(text.text=="ARCÁNGEL" && pas.experiencia>=coste[pas.cadencia_arcangel]){
                if (pas.cadencia_arcangel<4){
                    pas.RemoveEXP(coste[pas.cadencia_arcangel]);
                    pas.cadencia_arcangel++;
                    estrellas_cadencia[pas.cadencia_arcangel].SetActive(true);
                    if(pas.cadencia_arcangel==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.cadencia_arcangel]+" EXP";}
                }
            }else if(text.text=="PRINCIPADO" && pas.experiencia>=coste[pas.cadencia_principado]){
                if (pas.cadencia_principado<4){
                    pas.RemoveEXP(coste[pas.cadencia_principado]);
                    pas.cadencia_principado++;
                    estrellas_cadencia[pas.cadencia_principado].SetActive(true);
                    if(pas.cadencia_principado==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.cadencia_principado]+" EXP";}
                }
            }else if(text.text=="VIRTUD" && pas.experiencia>=coste[pas.cadencia_virtud]){
                if (pas.cadencia_virtud<4){
                    pas.RemoveEXP(coste[pas.cadencia_virtud]);
                    pas.cadencia_virtud++;
                    estrellas_cadencia[pas.cadencia_virtud].SetActive(true);
                    if(pas.cadencia_virtud==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.cadencia_virtud]+" EXP";}
                }
            }else if(text.text=="POTESTAD" && pas.experiencia>=coste[pas.cadencia_potestad]){
                if (pas.cadencia_potestad<4){
                    pas.RemoveEXP(coste[pas.cadencia_potestad]);
                    pas.cadencia_potestad++;
                    estrellas_cadencia[pas.cadencia_potestad].SetActive(true);
                    if(pas.cadencia_potestad==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.cadencia_potestad]+" EXP";}
                }
            }else if(text.text=="DOMINIO" && pas.experiencia>=coste[pas.cadencia_dominio]){
                if (pas.cadencia_dominio<4){
                    pas.RemoveEXP(coste[pas.cadencia_dominio]);
                    pas.cadencia_dominio++;
                    estrellas_cadencia[pas.cadencia_dominio].SetActive(true);
                    if(pas.cadencia_dominio==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.cadencia_dominio]+" EXP";}
                }
            }else if(text.text=="TRONO" && pas.experiencia>=coste[pas.cadencia_trono]){
                if (pas.cadencia_trono<4){
                    pas.RemoveEXP(coste[pas.cadencia_trono]);
                    pas.cadencia_trono++;
                    estrellas_cadencia[pas.cadencia_trono].SetActive(true);
                    if(pas.cadencia_trono==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.cadencia_trono]+" EXP";}
                }
            }else if(text.text=="QUERUBÍN" && pas.experiencia>=coste[pas.cadencia_querubin]){
                if (pas.cadencia_querubin<4){
                    pas.RemoveEXP(coste[pas.cadencia_querubin]);
                    pas.cadencia_querubin++;
                    estrellas_cadencia[pas.cadencia_querubin].SetActive(true);
                    if(pas.cadencia_querubin==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.cadencia_querubin]+" EXP";}
                }
            }else if(text.text=="SERAFÍN" && pas.experiencia>=coste[pas.cadencia_serafin]){
                if (pas.cadencia_serafin<4){
                    pas.RemoveEXP(coste[pas.cadencia_serafin]);
                    pas.cadencia_serafin++;
                    estrellas_cadencia[pas.cadencia_serafin].SetActive(true);
                    if(pas.cadencia_serafin==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.cadencia_serafin]+" EXP";}
                }
            }
        }
        else if(Setu_h.activeSelf){
            if (text.text=="FURIA DEL ORO" && pas.experiencia>=coste[pas.amount_GF]){
                if (pas.amount_GF<4){
                    pas.RemoveEXP(coste[pas.amount_GF]);
                    pas.amount_GF++;
                    estrellas_cadencia[pas.amount_GF].SetActive(true);
                    if(pas.amount_GF==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.amount_GF]+" EXP";}
            }
            }else if(text.text=="ERA DE HIELO" && pas.experiencia>=coste[pas.slow_EH]){
                if (pas.slow_EH<4){
                    pas.RemoveEXP(coste[pas.slow_EH]);
                    pas.slow_EH++;
                    estrellas_cadencia[pas.slow_EH].SetActive(true);
                    if(pas.slow_EH==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.slow_EH]+" EXP";}
                }
            }else if(text.text=="APOCALIPSIS" && pas.experiencia>=coste[pas.damage_A]){
                if (pas.damage_A<4){
                    pas.RemoveEXP(coste[pas.damage_A]);
                    pas.damage_A++;
                    estrellas_cadencia[pas.damage_A].SetActive(true);
                    if(pas.damage_A==4){
                        Texto_costeMejora3.text = "MAX";
                    }else{
                    Texto_costeMejora3.text = coste[pas.damage_A]+" EXP";}
                }
            }
        }
    }

    public void RESETEXP(){
        if(Setu_a.activeSelf){
            Reset();
            
            if (text.text=="ÁNGEL"){
                int exp = 0;
                for(int i=0;i<pas.rango_angelsimple;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.daño_angelsimple;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cadencia_angelsimple;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;

                pas.rango_angelsimple=0;
                pas.daño_angelsimple=0;
                pas.cadencia_angelsimple=0;

                Texto_costeMejora1.text = coste[pas.rango_angelsimple]+" EXP";
                Texto_costeMejora2.text = coste[pas.daño_angelsimple]+" EXP";
                Texto_costeMejora3.text = coste[pas.cadencia_angelsimple]+" EXP";
            }
            else if(text.text=="ARCÁNGEL"){
                int exp = 0;
                for(int i=0;i<pas.rango_arcangel;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.daño_arcangel;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cadencia_arcangel;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;
                
                pas.rango_arcangel=0;
                pas.daño_arcangel=0;
                pas.cadencia_arcangel=0;

                Texto_costeMejora1.text = coste[pas.rango_arcangel]+" EXP";
                Texto_costeMejora2.text = coste[pas.daño_arcangel]+" EXP";
                Texto_costeMejora3.text = coste[pas.cadencia_arcangel]+" EXP";
            }
            else if(text.text=="PRINCIPADO"){
                int exp = 0;
                for(int i=0;i<pas.rango_principado;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.daño_principado;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cadencia_principado;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;
                
                pas.rango_principado=0;
                pas.daño_principado=0;
                pas.cadencia_principado=0;

                Texto_costeMejora1.text = coste[pas.rango_principado]+" EXP";
                Texto_costeMejora2.text = coste[pas.daño_principado]+" EXP";
                Texto_costeMejora3.text = coste[pas.cadencia_principado]+" EXP";
            }
            else if(text.text=="VIRTUD"){
                int exp = 0;
                for(int i=0;i<pas.rango_virtud;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.daño_virtud;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cadencia_virtud;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;
                
                pas.rango_virtud=0;
                pas.daño_virtud=0;
                pas.cadencia_virtud=0;
                
                Texto_costeMejora1.text = coste[pas.rango_virtud]+" EXP";
                Texto_costeMejora2.text = coste[pas.daño_virtud]+" EXP";
                Texto_costeMejora3.text = coste[pas.cadencia_virtud]+" EXP";
            }
            else if(text.text=="POTESTAD"){
                int exp = 0;
                for(int i=0;i<pas.rango_potestad;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.daño_potestad;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cadencia_potestad;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;
                
                pas.rango_potestad=0;
                pas.daño_potestad=0;
                pas.cadencia_potestad=0;
                
                Texto_costeMejora1.text = coste[pas.rango_potestad]+" EXP";
                Texto_costeMejora2.text = coste[pas.daño_potestad]+" EXP";
                Texto_costeMejora3.text = coste[pas.cadencia_potestad]+" EXP";
            }
            else if(text.text=="DOMINIO"){
                int exp = 0;
                for(int i=0;i<pas.rango_dominio;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.daño_dominio;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cadencia_dominio;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;
                
                pas.rango_dominio=0;
                pas.daño_dominio=0;
                pas.cadencia_dominio=0;
                
                Texto_costeMejora1.text = coste[pas.rango_dominio]+" EXP";
                Texto_costeMejora2.text = coste[pas.daño_dominio]+" EXP";
                Texto_costeMejora3.text = coste[pas.cadencia_dominio]+" EXP";
            }
            else if(text.text=="TRONO"){
                int exp = 0;
                for(int i=0;i<pas.rango_trono;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.daño_trono;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cadencia_trono;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;
                
                pas.rango_trono=0;
                pas.daño_trono=0;
                pas.cadencia_trono=0;
                
                Texto_costeMejora1.text = coste[pas.rango_trono]+" EXP";
                Texto_costeMejora2.text = coste[pas.daño_trono]+" EXP";
                Texto_costeMejora3.text = coste[pas.cadencia_trono]+" EXP";
            }
            else if(text.text=="QUERUBÍN"){
                int exp = 0;
                for(int i=0;i<pas.rango_querubin;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.daño_querubin;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cadencia_querubin;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;
                
                pas.rango_querubin=0;
                pas.daño_querubin=0;
                pas.cadencia_querubin=0;
                
                Texto_costeMejora1.text = coste[pas.rango_querubin]+" EXP";
                Texto_costeMejora2.text = coste[pas.daño_querubin]+" EXP";
                Texto_costeMejora3.text = coste[pas.cadencia_querubin]+" EXP";
            }
            else if(text.text=="SERAFÍN"){
                int exp = 0;
                for(int i=0;i<pas.rango_serafin;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.daño_serafin;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cadencia_serafin;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;
                
                pas.rango_serafin=0;
                pas.daño_serafin=0;
                pas.cadencia_serafin=0;
                
                Texto_costeMejora1.text = coste[pas.rango_serafin]+" EXP";
                Texto_costeMejora2.text = coste[pas.daño_serafin]+" EXP";
                Texto_costeMejora3.text = coste[pas.cadencia_serafin]+" EXP";
            }
        }
        else if(Setu_h.activeSelf){
            Reset();
            if (text.text=="FURIA DEL ORO"){
                int exp = 0;
                for(int i=0;i<pas.duracion_GF;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cooldown_GF;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.amount_GF;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;

                pas.duracion_GF=0;
                pas.cooldown_GF=0;
                pas.amount_GF=0;

                Texto_costeMejora1.text = coste[pas.duracion_GF]+" EXP";
                Texto_costeMejora2.text = coste[pas.cooldown_GF]+" EXP";
                Texto_costeMejora3.text = coste[pas.amount_GF]+" EXP";

            }else if(text.text=="ERA DE HIELO"){
                int exp = 0;
                for(int i=0;i<pas.duracion_EH;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cooldown_EH;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.slow_EH;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;
                
                pas.duracion_EH=0;
                pas.cooldown_EH=0;
                pas.slow_EH=0;

                Texto_costeMejora1.text = coste[pas.duracion_EH]+" EXP";
                Texto_costeMejora2.text = coste[pas.cooldown_EH]+" EXP";
                Texto_costeMejora3.text = coste[pas.slow_EH]+" EXP";
            }
            else if(text.text=="APOCALIPSIS"){
                int exp = 0;
                for(int i=0;i<pas.duracion_A;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.cooldown_A;i++){
                exp += coste[i];
                }
                for(int i=0;i<pas.damage_A;i++){
                exp += coste[i];
                }
                pas.experiencia += exp;
                
                pas.duracion_A=0;
                pas.cooldown_A=0;
                pas.damage_A=0;

                Texto_costeMejora1.text = coste[pas.duracion_A]+" EXP";
                Texto_costeMejora2.text = coste[pas.cooldown_A]+" EXP";
                Texto_costeMejora3.text = coste[pas.damage_A]+" EXP";
            }

        }
    }

    public void Reset(){
        for(int i=1;i<=4;i++){
            estrellas_rango[i].SetActive(false);
            estrellas_daño[i].SetActive(false);
            estrellas_cadencia[i].SetActive(false);
        }
    }
}
