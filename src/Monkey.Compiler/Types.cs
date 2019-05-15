using System;
using System.Collections.Generic;
using System.Linq;

using Monkey.Shared;
using Object = Monkey.Shared.Object;

namespace Monkey
{
    public partial class Compiler
    {
        public class CompilerState
        {
            public Instruction CurrentInstruction { get; set; }
            public List<Object> Constants { get; set; }
            public List<AssertionError> Errors { get; set; }
            public Expression Expression { get; set; }
            public Node Node { get; set; }
            public List<byte> Instructions { get; set; }
            public Instruction PreviousInstruction { get; set; }
            public SymbolTable SymbolTable { get; set; }
        }

        public class Instruction
        {
            public byte Opcode { get; set; }
            public int Position { get; set; }
        }

        public class Symbol
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public SymbolScope Scope { get; set; }

            public static Symbol Undefined { get; private set; }

            static Symbol()
            {
                Undefined = new Symbol { Index = -1, Name = String.Empty, Scope = SymbolScope.None };
            }
        }

        public enum SymbolScope
        {
            None,
            Global
        }

        public class SymbolTable
        {
            private Dictionary<string, Symbol> Store { get; set; }

            public SymbolTable()
            {
                Store = new Dictionary<string, Symbol>();
            }

            public Symbol Define(string identifier)
            {
                var symbol = new Symbol { Index = Store.Count, Name = identifier, Scope = SymbolScope.Global };
                Store.Add(symbol.Name, symbol);
                return symbol;
            }

            public Symbol Resolve(string identifier)
            {
                var symbol = Store.Where(pair => pair.Key == identifier).FirstOrDefault();

                if (!symbol.Equals(default(KeyValuePair<string, Symbol>)))
                {
                    return symbol.Value;
                }

                return Symbol.Undefined;
            }
        }
    }
}
