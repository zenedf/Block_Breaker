using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// TODO
    /// </summary>
    class MathStuff
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Herro");
            Console.ReadLine();

            Calculations _calc = new Calculations();
            _calc.Tester();
        }
    }

    /// <summary>
    /// TODO
    /// </summary>
    class Calculations
    {
        /// <summary>
        /// TODO
        /// </summary>
        public void Tester()
        {
            float _meters = 6f, _seconds = 1f;

            Console.Out.WriteLine(MpsToMph(_meters, _seconds).ToString());

            Console.ReadLine();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="_meters"></param>
        /// <param name="_seconds"></param>
        /// <param name="_distance"></param>
        /// <param name="_time"></param>
        /// <returns></returns>
        //public float MetersPerSecond(float _meters, float _seconds, float _distance, float _time)
        //{
        public float MetersPerSecond(float _meters, float _seconds)
        {
            // Velocity(Speed) = (Distance(Meters)) / (Time(Seconds))

            // _velocity is meters per second

            float _velocity = 0f;

            // One unity unit is one meter.
            // speedInUnitsPerSecond = GetComponent<Rigidbody2D>().velocity.magnitude;
            // This code above will give us unity units/s, so meters/second


            // Velocity(m/s) = (distance in meters)/(time in seconds)
            //_velocity = (_distance * _meters) / (_time * _seconds);


            _velocity = _meters / _seconds;
            // Speed  = Distance / Time

            return _velocity;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="_meters"></param>
        /// <param name="_time"></param>
        /// <returns></returns>
        public float MpsToMph(float _meters, float _second)
        {
            float _mph = 0f;
            float _mps = 0f;

            _mps = MetersPerSecond(_meters, _second);

            _mph = _mps * 2.2369f;

            return _mph;
        }

        /// <summary>
        /// TODO
        /// </summary>
        //public float CalculateVelocity(float _distance, float _time)
        //{
        //    float _speed = 0f;

        //    return _speed;
        //}
    }
}
