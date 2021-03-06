using System.Collections.Generic;
using System.Linq;

namespace Monkey
{
    public static class Opcode
    {
        public struct Definition
        {
            public Name Name { get; set; }
            public List<int> OperandLengths { get; set; }
        }

        public enum Name : byte
        {
            Illegal = 0,
            Constant,
            Add,
            Pop,
            Subtract,
            Multiply,
            Divide,
            True,
            False,
            Equal,
            NotEqual,
            GreaterThan,
            Minus,
            Bang,
            Jump,
            JumpNotTruthy,
            Null,
            SetGlobal,
            GetGlobal,
            Array,
            Hash,
            Index,
            Call,
            Return,
            ReturnValue,
            SetLocal,
            GetLocal,
            GetBuiltIn,
            Closure,
            GetFree,
            GetCurrentClosure
        }
        
        private static Dictionary<byte, Definition> Opcodes = new Dictionary<byte, Definition>
        {
            { 0, new Definition { Name = Name.Illegal, OperandLengths = new List<int> { 0 } }},
            { 1, new Definition { Name = Name.Constant, OperandLengths = new List<int> { 2 } }},
            { 2, new Definition { Name = Name.Add, OperandLengths = new List<int> { 0 } }},
            { 3, new Definition { Name = Name.Pop, OperandLengths = new List<int> { 0 } }},
            { 4, new Definition { Name = Name.Subtract, OperandLengths = new List<int> { 0 } }},
            { 5, new Definition { Name = Name.Multiply, OperandLengths = new List<int> { 0 } }},
            { 6, new Definition { Name = Name.Divide, OperandLengths = new List<int> { 0 } }},
            { 7, new Definition { Name = Name.True, OperandLengths = new List<int> { 0 } }},
            { 8, new Definition { Name = Name.False, OperandLengths = new List<int> { 0 } }},
            { 9, new Definition { Name = Name.Equal, OperandLengths = new List<int> { 0 } }},
            { 10, new Definition { Name = Name.NotEqual, OperandLengths = new List<int> { 0 } }},
            { 11, new Definition { Name = Name.GreaterThan, OperandLengths = new List<int> { 0 } }},
            { 12, new Definition { Name = Name.Minus, OperandLengths = new List<int> { 0 } }},
            { 13, new Definition { Name = Name.Bang, OperandLengths = new List<int> { 0 } }},
            { 14, new Definition { Name = Name.Jump, OperandLengths = new List<int> { 2 } }},
            { 15, new Definition { Name = Name.JumpNotTruthy, OperandLengths = new List<int> { 2 } }},
            { 16, new Definition { Name = Name.Null, OperandLengths = new List<int> { 0 } }},
            { 17, new Definition { Name = Name.SetGlobal, OperandLengths = new List<int> { 2 } }},
            { 18, new Definition { Name = Name.GetGlobal, OperandLengths = new List<int> { 2 } }},
            { 19, new Definition { Name = Name.Array, OperandLengths = new List<int> { 2 } }},
            { 20, new Definition { Name = Name.Hash, OperandLengths = new List<int> { 2 } }},
            { 21, new Definition { Name = Name.Index, OperandLengths = new List<int> { 0 } }},
            { 22, new Definition { Name = Name.Call, OperandLengths = new List<int> { 1 } }},
            { 23, new Definition { Name = Name.Return, OperandLengths = new List<int> { 0 } }},
            { 24, new Definition { Name = Name.ReturnValue, OperandLengths = new List<int> { 0 } }},
            { 25, new Definition { Name = Name.SetLocal, OperandLengths = new List<int> { 1 } }},
            { 26, new Definition { Name = Name.GetLocal, OperandLengths = new List<int> { 1 } }},
            { 27, new Definition { Name = Name.GetBuiltIn, OperandLengths = new List<int> { 1 } }},
            { 28, new Definition { Name = Name.Closure, OperandLengths = new List<int> { 2, 1 } }},
            { 29, new Definition { Name = Name.GetFree, OperandLengths = new List<int> { 1 } }},
            { 30, new Definition { Name = Name.GetCurrentClosure, OperandLengths = new List<int> { 0 } }}
        };

        public static Definition Find(byte code)
        {
            var opcode = Opcodes.Where(item => item.Key == code).FirstOrDefault();
            if (!opcode.Equals(default(KeyValuePair<byte, Definition>)))
            {
                return opcode.Value;
            }

            return Opcodes[0];
        }
    }
}
