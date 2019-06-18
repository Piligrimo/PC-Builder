using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Load(int i)
    {
        Application.LoadLevel(i);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
