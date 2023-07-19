using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGComum.Core
{
    public static class DataTypes
    {
        public enum AmoOfertasOrderStatus
        {
            [Description("sNew")]
            New,

            [Description("sConfirmed")]
            Confirmed,

            [Description("sCanceled")]
            Canceled,

            [Description("sCompleted")]
            Completed,

            [Description("sScheduled")]
            Scheduled,
            [Description("sLocal")]
            Local, 

            [Description("sSent")]
            Sent,

            [Description("sAwaitingPayment")]
            AwaitingPayment
        }

        public enum TipoPedidoDelivery
        {
            Entrega,
            Agendado,
            Retirada,
            ConsumoLocal,
        }

        public enum StatusDeliveryIfood
        {
            PLC,
            CFM,
            RTP,
            DSP,
            CON,
            CAN,
        }

        public enum StatusDeliveryAmo
        {
            _new,
            confirmed,
            canceled,
            completed,
            scheduled,
            local,
            sent,
            awaiting_payment,
        }

        public static string StatusDeliveryIfoodToString(StatusDeliveryIfood statusDelivery)
        {
            switch (statusDelivery)
            {
                case StatusDeliveryIfood.PLC:
                    return "PLC";
                case StatusDeliveryIfood.CFM:
                    return "CFM";
                case StatusDeliveryIfood.RTP:
                    return "RTP";
                case StatusDeliveryIfood.DSP:
                    return "DSP";
                case StatusDeliveryIfood.CON:
                    return "CON";
                case StatusDeliveryIfood.CAN:
                    return "CAN";
                default:
                    return "PLC";
            }
        }

        public static StatusDeliveryIfood StringToStatusDeliveryIfood(string aString)
        {
            switch (aString)
            {
                case "PLC":
                    return StatusDeliveryIfood.PLC;
                case "CFM":
                    return StatusDeliveryIfood.CFM;
                case "RTP":
                    return StatusDeliveryIfood.RTP;
                case "DSP":
                    return StatusDeliveryIfood.DSP;
                case "CON":
                    return StatusDeliveryIfood.CON;
                case "CAN":
                    return StatusDeliveryIfood.CAN;
                default:
                    return StatusDeliveryIfood.PLC;

            }
        }
        public static string TipoPedidoDeliveryToString(TipoPedidoDelivery tipoPedidoDelivery)
        {
            switch (tipoPedidoDelivery)
            {
                case TipoPedidoDelivery.Entrega:
                    return "0";
                case TipoPedidoDelivery.ConsumoLocal:
                    return "1";
                default:
                    return "2";
            }
        }

        public static TipoPedidoDelivery StringToTipoPedidoDelivery(string aString)
        {
            switch (aString)
            {
                case "0":
                    return TipoPedidoDelivery.Entrega;
                case "1":
                    return TipoPedidoDelivery.ConsumoLocal;
                default:
                    return TipoPedidoDelivery.Retirada;
            }
        }
        public static bool SimNaoToBool(string aString)
        {
            return aString == "SIM";
        }

        public static string BoolToSimNao(bool aBool)
        {
            return aBool ? "SIM" : "NÃO";
        }

        public static bool? SimNaoNullToBool(string aString)
        {
            if (aString == null)
                return null;

            return aString == "SIM";
        }

        public static string BoolToSimNaoNull(bool? aBool)
        {
            if (aBool == null)
                return null;

            return aBool == true ? "SIM" : "NÃO";
        }

        public static bool? ZeroUmNullToBool(string aString)
        {
            if (aString == null)
                return null;

            return aString == "1";
        }

        public static string BoolToZeroUmNull(bool? aBool)
        {
            if (aBool == null)
                return null;

            return aBool == true ? "1" : "0";
        }

    }
}
