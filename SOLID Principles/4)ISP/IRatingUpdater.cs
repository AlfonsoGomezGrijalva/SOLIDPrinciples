using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Principles.ISP
{
    public interface IRatingUpdater
    {
        void UpdateRating(decimal rating);
    }
}
