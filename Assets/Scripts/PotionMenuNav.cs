using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionMenuNav : MonoBehaviour {

    public GameObject[] buttons;
    public int x;
    [HideInInspector] public Canvas potionCanvas;
    [HideInInspector] public EventSystem eventSystem;
    public GameObject currentFocus;
    [HideInInspector] public float timer;


	// Use this for initialization
	void Start () {
        potionCanvas = transform.parent.GetComponent<Canvas>();
        currentFocus = buttons[0];
        eventSystem = EventSystem.current;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!potionCanvas.enabled)
            return;
        if (timer > 0.3f)
        {
            float y = Input.GetAxis("Vertical");
            if(y != 0)
                Navigate(y);
            if(Input.GetButtonDown("Submit"))
            {
                eventSystem.currentSelectedGameObject.GetComponent<Button>().OnSubmit(new BaseEventData(EventSystem.current));
            }
            return;
        }
        timer += Time.deltaTime;
	}

    void Navigate(float y)
    {
        timer = 0;

        if(y > 0)
        {
            x--;
        }
        else if(y < 0)
        {
            x++;
        }

        
        if(x > 7)
        {
            x = 0;
        }
        if(x < 0)
        {
            x = 7;
        }
        
        eventSystem.SetSelectedGameObject(buttons[x], new BaseEventData(EventSystem.current));
    }
}
