using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic.Memberships
{
    public class FuzzyTrapezoid
    {
        public double m_x0;
        public double m_x1;
        public double m_x2;
        public double m_x3;

        public FuzzyTrapezoid(double x0, double x1, double x2, double x3)
        {
            m_x0 = x0;
            m_x1 = x1;
            m_x2 = x2;
            m_x3 = x3;
        }

        public double degree(double x)
        {
            if (x <= m_x0 || x >= m_x3)
            {
                return 0;
            }
            else if (x >= m_x1 && x <= m_x2)
            {
                return 1;
            }
            else if ((x > m_x0) && (x < m_x1))
            {
                return (x - m_x0) / (m_x1 - m_x0);
            }
            else
            {
                return (m_x3 - x) / (m_x3 - m_x2);
            }
        }
    }
}
