using UnityEngine;

public class Room1 : MonoBehaviour
{
    //public static bool isOpen = false;
    public static bool check = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stepped.Step)
        {
            anim.SetBool("isOpen", true);
            //Stepped.Step = false;
        }
    }
}
