using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotController
{
    // This project was made by Alex Alcaide Arroyes & Marc Ramis Caldes


    public struct MyQuat
    {
        public float w;
        public float x;
        public float y;
        public float z;

        public MyQuat(float _w, float _x, float _y, float _z) { w = _w; x = _x; y = _y; z = _z; }
        
        public MyQuat Conjugate()
        {
            MyQuat q2 = new MyQuat(0,0,0,0);
            q2.x = -x;
            q2.y = -y;
            q2.z = -z;
            q2.w = w;

            return q2;
        }

        public float Length()
        {
            return (float)Math.Sqrt(w * w + x * x + y * y + z * z);
        }

        public MyQuat Normalized()
        {
            return new MyQuat(w / Length(), x / Length(), y / Length(), z / Length());
        }

        public MyQuat Add(MyQuat _q1)
        {
            return new MyQuat(w + _q1.w, x + _q1.x, y + _q1.y, z + _q1.z);
        }

    }

    public struct MyVec
    {
        public float x;
        public float y;
        public float z;

        public MyVec(float _x, float _y, float _z) { x = _x; y = _y; z = _z; }
        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public MyVec Normalized()
        {
            return new MyVec(x / Length(), y / Length(), z / Length());
        }

    }






    public class MyRobotController
    {

        #region public methods



        public string Hi()
        {

            string s = "hello world from my Robot Controller";
            return s;

        }


        //EX1: this function will place the robot in the initial position

        public void PutRobotStraight(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3) {

            //todo: change this, use the function Rotate declared below
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;
        }



        //EX2: this function will interpolate the rotations necessary to move the arm of the robot until its end effector collides with the target (called Stud_target)
        //it will return true until it has reached its destination. The main project is set up in such a way that when the function returns false, the object will be droped and fall following gravity.


        public bool PickStudAnim(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3)
        {

            bool myCondition = false;
            //todo: add a check for your condition



            if (myCondition)
            {
                //todo: add your code here
                rot0 = NullQ;
                rot1 = NullQ;
                rot2 = NullQ;
                rot3 = NullQ;


                return true;
            }

            //todo: remove this once your code works.
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;

            return false;
        }


        //EX3: this function will calculate the rotations necessary to move the arm of the robot until its end effector collides with the target (called Stud_target)
        //it will return true until it has reached its destination. The main project is set up in such a way that when the function returns false, the object will be droped and fall following gravity.
        //the only difference wtih exercise 2 is that rot3 has a swing and a twist, where the swing will apply to joint3 and the twist to joint4

        public bool PickStudAnimVertical(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3)
        {

            bool myCondition = false;
            //todo: add a check for your condition



            while (myCondition)
            {
                //todo: add your code here


            }

            //todo: remove this once your code works.
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;

            return false;
        }


        public static MyQuat GetSwing(MyQuat rot3)
        {
            //todo: change the return value for exercise 3
            return NullQ;

        }


        public static MyQuat GetTwist(MyQuat rot3)
        {
            //todo: change the return value for exercise 3
            return NullQ;

        }




        #endregion


        #region private and internal methods

        internal int TimeSinceMidnight { get { return (DateTime.Now.Hour * 3600000) + (DateTime.Now.Minute * 60000) + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; } }


        private static MyQuat NullQ
        {
            get
            {
                MyQuat a;
                a.w = 1;
                a.x = 0;
                a.y = 0;
                a.z = 0;
                return a;

            }
        }

        internal MyQuat Multiply(MyQuat q1, MyQuat q2) {

            //todo: change this so it returns a multiplication:
            float w = (q1.w * q2.w) - (q1.x * q2.x) - (q1.y * q2.y) - (q1.z * q2.z);
            float x = (q1.w * q2.x) + (q1.x * q2.w) - (q1.y * q2.z) + (q1.z * q2.y);
            float y = (q1.w * q2.y) + (q1.x * q2.z) + (q1.y * q2.w) - (q1.z * q2.x);
            float z = (q1.w * q2.z) - (q1.x * q2.y) + (q1.y * q2.x) + (q1.z * q2.w);
            return new MyQuat(w, x, y, z);

        }

        internal MyQuat Rotate(MyQuat currentRotation, MyVec axis, float angle)
        {

            //todo: change this so it takes currentRotation, and calculate a new quaternion rotated by an angle "angle" radians along the normalized axis "axis"
            //axis = new MyVec(axis.x / axis.Length(), axis.y / axis.Length(), axis.z / axis.Length());
            //float theta = (float)Math.Atan2(axis.y, axis.z);
            return new MyQuat((float)Math.Cos(angle)/2,
                axis.x * (float)Math.Sin(angle) / 2,
                axis.y * (float)Math.Sin(angle) / 2,
                axis.z * (float)Math.Sin(angle) / 2);

        }




        //todo: add here all the functions needed

        #endregion






    }
}
