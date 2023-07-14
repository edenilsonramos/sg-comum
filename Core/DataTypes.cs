using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGComum.Core
{
    public static class DataTypes
    {
        public enum AmoOfertasOrderStatus
        {
            sNew,
            sConfirmed, 
            sCanceled, 
            sCompleted, 
            sScheduled, 
            sLocal, 
            sSent, 
            sAwaitingPayment
        }
    }
}
