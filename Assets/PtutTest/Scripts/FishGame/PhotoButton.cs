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
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        webcamTexture = new WebCamTexture();
        Debug.Log(webcamTexture.deviceName);
        screenrenderer = GameObject.Find("WebCamScreen").GetComponent<Renderer>();
        screenrenderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        Texture2D photo = new Texture2D(webcamTexture.width, webcamTexture.height);
        photo.SetPixels(webcamTexture.GetPixels());
        photo.Apply();
        screenrenderer.material.mainTexture = photo;

        byte[] bytes = photo.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath+"/ecailles.png", bytes);
        webcamTexture.Stop();
        SceneManager.LoadScene("SceneFish");

        Debug.Log("You have clicked the button!");
        
    }
}
