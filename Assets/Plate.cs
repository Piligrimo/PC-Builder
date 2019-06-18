using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject NormalCanv, ComplitedCanv;
    public void CheckIfComplited()
    {
        if (slots.All(slots => !slots.GetComponent<Slot>().enabled))
        {
            NormalCanv.SetActive(false);
            ComplitedCanv.SetActive(true);
        }
    }
}
