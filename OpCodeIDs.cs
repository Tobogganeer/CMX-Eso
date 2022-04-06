using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMX
{
    public static class OpCodeIDs
    {
        public static readonly OpCodeID Nop = new OpCodeID("nop", 0);
        public static readonly OpCodeID Out = new OpCodeID("out", 1);
        public static readonly OpCodeID Add = new OpCodeID("add", 2);
        public static readonly OpCodeID Sub = new OpCodeID("sub", 3);
        public static readonly OpCodeID Mul = new OpCodeID("mul", 4);
        public static readonly OpCodeID Div = new OpCodeID("div", 5);
        public static readonly OpCodeID Got = new OpCodeID("got", 6);
        public static readonly OpCodeID Mov = new OpCodeID("mov", 7);
        public static readonly OpCodeID Sin = new OpCodeID("sin", 8);
        public static readonly OpCodeID Sde = new OpCodeID("sde", 9);
        public static readonly OpCodeID Inc = new OpCodeID("inc", 10);
        public static readonly OpCodeID Dec = new OpCodeID("dec", 11);
        public static readonly OpCodeID Ldv = new OpCodeID("ldv", 12);
        public static readonly OpCodeID Set = new OpCodeID("set", 13);

        private static readonly Dictionary<string, OpCodeID> internalCodes = new Dictionary<string, OpCodeID>
        {
            { Nop.InternalCode, Nop },
            { Out.InternalCode, Out },
            { Add.InternalCode, Add },
            { Sub.InternalCode, Sub },
            { Mul.InternalCode, Mul },
            { Div.InternalCode, Div },
            { Got.InternalCode, Got },
            { Mov.InternalCode, Mov },
            { Sin.InternalCode, Sin },
            { Sde.InternalCode, Sde },
            { Inc.InternalCode, Inc },
            { Dec.InternalCode, Dec },
            { Ldv.InternalCode, Ldv },
            { Set.InternalCode, Set },
        };

        private static readonly Dictionary<string, OpCodeID> chemexCodes = new Dictionary<string, OpCodeID>
        {
            { Nop.ChemexCode, Nop },
            { Out.ChemexCode, Out },
            { Add.ChemexCode, Add },
            { Sub.ChemexCode, Sub },
            { Mul.ChemexCode, Mul },
            { Div.ChemexCode, Div },
            { Got.ChemexCode, Got },
            { Mov.ChemexCode, Mov },
            { Sin.ChemexCode, Sin },
            { Sde.ChemexCode, Sde },
            { Inc.ChemexCode, Inc },
            { Dec.ChemexCode, Dec },
            { Ldv.ChemexCode, Ldv },
            { Set.ChemexCode, Set },
        };

        private static readonly Dictionary<byte, OpCodeID> opCodes = new Dictionary<byte, OpCodeID>
        {
            { Nop.OpCode, Nop },
            { Out.OpCode, Out },
            { Add.OpCode, Add },
            { Sub.OpCode, Sub },
            { Mul.OpCode, Mul },
            { Div.OpCode, Div },
            { Got.OpCode, Got },
            { Mov.OpCode, Mov },
            { Sin.OpCode, Sin },
            { Sde.OpCode, Sde },
            { Inc.OpCode, Inc },
            { Dec.OpCode, Dec },
            { Ldv.OpCode, Ldv },
            { Set.OpCode, Set },
        };

        public static OpCodeID Get(byte opCode)
        {
            if (!opCodes.TryGetValue(opCode, out OpCodeID id))
            {
                Console.WriteLine("Could not get OpCodeID for " + opCode);
                return Nop;
            }

            return id;
        }

        public static OpCodeID Get(string chemexOrInternalCode)
        {
            OpCodeID id;

            if (!internalCodes.TryGetValue(chemexOrInternalCode, out id))
            {
                if (!chemexCodes.TryGetValue(chemexOrInternalCode, out id))
                {
                    Console.WriteLine($"Could not get OpCodeID for '{chemexOrInternalCode}'");
                    return Nop;
                }
            }

            return id;
        }

        public static bool IsInternalCode(string internalCode)
        {
            return internalCodes.ContainsKey(internalCode);
        }

        /*
        
        -nop
        -out
        -add
        -sub
        -mul
        -div
        -got
        -mov
        -sin
        -sde
        -inc
        -dec
        -ldv
        -set

        */
    }

    public class OpCodeID
    {
        public readonly string ChemexCode;
        public readonly string InternalCode;
        public readonly byte OpCode;

        public OpCodeID(string internalCode, byte opCode)
        {
            ChemexCode = ChemexConvertor.ToChemexCode(opCode);
            InternalCode = internalCode;
            OpCode = opCode;
        }

        public override string ToString()
        {
            return $"OpCodeID: {ChemexCode}/{InternalCode}/{OpCode}";
        }

        public static OpCodeID Get(byte opCode) => OpCodeIDs.Get(opCode);
        public static OpCodeID Get(string chemexOrInternalCode) => OpCodeIDs.Get(chemexOrInternalCode);
    }
}
