using UnityEngine;
using System.Collections;

public class lineRendererScript : MonoBehaviour {
    public LineRenderer line;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 pos;
    private float distance;
    private bool isDrawn;
    private GameObject hud;

    // Use this for initialization
    void Start () {
        hud = GameObject.Find("Canvas");
	}

    // Update is called once per frame
    void Update()
    {
        collision();
        if (Input.GetMouseButtonDown(0))
        {
            pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);

            startPosition = pos;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);

            endPosition = pos;
            distance = Vector3.Distance(startPosition, endPosition);
            if (distance <= 4)
            {
                line.SetPosition(0, startPosition);
                line.SetPosition(1, endPosition);
                isDrawn = true;
            }
        }
    }

    private void collision()
    {
        if (isDrawn)
        {
            RaycastHit2D hit = Physics2D.Raycast(endPosition, startPosition - endPosition, 4);
            Debug.DrawRay(endPosition, startPosition - endPosition, Color.green);
            if (hit.collider != null && isDrawn)
            {
                line.SetPosition(0, new Vector3(0, 0));
                line.SetPosition(1, new Vector3(0, 0));
                Destroy(hit.collider.gameObject);
                hud.GetComponent<HUD>().addScore(10);
                isDrawn = false;
            }
        }
    }
}
