using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
    using Memberships;
    public class FuzzySet
    {
        protected Dictionary<string, Membership> mMemberships = new Dictionary<string, Membership>();
        protected List<string> mValues = new List<string>();
        double mMinX = 0;
        double mMaxX = 1;
        double mDeltaX = 0.0001;
        string mName = null;
        double mValX = 0;

        public FuzzySet(string name, double lower_bound, double upper_bound, double dX)
        {
            mName = name;
            mMinX = lower_bound;
            mMaxX = upper_bound;
            mDeltaX = dX;
        }

        public FuzzySet(string name, double lower_bound, double upper_bound)
        {
            mName = name;
            mMinX = lower_bound;
            mMaxX = upper_bound;
        }

        public Membership GetMembership(string value)
        {
            return mMemberships[value];
        }

        public string GetMembershipName(int index)
        {
            return mValues[index];
        }

        public int GetMembershipCount()
        {
            return mValues.Count;
        }

        public Membership GetMembership(int index)
        {
            return GetMembership(mValues[index]);
        }

        public double X
        {
            set
            {
                mValX = value;
            }
            get
            {
                return mValX;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }
        }

        public double GetMinX()
        {
            return mMinX;
        }

        public double GetMaxX()
        {
            return mMaxX;
        }

        public double GetDeltaX()
        {
            return mDeltaX;
        }

        public void AddMembership(string membershipname, Membership membership)
        {
            mValues.Add(membershipname);
            mMemberships[membershipname]=membership;
        }

        public void Fire(List<Rule> rules)
        {
            Dictionary<string, List<double>> degrees = new Dictionary<string, List<double>>();
            for (int i = 0; i < mValues.Count; ++i)
            {
                degrees[mValues[i]]=new List<double>();
            }

            for (int i = 0; i < rules.Count; ++i)
            {
                Rule rule = rules[i];
                Clause consequent = rule.Consequent;
                if (consequent.Variable == this)
                {
                    double y = 1;

                    for (int j = 0; j < rule.AntecedentCount; ++j)
                    {
                        Clause antecedent = rule.getAntecedent(j);
                        FuzzySet variable = antecedent.Variable;
                        string value = antecedent.Value;
                        Membership ms = variable.GetMembership(value);
                        double degree = ms.degree(variable.X);
                        if (y > degree)
                        {
                            y = degree;
                        }

                    }
                    degrees[consequent.Value].Add(y);
                }
            }

            Dictionary<string, double> consequent_degrees = getRootSumSquare(degrees);

            mValX = getAreaCentroid(consequent_degrees);
        }

        public Dictionary<string, double> getRootSumSquare(Dictionary<string, List<double>> degrees)
        {
            Dictionary<string, double> results = new Dictionary<string, double>();

            foreach(string value in degrees.Keys)
            {
                List<double> de = degrees[value];
                double squareSum = 0;
                for (int i = 0; i < de.Count; ++i)
                {
                    double v = de[i];
                    squareSum += v * v;
                }
                results[value] = System.Math.Sqrt(squareSum);
            }

            return results;
        }

        /*
        public double getFuzzyCentroid(Dictionary<string, double> degrees)
        {
            double sumxy=0;
            double sumy=0;
            for(int i=0; i<m_values.Count; i++)
            {
                string value=m_values[i);
                double y=degrees[value).doubleValue();
                double x=m_memberships[value)[CentroidX();
                sumxy=
                sumy+=y;
            }
        }
        */

        public double getAreaCentroid(Dictionary<string, double> degrees)
        {
            double sumxy = 0;
            double sumy = 0;
            for (double x = mMinX; x <= mMaxX; x += mDeltaX)
            {
                for (int i = 0; i < mValues.Count; ++i)
                {
                    Membership ms = mMemberships[mValues[i]];
                    double d1 = degrees[mValues[i]];
                    double d2 = ms.degree(x);
                    double y = d1 > d2 ? d2 : d1;

                    sumxy += (x * y);
                    sumy += y;
                }
            }

            return sumxy / sumy;
        }
	
    }
}
