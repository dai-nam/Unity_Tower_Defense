using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Tiles
{
    public class PathTileClick : TileClick
    {
        PathTile pathTile;
        public delegate void PathTileClicked(PathTile tile);
        public static event PathTileClicked OnPathTileClicked;

        private void Awake()
        {
            pathTile = GetComponentInParent<PathTile>();
        }

        protected override void OnMouseDown()
        {
            if (base.MouseOverUI())
            {
                return;
            }

            print(pathTile.name+" clicked");
            OnPathTileClicked?.Invoke(pathTile);
        }

        protected override void OnMouseEnter()
        {
            if (base.MouseOverUI())
            {
                return;
            }
        }

        protected override void OnMouseExit()
        {

        }
    }
}