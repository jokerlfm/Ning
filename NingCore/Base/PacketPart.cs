using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NingCore.Base
{
    public enum PACKET_OPTION_UNIT
    {
        BYTE,
        UINT16,
        UINT32,
        UINT64,
        INT16,
        INT32,
        INT64,
        FLOAT,
        DOUBLE,
        STRING
    }

    public class PacketPart
    {
        public PacketPart()
        {
            dynamicBytes = new List<byte>();
            contentPos = 0;
        }

        public PacketPart(byte[] pmContentBytes)
        {
            contentBytes = pmContentBytes;
            contentPos = 0;
        }

        private List<byte> dynamicBytes;
        private byte[] contentBytes;
        private int contentPos;

        public object Read(PACKET_OPTION_UNIT pmUnitType)
        {
            if (contentBytes == null)
            {
                return 0;
            }

            int finishPos = contentPos;
            switch (pmUnitType)
            {
                case PACKET_OPTION_UNIT.BYTE:
                    {
                        finishPos += 1;
                        break;
                    }
                case PACKET_OPTION_UNIT.UINT16:
                    {
                        finishPos += 2;
                        break;
                    }
                case PACKET_OPTION_UNIT.UINT32:
                    {
                        finishPos += 4;
                        break;
                    }
                case PACKET_OPTION_UNIT.UINT64:
                    {
                        finishPos += 8;
                        break;
                    }
                case PACKET_OPTION_UNIT.INT16:
                    {
                        finishPos += 2;
                        break;
                    }
                case PACKET_OPTION_UNIT.INT32:
                    {
                        finishPos += 4;
                        break;
                    }
                case PACKET_OPTION_UNIT.INT64:
                    {
                        finishPos += 8;
                        break;
                    }
                case PACKET_OPTION_UNIT.FLOAT:
                    {
                        finishPos += 4;
                        break;
                    }
                case PACKET_OPTION_UNIT.DOUBLE:
                    {
                        finishPos += 8;
                        break;
                    }
                case PACKET_OPTION_UNIT.STRING:
                    {
                        while (finishPos < contentBytes.Length)
                        {
                            finishPos++;
                            if (contentBytes[finishPos] == 0)
                            {
                                break;
                            }
                        }
                        break;
                    }
                default:
                    {
                        return 0;
                    }
            }

            if (finishPos > contentBytes.Length)
            {
                return 0;
            }

            switch (pmUnitType)
            {
                case PACKET_OPTION_UNIT.BYTE:
                    {
                        byte result = contentBytes[contentPos];
                        contentPos = finishPos;
                        return result;
                    }
                case PACKET_OPTION_UNIT.UINT16:
                    {
                        UInt16 result = BitConverter.ToUInt16(contentBytes, contentPos);
                        contentPos = finishPos;
                        return result;
                    }
                case PACKET_OPTION_UNIT.UINT32:
                    {
                        UInt32 result = BitConverter.ToUInt32(contentBytes, contentPos);
                        contentPos = finishPos;
                        return result;
                    }
                case PACKET_OPTION_UNIT.UINT64:
                    {
                        UInt64 result = BitConverter.ToUInt64(contentBytes, contentPos);
                        contentPos = finishPos;
                        return result;
                    }
                case PACKET_OPTION_UNIT.INT16:
                    {
                        Int16 result = BitConverter.ToInt16(contentBytes, contentPos);
                        contentPos = finishPos;
                        return result;
                    }
                case PACKET_OPTION_UNIT.INT32:
                    {
                        Int32 result = BitConverter.ToInt32(contentBytes, contentPos);
                        contentPos = finishPos;
                        return result;
                    }
                case PACKET_OPTION_UNIT.INT64:
                    {
                        Int64 result = BitConverter.ToInt64(contentBytes, contentPos);
                        contentPos = finishPos;
                        return result;
                    }
                case PACKET_OPTION_UNIT.FLOAT:
                    {
                        float result = BitConverter.ToSingle(contentBytes, contentPos);
                        contentPos = finishPos;
                        return result;
                    }
                case PACKET_OPTION_UNIT.DOUBLE:
                    {
                        double result = BitConverter.ToDouble(contentBytes, contentPos);
                        contentPos = finishPos;
                        return result;
                    }
                case PACKET_OPTION_UNIT.STRING:
                    {
                        string result = Encoding.UTF8.GetString(contentBytes, contentPos, finishPos - contentPos);
                        result.Trim('\0');
                        contentPos = finishPos;
                        return result;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        public bool Write(PACKET_OPTION_UNIT pmUnitType, object pmValue)
        {
            switch (pmUnitType)
            {
                case PACKET_OPTION_UNIT.BYTE:
                    {
                        byte targetValue = (byte)pmValue;
                        dynamicBytes.Add(targetValue);
                        break;
                    }
                case PACKET_OPTION_UNIT.UINT16:
                    {
                        UInt16 targetValue = (UInt16)pmValue;
                        dynamicBytes.AddRange(BitConverter.GetBytes(targetValue));
                        break;
                    }
                case PACKET_OPTION_UNIT.UINT32:
                    {
                        UInt32 targetValue = (UInt32)pmValue;
                        dynamicBytes.AddRange(BitConverter.GetBytes(targetValue));
                        break;
                    }
                case PACKET_OPTION_UNIT.UINT64:
                    {
                        UInt64 targetValue = (UInt64)pmValue;
                        dynamicBytes.AddRange(BitConverter.GetBytes(targetValue));
                        break;
                    }
                case PACKET_OPTION_UNIT.INT16:
                    {
                        Int16 targetValue = (Int16)pmValue;
                        dynamicBytes.AddRange(BitConverter.GetBytes(targetValue));
                        break;
                    }
                case PACKET_OPTION_UNIT.INT32:
                    {
                        Int32 targetValue = (Int32)pmValue;
                        dynamicBytes.AddRange(BitConverter.GetBytes(targetValue));
                        break;
                    }
                case PACKET_OPTION_UNIT.INT64:
                    {
                        Int64 targetValue = (Int64)pmValue;
                        dynamicBytes.AddRange(BitConverter.GetBytes(targetValue));
                        break;
                    }
                case PACKET_OPTION_UNIT.FLOAT:
                    {
                        float targetValue = (float)pmValue;
                        dynamicBytes.AddRange(BitConverter.GetBytes(targetValue));
                        break;
                    }
                case PACKET_OPTION_UNIT.DOUBLE:
                    {
                        double targetValue = (double)pmValue;
                        dynamicBytes.AddRange(BitConverter.GetBytes(targetValue));
                        break;
                    }
                case PACKET_OPTION_UNIT.STRING:
                    {
                        string targetValue = (string)pmValue;
                        dynamicBytes.AddRange(Encoding.UTF8.GetBytes(targetValue));
                        dynamicBytes.Add(0);
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            return true;
        }

        public void Arrange()
        {
            if (dynamicBytes == null)
            {
                return;
            }
            contentBytes = dynamicBytes.ToArray();
            contentPos = 0;
        }
    }
}