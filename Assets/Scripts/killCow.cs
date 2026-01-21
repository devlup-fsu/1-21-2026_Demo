using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class killCow : MonoBehaviour
{
   private int cowScore = 0;
   public TextMeshProUGUI text;

   private void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("cow"))
      {
         cowScore++;
         print("kill cow");
         other.gameObject.GetComponent<MeshRenderer>().enabled = false;
         text.text = cowScore.ToString();
      }

      if (cowScore >= 7)
      {
         text.text = "WINNER";
      }
   }

   private void FixedUpdate()
   {
      if (cowScore >= 7)
      {
         text.text = text.text + "!";
      }
   }
}
