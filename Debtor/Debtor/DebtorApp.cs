using Debtor.Core;
using System;

namespace Debtor
{
    public class DebtorApp
    {
        public BorrowerManager BorrowerManager { get; set; } = new BorrowerManager();

        public void IntroduceDebtorApp()
        {
            Console.WriteLine("Witam w aplikacji Dłużnik. Zapisujemy tutaj listę dłużników, którzy mają do oddania Tobie pieniądze.");
        }

        public void AddBorrower()
        {
            Console.WriteLine("Podaj nazwę dłużnika którego chcesz dodać do listy dłużników.");
            var userName = Console.ReadLine();
            Console.WriteLine("Podaj kwotę jaką dana osoba jest Ci dłużna.");
            var userAmount = Console.ReadLine();
            Console.WriteLine("Podaj wartość oprocentowania w skali roku");
            var percentage = Console.ReadLine();

            var amountInDecimal = default(decimal);
            var percentageInDecimal = default(decimal);

            while (!decimal.TryParse(userAmount, out amountInDecimal))
            {

                Console.WriteLine("Podano nie poprawną kwotę");
                Console.WriteLine("Podaj kwotę jaką dana osoba jest Ci dłużna.");
                userAmount = Console.ReadLine();
            }

            while (!decimal.TryParse(percentage, out percentageInDecimal))
            {

                Console.WriteLine("Podano nie poprawną wartość oprocentowania");
                Console.WriteLine("Podaj wartość oprocentowania w skali roku");
                percentage = Console.ReadLine();
            }
            var begginingAmountInDecimal = amountInDecimal;

            Console.WriteLine("Poprawnie dodano dłużnika do listy.");
            BorrowerManager.AddBorrower(userName, begginingAmountInDecimal, amountInDecimal, percentageInDecimal);

        }

        public void DeleteBorrower()
        {
            Console.WriteLine("Podaj nazwę dłużnika ktory oddał pieniądze");
            var userName = Console.ReadLine();

            Console.WriteLine("Podaj jaka kwota pieniędzy została zwrócona");
            var loanPayback = int.Parse(Console.ReadLine());

            BorrowerManager.DeleteBorrower(userName, loanPayback);
        }

        public void ListAllBorrowers()
        {

            Console.WriteLine("Oto lista Twoich dłużników:");

            BorrowerManager.ListBorrowers();

            foreach (var borrower in BorrowerManager.ListBorrowers())
            {
                Console.WriteLine(borrower);
            }
        }

        public void SumOfAllLoan()
        {
            BorrowerManager.SumOfAllLoan();
            Console.WriteLine("Suma wszystkich długów: " + BorrowerManager.Summary);
            Console.WriteLine("Suma wszystkich odsetek: " + BorrowerManager.SummaryInterest);
            Console.WriteLine("Łącznie: " + BorrowerManager.SummaryOfAll);
        }

        public void AskForAction()
        {
            var userInput = default(string);

            while (userInput != "exit")
            {
                Console.WriteLine("Podaj czynność którą chcesz wykonać:");
                Console.WriteLine("add - dodawanie dłużnika");
                Console.WriteLine("del - usuwanie dłużnika");
                Console.WriteLine("list - wyświetlanie listy dłużników");
                Console.WriteLine("sum - wyświetlanie sumy wszystkich długów");
                Console.WriteLine("exit - wyjście z programu");

                userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                if (userInput == "add")
                {
                    AddBorrower();
                }
                else if (userInput == "del")
                {
                    DeleteBorrower();
                }
                else if (userInput == "list")
                {
                    ListAllBorrowers();
                }
                else if (userInput == "sum")
                {
                    SumOfAllLoan();
                }
                else if (userInput == "exit")
                {
                    BorrowerManager.FileList();
                }
                else
                {
                    Console.WriteLine("Podano błędną komende.");
                    AskForAction();
                }
            }


        }

    }
}
