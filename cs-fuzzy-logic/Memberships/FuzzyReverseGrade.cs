using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic.Memberships
{
    public class FuzzyReverseGrade : Membership
    {
        public double m_x0;
        public double m_x1;

        public FuzzyReverseGrade(double x0, double x1)
        {
            m_x0 = x0;
            m_x1 = x1;
        }

        public double degree(double x)
        {
            if (x <= m_x0)
            {
                return 1;
            }
            else if (x < m_x1)
            {
                return (m_x1 - x) / (m_x1 - m_x0);
            }
            else
            {
                return 0;
            }
        }
    }
}
