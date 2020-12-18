using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Renderer     mRenderer;

    public float        incrementoOffset;
    private float       offset;
    public float        speed;

    public string       materialOffsetString;
    public int          materiaSortingNumber;
    private Material    currentMaterial;

    [SerializeField]
    public GameController _Gm;



    void Start()
    {


        mRenderer = GetComponent<MeshRenderer>();
        currentMaterial = mRenderer.material;


        mRenderer.sortingLayerName = materialOffsetString;
        mRenderer.sortingOrder = materiaSortingNumber;




    }

    // Update is called once per frame
    void Update()
    {
        offset += incrementoOffset * speed;

        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * Time.fixedDeltaTime, 0));

    }
}
