using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleSelectPanel : MonoBehaviour
{
    private static RoleSelectPanel instance;
    public static RoleSelectPanel Instance
    {
        get
        {
            return instance;
        }
    }
    public List<RoleDefine> RoleDefines = new List<RoleDefine>();
    private TextAsset roleTextAsset;
    public Transform RoleList;//父物体
    private GameObject UIRole;//UI预制体
    public RoleInformation RoleContent;
    public GameObject RoleInformation;//角色信息面板
    public CanvasGroup canvasGroup;

    private void Awake()
    {
        instance = this;
        roleTextAsset = Resources.Load<TextAsset>("Data/role");
        RoleDefines = JsonConvert.DeserializeObject<List<RoleDefine>>(roleTextAsset.text);//解析Json文件
        UIRole = Resources.Load<GameObject>("Prefabs/Role");
    }

    private void Start()
    {
        UIRole firstRole=null;
        foreach (RoleDefine role in RoleDefines)
        {
            UIRole uiRole = GameObject.Instantiate(UIRole,RoleList).GetComponent<UIRole>();
            uiRole.SetInformation(role);
            uiRole.RoleInformation += RoleContent.UpDateRoleInformation;
            if (firstRole == null) firstRole = uiRole;
        }
        RoleContent.UpDateRoleInformation(RoleDefines[0]);
    }

    private void OnDestroy()
    {
        RoleContent = null;
    }

}
