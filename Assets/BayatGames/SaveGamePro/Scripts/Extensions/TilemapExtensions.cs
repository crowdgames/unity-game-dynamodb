#if UNITY_2017_2_OR_NEWER
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace BayatGames.SaveGamePro.Extensions
{

    public static class TilemapExtensions
    {

        /// <summary>
        /// Gets all the tiles from tilemap.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tilemap"></param>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static T[] GetTiles<T>(this Tilemap tilemap) where T : TileBase
        {
            List<T> tiles = new List<T>();
            for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
            {
                for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
                {
                    Vector3Int position = new Vector3Int(x, y, 0);
                    T tile = tilemap.GetTile<T>(position);
                    if (tile != null)
                    {
                        tiles.Add(tile);
                    }
                }
            }
            return tiles.ToArray();
        }

        /// <summary>
        /// Gets all the tiles from the tilemap and outputs an array of tiles position.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tilemap"></param>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static T[] GetTiles<T>(this Tilemap tilemap, out Vector3Int[] positions) where T : TileBase
        {
            List<T> tiles = new List<T>();
            List<Vector3Int> positionsList = new List<Vector3Int>();
            for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
            {
                for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
                {
                    Vector3Int position = new Vector3Int(x, y, 0);
                    T tile = tilemap.GetTile<T>(position);
                    if (tile != null)
                    {
                        positionsList.Add(position);
                        tiles.Add(tile);
                    }
                }
            }
            positions = positionsList.ToArray();
            return tiles.ToArray();
        }

    }

}
#endif