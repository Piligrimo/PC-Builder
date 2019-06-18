using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int type;
    DragAndDrop dragAndDrop;
    bool isPuttedHere;
    // Start is called before the first frame update
    void Start()
    {
        dragAndDrop = Camera.main.GetComponent<DragAndDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isPuttedHere)
        {
            dragAndDrop.draggedItem.transform.position = transform.position;
            dragAndDrop.draggedItem.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetMouseButtonUp(0) && isPuttedHere)
        {
            if (type == dragAndDrop.draggedItem.GetComponent<Part>().type)
            {
                dragAndDrop.draggedItem.GetComponent<Rigidbody>().isKinematic = true;
                dragAndDrop.draggedItem.GetComponent<Collider>().enabled = false;
                dragAndDrop.draggedItem.GetComponent<Part>().onItsPlace = true;
                GetComponent<Collider>().enabled = false;
                enabled = false;
                GetComponentInParent<Plate>().CheckIfComplited();
            }
            else
            {
                dragAndDrop.isPutted = false;
                isPuttedHere = false;
            }
        }
    }

    public void TryToPut(bool Dir)
    {
        if (dragAndDrop.isPutted^Dir)
        {
            dragAndDrop.isPutted = Dir;
            isPuttedHere = Dir;
        }
    }

}
