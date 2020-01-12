using System;

namespace SAME70_CLIENT.Values
{
    /* Define important values here */
    static class Same70Defines
    {
        public const int UDP_REMOTE_PORT = 7777; //port on SAME70 board
        public const int UDP_LOCAL_PORT = 7778; //port on this machine
        public const string REMOTE_IP_ADDRESS = "192.168.0.100";


        public const byte OFF = 0;
        public const byte ON = 1;

        public const byte OUTPUT_D0_MASK = 0x1;
        public const byte OUTPUT_D1_MASK = 0x2;
        public const byte OUTPUT_D2_MASK = 0x4;
        public const byte OUTPUT_D3_MASK = 0x8;
        public const byte OUTPUT_D4_MASK = 0x10;
        public const byte OUTPUT_D5_MASK = 0x20;
        public const byte OUTPUT_D6_MASK = 0x40;
        public const byte OUTPUT_D7_MASK = 0x80;

        public const Int32 OUTPUT_D0_SHIFT = 0;
        public const Int32 OUTPUT_D1_SHIFT = 1;
        public const Int32 OUTPUT_D2_SHIFT = 2;
        public const Int32 OUTPUT_D3_SHIFT = 3;
        public const Int32 OUTPUT_D4_SHIFT = 4;
        public const Int32 OUTPUT_D5_SHIFT = 5;
        public const Int32 OUTPUT_D6_SHIFT = 6;
        public const Int32 OUTPUT_D7_SHIFT = 7;

        public const byte INPUT_D14_MASK = 0x1;
        public const byte INPUT_D15_MASK = 0x2;
        public const byte INPUT_D16_MASK = 0x4;
        public const byte INPUT_D17_MASK = 0x8;
        public const byte INPUT_D18_MASK = 0x10;
        public const byte INPUT_D19_MASK = 0x20;
        public const byte INPUT_D52_MASK = 0x40;
        public const byte INPUT_D53_MASK = 0x80;

        public const Int32 INPUT_D14_SHIFT = 0;
        public const Int32 INPUT_D15_SHIFT = 1;
        public const Int32 INPUT_D16_SHIFT = 2;
        public const Int32 INPUT_D17_SHIFT = 3;
        public const Int32 INPUT_D18_SHIFT = 4;
        public const Int32 INPUT_D19_SHIFT = 5;
        public const Int32 INPUT_D52_SHIFT = 6;
        public const Int32 INPUT_D53_SHIFT = 7;

        //message header bytes
        public const byte HEADER_BYTE_1 = 0x41; //A
        public const byte HEADER_BYTE_2 = 0x53; //S
        public const byte HEADER_BYTE_3 = 0x37; //7
        public const byte HEADER_BYTE_4 = 0x30; //0

        //message ID's
        public const byte STATUS_MESSAGE_ID = 100;
        public const byte CONTROL_MESSAGE_ID = 200;

        //message sizes (bytes)
        public const byte STATUS_MESSAGE_SIZE = 10;
        public const byte CONTROL_MESSAGE_SIZE = 9;
    }
}
