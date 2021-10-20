using System;

namespace Visitor
{
    public interface IVisitor
    {
        void Visit(HPPrinter hpPrinter);
        void Visit(LexmarkPrinter lexmarkPrinter);
    }
    public class FaxVisitor : IVisitor
    {
        public void Visit(HPPrinter hpPrinter)
        {
            //...Process
            Console.WriteLine($"{nameof(HPPrinter)}'dan faks gonderilir...");
        }

        public void Visit(LexmarkPrinter lexmarkPrinter)
        {
            //...Process
            Console.WriteLine($"{nameof(LexmarkPrinter)}'dan faks gonderilir...");
        }
    }
    public interface IPrinter
    {
        //Printerlerde   olan print etme özelliyi.
        void Print();
        //Concrete Visitor obyekti  bu Concrete Element obyektini
        //elaqelendirib, gedisati Concrete Visitor obyektine buraxmagimzi
        //teskil eden metod.
        void Accept(IVisitor visit);
    }
    public class HPPrinter : IPrinter
    {
        public void Print()
        {
            //...Process
            Console.WriteLine($"{nameof(HPPrinter)} print edir...");
        }

        public void Accept(IVisitor visit)
            => visit.Visit(this);
    }
    public class LexmarkPrinter : IPrinter
    {
        public void Print()
        {
            //...Process
            Console.WriteLine($"{nameof(LexmarkPrinter)} print edir...");
        }

        public void Accept(IVisitor visit)
            => visit.Visit(this);
    }
    class Program
    {
        static void Main(string[] args)
        {
            HPPrinter hp = new();
            LexmarkPrinter lexmark = new();

            hp.Print();
            lexmark.Print();

            IVisitor fax = new FaxVisitor();
            hp.Accept(fax);
            lexmark.Accept(fax);
        }
    }
}
