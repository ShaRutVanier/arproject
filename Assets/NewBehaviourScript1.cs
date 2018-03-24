 using UnityEngine;
 using System.Collections;
 
 public class NewBehaviourScript1 : MonoBehaviour {
 
     private int[,] spaces;
 
     void Start() {
         spaces = ParseFile("C:/Users/Rutav/Documents/self trty/Assets/text.txt");
             // Output the data to verify the read
         for (int i = 0; i < spaces.GetLength(0); i++) {
             Debug.Log(spaces[i,0].ToString ()+spaces[i,1].ToString()+spaces[i,2].ToString ()+spaces[i,3].ToString()+spaces[i,4].ToString()+
                       spaces[i,5].ToString ()+spaces[i,6].ToString()+spaces[i,7].ToString ()+spaces[i,8].ToString());
         }
     }
 
     private int[,] ParseFile(string filePath) {
 
         string input = System.IO.File.ReadAllText (filePath);
         string[] lines = input.Split (new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
         int[,] spaces = new int[lines.Length, 9];
 
         for (int i = 0; i < lines.Length; i++) {
             string st = lines[i];
             string[] nums = st.Split(new[] { ',' });
             if (nums.Length != 9) {
                 Debug.Log ("Misforned input on line "+i+1);
             }
             for (int j = 0; j < Mathf.Min (nums.Length, 9); j++) {
                 int val;
                 if (int.TryParse (nums[j], out val))
                     spaces[i,j] = val;
                 else
                     spaces[i,j] = -1;
             
             }
         }
         return spaces;
     }
 }