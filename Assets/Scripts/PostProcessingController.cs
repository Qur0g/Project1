using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    private PostProcessProfile postProcess; 

    void Start()
    {
        postProcess = GameObject.Find("PostProcessing").GetComponent<PostProcessVolume>().profile;

        postProcess.GetSetting<ChromaticAberration>().enabled.value = false;
        postProcess.GetSetting<LensDistortion>().enabled.value = false;
    }

    public void SettingsToogle(bool flag)
    {
        postProcess.GetSetting<ChromaticAberration>().enabled.value = flag;
        postProcess.GetSetting<LensDistortion>().enabled.value = flag;
    }
}
