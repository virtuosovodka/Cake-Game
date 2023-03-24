using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class Ipad : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Material playButtonMaterial;
    public Material pauseButtonMaterial;
    public Renderer screenRenderer;
    public VideoClip[] videoClips;
    public GameObject playVideo1;
    public GameObject playPause;
    public GameObject playVideo2;
    public VideoClip[] materials;

    private int materialIndex;
    private int videoClipIndex;
    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.clip = videoClips[0];
        //Screen.material = materials[1]
        //make an list the same as the video clip code, on trigger enter with any trigger to switch back to material 0 from the black sreen, on trigger compare with the back button and switch to material 1
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void SwitchingMaterial()
    {
        materialIndex++;
}

    public void SwitchingClip()
    {
        //int videoClipIndex;

        videoClipIndex++;

        if(videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }

        videoPlayer.clip = videoClips[videoClipIndex];
        videoPlayer.Play();
    }

    public void PlayPause(VideoClip _clip)
    {
        videoPlayer.clip = _clip;

        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            //screenRenderer.material = playButtonMaterial;
        }
        else
        {
            videoPlayer.Play();
            //screenRenderer.material = pauseButtonMaterial;
        }

    }
}
