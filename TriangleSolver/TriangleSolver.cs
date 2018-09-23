using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSolver
{
    public class Triangle
            {

        private string mTriangleRow;
        private int mTriangleCol;

        //these base values will be used to calculate the vertex coords
        //(mRowBase, mColBase) is the upper left most vertex, the rest are calculated from that
        //based on if the column is odd (for lower triangles) or even (for upper triangles)
        private int? mRowBase;
        private int? mColBase;

        //v1 is the right angle vertex
        private int? mvy1;
        private int? mvx1;

        //v2 is the non-right angle vertex closest to the x axis
        private int? mvy2;
        private int? mvx2;

        //v3 is the non-right angle vertex farther from the x axis
        private int? mvx3;
        private int? mvy3;

        #region " Triangle from Coords "

        public Triangle(string row, int col)
        {
            mTriangleRow = row;
            mTriangleCol = col;

            //set the upper right vertex coords
            mRowBase = SetTriangleRowBaseValue(mTriangleRow);
            mColBase = SetTriangleColBaseValue(mTriangleCol);

            try
            {
                CalculateLowerRightAngleVertexCoords();
                CalculateRightAngleVertexCoord();
            } catch (Exception ex)
            {
                throw ex;
            }
            
        }

        int SetTriangleRowBaseValue(string row)
        {
            switch (row.ToUpper())
            {
                case "A":
                    return 0;
                case "B":
                    return 10;
                case "C":
                    return 20;
                case "D":
                    return 30;
                case "E":
                    return 40;
                case "F":
                    return 50;
                default:
                    throw new Exception("Invalid row.");
            }

        }

        int SetTriangleColBaseValue(int col)
        {
            //going to divide by two because we just need one base value per column of two triangles
            decimal temp = col / 2;

            switch ((int)Math.Ceiling(temp))
            {
                case 1: // row 1 or 2
                    return 0;
                case 2: // row 3 or 4
                    return 10;
                case 3: // row 5 or 6
                    return 20;
                case 4: // row 7 or 8
                    return 30;
                case 5: // row 9 or 10
                    return 40;
                case 6: // row 11 or 12
                    return 50;
                default:
                    throw new Exception("Invalid column.");
            }

        }
                    
        // this function takes the base coords (upper left vertex) and figures out the other non-right angle vertex (lower right)
        void CalculateLowerRightAngleVertexCoords()
        {

            if (!mRowBase.HasValue || !mColBase.HasValue)
            {
                throw new Exception("Failed to calculate base vertex. Unable to calculate vertex.");
            }
            else
            {          
                mvy2 = mColBase;
                mvy3 = mColBase + 10;

                decimal tempvx1 = ((decimal)mRowBase - 1) / 2;
                mvy2 = (int)Math.Floor(tempvx1);
            
                decimal tempvx2 = (decimal)mRowBase / 2;
                mvy3 = (int)Math.Ceiling(tempvx2);

            }
        }

        //this function will calculate the coords of the right-angle vertex, assuming the other two are already set
        int CalculateRightAngleVertexCoord()
        {
            if (!mRowBase.HasValue || !mColBase.HasValue)
            {
                throw new Exception("Failed to calculate base vertex. Unable to calculate vertex.");
            }
            else
            {
                if ((mColBase / 10) % 2 == 1)
                {
                    mvx1 = mvx2;
                    mvy1 = mvy3;

                }
                else
                {
                    mvx1 = mvx3;
                    mvy1 = mvy2;
                }

                throw new Exception("Failed to calculate right angle vertex coords?");
            }
        }

        #endregion

        #region " Triangle from Vertices "

        public Triangle(int vx1, int vy1, int vx2, int vy2, int vx3, int vy3)
        {
            mvx1 = vx1;
            mvy1 = vy1;

            mvy2 = vx2;
            mvy2 = vy2;

            mvy3 = vx3;
            mvy3 = vy3;

            if (!mvx1.HasValue || !mvx2.HasValue || !mvx3.HasValue || !mvy1.HasValue || !mvy2.HasValue || !mvy3.HasValue)
            {
                throw new Exception("One of the parameters was empty.");
            }
            mTriangleRow = CalculateRow();
            mTriangleCol = CalculateColumn(); 
               

        }


        string CalculateRow()
        {
            switch (mvy2)
            {
                case 10:
                    return "A";
                case 20:
                    return "B";
                case 30:
                    return "C";
                case 40:
                    return "D";
                case 50:
                    return "E";
                case 60:
                    return "F";

                default:
                    throw new Exception("Failed calculating row from vertices.");
            }
        }

        int CalculateColumn()
        {
            return (int)((mvx1 + mvx3) / 10);
        }

        #endregion


        public override string ToString()
        {
            return String.Format(@"Triangle {0}{1} has the following vertices: 
                    ({2}, {3}) 
                    ({4}, {5}) 
                    ({6}, {7})"
                    , mTriangleRow, mTriangleCol, mvx1, mvy1, mvx2, mvy2, mvx3, mvy3);

        }
    }
}
