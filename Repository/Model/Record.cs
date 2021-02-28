﻿using System.Collections.Generic;
using System.Linq;
using Repository.Analysis;

namespace Repository.Model
{
    public class Record : Symbol
    {
        public RecordType Type => this switch
        {
            {Disguised: true, GLibClassStructFor: {}} => RecordType.PrivateClass,
            {Disguised: false, GLibClassStructFor: {}} => RecordType.PublicClass,
            {Disguised: false, Fields: { } f} when f.Any() => RecordType.Value,
            {Disguised: false, Constructors: {} c} when c.Any() => RecordType.Ref,
            _ => RecordType.Opaque
        };

        public Method? GetTypeFunction { get; }
        public IEnumerable<Field> Fields { get; }
        public bool Disguised { get; }
        public IEnumerable<Method> Methods { get; }
        public IEnumerable<Method> Constructors { get; }
        public IEnumerable<Method> Functions { get; }
        public SymbolReference? GLibClassStructFor { get; }

        public Record(Namespace @namespace, string name, string managedName, SymbolReference? gLibClassStructFor, IEnumerable<Method> methods, IEnumerable<Method> functions, Method? getTypeFunction, IEnumerable<Field> fields, bool disguised, IEnumerable<Method> constructors) : base(@namespace, name, managedName)
        {
            GLibClassStructFor = gLibClassStructFor;
            Methods = methods;
            Functions = functions;
            GetTypeFunction = getTypeFunction;
            Fields = fields;
            Disguised = disguised;
            Constructors = constructors;
        }

        public override IEnumerable<SymbolReference> GetSymbolReferences()
        {
            var symbolReferences = IEnumerables.Concat(
                Constructors.GetSymbolReferences(),
                Fields.GetSymbolReferences(),
                Methods.GetSymbolReferences(),
                Functions.GetSymbolReferences()
            );

            if (GetTypeFunction is { })
                symbolReferences = symbolReferences.Concat(GetTypeFunction.GetSymbolReferences());

            if (GLibClassStructFor is { })
                symbolReferences = symbolReferences.Append(GLibClassStructFor);

            return symbolReferences;
        }
    }
}
