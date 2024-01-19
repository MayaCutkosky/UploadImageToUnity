using UnityEngine;
using System.IO;

using utils;

public class UploadNewImage : MonoBehaviour
{
    private GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("started main script");
    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        OpenMenu();

    }

    private void OpenMenu()
    {
        //Probably not best way to do this...
        Menu = new GameObject();
        var menuScript = Menu.AddComponent<MenuScript>();
        MenuScript.menuAction += LoadImage; //Tell menu to run load image before it closes.
        
        
    }
    private void LoadImage(string filename)
    { 
        Texture2D tex = new(16, 16);

        //Load image
        byte[] im = File.ReadAllBytes(filename);


        // Load data into the texture and upload it to the GPU.
        //ToDo: Error checking
        tex.LoadImage(im);

        //Set as texture in our object
        GetComponent<Renderer>().material.mainTexture = tex;

    }
}
