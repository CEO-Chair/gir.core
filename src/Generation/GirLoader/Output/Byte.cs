﻿namespace GirLoader.Output
{
    public class Byte : PrimitiveValueType, GirModel.Byte
    {
        public Byte(string ctype) : base(new CType(ctype), new TypeName("byte")) { }
    }
}
