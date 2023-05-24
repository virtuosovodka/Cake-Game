using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class Ipad : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public Player player;
   
    public VideoClip[] videoClips;
  
    //public VideoClip[] materials;
    private int materialIndex;
    private int videoClipIndex;
    
    //bool muted;


    private void Awake()

    {
        videoPlayer = GetComponent<VideoPlayer>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //start with black screen
        videoPlayer.clip = videoClips[1];
       
        //muted = false;
        
    }

    public void SwitchingMaterial()
    {
        materialIndex++;
    }

    public void SwitchingClip()
    {
        //int videoClipIndex;

        videoClipIndex++;

        if (videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }

        videoPlayer.clip = videoClips[videoClipIndex];
        videoPlayer.Play();

        //audio index section

 
    }

    /*
    public void Muting()
    {
        if(player.muted == true)
        {
            videoPlayer.SetDirectAudioMute(h);
        }

        else
        {
            player.muted = false;
        }
    }
  
    */
    public void PlayPause(VideoClip _clip)
    {

        videoPlayer.clip = _clip;
        videoPlayer.Play();

        /*
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            
        }
        else
        {
            videoPlayer.Play();
            
        }

        */


    }
    public VideoClip CurrentClip()
    {

        return videoPlayer.clip;

       
    }

}
