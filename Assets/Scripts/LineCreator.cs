using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    int vertexCount = 0; //It simply counts how many vertexs are in the line.
    bool mouseDown = false; //This will detect whenever we click on the mouse.
    LineRenderer line; //Get reference from Component.(Get access to 'LineRenderer' Component)

    void Awake()
    {
        line = GetComponent<LineRenderer>(); //Get the component
        line.startColor = Color.yellow;
        line.endColor = Color.red;
        line.startWidth = 0.3f;
        line.endWidth = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Input.GetMouseButtonDown(0) - This will be invoked when user clicks with the left mouse button.
            mouseDown = true; //Allow to move to the next logic
        }

        if (mouseDown)
        {
            //Line Renderer logics begin here.

            //line.SetVertexCount(vertexCount + 1); //When user clicks, increment the number of vertextCount. -  in other words, create lines.
            line.positionCount = vertexCount + 1;

            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Input.mousePosition returns the value of position. In other words, just get the value of mouse position


            line.SetPosition(vertexCount, mousePos); //move the position of the line, according to the position of the mouse.
            vertexCount++;
            //Whenever the mouse is down, we will create the line and increment lines 
            //and we are moving the position of the line according to the position of our mouse.

        }

        //we need to delete this mouse position and the line when the mouse button goes up.
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            vertexCount = 0;

            //line.SetVertexCount(0);
            line.positionCount = 0; //Remove all the lines.
            
        }
    }
}
