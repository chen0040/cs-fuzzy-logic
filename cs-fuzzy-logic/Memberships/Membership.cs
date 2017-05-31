using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic.Memberships
{
    public interface Membership
    {
        double degree(double x);
    }
}
