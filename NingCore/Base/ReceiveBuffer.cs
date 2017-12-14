using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NingCore.Base
{
    public class ReceiveBuffer
    {
        public ReceiveBuffer(UInt32 pmBufferLength)
        {
            bufferLength = pmBufferLength;
            bufferBytes = new byte[pmBufferLength];
            checkPosition = 0;
            validLength = 0;
        }

        private UInt32 bufferLength;
        private byte[] bufferBytes;
        private int checkPosition;
        public int CheckPosition
        {
            get
            {
                return this.checkPosition;
            }
        }
        private int validLength;

        public void ResetBuffer(byte[] pmLegacyBytes, UInt32 pmBufferLength)
        {
            bufferBytes = new byte[pmBufferLength];
            Buffer.BlockCopy(pmLegacyBytes, 0, bufferBytes, 0, pmLegacyBytes.Length);
            checkPosition = 0;
            validLength = pmLegacyBytes.Length;
        }

        public byte[] Take(int pmLength)
        {
            byte[] result = null;

            if (pmLength + checkPosition < validLength)
            {
                result = bufferBytes.Skip(checkPosition).Take(pmLength).ToArray();
                checkPosition += pmLength;
            }

            return result;
        }

        public bool Append(byte[] pmNewBytes)
        {
            bool result = true;

            lock (bufferBytes)
            {
                if (pmNewBytes.Length + validLength > bufferBytes.Length)
                {
                    byte[] legacyBytes = new byte[validLength - checkPosition];
                    ResetBuffer(legacyBytes, bufferLength);
                }
                if (pmNewBytes.Length + validLength > bufferBytes.Length)
                {
                    result = false;
                }
                else
                {
                    Buffer.BlockCopy(pmNewBytes, 0, bufferBytes, validLength, pmNewBytes.Length);                    
                    validLength = validLength + pmNewBytes.Length;
                }                
            }

            return result;
        }
    }
}