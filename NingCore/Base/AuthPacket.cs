using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NingCore.Base
{
    public enum AUTH_OPCODE : byte
    {
        NONE = 0,
    }

    public class AuthPacket : Packet
    {
        public AuthPacket()
        {
            
        }

        public AuthPacket(AUTH_OPCODE pmOpcode)
        {
            headPart = new PacketPart();
            bodyPart = new PacketPart();
            headPart.Write(PACKET_OPTION_UNIT.BYTE, pmOpcode);
        }

        private AUTH_OPCODE opcode;
        public AUTH_OPCODE Opcode
        {
            get
            {
                return this.opcode;
            }
        }
    }
}