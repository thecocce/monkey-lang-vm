using System.Collections.Generic;

using Monkey;

namespace Monkey.Tests.Fixtures
{
    public static class Opcodes
    {
        public static Dictionary<byte, Opcode.Definition> Find = new Dictionary<byte, Opcode.Definition>
        {
            { 0, new Opcode.Definition { Name = Opcode.Name.Illegal, OperandLengths = new List<int> { 0 } }},
            { 1, new Opcode.Definition { Name = Opcode.Name.Constant, OperandLengths = new List<int> { 2 } }},
            { 2, new Opcode.Definition { Name = Opcode.Name.Add, OperandLengths = new List<int> { 0 } }},
            { 3, new Opcode.Definition { Name = Opcode.Name.Pop, OperandLengths = new List<int> { 0 } }},
            { 4, new Opcode.Definition { Name = Opcode.Name.Subtract, OperandLengths = new List<int> { 0 } }},
            { 5, new Opcode.Definition { Name = Opcode.Name.Multiply, OperandLengths = new List<int> { 0 } }},
            { 6, new Opcode.Definition { Name = Opcode.Name.Divide, OperandLengths = new List<int> { 0 } }},
            { 7, new Opcode.Definition { Name = Opcode.Name.True, OperandLengths = new List<int> { 0 } }},
            { 8, new Opcode.Definition { Name = Opcode.Name.False, OperandLengths = new List<int> { 0 } }},
            { 9, new Opcode.Definition { Name = Opcode.Name.Equal, OperandLengths = new List<int> { 0 } }},
            { 10, new Opcode.Definition { Name = Opcode.Name.NotEqual, OperandLengths = new List<int> { 0 } }},
            { 11, new Opcode.Definition { Name = Opcode.Name.GreaterThan, OperandLengths = new List<int> { 0 } }},
            { 12, new Opcode.Definition { Name = Opcode.Name.Minus, OperandLengths = new List<int> { 0 } }},
            { 13, new Opcode.Definition { Name = Opcode.Name.Bang, OperandLengths = new List<int> { 0 } }},
            { 14, new Opcode.Definition { Name = Opcode.Name.Jump, OperandLengths = new List<int> { 2 } }},
            { 15, new Opcode.Definition { Name = Opcode.Name.JumpNotTruthy, OperandLengths = new List<int> { 2 } }},
            { 16, new Opcode.Definition { Name = Opcode.Name.Null, OperandLengths = new List<int> { 0 } }},
            { 17, new Opcode.Definition { Name = Opcode.Name.SetGlobal, OperandLengths = new List<int> { 2 } }},
            { 18, new Opcode.Definition { Name = Opcode.Name.GetGlobal, OperandLengths = new List<int> { 2 } }},
            { 19, new Opcode.Definition { Name = Opcode.Name.Array, OperandLengths = new List<int> { 2 } }},
            { 20, new Opcode.Definition { Name = Opcode.Name.Hash, OperandLengths = new List<int> { 2 } }},
            { 21, new Opcode.Definition { Name = Opcode.Name.Index, OperandLengths = new List<int> { 0 } }},
            { 22, new Opcode.Definition { Name = Opcode.Name.Call, OperandLengths = new List<int> { 1 } }},
            { 23, new Opcode.Definition { Name = Opcode.Name.Return, OperandLengths = new List<int> { 0 } }},
            { 24, new Opcode.Definition { Name = Opcode.Name.ReturnValue, OperandLengths = new List<int> { 0 } }},
            { 25, new Opcode.Definition { Name = Opcode.Name.SetLocal, OperandLengths = new List<int> { 1 } }},
            { 26, new Opcode.Definition { Name = Opcode.Name.GetLocal, OperandLengths = new List<int> { 1 } }},
            { 27, new Opcode.Definition { Name = Opcode.Name.GetBuiltIn, OperandLengths = new List<int> { 1 } }},
            { 28, new Opcode.Definition { Name = Opcode.Name.Closure, OperandLengths = new List<int> { 2, 1 } }},
            { 29, new Opcode.Definition { Name = Opcode.Name.GetFree, OperandLengths = new List<int> { 1 } }},
            { 30, new Opcode.Definition { Name = Opcode.Name.GetCurrentClosure, OperandLengths = new List<int> { 0 } }}
        };
    }

    public static class Bytecode
    {
        public static Dictionary<byte, List<byte>> Opcodes = new Dictionary<byte, List<byte>>
        {
            { 1, new List<byte> { 1, 254, 255 } },
            { 28, new List<byte> { 28, 254, 255, 255 } }
        };
    }
}
