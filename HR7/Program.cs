using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace HR7 {

    class Program {

        static void Main(string[] args) {

            //string[] weighteduniformstrings(string s, int[] queries)    --input format

            string s = "abbcccabzzzaaa"; //string s
            var queries = new int[] { 78, 4, 7, 6, 9, 22 }; //int[] queries

            //string breakdown + expected result. output is only the boolean + writeline
            //a   = 1  No
            //bb  = 4  Yes
            //ccc = 9  Yes
            //b   = 2  No
            //zzz = 78 Yes
            //aa  = 3  No

            //Assign values to each letter. Manual assign, or place in to array?
            //Identify contiguous strings
            //evaluate numerical values of contiguous strings - sum += value while letter == next letter, otherwise send to list/array & sum = 0
            //foreach number input, check if it exists in contiguous string values
            //return Yes or No for the exists boolean

            int counter = 0;
            s.ToLower();

            int AssignValue(char letter) {
                int value = 0;
                if (letter == 'a') { value = 1; }
                if (letter == 'b') { value = 2; }
                if (letter == 'c') { value = 3; }
                if (letter == 'd') { value = 4; }
                if (letter == 'e') { value = 5; }
                if (letter == 'f') { value = 6; }
                if (letter == 'g') { value = 7; }
                if (letter == 'h') { value = 8; }
                if (letter == 'i') { value = 9; }
                if (letter == 'j') { value = 10; }
                if (letter == 'k') { value = 11; }
                if (letter == 'l') { value = 12; }
                if (letter == 'm') { value = 13; }
                if (letter == 'n') { value = 14; }
                if (letter == 'o') { value = 15; }
                if (letter == 'p') { value = 16; }
                if (letter == 'q') { value = 17; }
                if (letter == 'r') { value = 18; }
                if (letter == 's') { value = 19; }
                if (letter == 't') { value = 20; }
                if (letter == 'u') { value = 21; }
                if (letter == 'v') { value = 22; }
                if (letter == 'w') { value = 23; }
                if (letter == 'x') { value = 24; }
                if (letter == 'y') { value = 25; }
                if (letter == 'z') { value = 26; }
                return value;
            }

            Console.WriteLine("String to evaluate:");
            Console.WriteLine(s);
            Console.WriteLine("");
          

            var valueList = new List<int>();

            Console.WriteLine("Converted to numbers:");
            foreach (char letter in s) {
                valueList.Add(AssignValue(letter));
                Console.Write($"{AssignValue(letter)} ");
            }
            Console.WriteLine("");
            Console.WriteLine("");


            var reducedList = new List<int>();

            // reduced list should output { 1, 4, 9, 1, 2, 72, 3 }

            int idxLen = (valueList.Count()) - 1; // note that index is 0 based, but idxLen starts counting at 1, hence - 1
            int sum = 0;
            var index = 1;

            foreach (int i in valueList) {
                while (index < idxLen) {   
                    if(valueList[index] == valueList[index - 1]){
                        while (valueList[index] == valueList[index - 1] && index < idxLen) {
                            sum += valueList[index];
                            index++;
                        }
                        sum += valueList[index - 1]; // necessary to add the last contiguous value to sum
                        reducedList.Add(sum);
                        sum = 0;
                    } else {
                        sum = valueList[index - 1];
                        reducedList.Add(sum);
                        sum = 0;
                    }
                    index++;
                }
                // dealing with last index
                if(index == idxLen + 1) {
                    if(valueList[idxLen] == valueList[idxLen - 1]) {
                        sum += valueList[index - 1] + reducedList.Last();
                        var rllast = reducedList.Count() - 1;
                        reducedList.RemoveAt(rllast);
                        reducedList.Add(sum);
                    }                    
                    else {
                        sum = valueList[idxLen];
                        reducedList.Add(sum);
                    }
                    break;
                }

            }
            Console.WriteLine("Reduced and list with sums of contiguous strings:");
            foreach (int i in reducedList) {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            foreach (int i in queries) {
                Console.WriteLine($"Is {i,4} in reduced list:   {(reducedList.Contains(i) ? "Yes" : "No")}");
            }
        }
    }
}