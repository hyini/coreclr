// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/******************************************************************************
 * This file is auto-generated from a template file by the GenerateTests.csx  *
 * script in tests\src\JIT\HardwareIntrinsics\X86\Shared. In order to make    *
 * changes, please update the corresponding template and run according to the *
 * directions listed in the file.                                             *
 ******************************************************************************/

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace JIT.HardwareIntrinsics.X86
{
    public static partial class Program
    {
        private static void CompareLessThanOrEqualUnorderedScalarBoolean()
        {
            var test = new BooleanComparisonOpTest__CompareLessThanOrEqualUnorderedScalarBoolean();

            if (test.IsSupported)
            {
                // Validates basic functionality works, using Unsafe.Read
                test.RunBasicScenario_UnsafeRead();

                if (Sse.IsSupported)
                {
                    // Validates basic functionality works, using Load
                    test.RunBasicScenario_Load();

                    // Validates basic functionality works, using LoadAligned
                    test.RunBasicScenario_LoadAligned();
                }

                // Validates calling via reflection works, using Unsafe.Read
                test.RunReflectionScenario_UnsafeRead();

                if (Sse.IsSupported)
                {
                    // Validates calling via reflection works, using Load
                    test.RunReflectionScenario_Load();

                    // Validates calling via reflection works, using LoadAligned
                    test.RunReflectionScenario_LoadAligned();
                }

                // Validates passing a static member works
                test.RunClsVarScenario();

                // Validates passing a local works, using Unsafe.Read
                test.RunLclVarScenario_UnsafeRead();

                if (Sse.IsSupported)
                {
                    // Validates passing a local works, using Load
                    test.RunLclVarScenario_Load();

                    // Validates passing a local works, using LoadAligned
                    test.RunLclVarScenario_LoadAligned();
                }

                // Validates passing the field of a local works
                test.RunLclFldScenario();

                // Validates passing an instance member works
                test.RunFldScenario();
            }
            else
            {
                // Validates we throw on unsupported hardware
                test.RunUnsupportedScenario();
            }

            if (!test.Succeeded)
            {
                throw new Exception("One or more scenarios did not complete as expected.");
            }
        }
    }

    public sealed unsafe class BooleanComparisonOpTest__CompareLessThanOrEqualUnorderedScalarBoolean
    {
        private const int VectorSize = 16;

        private const int Op1ElementCount = VectorSize / sizeof(Single);
        private const int Op2ElementCount = VectorSize / sizeof(Single);

        private static Single[] _data1 = new Single[Op1ElementCount];
        private static Single[] _data2 = new Single[Op2ElementCount];

        private static Vector128<Single> _clsVar1;
        private static Vector128<Single> _clsVar2;

        private Vector128<Single> _fld1;
        private Vector128<Single> _fld2;

        private BooleanComparisonOpTest__DataTable<Single, Single> _dataTable;

        static BooleanComparisonOpTest__CompareLessThanOrEqualUnorderedScalarBoolean()
        {
            var random = new Random();

            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = (float)(random.NextDouble()); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref _clsVar1), ref Unsafe.As<Single, byte>(ref _data1[0]), VectorSize);
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = (float)(random.NextDouble()); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref _clsVar2), ref Unsafe.As<Single, byte>(ref _data2[0]), VectorSize);
        }

        public BooleanComparisonOpTest__CompareLessThanOrEqualUnorderedScalarBoolean()
        {
            Succeeded = true;

            var random = new Random();

            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = (float)(random.NextDouble()); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref _fld1), ref Unsafe.As<Single, byte>(ref _data1[0]), VectorSize);
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = (float)(random.NextDouble()); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref _fld2), ref Unsafe.As<Single, byte>(ref _data2[0]), VectorSize);

            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = (float)(random.NextDouble()); }
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = (float)(random.NextDouble()); }
            _dataTable = new BooleanComparisonOpTest__DataTable<Single, Single>(_data1, _data2, VectorSize);
        }

        public bool IsSupported => Sse.IsSupported;

        public bool Succeeded { get; set; }

        public void RunBasicScenario_UnsafeRead()
        {
            var result = Sse.CompareLessThanOrEqualUnorderedScalar(
                Unsafe.Read<Vector128<Single>>(_dataTable.inArray1Ptr),
                Unsafe.Read<Vector128<Single>>(_dataTable.inArray2Ptr)
            );

            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, result);
        }

        public void RunBasicScenario_Load()
        {
            var result = Sse.CompareLessThanOrEqualUnorderedScalar(
                Sse.LoadVector128((Single*)(_dataTable.inArray1Ptr)),
                Sse.LoadVector128((Single*)(_dataTable.inArray2Ptr))
            );

            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, result);
        }

        public void RunBasicScenario_LoadAligned()
        {
            var result = Sse.CompareLessThanOrEqualUnorderedScalar(
                Sse.LoadAlignedVector128((Single*)(_dataTable.inArray1Ptr)),
                Sse.LoadAlignedVector128((Single*)(_dataTable.inArray2Ptr))
            );

            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, result);
        }

        public void RunReflectionScenario_UnsafeRead()
        {
            var result = typeof(Sse).GetMethod(nameof(Sse.CompareLessThanOrEqualUnorderedScalar), new Type[] { typeof(Vector128<Single>), typeof(Vector128<Single>) })
                                     .Invoke(null, new object[] {
                                        Unsafe.Read<Vector128<Single>>(_dataTable.inArray1Ptr),
                                        Unsafe.Read<Vector128<Single>>(_dataTable.inArray2Ptr)
                                     });

            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, (bool)(result));
        }

        public void RunReflectionScenario_Load()
        {
            var result = typeof(Sse).GetMethod(nameof(Sse.CompareLessThanOrEqualUnorderedScalar), new Type[] { typeof(Vector128<Single>), typeof(Vector128<Single>) })
                                     .Invoke(null, new object[] {
                                        Sse.LoadVector128((Single*)(_dataTable.inArray1Ptr)),
                                        Sse.LoadVector128((Single*)(_dataTable.inArray2Ptr))
                                     });

            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, (bool)(result));
        }

        public void RunReflectionScenario_LoadAligned()
        {
            var result = typeof(Sse).GetMethod(nameof(Sse.CompareLessThanOrEqualUnorderedScalar), new Type[] { typeof(Vector128<Single>), typeof(Vector128<Single>) })
                                     .Invoke(null, new object[] {
                                        Sse.LoadAlignedVector128((Single*)(_dataTable.inArray1Ptr)),
                                        Sse.LoadAlignedVector128((Single*)(_dataTable.inArray2Ptr))
                                     });

            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, (bool)(result));
        }

        public void RunClsVarScenario()
        {
            var result = Sse.CompareLessThanOrEqualUnorderedScalar(
                _clsVar1,
                _clsVar2
            );

            ValidateResult(_clsVar1, _clsVar2, result);
        }

        public void RunLclVarScenario_UnsafeRead()
        {
            var left = Unsafe.Read<Vector128<Single>>(_dataTable.inArray1Ptr);
            var right = Unsafe.Read<Vector128<Single>>(_dataTable.inArray2Ptr);
            var result = Sse.CompareLessThanOrEqualUnorderedScalar(left, right);

            ValidateResult(left, right, result);
        }

        public void RunLclVarScenario_Load()
        {
            var left = Sse.LoadVector128((Single*)(_dataTable.inArray1Ptr));
            var right = Sse.LoadVector128((Single*)(_dataTable.inArray2Ptr));
            var result = Sse.CompareLessThanOrEqualUnorderedScalar(left, right);

            ValidateResult(left, right, result);
        }

        public void RunLclVarScenario_LoadAligned()
        {
            var left = Sse.LoadAlignedVector128((Single*)(_dataTable.inArray1Ptr));
            var right = Sse.LoadAlignedVector128((Single*)(_dataTable.inArray2Ptr));
            var result = Sse.CompareLessThanOrEqualUnorderedScalar(left, right);

            ValidateResult(left, right, result);
        }

        public void RunLclFldScenario()
        {
            var test = new BooleanComparisonOpTest__CompareLessThanOrEqualUnorderedScalarBoolean();
            var result = Sse.CompareLessThanOrEqualUnorderedScalar(test._fld1, test._fld2);

            ValidateResult(test._fld1, test._fld2, result);
        }

        public void RunFldScenario()
        {
            var result = Sse.CompareLessThanOrEqualUnorderedScalar(_fld1, _fld2);

            ValidateResult(_fld1, _fld2, result);
        }

        public void RunUnsupportedScenario()
        {
            Succeeded = false;

            try
            {
                RunBasicScenario_UnsafeRead();
            }
            catch (PlatformNotSupportedException)
            {
                Succeeded = true;
            }
        }

        private void ValidateResult(Vector128<Single> left, Vector128<Single> right, bool result, [CallerMemberName] string method = "")
        {
            Single[] inArray1 = new Single[Op1ElementCount];
            Single[] inArray2 = new Single[Op2ElementCount];

            Unsafe.Write(Unsafe.AsPointer(ref inArray1[0]), left);
            Unsafe.Write(Unsafe.AsPointer(ref inArray2[0]), right);

            ValidateResult(inArray1, inArray2, result, method);
        }

        private void ValidateResult(void* left, void* right, bool result, [CallerMemberName] string method = "")
        {
            Single[] inArray1 = new Single[Op1ElementCount];
            Single[] inArray2 = new Single[Op2ElementCount];

            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Single, byte>(ref inArray1[0]), ref Unsafe.AsRef<byte>(left), VectorSize);
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Single, byte>(ref inArray2[0]), ref Unsafe.AsRef<byte>(right), VectorSize);

            ValidateResult(inArray1, inArray2, result, method);
        }

        private void ValidateResult(Single[] left, Single[] right, bool result, [CallerMemberName] string method = "")
        {
            if ((left[0] <= right[0]) != result)
            {
                Succeeded = false;

                Console.WriteLine($"{nameof(Sse)}.{nameof(Sse.CompareLessThanOrEqualUnorderedScalar)}<Boolean>(Vector128<Single>, Vector128<Single>): {method} failed:");
                Console.WriteLine($"    left: ({string.Join(", ", left)})");
                Console.WriteLine($"   right: ({string.Join(", ", right)})");
                Console.WriteLine($"  result: ({string.Join(", ", result)})");
                Console.WriteLine();
            }
        }
    }
}
