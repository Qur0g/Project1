using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    private PostProcessProfile postProcess; 

    void Start()
    {
        postProcess = gameObject.GetComponent<PostProcessVolume>().profile;

        postProcess.GetSetting<ChromaticAberration>().enabled.value = false;
        postProcess.GetSetting<Bloom>().enabled.value = false;
    }

    public void SettingsToogle(bool flag)
    {
        postProcess.GetSetting<ChromaticAberration>().enabled.value = flag;
        postProcess.GetSetting<Bloom>().enabled.value = flag;
    }
}
