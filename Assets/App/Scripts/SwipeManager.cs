using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    [SerializeField] private float timerSec;
   // [SerializeField] private Renderer rend;

    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown, running;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;
    private float timer;
    //[SerializeField] private Texture texture;


    private void Update()
    {
        swipeDown = swipeUp = swipeLeft = swipeRight = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
               // rend.material.mainTextureScale = new Vector2((texture.width*Time.deltaTime), (texture.height * Time.deltaTime));

                //StartCoroutine(ChangeTextureScale());

                tap = true;
                startTouch = Input.touches[0].position;
            }

            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                //StartCoroutine(ResetTextureScale());

                Reset();
            }
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        //Did we cross the distance?
        if (swipeDelta.magnitude > 100 && !running)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }
        else
        {

            if (timer > timerSec)
            {
                running = true;
                return;
            }

            if (tap)
            {
                timer += Time.deltaTime;
            }

        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
        timer = 0;
        tap = false;
        running = false;
    }

  /*  private IEnumerator ChangeTextureScale()
    {
        yield return new WaitForSeconds(0.2f);

        rend.material.mainTextureScale = new Vector2((texture.width / 0.5f), (texture.height / 0.5f));

    }

    private IEnumerator ResetTextureScale()
    {
        yield return new WaitForSeconds(0.2f);

        rend.material.mainTextureScale = new Vector2((0.8f * 0.5f), (1.6f * 0.5f));
    }

    */
}
