using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        //Vector2 scale = LevelElement.scale;
        animator = GetComponent<Animator>();

        //clip1.ClearCurves();

        //curve.AddKey(0.0f, 1.4f);

        /*Keyframe key = curve.keys[0];
        key.value = 103f;
        curve.MoveKey(0, key);
        AnimationUtility.SetEditorCurve(clip1, binding, curve);*/


        AnimationClip clip1;
        //clip1.legacy = false;

        //AnimationCurve xCurve1 = AnimationCurve.Linear(0.0f, 55f, 1.0f, scale.x + 0.1f);
        //AnimationCurve xCurve2 = AnimationCurve.Linear(1.0f, scale.x + 0.1f, 2.0f, scale.x);
        //AnimationCurve yCurve1 = AnimationCurve.Linear(0.0f, 55f, 1.0f, scale.y + 0.1f);
        //AnimationCurve yCurve2 = AnimationCurve.Linear(1.0f, scale.y + 0.1f, 2.0f, scale.y);

        //AnimationCurve xCurve = new AnimationCurve(new Keyframe(0.5f, 1.5f));
        //clip1.SetCurve("")

        //clip1.SetCurve("", typeof(Transform), "Scale.x", xCurve1);
        //clip1.SetCurve("LevelElement", typeof(Transform), "Scale.x", xCurve2);
        //clip1.SetCurve("", typeof(Transform), "Scale.y", yCurve1);
        //Debug.Log(clip1);
        //clip1.SetCurve("LevelElement", typeof(Transform), "Scale.y", yCurve2);

        /*Keyframe[] keys;
        keys = new Keyframe[3];
        keys[0] = new Keyframe(0.0f, 1.4f);
        keys[1] = new Keyframe(1.0f, 1.5f);
        keys[2] = new Keyframe(2.0f, 1.4f);
        AnimationCurve curve = new AnimationCurve(keys);*/
        //clip1.SetCurve("LevelElement Animation", typeof(Transform), "Scale.x", curve);

        Debug.Log(animator.runtimeAnimatorController.animationClips[0]);
        clip1 = animator.runtimeAnimatorController.animationClips[0];

        AnimationCurve curve = AnimationCurve.Linear(0.0f, 0.0f, 2.0f, 2.0f);
        clip1.SetCurve("", typeof(Transform), "Scale.x", curve);

        //AnimatorOverrideController animatorOverrideController = new AnimatorOverrideController();
        //animatorOverrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
        //Debug.Log(animator.runtimeAnimatorController.animationClips[0].name);
        //animator.runtimeAnimatorController.animationClips[0] = clip1;
        //Debug.Log(animator.runtimeAnimatorController.animationClips[0].name);
        //animatorOverrideController["LevelElement Animation"] = clip1;
        //Debug.Log(animatorOverrideController["Default"]);

        //animator.runtimeAnimatorController = animatorOverrideController;
    }
}
