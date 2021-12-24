﻿using Generator3.Renderer.Internal;

namespace Generator3.Generation.Interface
{
    public class InternalMethodsTemplate : Template<InternalMethodsModel>
    {
        public string Render(InternalMethodsModel model)
        {
            return $@"
using System;
using GObject;
using System.Runtime.InteropServices;

#nullable enable

namespace { model.NamespaceName }
{{
    // AUTOGENERATED FILE - DO NOT MODIFY

    public partial class { model.Name }
    {{
        public partial class Instance
        {{
            public class Methods
            {{
                {model.TypeFunction.Render()}
                {model.Functions.Render()}
                {model.Methods.Render()}
            }}
        }}
    }}
}}";
        }
    }
}