using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using static DoorScript;

public class DoorController : MonoBehaviour
{
    public DoorControls controls = new DoorControls();
    public AnimNames AnimationNames = new AnimNames();
    Animation doorAnimation;
    bool Opened = false;

    [Serializable]
    public class AnimNames //names of the animations, which you use for every action
    {
        public string OpeningAnim = "Door_open";
        public string LockedAnim = "Door_locked";
    }

    void Start()
    {
        doorAnimation = GetComponent<Animation>();

        // ќткрываем дверь медленно через 5 секунд
        Invoke("OpenDoor", 5f);

        // «акрываем дверь быстро через 3 секунды после открыти€
        Invoke("CloseDoor", 8f);
    }

    void OpenDoor()
    {
        doorAnimation.Play(AnimationNames.OpeningAnim);
        doorAnimation[AnimationNames.OpeningAnim].speed = controls.openingSpeed;
        doorAnimation[AnimationNames.OpeningAnim].normalizedTime = doorAnimation[AnimationNames.OpeningAnim].normalizedTime;
        Opened = true;

    }

    void CloseDoor()
    {
        if (doorAnimation[AnimationNames.OpeningAnim].normalizedTime < 0.98f && doorAnimation[AnimationNames.OpeningAnim].normalizedTime > 0)
        {
            doorAnimation[AnimationNames.OpeningAnim].speed = -controls.closingSpeed;
            doorAnimation[AnimationNames.OpeningAnim].normalizedTime = doorAnimation[AnimationNames.OpeningAnim].normalizedTime;
            doorAnimation.Play(AnimationNames.OpeningAnim);
        }
        else
        {
            doorAnimation[AnimationNames.OpeningAnim].speed = -controls.closingSpeed;
            doorAnimation[AnimationNames.OpeningAnim].normalizedTime = controls.closeStartFrom;
            doorAnimation.Play(AnimationNames.OpeningAnim);
        }
        if (doorAnimation[AnimationNames.OpeningAnim].normalizedTime > controls.closeStartFrom)
        {
            doorAnimation[AnimationNames.OpeningAnim].speed = -controls.closingSpeed;
            doorAnimation[AnimationNames.OpeningAnim].normalizedTime = controls.closeStartFrom;
            doorAnimation.Play(AnimationNames.OpeningAnim);
        }
        Opened = false;
    }
}

