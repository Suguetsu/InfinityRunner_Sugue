using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D playerRb;

    [SerializeField]
    public GameController _GM;
    private float moveX, moveY;

    private float UpMove;
    private bool playerDown, playerUp;
    public float speedTouch;

    void Start()
    {

        playerRb = GetComponent<Rigidbody2D>();



    }

    // Update is called once per frame
    void Update()
    {

        // armazena os comandos de entrada





        if (playerUp)
        {
            playerDown = false;


            speedTouch++;
            moveY = (Mathf.Clamp(speedTouch, 0, 2));
            Debug.Log("cima: " + moveY);
        }
        else if (playerDown)
        {
            playerUp = false;

            speedTouch++;
            moveY = -(Mathf.Clamp(speedTouch, 0, 2));

            Debug.Log("baixo: " + moveY);
        }
        else
        {
            moveX = Input.GetAxisRaw("Horizontal") * _GM.velocidade;
            moveY = Input.GetAxisRaw("Vertical") * _GM.velocidade;
        }


        //responsável por atribuir controle ao jogador
        playerRb.velocity = new Vector2(moveX, moveY * _GM.velocidade);
        //limita os movimentos
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, _GM.limiteBackX, _GM.limiteFrontX), Mathf.Clamp(transform.position.y, _GM.limiteDownY, _GM.limiteUpY));




    }



    public void BTN_PlayerUp()
    {
        playerUp = true;
        playerDown = false;




    }


    public void BTN_PlayerDown()
    {
        playerDown = true;
        playerUp = false;




    }




}
