using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplestConsoleMEFDemo.Types
{

    public class Car
    {
        [Import]
        private Engine engine;
        [Import]
        private Steer steer;
        [Import]
        private Brakes brakes;

        public void Drive()
        {
            engine.Start ();
            engine.Accelerate ();
            steer.TurnLeft ();
            engine.Accelerate ();
            steer.TurnRight ();
            brakes.Brake ();
            engine.Stop ();
        }
    }

    [Export]
    public class Engine : SimplestConsoleMEFDemo.Types.IEngine
    {

        public void Start ()
        {
            Console.WriteLine ( "engine started" );
        }

        public void Stop ()
        {
            Console.WriteLine ( "engine stopped" );
        }

        public void Accelerate ()
        {
            Console.WriteLine ( "vrooom" );
        }

    }

    [Export]
    public class Brakes : SimplestConsoleMEFDemo.Types.IBrakes
    {
        public void Brake ()
        {
            Console.WriteLine ( "screeeeech" );
        }
    }


    [Export]
    public class Steer : SimplestConsoleMEFDemo.Types.ISteer
    {
        public void TurnLeft ()
        {
            Console.WriteLine ( "turning left" );
        }
        public void TurnRight ()
        {
            Console.WriteLine ( "turning right" );
        }
    }
}
