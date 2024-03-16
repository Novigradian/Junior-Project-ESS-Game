using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClicker : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;

    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        gameManager = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {

            if (Input.GetMouseButtonDown(0) && hit.transform.gameObject.CompareTag("Outlineable"))
            {
                //Debug.Log(hit.transform.name);
                gameManager.ApplyTile(hit.transform.gameObject.GetComponent<TileManager>());
            }
        }
    }
}
