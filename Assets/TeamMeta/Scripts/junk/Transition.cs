using System.Collections;
using UnityEngine;

using Basic_Matrix;

public class Transition : MonoBehaviour
{
    [SerializeField]
    private float transitionTime = 1000;
    [SerializeField]
    private int start_sce = 0;

    public float TransitionTime
    {
        get { return transitionTime; }
    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(transitionTime * 1e-3f);
       // SceneManager.SceneMang.LoadRandomScene();
    }


}
