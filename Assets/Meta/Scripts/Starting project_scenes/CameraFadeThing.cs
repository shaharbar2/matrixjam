using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Transition))]
public class CameraFadeThing : MonoBehaviour
{
    [SerializeField]
    Image backgroundImage = null;
    [SerializeField]
    Gradient backgroundGrad = null;
    float transitionTime;
    float startingTime;

    private void Awake()
    {
        transitionTime = 0.001f * GetComponent<Transition>().TransitionTime;
    }

    private void Start()
    {
        startingTime = Time.time;
    }

    private void Update()
    {
        float time = Mathf.Clamp01((Time.time - startingTime) / transitionTime);
        backgroundImage.color = backgroundGrad.Evaluate(time);
    }
}
