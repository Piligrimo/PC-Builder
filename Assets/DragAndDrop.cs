using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {
    public GameObject draggedItem;
    GameObject slot;
    Camera cam;
    public bool isDraging = false,isPutted;
    public RaycastHit hit;
    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
	}

    // Update is called once per frame
    void Update()
    {
           
        Ray ray =cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        Debug.DrawLine(transform.position,transform.position+ ray.direction*15, Color.yellow);
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Part"))
                {
                    draggedItem = hit.collider.gameObject;
                    isDraging = true;
                    draggedItem.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                    draggedItem.transform.rotation = Quaternion.Euler(0, 0, 0);
                    draggedItem.GetComponent<Collider>().enabled = false;
                }                                
            }
        }

        if (Input.GetMouseButton(0) && isDraging)
        {
            if (hit.collider.gameObject.CompareTag("Slot"))
            {
                Debug.Log("Try");
                if (slot == null)
                {
                    slot = hit.collider.gameObject;
                    slot.GetComponent<Slot>().TryToPut(true);

                }
            }
            else
            {
                if (slot != null)
                {
                    slot.GetComponent<Slot>().TryToPut(false);
                    slot = null;
                }
            }
                if (!isPutted)
            draggedItem.transform.position = hit.point + new Vector3(0, 0.2f, 0);                      
        }
        if (Input.GetMouseButtonUp(0) && isDraging)
        {
            isDraging = false;
            if (!draggedItem.GetComponent<Part>().onItsPlace)
                draggedItem.GetComponent<Collider>().enabled = true;
            draggedItem = null;
        }

    }
}
