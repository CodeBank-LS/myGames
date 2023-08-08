using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour
{
    public Text startText;

    private void Start()
    {
        // set text
        startText.enabled = true;
    }

    private void Update()
    {
        // if pressed Space, hide text and start game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startText.enabled = false;
            // start game
        }
    }
}
