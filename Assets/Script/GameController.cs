using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine.UI;
using UnityEngine;


public class GameController : MonoBehaviour
{


    [Header("Player Config")]// Start is called before the first frame update
    public float velocidade;
    public Transform player;
    public float limiteBackX, limiteFrontX;
    public float limiteDownY, limiteUpY;


    [Header("Bridge config")]
    public float velBridge;
    public float destroyBridgePos;
    public float instaciaBridgeFloat;
    [SerializeField]
    public Transform bridgeprefa;

    [Header("Barril Config")]
    [SerializeField]
    public GameObject barril;
    public float posBarrilUp, posBarrilDown;
    public float barrilIncremento;
    //[HideInInspector]
    public float barrilSpeed = 2;
    public int SpawnSeconds;
    public bool instancia;
    private int rand, order;
    private float pos_Bar;

    [Header("Pontuação Config.")]
    public bool pontuation;
    public Text textPontos;
    public float Score = 0;

    [Header("FX Sound")]
    public AudioSource fxSource;
    public AudioClip fxSound;









    void Start()
    {

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        StartCoroutine(BarrilInstantiate());
    }

    // Update is called once per frame
    void Barril()
    {
        rand = UnityEngine.Random.Range(0, 100);

        if (rand > 50)
        {
            pos_Bar = posBarrilDown;
            order = 3;

        }
        else
        {
            pos_Bar = posBarrilUp;
            order = 2;
        }


        instancia = false;

    }

    IEnumerator BarrilInstantiate()
    {
        yield return new WaitForSeconds(SpawnSeconds);

        Barril();

        if (instancia == false)
        {

            instancia = true;
             GameObject temp = Instantiate(barril, new Vector3(barril.transform.position.x, pos_Bar, barril.transform.position.z), Quaternion.identity) as GameObject;
             temp.GetComponent<SpriteRenderer>().sortingOrder = order;
        }



        StartCoroutine("BarrilInstantiate");
    }
}

