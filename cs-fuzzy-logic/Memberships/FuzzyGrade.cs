using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic.Memberships
{
    public class FuzzyGrade : Membership
    {
        public double m_x0;
        public double m_x1;

        public FuzzyGrade(double x0, double x1)
        {
            m_x0 = x0;
            m_x1 = x1;
        }

        public double degree(double x)
        {
            if (x <= m_x0)
            {
                return 0;
            }
            else if (x < m_x1)
            {
                return (x - m_x0) / (m_x1 - m_x0);
            }
            else
            {
                return 1;
            }
        }
    }
}
