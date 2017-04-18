using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Syroot.IO;

namespace Syroot.NintenTools.MarioKart8
{
    /// <summary>
    /// Represents <see cref="Marshal"/>-like methods which can handle endianness correctly.
    /// </summary>
    public static class MarshalEndian
    {
        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Converts the given <paramref name="bytes"/> to the structure of type <typeparamref name="T"/>, respecting
        /// the provided <paramref name="byteOrder"/>
        /// </summary>
        /// <typeparam name="T">The type of the structure to convert to.</typeparam>
        /// <param name="bytes">The raw bytes to convert.</param>
        /// <param name="byteOrder">The <see cref="ByteOrder"/> to respect.</param>
        /// <returns>The converted structure instance.</returns>
        public static T BytesToStruct<T>(byte[] bytes, ByteOrder byteOrder)
        {
            AdjustByteOrder(typeof(T), bytes, byteOrder);
            
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T instance = Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
            handle.Free();

            return instance;
        }

        /// <summary>
        /// Converts the given structure <paramref name="instance"/> into a byte array, respecting the provided
        /// <paramref name="byteOrder"/>.
        /// </summary>
        /// <typeparam name="T">The type of the structure to convert from.</typeparam>
        /// <param name="instance">The structure instance to convert.</param>
        /// <param name="byteOrder">The <see cref="ByteOrder"/> to respect.</param>
        /// <returns>The converted byte array.</returns>
        public static byte[] StructToBytes<T>(T instance, ByteOrder byteOrder)
        {
            byte[] bytes = new byte[Marshal.SizeOf(instance)];
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            Marshal.StructureToPtr(instance, handle.AddrOfPinnedObject(), false);
            handle.Free();

            AdjustByteOrder(typeof(T), bytes, byteOrder);

            return bytes;
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

#pragma warning disable CS0618 // Marshal methods without generic parameter are obsolete, but we have a runtime type.
        private static void AdjustByteOrder(Type type, byte[] data, ByteOrder byteOrder, int startOffset = 0)
        {
            if (BitConverter.IsLittleEndian == (byteOrder == ByteOrder.LittleEndian))
            {
                return;
            }

            foreach (FieldInfo field in type.GetTypeInfo().GetFields())
            {
                Type fieldType = field.FieldType;
                // Ignore static fields and strings.
                if (field.IsStatic || fieldType == typeof(string))
                {
                    continue;
                }
                // Check for sub-fields to traverse recursively.
                FieldInfo[] subFields = fieldType.GetTypeInfo().GetFields().Where(x => !x.IsStatic).ToArray();

                int offset = Marshal.OffsetOf(type, field.Name).ToInt32();
                int effectiveOffset = startOffset + offset;

                if (subFields.Length == 0)
                {
                    Array.Reverse(data, effectiveOffset, Marshal.SizeOf(fieldType));
                }
                else
                {
                    AdjustByteOrder(fieldType, data, byteOrder, effectiveOffset);
                }
            }
        }
#pragma warning restore CS0618
    }
}
