using NingCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NingCore.Business
{
    public class AuthReceiveBufferHandler
    {
        private AuthReceiveBufferHandler()
        {
            handlerDic = new Dictionary<AUTH_OPCODE, AuthOpcodeHandlingDelegate>();
            handlerDic.Add(AUTH_OPCODE.NONE, new AuthOpcodeHandlingDelegate(HandleNONE));
        }

        private static AuthReceiveBufferHandler singletonHandle;

        private delegate void AuthOpcodeHandlingDelegate(AuthClientSession pmTargetSession);
        private Dictionary<AUTH_OPCODE, AuthOpcodeHandlingDelegate> handlerDic;

        public static void HandleAuthOpcode(AuthClientSession pmTargetSession, AUTH_OPCODE pmOpcode)
        {
            if (singletonHandle == null)
            {
                singletonHandle = new AuthReceiveBufferHandler();
            }
            singletonHandle.handlerDic[pmOpcode](pmTargetSession);
        }

        private void HandleNONE(AuthClientSession pmTargetSession)
        {

        }
    }
}