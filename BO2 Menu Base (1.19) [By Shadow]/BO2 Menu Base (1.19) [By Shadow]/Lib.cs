namespace BO2_Menu_Base__1._19___By_Shadow_
{
    using PS3Lib;
    using PS3Lib.NET;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    public static class Lib
    {
        public static PS3Lib.CCAPI CCAPI = new PS3Lib.CCAPI();
        public static SelectAPI CurrentAPI;
        public static int maxIntValue = 0x7fffffff;
        public static int minIntValue = -2147483647;
        public static double Pi = 3.1415926535897931;
        private static PS3API PS3 = new PS3API(SelectAPI.TargetManager);
        public static PS3Lib.NET.PS3TMAPI PS3TMAPI = new PS3Lib.NET.PS3TMAPI();
        public static PS3Lib.TMAPI TMAPI = new PS3Lib.TMAPI();

        public static List<byte> _add_(List<byte> A, byte b, int idx = 0, byte rem = 0)
        {
            short num = 0;
            if (idx < A.Count)
            {
                num = (short)(A[idx] + b);
                A[idx] = (byte)(num % 0x100);
                rem = (byte)((num - A[idx]) % 0xff);
                if (rem > 0)
                {
                    return _add_(A, rem, idx + 1, 0);
                }
                return A;
            }
            A.Add(b);
            return A;
        }

        public static void And_Int32(uint address, int input)
        {
            int num = ReadInt32(address, true) & input;
            WriteInt32(address, num, true);
        }

        public static float[] AnglesToForward(float[] Origin, float[] Angles, uint diff)
        {
            float num = ((float)Math.Sin((Angles[0] * 3.1415926535897931) / 180.0)) * diff;
            float num2 = (float)Math.Sqrt((double)((diff * diff) - (num * num)));
            float num3 = ((float)Math.Sin((Angles[1] * 3.1415926535897931) / 180.0)) * num2;
            float num4 = ((float)Math.Cos((Angles[1] * 3.1415926535897931) / 180.0)) * num2;
            return new float[] { (Origin[0] + num4), (Origin[1] + num3), (Origin[2] - num) };
        }

        public static byte[] ArrayReverse(byte[] Byte_43)
        {
            Array.Reverse(Byte_43);
            return Byte_43;
        }

        public static void Attach()
        {
            try
            {
                PS3.AttachProcess();
            }
            catch
            {
            }
        }

        public static void AttachProcess()
        {
            try
            {
                PS3.AttachProcess();
            }
            catch
            {
            }
        }

        public static string ByteArrayToString(byte[] Bytes)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetString(Bytes);
        }

        public static string centerString(string[] StringArray)
        {
            int num;
            int length = 0;
            int num3 = 0;
            string str = "";
            for (num = 0; num < StringArray.Length; num++)
            {
                if (StringArray[num].Length > length)
                {
                    length = StringArray[num].Length;
                }
            }
            for (num = 0; num < StringArray.Length; num++)
            {
                str = "";
                if (StringArray[num].Length < length)
                {
                    num3 = length - StringArray[num].Length;
                    if (StringArray[num].Contains("[{+"))
                    {
                        num3 += 13;
                    }
                    for (int i = 0; i < num3; i++)
                    {
                        str = str + " ";
                    }
                }
                StringArray[num] = str + StringArray[num];
            }
            string str2 = "";
            for (num = 0; num < StringArray.Length; num++)
            {
                str2 = str2 + StringArray[num] + "\n";
            }
            return ("^7" + str2);
        }

        public static void ChangeAPI(SelectAPI API)
        {
            try
            {
                PS3.ChangeAPI(API);
            }
            catch
            {
            }
        }

        public static string char_to_wchar(string text)
        {
            string str = text;
            for (int i = 0; i < text.Length; i++)
            {
                str = str.Insert(i * 2, "\0");
            }
            return str;
        }

        private static byte[] Combine(byte[] Arr1, byte[] Arr2)
        {
            byte[] dst = new byte[Arr1.Length + Arr2.Length];
            Buffer.BlockCopy(Arr1, 0, dst, 0, Arr1.Length);
            Buffer.BlockCopy(Arr2, 0, dst, Arr1.Length, Arr2.Length);
            return dst;
        }

        public static bool CompareByteArray(byte[] a, byte[] b)
        {
            int num = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                {
                    num++;
                }
            }
            return (num == a.Length);
        }

        public static void Connect()
        {
            try
            {
                PS3.ConnectTarget(0);
            }
            catch
            {
            }
        }

        public static void ConnectTarget()
        {
            try
            {
                PS3.ConnectTarget(0);
            }
            catch
            {
            }
        }

        public static string DetectButtonsBytes(string TexT)
        {
            return TexT.Replace("[X]", "\x0001").Replace("[O]", "\x0002").Replace("[]", "\x0003").Replace("[Y]", "\x0004").Replace("[L1]", "\x0005").Replace("[R1]", "\x0006").Replace("[L3]", "\x0010").Replace("[R3]", "\x0011").Replace("[L2]", "\x0012").Replace("[R2]", "\x0013").Replace("[UP]", "\x0014").Replace("[DOWN]", "\x0015").Replace("[LEFT]", "\x0016").Replace("[RIGHT]", "\x0017").Replace("[START]", "\x000e").Replace("[SELECT]", "\x000f").Replace("[LINE]", "\n").Replace("[3D]", "\r").Replace("\n", "\n").Replace("\r", "\r").Replace("[\n]", "\n").Replace("null", "\0");
        }

        public static string DetectButtonsCodes(string TexT)
        {
            string newValue = GameHost();
            return TexT.Replace("[X]", "[{+gostand}]").Replace("[O]", "[{+stance}]").Replace("[ ]", "[{+usereload}]").Replace("[T]", "[{weapnext}]").Replace("[R1]", "[{+attack}]").Replace("[L1]", "[{+speed_throw}]").Replace("[L2]", "[{+smoke}]").Replace("[R2]", "[{+frag}]").Replace("[R3]", "[{+melee}]").Replace("[L3]", "[{+breath_sprint}]").Replace("[UP]", "[{+actionslot 1}]").Replace("[RIGHT]", "[{+actionslot 2}]").Replace("[DOWN]", "[{+actionslot 3}]").Replace("[LEFT]", "[{+actionslot 4}]").Replace("[LINE]", "\n").Replace("[HOST]", newValue).Replace("(X)", "[{+gostand}]").Replace("(O)", "[{+stance}]").Replace("( )", "[{+usereload}]").Replace("(T)", "[{weapnext}]").Replace("(R1)", "[{+attack}]").Replace("(L1)", "[{+speed_throw}]").Replace("(L2)", "[{+smoke}]").Replace("(R2)", "[{+frag}]").Replace("(R3)", "[{+melee}]").Replace("(L3)", "[{+breath_sprint}]").Replace("(UP)", "[{+actionslot 1}]").Replace("(RIGHT)", "[{+actionslot 2}]").Replace("(DOWN)", "[{+actionslot 3}]").Replace("(LEFT)", "[{+actionslot 4}]").Replace("(LINE)", "\n").Replace("(HOST)", newValue);
        }

        public static void DisconnectTarget()
        {
            try
            {
                PS3.DisconnectTarget();
            }
            catch
            {
            }
        }

        public static float Distance2D(float[] point1, float[] point2)
        {
            float num = point2[0] - point1[0];
            float num2 = point2[1] - point1[1];
            return Convert.ToSingle(Math.Sqrt((double)((num * num) + (num2 * num2))));
        }

        public static float Distance3D(float[] point1, float[] point2)
        {
            float num = point2[0] - point1[0];
            float num2 = point2[1] - point1[1];
            float num3 = point2[2] - point1[2];
            return Convert.ToSingle(Math.Sqrt((double)(((num * num) + (num2 * num2)) + (num3 * num3))));
        }

        public static string EncodingText(byte[] byte_43)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetString(byte_43);
        }

        public static void FillMemory(uint Start, uint Length, byte[] Bytes)
        {
            uint length = (uint)Bytes.Length;
            uint num2 = Start + Length;
            uint address = Start;
            while (address < num2)
            {
                while (num2 > address)
                {
                    SetMemory(address, Bytes);
                    address += length;
                }
            }
        }

        public static uint G_Client(uint G_ClientAddress, uint clientIndex, uint offset, uint G_ClientSize)
        {
            return ((G_ClientAddress + offset) + (clientIndex * G_ClientSize));
        }

        public static uint G_Entity(uint G_EntityAddress, uint clientIndex, uint offset, uint G_EntitySize)
        {
            return ((G_EntityAddress + offset) + (clientIndex * G_EntitySize));
        }

        public static string GameHost()
        {
            return ReadString(0x17864d8);
        }

        public static byte[] GetBytes(uint Offset, int Length)
        {
            return PS3.GetBytes(Offset, Length);
        }

        private static byte[] GetBytes(uint offset, int length, SelectAPI API)
        {
            byte[] bytes = new byte[length];
            if (API == SelectAPI.ControlConsole)
            {
                CurrentAPI = PS3.GetCurrentAPI();
                return PS3.GetBytes(offset, length);
            }
            if (API == SelectAPI.TargetManager)
            {
                CurrentAPI = PS3.GetCurrentAPI();
                bytes = PS3.GetBytes(offset, length);
            }
            return bytes;
        }

        private static SelectAPI GetCurrentAPI()
        {
            return PS3.GetCurrentAPI();
        }

        public static string getDetails(uint g_gametype, string type)
        {
            string str = ReadString(g_gametype);
            string[] strArray = str.Split(new char[] { '\\' });
            int length = str.Length;
            int index = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] == type)
                {
                    i++;
                    index = i;
                }
            }
            return strArray[index];
        }

        private static void GetMem(uint offset, byte[] buffer, SelectAPI API)
        {
            try
            {
                if (API == SelectAPI.ControlConsole)
                {
                    GetMemoryR(offset, ref buffer);
                }
                else if (API == SelectAPI.TargetManager)
                {
                    GetMemoryR(offset, ref buffer);
                }
            }
            catch
            {
            }
        }

        public static void GetMemory(uint Offset, byte[] Buffer)
        {
            try
            {
                PS3.GetMemory(Offset, Buffer);
            }
            catch
            {
            }
        }

        public static byte[] GetMemoryL(uint address, int length)
        {
            byte[] buffer = new byte[length];
            GetMemory(address, buffer);
            return buffer;
        }

        public static void GetMemoryR(uint offset, ref byte[] buffer)
        {
            getMemR(offset, ref buffer, CurrentAPI);
        }

        private static void getMemR(uint Address, ref byte[] buffer, SelectAPI API)
        {
            try
            {
                if (API == SelectAPI.ControlConsole)
                {
                    CCAPI.GetMemory(Address, buffer);
                }
                else if (API == SelectAPI.TargetManager)
                {
                    TMAPI.GetMemory(Address, buffer);
                }
            }
            catch
            {
            }
        }

        //    public static string GetTextBetween(string source, string leftWord, string rightWord)
        //  {
        //    return Regex.Match(source, string.Format(@"{0}(?<words>[-\\^\w\s]+){1}", leftWord, rightWord), 1).Groups["words"].Value;
        //}

        public static float[] getVector(float[] point1, float[] point2)
        {
            return new float[] { (point2[0] - point1[0]), (point2[1] - point1[1]), (point2[2] - point1[2]) };
        }

        public static void lockIntDvarToValue(uint pointer, byte[] value)
        {
            uint num = 4;
            uint num2 = 11;
            byte[] buffer = new byte[4];
            GetMemory(pointer, buffer);
            Array.Reverse(buffer);
            uint num3 = BitConverter.ToUInt32(buffer, 0);
            byte[] bytes = new byte[2];
            GetMemory(num3 + num, bytes);
            Array.Reverse(bytes);
            ushort num4 = BitConverter.ToUInt16(bytes, 0);
            if ((num4 & 0x800) != 0x800)
            {
                num4 = (ushort)(num4 | 0x800);
                bytes = BitConverter.GetBytes(num4);
                Array.Reverse(bytes);
                SetMemory(num3 + num, bytes);
            }
            SetMemory(num3 + num2, value);
        }

        public static byte[] Multiply(this byte[] A, byte[] B)
        {
            List<byte> a = new List<byte>();
            int idx = 0;
            for (int i = 0; i < A.Length; i++)
            {
                byte b = 0;
                for (int j = 0; j < B.Length; j++)
                {
                    short num6 = (short)((A[i] * B[j]) + b);
                    b = (byte)(num6 >> 8);
                    byte num2 = (byte)num6;
                    idx = i + j;
                    if (idx < a.Count)
                    {
                        a = _add_(a, num2, idx, 0);
                    }
                    else
                    {
                        a.Add(num2);
                    }
                }
                if (b > 0)
                {
                    if ((idx + 1) < a.Count)
                    {
                        a = _add_(a, b, idx + 1, 0);
                    }
                    else
                    {
                        a.Add(b);
                    }
                }
            }
            return a.ToArray();
        }

        public static void Or_Int32(uint address, int input)
        {
            int num = ReadInt32(address, true) | input;
            WriteInt32(address, num, true);
        }

        public static bool ReadBool(uint offset)
        {
            byte[] buffer = new byte[1];
            GetMem(offset, buffer, CurrentAPI);
            return (buffer[0] != 0);
        }

        public static byte ReadByte(uint offset)
        {
            return GetBytes(offset, 1, CurrentAPI)[0];
        }

        public static bool ReadByte(uint Address, byte Byte)
        {
            byte[] buffer = new byte[1];
            GetMemoryR(Address, ref buffer);
            return new byte[] { Byte }.SequenceEqual<byte>(buffer);
        }

        public static byte[] ReadBytes(uint offset, int length)
        {
            return GetBytes(offset, length, CurrentAPI);
        }

        public static bool ReadBytes(uint Address, byte[] newBytes)
        {
            byte[] second = new byte[newBytes.Length];
            GetMemoryR(Address, ref newBytes);
            return newBytes.SequenceEqual<byte>(second);
        }

        public static double[] ReadDouble(uint address, int length)
        {
            byte[] memoryL = GetMemoryL(address, length * 8);
            ReverseBytes(memoryL);
            double[] numArray = new double[length];
            for (int i = 0; i < length; i++)
            {
                numArray[i] = BitConverter.ToSingle(memoryL, ((length - 1) - i) * 8);
            }
            return numArray;
        }

        public static float ReadFloat(uint offset, bool Reverse = true)
        {
            byte[] array = GetBytes(offset, 4, CurrentAPI);
            if (Reverse)
            {
                Array.Reverse(array, 0, 4);
            }
            return BitConverter.ToSingle(array, 0);
        }

        public static float[] ReadFloatLength(uint Offset, int Length)
        {
            byte[] buffer = new byte[Length * 4];
            PS3.GetMemory(Offset, buffer);
            Array.Reverse(buffer);
            float[] numArray = new float[Length];
            for (int i = 0; i < Length; i++)
            {
                numArray[i] = BitConverter.ToSingle(buffer, ((Length - 1) - i) * 4);
            }
            return numArray;
        }

        public static int ReadInt(uint Offset, bool Reverse = true)
        {
            byte[] buffer = new byte[4];
            PS3.GetMemory(Offset, buffer);
            if (Reverse)
            {
                Array.Reverse(buffer);
            }
            return BitConverter.ToInt32(buffer, 0);
        }

        public static short ReadInt16(uint offset, bool Reverse = true)
        {
            byte[] array = GetBytes(offset, 2, CurrentAPI);
            if (Reverse)
            {
                Array.Reverse(array, 0, 2);
            }
            return BitConverter.ToInt16(array, 0);
        }

        public static int ReadInt32(uint offset, bool Reverse = true)
        {
            byte[] array = GetBytes(offset, 4, CurrentAPI);
            if (Reverse)
            {
                Array.Reverse(array, 0, 4);
            }
            return BitConverter.ToInt32(array, 0);
        }

        public static long ReadInt64(uint offset, bool Reverse = true)
        {
            byte[] array = GetBytes(offset, 8, CurrentAPI);
            if (Reverse)
            {
                Array.Reverse(array, 0, 8);
            }
            return BitConverter.ToInt64(array, 0);
        }

        public static void ReadIntToByte(uint Address, int Value)
        {
            int num = Value;
            byte num2 = (byte)num;
            byte num3 = (byte)(num >> 8);
            GetMemory(Address, new byte[] { num3, num2 });
        }

        public static byte[] ReadMemory(uint Address, uint Interval, int Clients, int Length)
        {
            byte[] buffer = new byte[Length];
            for (uint i = 0; i < Clients; i++)
            {
                GetMemory(Address + (i * Interval), buffer);
            }
            return buffer;
        }

        public static sbyte ReadSByte(uint offset)
        {
            byte[] buffer = new byte[1];
            GetMem(offset, buffer, CurrentAPI);
            return (sbyte)buffer[0];
        }

        public static sbyte[] ReadSBytes(uint address, int length)
        {
            byte[] memoryL = GetMemoryL(address, length);
            sbyte[] numArray = new sbyte[length];
            for (int i = 0; i < length; i++)
            {
                numArray[i] = (sbyte)memoryL[i];
            }
            return numArray;
        }

        public static float ReadSingle(uint address)
        {
            byte[] memoryL = GetMemoryL(address, 4);
            Array.Reverse(memoryL, 0, 4);
            return BitConverter.ToSingle(memoryL, 0);
        }

        public static float[] ReadSingle(uint address, int length)
        {
            byte[] inArray = ReadBytes(address, (int)(length * 4));
            ReverseBytes(inArray);
            float[] numArray = new float[length];
            for (int i = 0; i < length; i++)
            {
                numArray[i] = BitConverter.ToSingle(inArray, ((length - 1) - i) * 4);
            }
            return numArray;
        }

        public static string ReadString(uint offset)
        {
            int length = 40;
            int num2 = 0;
            string source = "";
            do
            {
                byte[] bytes = ReadBytes(offset + ((uint)num2), length);
                source = source + Encoding.UTF8.GetString(bytes);
                num2 += length;
            }
            while (!source.Contains<char>('\0'));
            int index = source.IndexOf('\0');
            string str2 = source.Substring(0, index);
            source = string.Empty;
            return str2;
        }

        public static ushort ReadUInt16(uint offset, bool Reverse = true)
        {
            byte[] array = GetBytes(offset, 2, CurrentAPI);
            if (Reverse)
            {
                Array.Reverse(array, 0, 2);
            }
            return BitConverter.ToUInt16(array, 0);
        }

        public static uint ReadUInt32(uint offset, bool Reverse = true)
        {
            byte[] array = GetBytes(offset, 4, CurrentAPI);
            if (Reverse)
            {
                Array.Reverse(array, 0, 4);
            }
            return BitConverter.ToUInt32(array, 0);
        }

        public static ulong ReadUInt64(uint offset, bool Reverse = true)
        {
            byte[] array = GetBytes(offset, 8, CurrentAPI);
            if (Reverse)
            {
                Array.Reverse(array, 0, 8);
            }
            return BitConverter.ToUInt64(array, 0);
        }

        public static float[] ReadVec(uint address, uint dim)
        {
            float[] numArray = new float[dim];
            uint index = 0;
            for (uint i = 0; index < dim; i += 4)
            {
                numArray[index] = ReadSingle(address + i);
                index++;
            }
            return numArray;
        }

        public static string ReturnInfo(uint g_gametype, int Length, int Index)
        {
            try
            {
                return Encoding.ASCII.GetString(GetBytes(g_gametype, Length)).Replace(@"\", "|").Split(new char[] { '|' })[Index];
            }
            catch
            {
                return null;
            }
        }

        public static byte[] Reverse(byte[] buff)
        {
            Array.Reverse(buff);
            return buff;
        }

        public static byte[] ReverseArray(float float_0)
        {
            byte[] bytes = BitConverter.GetBytes(float_0);
            Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] ReverseBytes(byte[] inArray)
        {
            Array.Reverse(inArray);
            return inArray;
        }

        public static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            if (s == null)
            {
                return null;
            }
            return new string(array);
        }

        public static byte[] RGBA(decimal R, decimal G, decimal B, decimal A)
        {
            byte[] buffer = new byte[4];
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(R));
            byte[] buffer3 = BitConverter.GetBytes(Convert.ToInt32(G));
            byte[] buffer4 = BitConverter.GetBytes(Convert.ToInt32(B));
            byte[] buffer5 = BitConverter.GetBytes(Convert.ToInt32(A));
            buffer[0] = bytes[0];
            buffer[1] = buffer3[0];
            buffer[2] = buffer4[0];
            buffer[3] = buffer5[0];
            return buffer;
        }

        private static void SetMem(uint Address, byte[] buffer, SelectAPI API)
        {
            try
            {
                if (API == SelectAPI.ControlConsole)
                {
                    PS3.CCAPI.SetMemory(Address, buffer);
                }
                else if (API == SelectAPI.TargetManager)
                {
                    PS3.TMAPI.SetMemory(Address, buffer);
                }
            }
            catch
            {
            }
        }

        public static void SetMemory(uint Address, byte[] Bytes)
        {
            try
            {
                if (PS3.GetCurrentAPI() == SelectAPI.TargetManager)
                {
                    SetMem(Address, Bytes, SelectAPI.TargetManager);
                }
                else if (PS3.GetCurrentAPI() == SelectAPI.ControlConsole)
                {
                    SetMem(Address, Bytes, SelectAPI.ControlConsole);
                }
            }
            catch
            {
            }
        }

        public static void SetMemoryref(uint Address, ref byte[] buffer)
        {
            SetMemory(Address, buffer);
        }

        public static void Sleep(int millisecondsTimeout)
        {
            Thread.Sleep(millisecondsTimeout);
        }

        public static byte[] stringToBytesASCII(string str)
        {
            char[] chArray = str.ToCharArray();
            byte[] buffer = new byte[chArray.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)chArray[i];
            }
            return buffer;
        }

        public static byte[] ToHexFloat(float Axis)
        {
            byte[] bytes = BitConverter.GetBytes(Axis);
            Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] uintBytes(uint input)
        {
            byte[] bytes = BitConverter.GetBytes(input);
            Array.Reverse(bytes);
            return bytes;
        }

        public static void vec_scale(float[] vec, float scale, out float[] Forward)
        {
            Forward = new float[] { vec[0] * scale, vec[1] * scale, vec[2] * scale };
        }

        public static float VecDistance3D(float[] Vector)
        {
            return Convert.ToSingle(Math.Sqrt((double)(((Vector[0] * Vector[0]) + (Vector[1] * Vector[1])) + (Vector[2] * Vector[2]))));
        }

        public static float[] VecMultiply(float[] Vector, float Value)
        {
            return new float[] { (Vector[0] *= Value), (Vector[1] *= Value), (Vector[2] *= Value) };
        }

        public static float[] vectoangles(float[] Angles)
        {
            float num2;
            float num3;
            float[] numArray = new float[3];
            if ((Angles[1] == 0f) && (Angles[0] == 0f))
            {
                num2 = 0f;
                if (Angles[2] > 0f)
                {
                    num3 = 90f;
                }
                else
                {
                    num3 = 270f;
                }
            }
            else
            {
                if (!(Angles[0] == -1f))
                {
                    num2 = (float)((Math.Atan2((double)Angles[1], (double)Angles[0]) * 180.0) / 3.1415926535897931);
                }
                else if (Angles[1] > 0f)
                {
                    num2 = 90f;
                }
                else
                {
                    num2 = 270f;
                }
                if (num2 < 0f)
                {
                    num2 += 360f;
                }
                float num = (float)Math.Sqrt((double)((Angles[0] * Angles[0]) + (Angles[1] * Angles[1])));
                num3 = (float)((Math.Atan2((double)Angles[2], (double)num) * 180.0) / 3.1415926535897931);
                if (num3 < 0f)
                {
                    num3 += 360f;
                }
            }
            numArray[0] = -num3;
            numArray[1] = num2;
            numArray[2] = 0f;
            return numArray;
        }

        public static float[] vectoanglesAsNum(float[] Angles)
        {
            float num;
            float num2;
            float[] numArray = new float[3];
            if ((Angles[1] == 0f) && (Angles[0] == 0f))
            {
                num = 0f;
                if (Angles[2] > 0f)
                {
                    num2 = 90f;
                }
                else
                {
                    num2 = 270f;
                }
            }
            else
            {
                if (!(Angles[0] == -1f))
                {
                    num = (float)((Math.Atan2((double)Angles[1], (double)Angles[0]) * 180.0) / 3.1415926535897931);
                }
                else if (Angles[1] > 0f)
                {
                    num = 90f;
                }
                else
                {
                    num = 270f;
                }
                if (num < 0f)
                {
                    num += 360f;
                }
                float num3 = (float)Math.Sqrt((double)((Angles[0] * Angles[0]) + (Angles[1] * Angles[1])));
                num2 = (float)((Math.Atan2((double)Angles[2], (double)num3) * 180.0) / 3.1415926535897931);
                if (num2 < 0f)
                {
                    num2 += 360f;
                }
            }
            numArray[0] = -num2;
            numArray[1] = num;
            return numArray;
        }

        public static void Wait(int Seconds)
        {
            int num = 0x3e8;
            int millisecondsTimeout = Seconds * num;
            Thread.Sleep(millisecondsTimeout);
        }

        public static void Wait(int Seconds, int Minutes)
        {
            int num = 0x3e8;
            int millisecondsTimeout = ((Minutes + num) * 60) + (Seconds * num);
            Thread.Sleep(millisecondsTimeout);
        }

        public static void Wait(int Seconds, int Minutes, int Hours)
        {
            int num = 0x3e8;
            int millisecondsTimeout = (((Hours + num) * 0xe10) + ((Minutes + num) * 60)) + (Seconds * num);
            Thread.Sleep(millisecondsTimeout);
        }

        public static void Wait(int Seconds, int Minutes, int Hours, int Days)
        {
            int num = 0x3e8;
            int millisecondsTimeout = ((((Days + num) * 0x15180) + ((Hours + num) * 0xe10)) + ((Minutes + num) * 60)) + (Seconds * num);
            Thread.Sleep(millisecondsTimeout);
        }

        public static void WriteBool(uint offset, bool input)
        {
            try
            {
                byte[] buffer = new byte[] { input ? ((byte)1) : ((byte)0) };
                SetMem(offset, buffer, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteByte(uint offset, byte input)
        {
            try
            {
                byte[] buffer = new byte[] { input };
                SetMem(offset, buffer, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteByte(uint offset, byte input1, byte input2)
        {
            try
            {
                byte[] buffer = new byte[] { input1, input2 };
                SetMem(offset, buffer, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteByte(uint address, byte Byte, int length)
        {
            int num = 0;
            uint num2 = Convert.ToUInt32((long)(address + num));
            byte[] bytes = new byte[] { Byte };
            while (num < length)
            {
                SetMemory(num2, bytes);
            }
        }

        public static void WriteByte(uint offset, byte input1, byte input2, byte input3)
        {
            try
            {
                byte[] buffer = new byte[] { input1, input2, input3 };
                SetMem(offset, buffer, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteByte(uint offset, byte input1, byte input2, byte input3, byte input4)
        {
            try
            {
                byte[] buffer = new byte[] { input1, input2, input3, input4 };
                SetMem(offset, buffer, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteBytes(uint offset, byte[] input)
        {
            try
            {
                byte[] buffer = input;
                SetMem(offset, buffer, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteBytes(uint address, byte[] ByteArray, int length)
        {
            int num = 0;
            uint num2 = Convert.ToUInt32((long)(address + num));
            while (num < length)
            {
                SetMemory(num2, ByteArray);
            }
        }

        public static bool WriteBytesToggle(uint Offset, byte[] On, byte[] Off)
        {
            bool flag = ReadByte(Offset) == On[0];
            WriteBytes(Offset, !flag ? On : Off);
            return flag;
        }

        public static void WriteDouble(uint address, double input, bool Reverse = true)
        {
            byte[] array = new byte[8];
            BitConverter.GetBytes(input).CopyTo(array, 0);
            if (Reverse)
            {
                Array.Reverse(array, 0, 8);
            }
            SetMemory(address, array);
        }

        public static void WriteDouble(uint address, double[] input, bool Reverse = true)
        {
            int length = input.Length;
            byte[] array = new byte[length * 8];
            for (int i = 0; i < length; i++)
            {
                if (Reverse)
                {
                    ReverseBytes(BitConverter.GetBytes(input[i])).CopyTo(array, (int)(i * 8));
                }
                else
                {
                    BitConverter.GetBytes(input[i]).CopyTo(array, (int)(i * 8));
                }
            }
            SetMemory(address, array);
        }

        private static void WriteFloat(uint Offset, float[] input)
        {
            try
            {
                for (uint i = 0; i < input.Length; i++)
                {
                    WriteFloat(Offset + (i * 4), input[i], true);
                }
            }
            catch
            {
            }
        }

        public static void WriteFloat(uint offset, float input, bool Reverse = true)
        {
            try
            {
                byte[] array = new byte[4];
                BitConverter.GetBytes(input).CopyTo(array, 0);
                if (Reverse)
                {
                    Array.Reverse(array, 0, 4);
                }
                SetMem(offset, array, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteFloatArray(uint Offset, float[] Array)
        {
            try
            {
                byte[] array = new byte[Array.Length * 4];
                for (int i = 0; i < Array.Length; i++)
                {
                    ReverseBytes(BitConverter.GetBytes(Array[i])).CopyTo(array, (int)(i * 4));
                }
                SetMemory(Offset, array);
            }
            catch
            {
            }
        }

        public static void WriteInt(uint address, int val, bool Reverse = true)
        {
            if (Reverse)
            {
                SetMemory(address, ReverseBytes(BitConverter.GetBytes(val)));
            }
            else
            {
                SetMemory(address, BitConverter.GetBytes(val));
            }
        }

        public static void WriteInt16(uint offset, short input, bool Reverse = true)
        {
            try
            {
                byte[] array = new byte[2];
                BitConverter.GetBytes(input).CopyTo(array, 0);
                if (Reverse)
                {
                    Array.Reverse(array, 0, 2);
                }
                SetMem(offset, array, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteInt32(uint offset, int input, bool Reverse = true)
        {
            try
            {
                byte[] array = new byte[4];
                BitConverter.GetBytes(input).CopyTo(array, 0);
                if (Reverse)
                {
                    Array.Reverse(array, 0, 4);
                }
                SetMem(offset, array, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteInt64(uint offset, long input, bool Reverse = true)
        {
            try
            {
                byte[] array = new byte[8];
                BitConverter.GetBytes(input).CopyTo(array, 0);
                if (Reverse)
                {
                    Array.Reverse(array, 0, 8);
                }
                SetMem(offset, array, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteIntToByte(uint Address, int Value)
        {
            int num = Value;
            byte num2 = (byte)num;
            byte num3 = (byte)(num >> 8);
            SetMemory(Address, new byte[] { num3, num2 });
        }

        public static void WriteMemory(uint Address, uint Interval, int Clients, byte[] Bytes)
        {
            for (uint i = 0; i < Clients; i++)
            {
                SetMemory(Address + (i * Interval), Bytes);
            }
        }

        public static void WriteSByte(uint offset, sbyte input)
        {
            try
            {
                byte[] buffer = new byte[] { (byte)input };
                SetMem(offset, buffer, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteShort(uint address, int val, bool dvar = false)
        {
            byte[] bytes = BitConverter.GetBytes(val);
            if (!dvar)
            {
                SetMemory(address, new byte[] { bytes[0], bytes[1] });
            }
            else
            {
                SetMemory(address, new byte[] { bytes[1], bytes[0] });
            }
        }

        public static void WriteSingle(uint address, float input)
        {
            byte[] array = new byte[4];
            BitConverter.GetBytes(input).CopyTo(array, 0);
            Array.Reverse(array, 0, 4);
            SetMemory(address, array);
        }

        public static void WriteSingle(uint address, float[] input)
        {
            int length = input.Length;
            byte[] array = new byte[length * 4];
            for (int i = 0; i < length; i++)
            {
                ReverseBytes(BitConverter.GetBytes(input[i])).CopyTo(array, (int)(i * 4));
            }
            PS3.SetMemory(address, array);
        }

        public static void WriteString(uint offset, string input)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(DetectButtonsBytes(input));
                Array.Resize<byte>(ref bytes, bytes.Length + 1);
                SetMem(offset, bytes, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteUInt(uint address, uint val, bool Reverse = true)
        {
            if (Reverse)
            {
                SetMemory(address, ReverseBytes(BitConverter.GetBytes(val)));
            }
            else
            {
                SetMemory(address, BitConverter.GetBytes(val));
            }
        }

        public static void WriteUInt16(uint offset, ushort input, bool Reverse = true)
        {
            try
            {
                byte[] array = new byte[2];
                BitConverter.GetBytes(input).CopyTo(array, 0);
                if (Reverse)
                {
                    Array.Reverse(array, 0, 2);
                }
                SetMem(offset, array, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteUInt32(uint offset, uint input, bool Reverse = true)
        {
            try
            {
                byte[] array = new byte[4];
                BitConverter.GetBytes(input).CopyTo(array, 0);
                if (Reverse)
                {
                    Array.Reverse(array, 0, 4);
                }
                SetMem(offset, array, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteUInt64(uint offset, ulong input, bool Reverse = true)
        {
            try
            {
                byte[] array = new byte[8];
                BitConverter.GetBytes(input).CopyTo(array, 0);
                if (Reverse)
                {
                    Array.Reverse(array, 0, 8);
                }
                SetMem(offset, array, CurrentAPI);
            }
            catch
            {
            }
        }

        public static void WriteVec(uint address, float[] vec)
        {
            uint index = 0;
            for (uint i = 0; index < vec.Length; i += 4)
            {
                WriteSingle(address + i, vec[index]);
                index++;
            }
        }

        public static class ASCII
        {
            public static byte[] GetBytes(string s)
            {
                return Encoding.ASCII.GetBytes(Lib.DetectButtonsBytes(s));
            }
        }
        /*
        public static class Builder
        {
            public static class ArrayReader
            {
                private static byte[] buffer;
                private static int size;

                public static bool GetBool(int pos)
                {
                    return (buffer[pos] != 0);
                }

                public static byte GetByte(int pos)
                {
                    return buffer[pos];
                }

                public static byte[] GetBytes(int pos, int length)
                {
                    byte[] buffer = new byte[length];
                    for (int i = 0; i < length; i++)
                    {
                        buffer[i] = buffer[pos + i];
                    }
                    return buffer;
                }

                public static char GetChar(int pos)
                {
                    return buffer[pos].ToString()[0];
                }

                public static float GetFloat(int pos)
                {
                    byte[] array = new byte[4];
                    for (int i = 0; i < 4; i++)
                    {
                        array[i] = buffer[pos + i];
                    }
                    Array.Reverse(array, 0, 4);
                    return BitConverter.ToSingle(array, 0);
                }

                public static short GetInt16(int pos, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] array = new byte[2];
                    for (int i = 0; i < 2; i++)
                    {
                        array[i] = buffer[pos + i];
                    }
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(array, 0, 2);
                    }
                    return BitConverter.ToInt16(array, 0);
                }

                public static int GetInt32(int pos, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] array = new byte[4];
                    for (int i = 0; i < 4; i++)
                    {
                        array[i] = buffer[pos + i];
                    }
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(array, 0, 4);
                    }
                    return BitConverter.ToInt32(array, 0);
                }

                public static long GetInt64(int pos, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] array = new byte[8];
                    for (int i = 0; i < 8; i++)
                    {
                        array[i] = buffer[pos + i];
                    }
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(array, 0, 8);
                    }
                    return BitConverter.ToInt64(array, 0);
                }

                public static sbyte GetSByte(int pos)
                {
                    return (sbyte) buffer[pos];
                }

                public static string GetString(int pos)
                {
                    int num = 0;
                    while (true)
                    {
                        if (buffer[pos + num] == 0)
                        {
                            byte[] bytes = new byte[num];
                            for (int i = 0; i < num; i++)
                            {
                                bytes[i] = buffer[pos + i];
                            }
                            return Encoding.UTF8.GetString(bytes);
                        }
                        num++;
                    }
                }

                public static ushort GetUInt16(int pos, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] array = new byte[2];
                    for (int i = 0; i < 2; i++)
                    {
                        array[i] = buffer[pos + i];
                    }
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(array, 0, 2);
                    }
                    return BitConverter.ToUInt16(array, 0);
                }

                public static uint GetUInt32(int pos, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] array = new byte[4];
                    for (int i = 0; i < 4; i++)
                    {
                        array[i] = buffer[pos + i];
                    }
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(array, 0, 4);
                    }
                    return BitConverter.ToUInt32(array, 0);
                }

                public static ulong GetUInt64(int pos, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] array = new byte[8];
                    for (int i = 0; i < 8; i++)
                    {
                        array[i] = buffer[pos + i];
                    }
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(array, 0, 8);
                    }
                    return BitConverter.ToUInt64(array, 0);
                }

                private static int None(uint Address, sbyte sByte)
                {
                    size = 1;
                    buffer = new byte[] { (byte) sByte };
                    Lib.SetMemory(Address, buffer);
                    return size;
                }
            }

            public static class ArrayWriter
            {
                private static byte[] buffer;
                private static int size;

                private static int None(uint Address, sbyte sByte)
                {
                    size = 1;
                    buffer = new byte[] { (byte) sByte };
                    Lib.SetMemory(Address, buffer);
                    return size;
                }

                public static void SetBool(int pos, bool value)
                {
                    byte[] buffer = new byte[] { value ? ((byte) 1) : ((byte) 0) };
                    buffer[pos] = buffer[0];
                }

                public static void SetByte(int pos, byte value)
                {
                    buffer[pos] = value;
                }

                public static void SetBytes(int pos, byte[] value)
                {
                    int length = value.Length;
                    for (int i = 0; i < length; i++)
                    {
                        buffer[i + pos] = value[i];
                    }
                }

                public static void SetChar(int pos, char value)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(value.ToString());
                    buffer[pos] = bytes[0];
                }

                public static void SetFloat(int pos, float value)
                {
                    byte[] bytes = BitConverter.GetBytes(value);
                    Array.Reverse(bytes, 0, 4);
                    for (int i = 0; i < 4; i++)
                    {
                        buffer[i + pos] = bytes[i];
                    }
                }

                public static void SetInt16(int pos, short value, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] bytes = BitConverter.GetBytes(value);
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(bytes, 0, 2);
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        buffer[i + pos] = bytes[i];
                    }
                }

                public static void SetInt32(int pos, int value, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] bytes = BitConverter.GetBytes(value);
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(bytes, 0, 4);
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        buffer[i + pos] = bytes[i];
                    }
                }

                public static void SetInt64(int pos, long value, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] bytes = BitConverter.GetBytes(value);
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(bytes, 0, 8);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        buffer[i + pos] = bytes[i];
                    }
                }

                public static void SetSByte(int pos, sbyte value)
                {
                    buffer[pos] = (byte) value;
                }

                public static void SetString(int pos, string value)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(value + "\0");
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        buffer[i + pos] = bytes[i];
                    }
                }

                public static void SetUInt16(int pos, ushort value, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] bytes = BitConverter.GetBytes(value);
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(bytes, 0, 2);
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        buffer[i + pos] = bytes[i];
                    }
                }

                public static void SetUInt32(int pos, uint value, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] bytes = BitConverter.GetBytes(value);
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(bytes, 0, 4);
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        buffer[i + pos] = bytes[i];
                    }
                }

                public static void SetUInt64(int pos, ulong value, LauncherCrystalProject.EndianType Type = 1)
                {
                    byte[] bytes = BitConverter.GetBytes(value);
                    if (Type == LauncherCrystalProject.EndianType.BigEndian)
                    {
                        Array.Reverse(bytes, 0, 8);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        buffer[i + pos] = bytes[i];
                    }
                }
            }
        }

        public static class ControleConsole
        {
            public static int AttachProcess()
            {
                return Lib.CCAPI.AttachProcess();
            }

            public static int AttachProcess(CCAPI.ProcessType procType)
            {
                return Lib.CCAPI.AttachProcess(procType);
            }

            public static int AttachProcess(uint process)
            {
                return Lib.CCAPI.AttachProcess(process);
            }

            public static void ClearTargetInfo()
            {
                Lib.CCAPI.ClearTargetInfo();
            }

            public static bool ConnectTarget()
            {
                return Lib.CCAPI.ConnectTarget();
            }

            public static int ConnectTarget(string targetIP)
            {
                return Lib.CCAPI.ConnectTarget(targetIP);
            }

            private enum ProcessType
            {
                VSH,
                SYS_AGENT,
                CURRENTGAME
            }
        }

        public static class UTF8
        {
            public static byte[] GetBytes(string s)
            {
                return Encoding.UTF8.GetBytes(Lib.DetectButtonsBytes(s));
            }
        }*/
    }
}

