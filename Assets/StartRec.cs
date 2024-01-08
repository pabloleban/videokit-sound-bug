using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using VideoKit;
using VideoKit.Assets;

public class StartRec : MonoBehaviour
{
    public VideoKitRecorder rec;
    private bool isRecording = false;
    private float audioVolume = 0f;
    public AudioMixer mixer;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 30), "Toggle Recording"))
        {
            if (isRecording)
            {
                rec.StopRecording();
                isRecording = false;
            }
            else
            {
                rec.StartRecording();
                isRecording = true;
            }
        }

        if (GUI.Button(new Rect(10, 50, 150, 30), "Toggle Audio Volume"))
        {
            if (audioVolume == 0f)
            {
                audioVolume = 15f;
            }
            else
            {
                audioVolume = 0f;
            }

            mixer.SetFloat("Volume", audioVolume);
        }
    }

    public void RecFinished(MediaAsset asset){
        System.Diagnostics.Process.Start(asset.path);
    }
}
