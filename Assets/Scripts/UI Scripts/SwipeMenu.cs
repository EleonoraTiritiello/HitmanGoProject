using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HitmanGO
{
    public class SwipeMenu : MonoBehaviour
    {
        #region Public Variables

        public GameObject ScrollBar, LeftDot, MidDot, RightDot;
        float scroll_pos = 0;
        float[] pos;
        #endregion

        #region Unity Callbacks

        void Update()
        {
            Swiper();
        }

        #endregion

        #region Swiper
        void Swiper()
        {
            pos = new float[transform.childCount];

            float distance = 1f / (pos.Length - 1f);

            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = distance * i;

            }
            if (Input.GetMouseButton(0))
                scroll_pos = ScrollBar.GetComponent<Scrollbar>().value;
            else
            {

                for (int i = 0; i < pos.Length; i++)
                {
                    if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                    {
                        ScrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(ScrollBar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                        if (pos[i] == 0)
                        {
                            LeftDot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                            MidDot.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                            RightDot.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                        }
                        else
                        if (pos[i] == 0.5)
                        {
                            LeftDot.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                            MidDot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                            RightDot.GetComponent<Image>().color = new Color32(0, 0, 0, 255);

                        }
                        else
                        if (pos[i] == 1)
                        {
                            LeftDot.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                            MidDot.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                            RightDot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                        }
                    }
                }
            }
        }

        #endregion

    }
}
