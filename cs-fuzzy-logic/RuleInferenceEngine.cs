using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
    public class RuleInferenceEngine
    {
        List<string> mVariables = new List<string>();
        Dictionary<string, FuzzySet> mWorkingMemory = new Dictionary<string, FuzzySet>();
        List<Rule> mRules = new List<Rule>();

        public void AddFuzzySet(string variable, FuzzySet set)
        {
            mVariables.Add(variable);
            mWorkingMemory[variable]=set;
        }

        public int FuzzySetCount
        {
            get
            {
                return mVariables.Count;
            }
        }

        public void AddRule(Rule fr)
        {
            mRules.Add(fr);
        }

        public void SetVariable(string variable, double crispValue)
        {
            mWorkingMemory[variable].X=crispValue;
        }

        public double GetVariable(string variable)
        {
            return mWorkingMemory[variable].X;
        }

        public void Infer(FuzzySet output)
        {
            output.Fire(mRules);
        }
    }
}
