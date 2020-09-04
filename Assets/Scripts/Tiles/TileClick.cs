using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Tiles
{
    public abstract class TileClick : MonoBehaviour
    {

        protected abstract void OnMouseEnter();
        protected abstract void OnMouseExit();
        protected abstract void OnMouseDown();

        protected bool MouseOverUI()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}