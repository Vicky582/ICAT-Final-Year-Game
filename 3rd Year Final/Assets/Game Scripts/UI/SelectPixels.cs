using System.Collections;
using UnityEngine;

public class SelectPixels : MonoBehaviour
{
    public GameObject selectPixels;

    public void SelectPixel()
    {
        selectPixels.SetActive(true);
    }

    public void DeselectPixel()
    {
        selectPixels.SetActive(false);
    }
}
