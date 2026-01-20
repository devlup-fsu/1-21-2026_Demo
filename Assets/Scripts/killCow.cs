using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class killCow : MonoBehaviour
{
   private int cowScore = 0;
   public TextMeshProUGUI text;
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("cow"))
      {
         cowScore++;
         print("kill cow");
         other.GetComponent<MeshRenderer>().enabled = false;
         text.text = cowScore.ToString();
      }
   }
}
