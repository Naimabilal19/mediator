using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public interface IMediator
    {
        void Notify(object sender, string ev);
    }

    class ConcreteMediator : IMediator
    {
        private Component1 Plane1;

        private Component2 Plane2;

        private Component3 Helicopter;

        public ConcreteMediator(Component1 pl1, Component2 pl2, Component3 hl)
        {
            this.Plane1 = pl1;
            this.Plane1.SetMediator(this);
            this.Plane2 = pl2;
            this.Plane2.SetMediator(this);
            this.Helicopter = hl;
            this.Helicopter.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            if (ev == "A")
            {
                Console.WriteLine("Mediator reacts on message: ");
                this.Plane2.Mess3();
            }
            if (ev == "B")
            {
                Console.WriteLine("Mediator reacts on message: ");
                this.Helicopter.Mess5();
            }
        }
    }

    class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }

    class Component1 : BaseComponent
    {
        public void Mess1()
        {
            Console.WriteLine("Plane1: Hi!");

            this._mediator.Notify(this, "A");
        }
    }

    class Component2 : BaseComponent
    {
        public void Mess3()
        {
            Console.WriteLine("Plane2: Hello!");

            this._mediator.Notify(this, "B");
        }
    }

    class Component3 : BaseComponent
    {
        public void Mess5()
        {
            Console.WriteLine("Helicopter: Hey!");

            this._mediator.Notify(this, "C");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            Component3 helicopter = new Component3();
            new ConcreteMediator(component1, component2, helicopter);

            Console.WriteLine("Plane1 message");
            component1.Mess1();

            Console.WriteLine();

            Console.WriteLine("Plane2 message.");
            component2.Mess3();

            Console.WriteLine();
        }
    }
}
