using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MingCore
{
    public class SocketOperator
    {
        public static void FinishSocket(ref Socket pmTarget)
        {
            if (pmTarget != null)
            {
                try
                {
                    if (pmTarget.Connected)
                    {
                        pmTarget.Shutdown(SocketShutdown.Both);
                        pmTarget.Disconnect(false);
                    }
                    pmTarget.Close();
                    pmTarget.Dispose();
                }
                catch (Exception)
                {

                }
                finally
                {
                    pmTarget = null;
                }
            }
        }

        public static int ReceiveLength(Socket pmTargetSocket, ref byte[] pmBuffer, int pmTimeLimit)
        {
            int receivedLength = 0;

            int elapsedTime = 0;
            List<byte> receivedList = new List<byte>();
            while (elapsedTime < pmTimeLimit)
            {
                receivedLength += pmTargetSocket.Receive(pmBuffer, receivedLength, pmBuffer.Length - receivedLength, SocketFlags.None);
                Thread.Sleep(10);
                elapsedTime += 10;
            }

            return receivedLength;
        }
    }
}