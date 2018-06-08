using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class EnigmaMachine
    {
        char[,] mapping;
        char[] abc, refletor, R1, IR1, R2, IR2, R3, IR3;
        int rotations1 = 0, rotations2 = 0, rotations3 = 0;
        public EnigmaMachine()
        {
            mapping = new char[,]
            { { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T' ,'U', 'V', 'W', 'X', 'Y', 'Z' },
              { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T' ,'U', 'V', 'W', 'X', 'Y', 'Z'}
            };
            abc = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' } ;
            refletor = new char[] { 'Y', 'R', 'U', 'H', 'Q', 'S', 'L', 'D', 'P', 'X', 'N', 'G', 'O', 'K', 'M', 'I', 'E', 'B', 'F', 'Z', 'C', 'W', 'V', 'J', 'A', 'T' };
            R3 = new char[] { 'B', 'D', 'F', 'H', 'J', 'L', 'C', 'P', 'R', 'T', 'X', 'V', 'Z', 'N', 'Y', 'E', 'I', 'W', 'G', 'A', 'K', 'M', 'U', 'S', 'Q', 'O' };
            IR3 = new char[] { 'T', 'A', 'G', 'B', 'P', 'C', 'S', 'D', 'Q', 'E', 'U', 'F', 'V', 'N', 'Z', 'H', 'Y', 'I', 'X', 'J', 'W', 'L', 'R', 'K', 'O', 'N' };
            R2 = new char[] { 'A', 'J', 'D', 'K', 'S', 'I', 'R', 'U', 'X', 'B', 'L', 'H', 'W', 'T', 'N', 'C', 'Q', 'G', 'Z', 'N', 'P', 'Y', 'F', 'V', 'O', 'E' };
            IR2 = new char[] { 'A', 'J', 'P', 'C', 'Z', 'W', 'R', 'L', 'F', 'B', 'D', 'K', 'O', 'T', 'Y', 'U', 'Q', 'G', 'E', 'N', 'H', 'X', 'N', 'I', 'V', 'S' };
            R1 = new char[] { 'E', 'K', 'N', 'F', 'L', 'G', 'D', 'Q', 'V', 'Z', 'N', 'T', 'O', 'W', 'Y', 'H', 'X', 'U', 'S', 'P', 'A', 'I', 'B', 'R', 'C', 'J' };
            IR1 = new char[] { 'U', 'W', 'Y', 'G', 'A', 'D', 'F', 'P', 'V', 'Z', 'B', 'E', 'C', 'K', 'N', 'T', 'H', 'X', 'S', 'L', 'R', 'I', 'N', 'Q', 'O', 'J' };
        }

        public string Encrypt(string input)
        {
            string output = "";
            foreach (char l in input)
            {
                char o;
                o = Map(l);
                o = RunRotor(o, R3, rotations3);
                o = RunRotor(o, R2, rotations2);
                o = RunRotor(o, R1, rotations1);
                o = Reflect(o);
                o = RunRotorBack(o, R1, rotations1);
                o = RunRotorBack(o, R2, rotations2);
                o = RunRotorBack(o, R3, rotations3);
                o = Map(o);
                Rotate();
                output += o;
            }
            rotations1 = 0; rotations2 = 0; rotations3 = 0;
            return output;
        }

        private int FindInArray(char[] arr, char c)
        {
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                if (arr[i] == c)
                {
                    break;
                }
            }
            return i;
        }

        private char[] RotateAbc(int r)
        {
            char[] ret = new char[26];
            for (int i = 0; i < abc.Length; i++)
            {
                int newIndex = i + r;
                ret[newIndex % 26] = abc[i];
            }
            return ret;
        }

        private char Map(char c)
        {
            char[] from = mapping.Cast<char>().Skip(26).Take(26).ToArray();
            int index = FindInArray(from, c);
            return mapping[1, index];
        }

        private char RunRotor(char c, char[] rotor, int rotations)
        {
            int rotatedIndex = (FindInArray(abc, c) + rotations) % 26; 
            char rotorLetter = rotor[rotatedIndex]; 
            int abcRotorLetterIndex = FindInArray(abc, rotorLetter); 
            return RotateAbc(rotations)[abcRotorLetterIndex];
        }

        private char RunRotorBack(char c, char[] rotor, int rotations)
        {
            int rotatedIndex = (FindInArray(abc, c) + rotations) % 26;
            char abcdLetter = abc[rotatedIndex];
            int abcRotorLetterIndex = FindInArray(rotor, abcdLetter);
            return RotateAbc(rotations)[abcRotorLetterIndex];
        }

        private char Reflect(char c)
        {
            int abcLetterIndex = FindInArray(abc, c);
            return refletor[abcLetterIndex];
        }

        private void Rotate()
        {
            rotations3++;
            if (rotations3 == 26)
            {
                rotations2++;
                rotations3 = 0;
                if (rotations2 == 26)
                {
                    rotations1++;
                    rotations2 = 0;
                }
            }
        }
    }
}
