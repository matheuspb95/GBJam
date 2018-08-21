using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class PlatformTile : Tile  {
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
        int result = 0;
        if(IsThisTile(tilemap, location + Vector3Int.down))
		    result += 1;
        if(IsThisTile(tilemap, location + Vector3Int.up))
		    result += 2;
        if(IsThisTile(tilemap, location + Vector3Int.left))
		    result += 4;    
        if(IsThisTile(tilemap, location + Vector3Int.right))
		    result += 8;
        //if(result > 8)
            //result = 0;

        tileData.sprite = m_Sprites[result];        
    }

	private bool IsThisTile(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }

	#if UNITY_EDITOR
	// The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/PlatformTile")]
    public static void CreateRoadTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Platform Tile", "New Platform Tile", "Asset", "Save Platform Tile", "Assets");
        if (path == "")
            return;
    AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<PlatformTile>(), path);
    }
	#endif
}
