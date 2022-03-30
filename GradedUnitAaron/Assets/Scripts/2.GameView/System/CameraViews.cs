using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViews : MonoBehaviour
{
    public Transform m_Camera;

    public GameObject fox;
    private bool changeView;
    private int view;

    // Start is called before the first frame update
    void Start()
    {

        //Automatically start of Over Head
        view = 1;
        //Make sure it does
        changeView = true;
    }

    // Update is called once per frame
    void Update()
    {
        //F4 will change the view
        if (Input.GetKeyDown(KeyCode.F4) && !changeView)
        {
            view++;
            changeView = true;
        }

        //This makes sure the game is not setting the camera every frame
        if (changeView)
        {
            ChangeView();
        }
            
    }

    #region Views
    void FirstPersonView()
    {
        //Hide Fox to save resources
        fox.SetActive(false);
        m_Camera.localRotation = Quaternion.Euler(0f, 0f, 0f);
        m_Camera.localPosition = new Vector3(0f, 0.1f, 1f);
        Debug.Log("First");
    }
    

    void OverHeadCamera()
    {
        fox.SetActive(true);
        m_Camera.localRotation = Quaternion.Euler(75f,0f,0f);
        m_Camera.localPosition = new Vector3(0f, 10f, -1f);
        Debug.Log("Over");
    }

    void ThirdPersonView()
    {
        m_Camera.localRotation =Quaternion.Euler(25f,0f,0f);
        m_Camera.localPosition = new Vector3(-1.1f, 1.3f, -1f);
        Debug.Log("Third");
    }
    #endregion

    #region View Changer
    void ChangeView()
    {
        if (view > 2){ view = 0; }

        switch (view)
        {
            case 0:
                FirstPersonView();
                changeView = false;
                break;
            case 1:
                OverHeadCamera();
                changeView = false;
                break;
            case 2:
                ThirdPersonView();
                changeView = false;
                break;
        }
    }
    #endregion

}
