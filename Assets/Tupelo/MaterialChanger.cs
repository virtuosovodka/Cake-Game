using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MaterialChanger : MonoBehaviour
{
    public Material newMaterial;
    public VideoPlayer videoPlayer;
    public Ipad ipad;
    public bool changeMaterial = false;

    private void Awake()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        videoPlayer = GetComponent<VideoPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        Material oldMaterial = meshRenderer.material;
        Debug.Log("Applied Material: " + oldMaterial.name);
        meshRenderer.material = oldMaterial;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changeMaterial)
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            
            meshRenderer.material = newMaterial;
        }
    }
}
