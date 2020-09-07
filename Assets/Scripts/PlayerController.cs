using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerConfig playerConfig;

    public CharacterController cc;

    float walkSpeed;
    float rotateSpeed;
    
    public Transform cam;
    
    float ver;
    
    public Transform myEmote;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        cc = GetComponent<CharacterController>();
  
        cam = Camera.main.transform;

        walkSpeed = playerConfig.walkSpeed;
        rotateSpeed = playerConfig.rotateSpeed;

        UIController.uIController.myPlayer = this;

        myEmote = transform.GetChild(0);
    }
    
    void Update()
    {
        ver = Input.GetAxisRaw("Vertical");
        
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime, 0);

        var forwardVector = transform.forward.normalized * walkSpeed * Time.deltaTime * ver;
        
        cc.Move(forwardVector);


        if(Input.GetKeyDown(KeyCode.Tab))
        {
            UIController.uIController.ToggleEmoteMenu();
        }

        var camPos = (transform.forward.normalized * - playerConfig.cameraDistance) + transform.position;
        camPos.y = playerConfig.cameraHeight;
        cam.position = camPos;
        cam.eulerAngles += new Vector3(playerConfig.cameraTiltSpeed * -Input.GetAxis("Mouse Y") * Time.deltaTime, 0, 0);
        cam.transform.eulerAngles = new Vector3(Mathf.Clamp(cam.transform.eulerAngles.x, playerConfig.cameraTiltRange.x, playerConfig.cameraTiltRange.y), transform.eulerAngles.y, 0);
    }

}
