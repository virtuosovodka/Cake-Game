using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MaterialChanger : MonoBehaviour
{
    public Material blackMaterial;
    public Material movieMaterial;
    public VideoPlayer videoPlayer;
    public Ipad ipad;
    public bool changeMaterial;
    public bool changeMaterialMovie;
    public Renderer r;
    public Material[] mats;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        mats = GetComponent<Renderer>().materials;
        Debug.Log(mats[0]);
        //mats[0] = movieMaterial;
        // mats[1] = blackMaterial;
        //GetComponent<Renderer>().materials = mats;

        meshRenderer = GetComponent<MeshRenderer>();
        videoPlayer = GetComponent<VideoPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer.material = mats[1];
        //Debug.Log("Applied Material: " + oldMaterial.name);
        //meshRenderer.material = oldMaterial;

    }

    // Update is called once per frame
    void Update()
    {
        if (changeMaterial)
        {


            meshRenderer.material = mats[1];
        }
        if (changeMaterialMovie)
        {
            meshRenderer.material = mats[0];
        }
    }
  
}
