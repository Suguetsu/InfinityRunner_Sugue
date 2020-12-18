using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BridgeController : MonoBehaviour
{


    private Rigidbody2D bridgeRb;

    [SerializeField]
    public GameController _Gm;


    private float bridgePos;

    private bool instantiate;
    // Start is called before the first frame update
    void Start()
    {
        _Gm = FindObjectOfType(typeof(GameController)) as GameController;

        bridgeRb = GetComponent<Rigidbody2D>();
        bridgeRb.velocity = new Vector2(_Gm.velBridge, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= _Gm.destroyBridgePos)
        {
            Destroy(this.gameObject);

        }
        if (transform.position.x <= 0 && instantiate == false)
        {

            SetBridge();
        }






    }


    void SetBridge()
    {

        instantiate = true;
        bridgePos = transform.position.x + _Gm.instaciaBridgeFloat;
        _= Instantiate(_Gm.bridgeprefa, new Vector2(bridgePos, transform.position.y), Quaternion.identity);
        

       

    }
}
