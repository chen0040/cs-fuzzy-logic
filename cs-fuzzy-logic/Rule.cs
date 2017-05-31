using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
    public class Rule
    {
        protected List<Clause> mAntecedents = new List<Clause>();
        protected Clause mConsequent = null;
        string mName;

        public Rule(string name)
        {
            mName = name;
        }

        public Clause Consequent
        {
            set
            {
                mConsequent = value;
            }
            get
            {
                return mConsequent;
            }
        }

        public void AddAntecedent(Clause antecedent)
        {
            mAntecedents.Add(antecedent);
        }

        public Clause getAntecedent(int index)
        {
            return mAntecedents[index];
        }

        public int AntecedentCount
        {
            get
            {
                return mAntecedents.Count;
            }
        }

        /*
        public void fire()
        {
            double Ad=1;
            for(int i=0; i<m_antecedents.size(); ++i)
            {
                FuzzySet variable=m_antecedents.get(i).getVariable();
                string value=m_antecedents.get(i).getValue();
                Membership ms=variable.getMembership(value);
                if(!ms.hasValidX())
                {
                    Ad=0;
                    break;
                }
                double xVal=ms.getX();
                if(xVal >= variable.getMinX() && xVal <= variable.getMaxX())
                {
                    double degree=ms.degree(xVal);
                    if(degree < Ad)
                    {
                        Ad=degree;
                    }
                }
                else
                {
                    Ad=0;
                    break;
                }
            }
		
            Membership ms2=m_consequent.getVariable().getMembership(m_consequent.getValue());
		
            double Ad0=ms2.getDegree();
            if(Ad0 > Ad)
            {
                ms2.setDegree(Ad);
            }
		
            System.out.println(m_name+": "+ms2.getDegree());
        }
        */
    }
}
