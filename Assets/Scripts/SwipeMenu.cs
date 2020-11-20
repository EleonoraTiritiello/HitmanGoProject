using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HitmanGO
{
    public class SwipeMenu : MonoBehaviour
    {
        #region Public Variables

        public GameObject ScrollBar;
        float scroll_pos = 0;
        float[] pos;
        #endregion

        #region Unity Callbacks
        void Update()
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
                        ScrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(ScrollBar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }
        #endregion
    }
}
