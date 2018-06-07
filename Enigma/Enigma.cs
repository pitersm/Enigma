using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
    public class EnigmaMachine
    {
        char[,] mapeamento;
        char[] abc, refletor, R1, IR1, R2, IR2, R3, IR3;
        public EnigmaMachine()
        {
            mapeamento = new char[,]
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

        public void Teste()
        {
            char x = mapeamento[1, 1];
        }
    }
}
