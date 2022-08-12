using System;
using System.Collections.Generic;

namespace PaymentTicket {
    class Payment {

        public double TicketValue { get; private set; }
        public double FeesMounth { get; set; }
        public double FeesDiary { get;  set; }
        public double TotalDay { get; set; }
        public int TotalMounth { get; set; }


        public DateTime DayNow { get; private set; }
        public DateTime DayAfter { get; private set; }
        public DateTime DayPayment { get; private set; }        



        public Payment(double ticketValue, DateTime dayNow, DateTime dayAfter) {
            TicketValue = ticketValue;
            DayNow = dayNow;
            DayAfter = dayAfter;
        }

        public Payment(DateTime dayPayment, double feesMounth, double feesDiary, int totalMounth,double totalDay) {
            DayPayment = dayPayment;
            FeesMounth = feesMounth;
            FeesDiary = feesDiary;
            TotalMounth = totalMounth;
            TotalDay = totalDay;
        }
         
        public double FeesOfMounth(double ticketValue) {
            TicketValue = ticketValue;
            return (TicketValue * FeesMounth / 100.00) * TotalMounth;
        }

        public double FeesOfDiary(double ticketValue) {
            TicketValue = ticketValue;
            return TotalDay * FeesDiary;
        }

        public double TotalPayment(double ticketValue) {
            TicketValue = ticketValue;
            return TicketValue + FeesOfMounth(ticketValue) + FeesOfDiary(ticketValue); 
        }
        




    }
}