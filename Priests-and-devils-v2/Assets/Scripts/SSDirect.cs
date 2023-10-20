﻿using InterfaceApplication;

//导演
public class SSDirector : System.Object {
    private static SSDirector _instance;
    public ISceneController CurrentScenceController { get; set; }
    public static SSDirector GetInstance() {
        if (_instance == null) {
            _instance = new SSDirector();
        }
        return _instance;
    }
}