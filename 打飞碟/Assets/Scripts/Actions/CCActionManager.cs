using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, IActionCallback 
{
    public RoundController sceneController;
    public CCFlyAction action;
    public DiskFactory factory;
    
    // Start is called before the first frame update
    protected new void Start()
    {
        sceneController = (RoundController)SSDirector.getInstance().currentSceneController;
        sceneController.actionManager = this;
        factory = Singleton<DiskFactory>.Instance;
    }

    public void SSActionEvent(SSAction source,
        SSActionEventType events = SSActionEventType.Completed,
        int intParam = 0,
        string strParam = null,
        Object objectParam = null) {
            factory.FreeDisk(source.transform.gameObject);
    }

    public void MoveDisk(GameObject disk) {
        action = CCFlyAction.GetSSAction(disk.GetComponent<DiskAttributes>().speedX, disk.GetComponent<DiskAttributes>().speedY);
        RunAction(disk, action, this);
    }
}
