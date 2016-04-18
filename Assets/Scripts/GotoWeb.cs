using UnityEngine;
using System.Collections;

public class GotoWeb : MonoBehaviour {

    public void WebLink(string link)
    {
        if(link == null)
        {
            Application.OpenURL("http://ludumdare.com/compo/ludum-dare-3");
        }else
        {
            Application.OpenURL(link);
        }
    }
}
