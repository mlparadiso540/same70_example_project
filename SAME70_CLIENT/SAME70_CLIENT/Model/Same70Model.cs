using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SAME70_CLIENT.Messages.MessageDefines;
using static SAME70_CLIENT.Values.Same70Defines;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace SAME70_CLIENT.Model
{
    public class Same70Model
    {
        public bool OutputD0;
        public bool OutputD1;
        public bool OutputD2;
        public bool OutputD3;
        public bool OutputD4;
        public bool OutputD5;
        public bool OutputD6;
        public bool OutputD7;

        public bool InputD14;
        public bool InputD15;
        public bool InputD16;
        public bool InputD17;
        public bool InputD18;
        public bool InputD19;
        public bool InputD52;
        public bool InputD53;

        private UdpClient _udpClient;
        private IPEndPoint _remoteEndPoint;
        private Same70ControlMessage _controlMessage;

        public Same70Model()
        { 
            OutputD0 = false;
            OutputD1 = false;
            OutputD2 = false;
            OutputD3 = false;
            OutputD4 = false;
            OutputD5 = false;
            OutputD6 = false;
            OutputD7 = false;

            InputD14 = false;
            InputD15 = false;
            InputD16 = false;
            InputD17 = false;
            InputD18 = false;
            InputD19 = false;
            InputD52 = false;
            InputD53 = false;

            //endpoint for SAME70 board
            _remoteEndPoint = new IPEndPoint(IPAddress.Parse(REMOTE_IP_ADDRESS), UDP_REMOTE_PORT);

            //Populate message header
            //ControlMessage struct will be re-used for each control command
            _controlMessage.header.headerByte1 = HEADER_BYTE_1;
            _controlMessage.header.headerByte2 = HEADER_BYTE_2;
            _controlMessage.header.headerByte3 = HEADER_BYTE_3;
            _controlMessage.header.headerByte4 = HEADER_BYTE_4;
            _controlMessage.header.messageID = CONTROL_MESSAGE_ID;
            _controlMessage.header.messageSize = CONTROL_MESSAGE_SIZE;

            _udpClient = null;
            StartUdpListener(); 
        }

        public void StartUdpListener()
        {
            if (_udpClient == null)
            {
                _udpClient = new UdpClient(UDP_LOCAL_PORT);
            }
            try
            {
                _udpClient.BeginReceive(new AsyncCallback(recv), null);
            }
            catch (Exception e)
            {
                Console.WriteLine("UDP Client error");
                StopUdpListener();
            }
        }

        public void StopUdpListener()
        {
            _udpClient.Close();
            _udpClient = null;
        }

        //CallBack
        private void recv(IAsyncResult res)
        {
            byte[] received = _udpClient.EndReceive(res, ref _remoteEndPoint);

            //Process data
            ProcessMessage(received);
            
            //continue to listen for data
            _udpClient.BeginReceive(new AsyncCallback(recv), null);
        }

        public void ProcessMessage(byte[] data)
        { 
            //check for valid header
            if (data[0] != HEADER_BYTE_1)
            {
                return;
            }
            if (data[1] != HEADER_BYTE_2)
            {
                return;
            }
            if (data[2] != HEADER_BYTE_3)
            {
                return;
            }
            if (data[3] != HEADER_BYTE_4)
            {
                return;
            }
            byte id = data[4];
            byte size = data[5];
            
            //process status message
            if (id == STATUS_MESSAGE_ID)
            {
                Same70StatusMessage statusMessage = ByteArrayToStructure<Same70StatusMessage>(data);
                byte input = statusMessage.msg.input;
                byte output = statusMessage.msg.output;
                if (statusMessage.msg.checksum != calculateChecksum(data, size))
                {
                    //bad checksum
                    return;
                }

                //Set current state of outputs
                OutputD0 = ((output & OUTPUT_D0_MASK) == OUTPUT_D0_MASK);
                OutputD1 = ((output & OUTPUT_D1_MASK) == OUTPUT_D1_MASK);
                OutputD2 = ((output & OUTPUT_D2_MASK) == OUTPUT_D2_MASK);
                OutputD3 = ((output & OUTPUT_D3_MASK) == OUTPUT_D3_MASK);
                OutputD4 = ((output & OUTPUT_D4_MASK) == OUTPUT_D4_MASK);
                OutputD5 = ((output & OUTPUT_D5_MASK) == OUTPUT_D5_MASK);
                OutputD6 = ((output & OUTPUT_D6_MASK) == OUTPUT_D6_MASK);
                OutputD7 = ((output & OUTPUT_D7_MASK) == OUTPUT_D7_MASK);

                //Set current state of inputs
                InputD14 = ((input & INPUT_D14_MASK) == INPUT_D14_MASK);
                InputD15 = ((input & INPUT_D15_MASK) == INPUT_D15_MASK);
                InputD16 = ((input & INPUT_D16_MASK) == INPUT_D16_MASK);
                InputD17 = ((input & INPUT_D17_MASK) == INPUT_D17_MASK);
                InputD18 = ((input & INPUT_D18_MASK) == INPUT_D18_MASK);
                InputD19 = ((input & INPUT_D19_MASK) == INPUT_D19_MASK);
                InputD52 = ((input & INPUT_D52_MASK) == INPUT_D52_MASK);
                InputD53 = ((input & INPUT_D53_MASK) == INPUT_D53_MASK);
            }
            //process future messages here
            //else if (id == MESSAGE_ID_HERE)
            //{
            //        //Do something
            //}

        }

        public void ToggleOutput(byte outputMask)
        {
            byte newOutput = 0;
            //Populate current output state
            if (OutputD0)
            {
                newOutput |= OUTPUT_D0_MASK;
            }
            if (OutputD1)
            {
                newOutput |= OUTPUT_D1_MASK;
            }
            if (OutputD2)
            {
                newOutput |= OUTPUT_D2_MASK;
            }
            if (OutputD3)
            {
                newOutput |= OUTPUT_D3_MASK;
            }
            if (OutputD4)
            {
                newOutput |= OUTPUT_D4_MASK;
            }
            if (OutputD5)
            {
                newOutput |= OUTPUT_D5_MASK;
            }
            if (OutputD6)
            {
                newOutput |= OUTPUT_D6_MASK;
            }
            if (OutputD7)
            {
                newOutput |= OUTPUT_D7_MASK;
            }

            //Flip the bit of the commanded output
            newOutput ^= outputMask;

            //send the output command to the SAME70 board
            _controlMessage.msg.output = newOutput;
            byte[] sendBytes = StructToBytes(_controlMessage);
            packChecksum(sendBytes, CONTROL_MESSAGE_SIZE);

            //send new output config
            _udpClient.Send(sendBytes, CONTROL_MESSAGE_SIZE, _remoteEndPoint);
        }
    }
}
