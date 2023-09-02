using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    bool isActive = false;
    public void ActivatePanel(GameObject panel)
    {
        isActive = !isActive;
        panel.SetActive(isActive);
    }
}
