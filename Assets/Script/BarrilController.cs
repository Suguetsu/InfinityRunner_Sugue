using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

using UnityEngine;

public class BarrilController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public GameController _Gm;
    private Rigidbody2D barRb;


    void Start()
    {

        _Gm = FindObjectOfType(typeof(GameController)) as GameController;

       

        barRb = GetComponent<Rigidbody2D>();
        barRb.velocity = new Vector2(_Gm.barrilSpeed * _Gm.barrilIncremento, 0);

        _Gm.pontuation = true;


    }

    private void Update()
    {

        if (_Gm.pontuation && transform.position.x < _Gm.player.position.x)
        {
            _Gm.pontuation = false;

            _Gm.Score += 15;
            _Gm.textPontos.text ="Score:"+ _Gm.Score;

            Debug.Log("passei");

            _Gm.velBridge -= 0.1f;
            _Gm.barrilSpeed -= 0.1f;

            _Gm.fxSource.PlayOneShot(_Gm.fxSound);
            
        }

        if (transform.position.x <= _Gm.destroyBridgePos)
        {
            Destroy(this.gameObject);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("GameOver");
    }




}
