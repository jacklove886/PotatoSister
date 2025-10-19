using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffSelectPanel : MonoBehaviour
{
    private static DiffSelectPanel instance;
    public static DiffSelectPanel Instance
    {
        get
        {
            return instance;
        }
    }

    public CanvasGroup canvasGroup;
    public Transform DiffContent;
    private List<DiffDefine> DiffDefines = new List<DiffDefine>();
    private TextAsset diffTextAsset;
    public GameObject UIDiff;
    public DiffInformation DiffInformation;
    public Transform DiffList;

    private void Awake()
    {
        instance = this;
        diffTextAsset = Resources.Load<TextAsset>("Data/difficulty");
        DiffDefines = JsonConvert.DeserializeObject<List<DiffDefine>>(diffTextAsset.text);
    }

    public void Start()
    {
        foreach(DiffDefine diff in DiffDefines)
        {
            UIDiff uiDiff = GameObject.Instantiate(UIDiff, DiffList).GetComponent<UIDiff>();
            uiDiff.SetInformation(diff);
            uiDiff.DiffInformation += DiffInformation.UpDateDiffInformation;

        }
    }

    private void OnDestroy()
    {
        DiffInformation = null;
    }




}
