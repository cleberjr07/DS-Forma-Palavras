using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SessionData : MonoBehaviour
{


    public static SessionData instance;
    public float numErros = 0;
    public float numAcertos = 0;
    public float numDrags = 0;
    public float dragTimer = 0;
    public float totalDragTime = 0;
    public float avgDragTime = 0;
    public string filepath = "caminho para o arquivo";
    public bool isDraging = false;

    void Update()
    {
        if(isDraging){
            dragTimer += Time.deltaTime;
        }
    }

    public void DragTimeCount(float dragTimer){
        totalDragTime = totalDragTime + dragTimer;
    }

    private void saveData(float numAcertos, float numErros, float dragTimer, string id, string date, float sessionTime, string nameResp, int level){
        numDrags = numAcertos + numErros;
        avgDragTime = dragTimer/numDrags;
        string data = $"{id},{nameResp}, {date},{sessionTime}, {numAcertos}, {numErros}, {numDrags}, {avgDragTime}";
        WriteToCSV(data);
    }

    public void WriteToCSV(string data){        
        using (StreamWriter writer = new StreamWriter(filepath, true)){
            writer.WriteLine(data);
        }
        
        Debug.Log($"Dados salvos em: {filePath}");

    }
}
