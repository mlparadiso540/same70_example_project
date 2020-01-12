using System;
using System.Runtime.InteropServices;

namespace SAME70_CLIENT.Messages
{
    /* Define important values here */
    static class MessageDefines
    {
        /* 
         * standard header for all messages
         * messages without this header will be ignored
         */
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Same70MessageHeader
        {
            public byte headerByte1;
            public byte headerByte2;
            public byte headerByte3;
            public byte headerByte4;
            public byte messageID;
            public byte messageSize;
        }

        /* Sent by client, commands IO change on SAME70 board */
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Same70ControlMessageBody
        {
            public byte output;
            public UInt16 checksum;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Same70ControlMessage
        {
            public Same70MessageHeader header;
            public Same70ControlMessageBody msg;
        }

        /* Message from SAME70 board representing current IO status */
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Same70StatusMessageBody
        {
            public byte output;
            public byte input;
            public UInt16 checksum;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Same70StatusMessage
        {
            public Same70MessageHeader header;
            public Same70StatusMessageBody msg;
        }

        /* Converts byte array to struct */
        public static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var result = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return result;
        }

        /* Converts struct to byte array */
        public static byte[] StructToBytes<T>(T structure) where T : struct
        {
            int size = Marshal.SizeOf(structure);
            byte[] rawData = new byte[size];
            GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            try
            {
                IntPtr rawDataPtr = handle.AddrOfPinnedObject();
                Marshal.StructureToPtr(structure, rawDataPtr, false);
            }
            finally
            {
                handle.Free();
            }
            return rawData;
        }

        /*
         * gets the message checksum for comparison
         * use to check for valid checksum
         */
        public static UInt16 calculateChecksum(byte[] bytes, int size)
        {
            if (size <= 2)
            {
                //message too small
                return 0;
            }
            UInt16 checksum = 0;
            for (int i = 0; i < (size - 2); i++)
            {
                checksum += bytes[i];
            }

            return checksum;
        }

        /* calculates checksum and packs into last two bytes of array */
        public static void packChecksum(byte[] bytes, int size)
        {
            if (size <= 2)
            {
                //message too small
                return;
            }
            UInt16 checksum = 0;
            for (int i = 0; i < (size - 2); i++)
            {
                checksum += bytes[i];
            }

            //little endian
            bytes[size - 1] = (byte)((checksum & 0xFF00) >> 8);
            bytes[size - 2] = (byte)(checksum & 0x00FF);
        }
    }
}
