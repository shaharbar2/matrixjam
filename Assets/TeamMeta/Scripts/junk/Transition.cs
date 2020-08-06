using System.Collections;
using UnityEngine;

using Basic_Matrix;

public class Transition : MonoBehaviour
{
    [SerializeField]
    private float transitionTime = 1000;
    [SerializeField]
    private Exit exit = null;
    [SerializeField]
    private int numberOfScenes = 0;

    public float TransitionTime
    {
        get { return transitionTime; }
    }

    void Awake()
    {
        //numberOfScenes = numberOfScenes > 0 ? numberOfScenes : USceneManager.sceneCountInBuildSettings - 2;
        //exit.connect_to = new Connection() { scene_num = 1 + Random.Range(0, numberOfScenes), target_portal_num = 0 };
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(transitionTime * 1e-3f);
        //randomExit.EndLevel();
    }
}
