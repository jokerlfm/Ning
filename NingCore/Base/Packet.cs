using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NingCore.Base
{
    public class Packet
    {
        public Packet()
        {
            byteBuffer = null;
            headPart = null;
            bodyPart = null;
        }

        protected byte[] byteBuffer;
        protected PacketPart headPart;
        protected PacketPart bodyPart;
        protected bool complete;
        public bool Complete
        {
            get
            {
                return this.complete;
            }
        }

        public object ReadHead(PACKET_OPTION_UNIT pmUnitType)
        {
            return headPart.Read(pmUnitType);
        }

        public object ReadBody(PACKET_OPTION_UNIT pmUnitType)
        {
            return bodyPart.Read(pmUnitType);
        }

        public bool WriteHead(PACKET_OPTION_UNIT pmUnitType, object pmValue)
        {
            return headPart.Write(pmUnitType, pmValue);
        }

        public bool WriteBody(PACKET_OPTION_UNIT pmUnitType, object pmValue)
        {
            return bodyPart.Write(pmUnitType, pmValue);
        }

        public byte[] GetPacketBuffer()
        {
            return this.byteBuffer;
        }
    }
}