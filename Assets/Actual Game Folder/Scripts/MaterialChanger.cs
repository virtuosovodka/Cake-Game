using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MaterialChanger : MonoBehaviour
{
    
    //VideoPlayer videoPlayer;
    public Ipad ipad;
    //public bool changeMaterial;
    public Material[] mats;
    public MeshRenderer meshRenderer;
    float changeMaterialCoolDown = 1.5f;
    float changeMaterialCoolDownTimer;

    private void Awake()
    {
        mats = GetComponent<Renderer>().materials;
        
        changeMaterialCoolDownTimer = changeMaterialCoolDown;

        meshRenderer = GetComponent<MeshRenderer>();
        //videoPlayer = GetComponent<VideoPlayer>();
    }
    
  
}
