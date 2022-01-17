using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadTextFish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer myrenderer = GetComponent<Renderer>();
        Texture2D photo = LoadPNG(Application.dataPath + "/ecailles.png");
        photo = rotateTexture(photo, false);

        myrenderer.material.mainTextureOffset = new Vector2(-1, 10);
        myrenderer.material.mainTexture = photo;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }

    Texture2D rotateTexture(Texture2D originalTexture, bool clockwise)
    {
        Color32[] original = originalTexture.GetPixels32();
        Color32[] rotated = new Color32[original.Length];
        int w = originalTexture.width;
        int h = originalTexture.height;

        int iRotated, iOriginal;

        for (int j = 0; j < h; ++j)
        {
            for (int i = 0; i < w; ++i)
            {
                iRotated = (i + 1) * h - j - 1;
                iOriginal = clockwise ? original.Length - 1 - (j * w + i) : j * w + i;
                rotated[iRotated] = original[iOriginal];
            }
        }

        Texture2D rotatedTexture = new Texture2D(h, w);
        rotatedTexture.SetPixels32(rotated);
        rotatedTexture.Apply();
        return rotatedTexture;
    }
}
