using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MaterialChanger : MonoBehaviour
{
    
    public VideoPlayer videoPlayer;
    public Ipad ipad;
    public bool changeMaterial;
    
    public Renderer r;
    public Material[] mats;
    MeshRenderer meshRenderer;
    float changeMaterialCoolDown = 1.5f;
    float changeMaterialCoolDownTimer;

    private void Awake()
    {
        mats = GetComponent<Renderer>().materials;
        
        changeMaterialCoolDownTimer = changeMaterialCoolDown;

        meshRenderer = GetComponent<MeshRenderer>();
        videoPlayer = GetComponent<VideoPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeMaterialCoolDownTimer -= Time.deltaTime;
        if (changeMaterial && changeMaterialCoolDownTimer<0)
        {

            if (meshRenderer.material == mats[0])
            {

                meshRenderer.material = mats[1];
                changeMaterial = false;
                changeMaterialCoolDownTimer = changeMaterialCoolDown;
            }
            else
            {

                meshRenderer.material = mats[0];
                changeMaterial = false;
                changeMaterialCoolDownTimer = changeMaterialCoolDown;
            }
        }
    }
  
}
