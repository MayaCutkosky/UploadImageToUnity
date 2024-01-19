using UnityEngine;
//using UnityEngine.Events;
public class MenuScript : MonoBehaviour
{
    //public UnityEvent finishedInput;
    public delegate void MenuAction(string filename);
    public static MenuAction menuAction;
    public string stringToEdit = "";
    private Rect inputScreen = new(100, 100, 200, 20);
    public void Start()
    {
        Debug.Log("Started Menu script");
        
    }
    void OnGUI()
    {
        Event e = Event.current;
        char c = e.character;
        if ((c == '\n') || (c == '\r'))
        {
            Debug.Log("Done Typing!");
            //finishedInput.Invoke();
            CloseMenu();
        }
        else
        {
            stringToEdit = GUI.TextField(inputScreen, stringToEdit, 100);
        }
     
    }
    public void CloseMenu()
    {

        //Copy over stringToEdit
        menuAction(stringToEdit);

        //destroy menu object after 5 seconds (To give everything else time.
        Destroy(gameObject, 5);
    }
}