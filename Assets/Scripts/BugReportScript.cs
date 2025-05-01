using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugReportScript : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(openBugReport);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void openBugReport()
    {
        Application.OpenURL("https://forms.gle/ZXg4X2Xna1WVqUpV6");
    }
}
