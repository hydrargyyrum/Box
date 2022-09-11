using System;

namespace task
{
    struct paramBox
    {
        public double l;
        public double w;
        public double h;
    }

    struct point
    {
        public double x;
        public double y;
        public double z;
    }

    class box
    {
        protected paramBox paramBox;
        protected point point;

        public box(paramBox pB, point p)
        {
            paramBox = pB;
            point = p;
        }

        public box(box b)
        {
            paramBox = b.paramBox;
            point = b.point;
        }

        public static bool crossX(box b1, box b2)
        {
            if (((b2.point.x >= b1.point.x) && (b2.point.x <= (b1.point.x + b1.paramBox.l))) && ((b2.point.x + b2.paramBox.l) <= (b1.point.x + b1.paramBox.l))) return true;
            else return false;

        }
        public static bool crossY(box b1, box b2)
        {
            if (((b2.point.y >= b1.point.y) && (b2.point.y <= (b1.point.y + b1.paramBox.w))) && ((b2.point.y + b2.paramBox.w) <= (b1.point.y + b1.paramBox.w))) return true;
            else return false;
        }
        public static bool crossZ(box b1, box b2)
        {
            if (((b2.point.z >= b1.point.z) && (b2.point.z <= (b1.point.z + b1.paramBox.h))) && ((b2.point.z + b2.paramBox.h) <= (b1.point.z + b1.paramBox.h))) return true;
            else return false;
        }

        public static int edge()
        {
            Console.WriteLine("open the rigth side, press 1");
            Console.WriteLine("open the left side, press 2");
            Console.WriteLine("open the front side, press 3");
            Console.WriteLine("open the backside, press 4");
            Console.WriteLine("open the top part, press 5");
            Console.WriteLine("open the bottom part, press 6");
            return Convert.ToInt32(Console.ReadLine());
        }


        public double volume(box b2)
        {

            box b1 = new box(this);
            switch (edge())
            {
                case 1:
                    {
                        if (b2.point.x >= b1.point.x)
                        {
                            if (crossY(b1, b2) && crossZ(b1, b2))
                            {
                                if ((b2.point.x + b2.paramBox.l) >= (b1.point.x + b1.paramBox.l)) return b2.paramBox.w * b2.paramBox.h * (b1.paramBox.l - b2.point.x + b1.point.x);
                                else return b2.paramBox.w * b2.paramBox.h * b2.paramBox.l;
                            }
                        }
                        return -1;
                    }
                case 2:
                    {
                        if ((b2.point.x + b2.paramBox.l) <= (b1.point.x + b1.paramBox.l))
                        {
                            if (crossY(b1, b2) && crossZ(b1, b2))
                            {
                                if (b2.point.x <= b1.point.x) return b2.paramBox.w * b2.paramBox.h * (b1.paramBox.l - (b1.paramBox.l + b1.point.x - (b2.point.x + b2.paramBox.l)));
                                else return b2.paramBox.w * b2.paramBox.h * b2.paramBox.l;
                            }
                        }
                        return -1;
                    }
                case 3:
                    {

                        if (b2.point.y >= b1.point.y)
                        {
                            if (crossX(b1, b2) && crossZ(b1, b2))
                            {
                                if ((b2.point.y + b2.paramBox.w) >= (b1.point.y + b1.paramBox.w)) return b2.paramBox.l * b2.paramBox.h * (b1.paramBox.w - b2.point.y + b1.point.y);
                                else return b2.paramBox.w * b2.paramBox.h * b2.paramBox.l;
                            }
                        }
                        return -1;

                    }
                case 4:
                    {
                        if ((b2.point.y + b2.paramBox.w) <= (b1.point.y + b1.paramBox.w))
                        {
                            if (crossX(b1, b2) && crossZ(b1, b2))
                            {
                                if (b2.point.y <= b1.point.y) return b2.paramBox.l * b2.paramBox.h * (b1.paramBox.w - (b1.paramBox.w + b1.point.y - (b2.point.y + b2.paramBox.w)));
                                else return b2.paramBox.w * b2.paramBox.h * b2.paramBox.l;
                            }
                        }
                        return -1;
                    }
                case 5:
                    {
                        if (b2.point.z >= b1.point.z)
                        {
                            if (crossX(b1, b2) && crossY(b1, b2))
                            {
                                if ((b2.point.z + b2.paramBox.h) >= (b1.point.z + b1.paramBox.h)) return b2.paramBox.l * b2.paramBox.w * (b1.paramBox.h - b2.point.z + b1.point.z);
                                else return b2.paramBox.w * b2.paramBox.h * b2.paramBox.l;
                            }
                        }
                        return -1;
                    }
                case 6:
                    {
                        if ((b2.point.z + b2.paramBox.h) <= (b1.point.z + b1.paramBox.h))
                        {
                            if (crossX(b1, b2) && crossY(b1, b2))
                            {
                                if (b2.point.z <= b1.point.z) return b2.paramBox.l * b2.paramBox.w * (b1.paramBox.h - (b1.paramBox.h + b1.point.z - (b2.point.z + b2.paramBox.h)));
                                else return b2.paramBox.w * b2.paramBox.h * b2.paramBox.l;
                            }
                        }
                        return -1;
                    }
                default:
                    return -1;
            }
        }
    }

    class mainClass
    {

        public static void Main()
        {
            paramBox pB1;
            pB1.l = 1;
            pB1.w = 2;
            pB1.h = 10;

            paramBox pB2;
            pB2.l = 1;
            pB2.w = 1;
            pB2.h = 11;

            point p1;
            p1.x = 0;
            p1.y = 0;
            p1.z = 0;

            point p2;
            p2.x = 0;
            p2.y = 0;
            p2.z = -3;

            box b1 = new box(pB1, p1);
            box b2 = new box(pB2, p2);


            Console.WriteLine($"V = {b1.volume(b2)}");

        }
    }



}
