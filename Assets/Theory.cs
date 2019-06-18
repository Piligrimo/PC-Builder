using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Theory : MonoBehaviour
{
    public GameObject panel,item;
    public Text partname, description;
    public RaycastHit hit;
    Vector3 itemsPlace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        Debug.DrawLine(transform.position, ray.direction * 15, Color.red);
        if (Input.GetMouseButtonDown(0) )
        {
            if (hit.collider != null && !panel.activeSelf)
            {
                if (hit.collider.gameObject.CompareTag("Part"))
                {
                    item = hit.collider.gameObject;
                    panel.SetActive(true);
                    partname.text = item.GetComponent<Part>().partname;
                    description.text = item.GetComponent<Part>().description;
                    itemsPlace = item.transform.position;
                    item.transform.position = new Vector3(0.15f,1.35f,-0.5f);
                }
            }
        }
        if (Input.GetMouseButton(0) && panel.activeSelf)
        {
            item.transform.Rotate(10*Input.GetAxis("Mouse Y"), 10*Input.GetAxis("Mouse X"),0);
        }
    }
    public void Close()
    {
        
        item.transform.position = itemsPlace;
        item.transform.rotation = Quaternion.Euler(0,0,0);
        panel.SetActive(false);
    }
}
