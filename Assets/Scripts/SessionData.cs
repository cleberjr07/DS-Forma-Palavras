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
    public string filePath = "";
    public bool isDraging = false;
    private string head = "ID, Data, Duração da Sessão, Profissional Responsável, ID do Paciente, Nome do nível, Tempo gasto no nível, Erros, Dicas, Nivel finalizado, Derrotas, Comentario do Profissional";

    void Update()
    {
        if(isDraging){
            dragTimer += Time.deltaTime;
        }
    }

    public void DragTimeCount(float dragTimer){
        totalDragTime = totalDragTime + dragTimer;
    }

    private void saveData(string id, string date, float sessionTime, string nameResp, string paciID, int level,float spentTime, int  numErros, int numClues, int nivelEnd, int derrotas, string commentary){
        string appPath = System.IO.Directory.GetCurrentDirectory();
        filePath = appPath + "/Dados.csv";
        if (new FileInfo(filePath).Length == 0){
            using (StreamWriter writer = new StreamWriter(filePath, true)){
                writer.WriteLine(head);
            }
        }
        string data = ($"{id}, {date}, {sessionTime}, {nameResp}, {paciID}, {level}, {spentTime}, {numErros}, {numClues}, {nivelEnd}, {derrotas}, {commentary}");
        WriteToCSV(data);
    }

    public void WriteToCSV(string data){        
        using (StreamWriter writer = new StreamWriter(filePath, true)){
            writer.WriteLine(data);
        }
        
        Debug.Log($"Dados salvos em: {filePath}");

    }
}
