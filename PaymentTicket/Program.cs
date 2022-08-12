using System;
using System.Globalization;
using System.Collections.Generic;

namespace PaymentTicket {
    class Program {
        static void Main(string[] args) {

            CultureInfo CI = CultureInfo.InvariantCulture;

            Payment pay;

            // Informar o dia inicial do boleto
            Console.Write("Enter the initial day of the ticket: ");
            DateTime dayNow = DateTime.Parse(Console.ReadLine());
            DateTime dayAfter = dayNow.AddMonths(1);            

            // Informar o valor do boleto
            Console.Write("Enter the ticket price: R$ ");
            double ticketValue = double.Parse(Console.ReadLine(), CI);
            pay = new Payment(ticketValue, dayNow, dayAfter); // Inicializando os dados nas variaveis da classe(boleto,dayInicial,diaFinal)
            Console.WriteLine();

            //Informando o usuario quando o boleto vai vencer, e suas taxas de juros se caso for pagar após o vencimento
            Console.WriteLine("The ticket is values R$ " + pay.TicketValue.ToString("F2", CI) + " will expire on the day: " + pay.DayAfter.ToShortDateString());
            Console.WriteLine("And you will be charged 2% interest per month, with additions of 0.15 cents per day.");
            Console.WriteLine();

            // Informar o dia do pagamento
            Console.Write("Inform day payment: ");

            DateTime dayPayment = DateTime.Parse(Console.ReadLine());            
            double feesMounth = 0;
            double feesDiary = 0;
            int totalMouth = 0;
            double totalDays = 0;
            Payment pay2 = new Payment(dayPayment,feesMounth,feesDiary,totalMouth,totalDays); // Inicializando os dados na variavel (diaPagamento)
            TimeSpan sub;
            Console.WriteLine();
            
            


            // Verificar se o dia de pagamento foi antes ou depois da data de vencimento
            if (pay2.DayPayment > pay.DayAfter) {
                // Se caso a casa de pagamento foi superior a data de vencimento, fazer a subtração entre as datas para a duração do intervalo
                sub = pay2.DayPayment.Subtract(pay.DayAfter);
                pay2.FeesMounth = 2;
                pay2.FeesDiary = 0.15;
                /* Se caso o total de dias dias for maior ou igual a 30, fazer a divisão para achar a quantidade de meses e os dias
                 * Assim que achar os meses e os dias, é só calcular os juros. 
                 */
                pay2.TotalDay = sub.TotalDays;
                if (sub.TotalDays >= 30) {
                    pay2.TotalMounth = (int)sub.TotalDays / 30;
                    
                }
                Console.WriteLine("Days late: " + pay2.TotalDay);
                Console.WriteLine("Total mounths late: "+pay2.TotalMounth);
                Console.WriteLine("Value fees mounth: R$ " + pay2.FeesMounth.ToString("F2", CI) + "%");
                Console.WriteLine("Value fees diary: R$ " + pay2.FeesDiary.ToString("F2", CI));
            }
            else {
                Console.WriteLine("No Fess");
            }

            Console.WriteLine();           

            Console.WriteLine("Total fees of mounths: R$ "+pay2.FeesOfMounth(pay.TicketValue).ToString("F2",CI));
            Console.WriteLine("Total fees of diary: R$ " + pay2.FeesOfDiary(pay.TicketValue).ToString("F2", CI));
            Console.WriteLine("Total payment value: R$ "+pay2.TotalPayment(pay.TicketValue).ToString("F2", CI));



            Console.WriteLine();




        }
    }
}