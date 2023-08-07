
using UnityEngine;

public class passTrigger : MonoBehaviour
{
    public Animation LevelTransitionAnimator1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            LevelTransitionAnimator1.Play("level0End");
        }
    }
}
