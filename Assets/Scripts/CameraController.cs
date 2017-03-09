using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 10f;

    private bool doMovement = true;
    public float minY = 5f;
    public float maxY = 50f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

       /* Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);*/
        if (Input.GetKeyDown(KeyCode.Escape) /*|| !screenRect.Contains(Input.mousePosition)*/)
            doMovement = !doMovement;

        if(!doMovement) 
        {
            return;
        }




        if (Input.GetKey("z") || Input.GetKey("up") /*|| Input.mousePosition.y >= Screen.height - panBorderThickness*/) 
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.GetKey("down")/*|| Input.mousePosition.y <= panBorderThickness*/)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.GetKey("right")/*|| Input.mousePosition.x >= Screen.width - panBorderThickness*/)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("q") || Input.GetKey("left")/*|| Input.mousePosition.x <= panBorderThickness*/)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 50 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
