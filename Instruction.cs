using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMX.Instructions;

namespace CMX
{
    public abstract class Instruction
    {
        #region Instructions
        public static readonly Instruction Nop = new NopInstruction("nop", InsValueType.None);
        public static readonly Instruction Out = new OutInstruction("out", InsValueType.None);
        public static readonly Instruction Add = new AddInstruction("add", InsValueType.None);
        public static readonly Instruction Sub = new SubInstruction("sub", InsValueType.None);
        public static readonly Instruction Mul = new MulInstruction("mul", InsValueType.None);
        public static readonly Instruction Div = new DivInstruction("div", InsValueType.None);
        public static readonly Instruction Got = new GotInstruction("got", InsValueType.None);
        public static readonly Instruction Mov = new MovInstruction("mov", InsValueType.None);
        public static readonly Instruction Sin = new SinInstruction("sin", InsValueType.None);
        public static readonly Instruction Sde = new SdeInstruction("sde", InsValueType.None);
        public static readonly Instruction Inc = new IncInstruction("inc", InsValueType.Byte);
        public static readonly Instruction Dec = new DecInstruction("dec", InsValueType.Byte);
        public static readonly Instruction Ldv = new LdvInstruction("ldv", InsValueType.Char);
        public static readonly Instruction Set = new SetInstruction("set", InsValueType.Byte);
        #endregion

        private static readonly Dictionary<OpCodeID, Instruction> instructions = new Dictionary<OpCodeID, Instruction>
        {
            { Nop.OpCodeID, Nop },
            { Out.OpCodeID, Out },
            { Add.OpCodeID, Add },
            { Sub.OpCodeID, Sub },
            { Mul.OpCodeID, Mul },
            { Div.OpCodeID, Div },
            { Got.OpCodeID, Got },
            { Mov.OpCodeID, Mov },
            { Sin.OpCodeID, Sin },
            { Sde.OpCodeID, Sde },
            { Inc.OpCodeID, Inc },
            { Dec.OpCodeID, Dec },
            { Ldv.OpCodeID, Ldv },
            { Set.OpCodeID, Set },
        };

        public readonly OpCodeID OpCodeID;
        public readonly InsValueType NextInsValueType;
        public abstract void Execute();
        public abstract string GetDescription();

        public Instruction(string internalID, InsValueType nextInsValueType)
        {
            OpCodeID = OpCodeIDs.Get(internalID);
            NextInsValueType = nextInsValueType;
        }

        public static Instruction Get(string chemexOrInternalID)
        {
            OpCodeID id = OpCodeID.Get(chemexOrInternalID);

            if (!instructions.TryGetValue(id, out Instruction inst))
            {
                Console.WriteLine("Could not get instruction for " + chemexOrInternalID);
                return Nop;
            }

            return inst;
        }

        public static Instruction Get(byte opCode)
        {
            OpCodeID id = OpCodeID.Get(opCode);

            if (!instructions.TryGetValue(id, out Instruction inst))
            {
                Console.WriteLine("Could not get instruction for " + opCode);
                return Nop;
            }

            return inst;
        }

        public static List<Instruction> GetAllInstructions()
        {
            List<Instruction> ret = new List<Instruction>(instructions.Count);

            foreach (Instruction ins in instructions.Values)
            {
                ret.Add(ins);
            }

            return ret;
        }
    }

    public enum InsValueType
    {
        None,
        Char,
        Byte
    }
}
