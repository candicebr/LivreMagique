using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhotoButton : MonoBehaviour
{

    //public Button MyButtonPhoto;
    WebCamTexture webcamTexture;
    Renderer screenrenderer;

    // Start is called before the first frame update
    void Start()
    {
        webcamTexture = new WebCamTexture();
        screenrenderer = GetComponent<Renderer>();
        screenrenderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LiveCam()
    {
        screenrenderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    public void TakePicture()
    {
        Texture2D photo = new Texture2D(webcamTexture.width, webcamTexture.height);
        photo.SetPixels(webcamTexture.GetPixels());
        photo.Apply();
        screenrenderer.material.mainTexture = photo;

        byte[] bytes = photo.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath+"/ecailles.png", bytes);
        webcamTexture.Stop();
    }
}
