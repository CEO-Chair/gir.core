﻿namespace GirLoader.Output
{
    public class NativeUnsignedInteger : PrimitiveValueType, GirModel.NativeUnsignedInteger
    {
        public NativeUnsignedInteger(string ctype) : base(new CType(ctype), new TypeName("nuint")) { }
    }
}
