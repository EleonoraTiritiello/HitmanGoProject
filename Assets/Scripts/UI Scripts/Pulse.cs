using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HitmanGO
{
    public class Pulse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        private void OnMouseOver()
        {
            GetComponent<Animator>().enabled = true;
        }

        private void OnMouseExit()
        {
            //GetComponent<Animator>().enabled = false;
            transform.localScale = new Vector3(1, 1, 1);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}