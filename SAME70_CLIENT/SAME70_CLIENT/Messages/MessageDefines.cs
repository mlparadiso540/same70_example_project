using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SAME70_CLIENT.Messages
{
    static class MessageDefines
    {
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

        public static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var result = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return result;
        }

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

        //gets the message checksum for comparison
        //use to check for valid checksum
        public static UInt16 calculateChecksum(byte[] bytes, int size)
        {
            UInt16 checksum = 0;
            for (int i = 0; i < (size - 2); i++)
            {
                checksum += bytes[i];
            }

            return checksum;
        }

        public static void packChecksum(byte[] bytes, int size)
        {
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
