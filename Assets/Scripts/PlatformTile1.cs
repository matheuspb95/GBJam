using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class PlatformTile1 : Tile  {
	public Sprite[] m_Sprites;
    public Sprite m_Preview;

	public override void RefreshTile(Vector3Int location, ITilemap tilemap)
    {
        for (int yd = -1; yd <= 1; yd++)
            for (int xd = -1; xd <= 1; xd++)
            {
                Vector3Int position = new Vector3Int(location.x + xd, location.y + yd, location.z);
                if (IsThisTile(tilemap, position))
                    tilemap.RefreshTile(position);
            }
    }

	public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        if(!IsThisTile(tilemap, location + Vector3Int.up))
        {
            tileData.sprite = m_Sprites[1];
        } else {
            tileData.sprite = m_Sprites[0];
        }
    }

	private bool IsThisTile(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }

	#if UNITY_EDITOR
	// The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/PlatformTile1")]
    public static void CreateRoadTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Platform Tile1", "New Platform Tile1", "Asset", "Save Platform Tile1", "Assets");
        if (path == "")
            return;
    AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<PlatformTile1>(), path);
    }
	#endif
}
