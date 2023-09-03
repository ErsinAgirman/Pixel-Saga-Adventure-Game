using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkManager : MonoBehaviour
{
    public void OpenLinks(string link)
    {
        Application.OpenURL(link);
    }
}
