using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class RoundController : MonoBehaviour, ISceneController, IUserAction
{
    int round = 0;
    int max_round = 5;
    float timer = 0.5f;
    GameObject disk;
    DiskFactory factory ;
    public CCActionManager actionManager;
    public ScoreController scoreController;
    public UserGUI userGUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (userGUI.mode == 0) return;
        GetHit();
        gameOver();
        if (round > max_round) {
            return;
        }
        timer -= Time.deltaTime;
        if (timer <= 0 && actionManager.RemainActionCount() == 0) {
            for (int i = 0; i < 10; ++i) {
                disk = factory.GetDisk(round);
                actionManager.MoveDisk(disk);
                //Thread.Sleep(100);
            }
            round += 1;
            if (round <= max_round) {
                userGUI.round = round;
            }
            timer = 4.0f;
        }
        
    }
    void Awake() {
        SSDirector director = SSDirector.getInstance();
        director.currentSceneController = this;
        director.currentSceneController.LoadSource();
        gameObject.AddComponent<UserGUI>();
        gameObject.AddComponent<CCActionManager>();
        gameObject.AddComponent<ScoreController>();
        gameObject.AddComponent<DiskFactory>();
        factory = Singleton<DiskFactory>.Instance;
        userGUI = gameObject.GetComponent<UserGUI>();
        
    }

    public void LoadSource() 
    {

    }

    public void gameOver() 
    {
        if (round > max_round && actionManager.RemainActionCount() == 0)
            userGUI.gameMessage = "Game Over!";
    }

    public void GetHit() {
        if (Input.GetButtonDown("Fire1")) {
			Camera ca = Camera.main;
			Ray ray = ca.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
                scoreController.Record(hit.transform.gameObject);
                hit.transform.gameObject.SetActive(false);
			}
		}
    }
}
